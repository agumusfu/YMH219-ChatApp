using System.Net.Sockets;
using System.Text;
using ChatApp.Core.Models;

namespace ChatApp.Client.Services;

/// <summary>
/// TcpClient, StreamReader/StreamWriter ve async/await kullanarak
/// TCP sunucusuna bağlanan, mesaj gönderen ve arka planda mesaj dinleyen istemci sınıfı.
/// </summary>
public class TcpChatClient
{
    private TcpClient? _client;
    private StreamReader? _reader;
    private StreamWriter? _writer;
    private CancellationTokenSource? _cts;
    private readonly SemaphoreSlim _writeLock = new(1, 1);

    public bool IsConnected => _client?.Connected ?? false;
    public string Username { get; private set; } = string.Empty;

    public event Action<ChatMessage>? MessageReceived;
    public event Action<bool, string>? ConnectionStateChanged;
    public event Action<string>? ErrorOccurred;

    public async Task ConnectAsync(string host, int port, string username)
    {
        if (IsConnected) return;

        try
        {
            Username = username.Trim();
            _client = new TcpClient();
            _cts = new CancellationTokenSource();

            using var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(_cts.Token, timeoutCts.Token);

            await _client.ConnectAsync(host.Trim(), port, linkedCts.Token);

            var stream = _client.GetStream();
            _reader = new StreamReader(stream, Encoding.UTF8);
            _writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

            // Sunucuya ilk Join paketini gönder
            await SendRawAsync(new ChatMessage
            {
                Type = MessageType.Join,
                Sender = Username,
                Content = "bağlandı"
            });

            ConnectionStateChanged?.Invoke(true, $"{host}:{port} sunucusuna '{Username}' olarak bağlanıldı.");
            _ = ReceiveLoopAsync(_cts.Token);
        }
        catch (OperationCanceledException)
        {
            Cleanup();
            ErrorOccurred?.Invoke("Sunucuya bağlantı zaman aşımına uğradı. IP ve Port bilgilerini kontrol ediniz.");
        }
        catch (SocketException ex)
        {
            Cleanup();
            ErrorOccurred?.Invoke($"Sunucuya bağlanılamadı ({ex.SocketErrorCode}): Sunucunun açık olduğundan emin olun.");
        }
        catch (Exception ex)
        {
            Cleanup();
            ErrorOccurred?.Invoke($"Bağlantı hatası: {ex.Message}");
        }
    }

    private async Task ReceiveLoopAsync(CancellationToken token)
    {
        try
        {
            while (!token.IsCancellationRequested && _reader != null && IsConnected)
            {
                string? line = await _reader.ReadLineAsync(token);
                if (line == null) break;

                var msg = ChatMessage.FromJson(line);
                if (msg != null)
                {
                    MessageReceived?.Invoke(msg);
                }
            }
        }
        catch (OperationCanceledException) { }
        catch (IOException) { }
        catch (Exception ex)
        {
            ErrorOccurred?.Invoke($"Veri alımı sırasında hata: {ex.Message}");
        }
        finally
        {
            bool wasConnected = _cts != null && !_cts.IsCancellationRequested;
            Cleanup();
            if (wasConnected)
            {
                ConnectionStateChanged?.Invoke(false, "Sunucu bağlantısı kesildi.");
            }
        }
    }

    public async Task SendMessageAsync(string content, string recipient = "ALL")
    {
        if (!IsConnected || string.IsNullOrWhiteSpace(content)) return;

        bool isPrivate = !string.IsNullOrWhiteSpace(recipient) && recipient != "ALL";
        var msg = new ChatMessage
        {
            Type = isPrivate ? MessageType.Private : MessageType.Chat,
            Sender = Username,
            Recipient = isPrivate ? recipient : "ALL",
            Content = content.Trim(),
            Timestamp = DateTime.Now
        };

        await SendRawAsync(msg);
    }

    private async Task SendRawAsync(ChatMessage msg)
    {
        if (_writer == null) return;
        await _writeLock.WaitAsync();
        try
        {
            await _writer.WriteLineAsync(msg.ToJson());
        }
        catch (Exception ex)
        {
            ErrorOccurred?.Invoke($"Mesaj gönderilemedi: {ex.Message}");
        }
        finally
        {
            _writeLock.Release();
        }
    }

    public void Disconnect()
    {
        if (_cts != null && !_cts.IsCancellationRequested)
        {
            _cts.Cancel();
        }
        Cleanup();
        ConnectionStateChanged?.Invoke(false, "Bağlantı kullanıcı tarafından sonlandırıldı.");
    }

    private void Cleanup()
    {
        try { _reader?.Dispose(); } catch { }
        try { _writer?.Dispose(); } catch { }
        try { _client?.Close(); } catch { }
        _reader = null;
        _writer = null;
        _client = null;
    }
}
