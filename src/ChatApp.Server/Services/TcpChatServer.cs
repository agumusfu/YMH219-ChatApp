using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ChatApp.Core.Models;

namespace ChatApp.Server.Services;

/// <summary>
/// TcpListener ve async/await kullanarak birden fazla istemciyi eşzamanlı yöneten,
/// genel yayın (broadcast) ve özel mesaj (private DM) yönlendirmesi yapan asenkron TCP sunucusu.
/// </summary>
public class TcpChatServer
{
    private TcpListener? _listener;
    private CancellationTokenSource? _cts;
    private readonly ConcurrentDictionary<string, ClientSession> _clients = new();

    public bool IsRunning { get; private set; }
    public int Port { get; private set; }

    public event Action<string>? LogAdded;
    public event Action<List<ConnectedClientInfo>>? ClientsUpdated;
    public event Action<bool>? ServerStateChanged;

    private sealed class ClientSession
    {
        public string Id { get; init; } = Guid.NewGuid().ToString("N")[..8];
        public TcpClient TcpClient { get; init; } = null!;
        public StreamReader Reader { get; init; } = null!;
        public StreamWriter Writer { get; init; } = null!;
        public ConnectedClientInfo Info { get; init; } = null!;
        public SemaphoreSlim WriteLock { get; } = new(1, 1);
    }

    public async Task StartAsync(int port)
    {
        if (IsRunning) return;

        try
        {
            Port = port;
            _cts = new CancellationTokenSource();
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();
            IsRunning = true;

            ServerStateChanged?.Invoke(true);
            LogAdded?.Invoke($"[{DateTime.Now:HH:mm:ss}] [SİSTEM] TCP Sunucusu {port} numaralı port üzerinde başlatıldı.");

            _ = AcceptClientsLoopAsync(_cts.Token);
        }
        catch (SocketException ex)
        {
            IsRunning = false;
            ServerStateChanged?.Invoke(false);
            LogAdded?.Invoke($"[{DateTime.Now:HH:mm:ss}] [HATA] Port {port} dinlenemedi: {ex.Message}");
            throw;
        }
    }

    private async Task AcceptClientsLoopAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested && _listener != null)
        {
            try
            {
                var tcpClient = await _listener.AcceptTcpClientAsync(token);
                _ = HandleClientAsync(tcpClient, token);
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (ObjectDisposedException)
            {
                break;
            }
            catch (Exception ex)
            {
                LogAdded?.Invoke($"[{DateTime.Now:HH:mm:ss}] [HATA] İstemci kabul hatası: {ex.Message}");
            }
        }
    }

    private async Task HandleClientAsync(TcpClient tcpClient, CancellationToken token)
    {
        ClientSession? session = null;

        try
        {
            var stream = tcpClient.GetStream();
            var reader = new StreamReader(stream, Encoding.UTF8);
            var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

            // İlk mesaj istemcinin kullanıcı adı (Join) bilgisini taşımalıdır
            string? firstLine = await reader.ReadLineAsync(token);
            var joinMsg = ChatMessage.FromJson(firstLine ?? string.Empty);

            if (joinMsg == null || string.IsNullOrWhiteSpace(joinMsg.Sender))
            {
                tcpClient.Close();
                return;
            }

            string requestedName = joinMsg.Sender.Trim();
            // Aynı kullanıcı adı varsa sonuna ek numara vererek çakışmayı önle
            string finalUsername = requestedName;
            int suffix = 2;
            while (_clients.Values.Any(c => c.Info.Username.Equals(finalUsername, StringComparison.OrdinalIgnoreCase)))
            {
                finalUsername = $"{requestedName}_{suffix++}";
            }

            var remoteEndPoint = tcpClient.Client.RemoteEndPoint as IPEndPoint;
            var info = new ConnectedClientInfo
            {
                ClientId = Guid.NewGuid().ToString("N")[..8],
                Username = finalUsername,
                IpAddress = remoteEndPoint?.Address.ToString() ?? "127.0.0.1",
                Port = remoteEndPoint?.Port ?? 0,
                ConnectedAt = DateTime.Now
            };

            session = new ClientSession
            {
                Id = info.ClientId,
                TcpClient = tcpClient,
                Reader = reader,
                Writer = writer,
                Info = info
            };

            _clients[session.Id] = session;
            NotifyClientsListUpdated();

            LogAdded?.Invoke($"[{DateTime.Now:HH:mm:ss}] [BAĞLANTI] '{finalUsername}' ({info.EndPoint}) bağlandı.");

            // Eğer adı değiştiyse istemciye bildir
            if (finalUsername != requestedName)
            {
                await SendToSessionAsync(session, new ChatMessage
                {
                    Type = MessageType.System,
                    Sender = "Sunucu",
                    Content = $"Kullanıcı adınız çakışma nedeniyle '{finalUsername}' olarak güncellendi."
                });
            }

            // Herkese katılma bildirimi ve güncel kullanıcı listesi gönder
            await BroadcastAsync(new ChatMessage
            {
                Type = MessageType.Join,
                Sender = finalUsername,
                Content = "sohbete katıldı."
            });
            await BroadcastUserListAsync();

            // Mesaj dinleme döngüsü
            while (!token.IsCancellationRequested && tcpClient.Connected)
            {
                string? line = await reader.ReadLineAsync(token);
                if (line == null) break; // Bağlantı kapandı

                var msg = ChatMessage.FromJson(line);
                if (msg == null) continue;

                msg.Sender = finalUsername;
                msg.Timestamp = DateTime.Now;

                if (msg.Type == MessageType.Private && !string.IsNullOrWhiteSpace(msg.Recipient) && msg.Recipient != "ALL")
                {
                    await RoutePrivateMessageAsync(session, msg);
                }
                else
                {
                    msg.Type = MessageType.Chat;
                    LogAdded?.Invoke(msg.ToDisplayString());
                    await BroadcastAsync(msg);
                }
            }
        }
        catch (OperationCanceledException) { }
        catch (IOException) { }
        catch (Exception ex)
        {
            LogAdded?.Invoke($"[{DateTime.Now:HH:mm:ss}] [UYARI] İstemci iletişim hatası: {ex.Message}");
        }
        finally
        {
            if (session != null)
            {
                _clients.TryRemove(session.Id, out _);
                NotifyClientsListUpdated();
                LogAdded?.Invoke($"[{DateTime.Now:HH:mm:ss}] [AYRILDI] '{session.Info.Username}' bağlantıyı kesti.");

                if (IsRunning)
                {
                    await BroadcastAsync(new ChatMessage
                    {
                        Type = MessageType.Leave,
                        Sender = session.Info.Username,
                        Content = "sohbetten ayrıldı."
                    });
                    await BroadcastUserListAsync();
                }
            }

            try { tcpClient.Close(); } catch { }
        }
    }

    private async Task RoutePrivateMessageAsync(ClientSession senderSession, ChatMessage msg)
    {
        var target = _clients.Values.FirstOrDefault(c =>
            c.Info.Username.Equals(msg.Recipient, StringComparison.OrdinalIgnoreCase));

        LogAdded?.Invoke(msg.ToDisplayString());

        if (target != null)
        {
            await SendToSessionAsync(target, msg);
            if (target.Id != senderSession.Id)
            {
                await SendToSessionAsync(senderSession, msg);
            }
        }
        else
        {
            await SendToSessionAsync(senderSession, new ChatMessage
            {
                Type = MessageType.System,
                Sender = "Sunucu",
                Content = $"'{msg.Recipient}' adlı kullanıcı şu anda çevrimiçi değil."
            });
        }
    }

    public async Task BroadcastSystemMessageAsync(string content)
    {
        var msg = new ChatMessage
        {
            Type = MessageType.System,
            Sender = "Sunucu",
            Content = content,
            Timestamp = DateTime.Now
        };
        LogAdded?.Invoke(msg.ToDisplayString());
        await BroadcastAsync(msg);
    }

    private async Task BroadcastUserListAsync()
    {
        var users = _clients.Values.Select(c => c.Info.Username).OrderBy(u => u).ToList();
        var msg = new ChatMessage
        {
            Type = MessageType.UserList,
            Sender = "Sunucu",
            OnlineUsers = users
        };
        await BroadcastAsync(msg);
    }

    private async Task BroadcastAsync(ChatMessage msg)
    {
        var tasks = _clients.Values.Select(c => SendToSessionAsync(c, msg));
        await Task.WhenAll(tasks);
    }

    private static async Task SendToSessionAsync(ClientSession session, ChatMessage msg)
    {
        await session.WriteLock.WaitAsync();
        try
        {
            if (session.TcpClient.Connected)
            {
                await session.Writer.WriteLineAsync(msg.ToJson());
            }
        }
        catch { }
        finally
        {
            session.WriteLock.Release();
        }
    }

    private void NotifyClientsListUpdated()
    {
        var list = _clients.Values.Select(c => c.Info).OrderBy(i => i.ConnectedAt).ToList();
        ClientsUpdated?.Invoke(list);
    }

    public void Stop()
    {
        if (!IsRunning) return;

        IsRunning = false;
        try { _cts?.Cancel(); } catch { }
        try { _listener?.Stop(); } catch { }

        foreach (var client in _clients.Values)
        {
            try { client.TcpClient.Close(); } catch { }
        }
        _clients.Clear();

        NotifyClientsListUpdated();
        ServerStateChanged?.Invoke(false);
        LogAdded?.Invoke($"[{DateTime.Now:HH:mm:ss}] [SİSTEM] TCP Sunucusu durduruldu.");
    }
}
