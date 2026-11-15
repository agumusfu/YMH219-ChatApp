using System.Data;
using ChatApp.Core.Models;
using ChatApp.Core.Services;
using ChatApp.Server.Services;

namespace ChatApp.Server;

public partial class ServerForm : Form
{
    private readonly TcpChatServer _server;
    private readonly ChatHistoryService _historyService;
    private readonly DataTable _clientsTable;

    public ServerForm()
    {
        InitializeComponent();
        try
        {
            if (!string.IsNullOrEmpty(Environment.ProcessPath))
                this.Icon = Icon.ExtractAssociatedIcon(Environment.ProcessPath);
        }
        catch { }

        _server = new TcpChatServer();
        _historyService = new ChatHistoryService();

        // Bağlı istemciler tablosu
        _clientsTable = new DataTable();
        _clientsTable.Columns.Add("Kullanıcı", typeof(string));
        _clientsTable.Columns.Add("IP : Port", typeof(string));
        _clientsTable.Columns.Add("Bağlantı Zamanı", typeof(string));
        dgvClients.DataSource = _clientsTable;

        // Sunucu olaylarına abone ol
        _server.LogAdded += OnLogAdded;
        _server.ClientsUpdated += OnClientsUpdated;
        _server.ServerStateChanged += OnServerStateChanged;
    }

    private async void BtnStart_Click(object? sender, EventArgs e)
    {
        try
        {
            int port = (int)numPort.Value;
            await _server.StartAsync(port);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Sunucu başlatılırken hata oluştu:\n{ex.Message}", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnStop_Click(object? sender, EventArgs e)
    {
        _server.Stop();
    }

    private async void BtnBroadcast_Click(object? sender, EventArgs e)
    {
        await SendBroadcastAsync();
    }

    private async void TxtBroadcast_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            await SendBroadcastAsync();
        }
    }

    private async Task SendBroadcastAsync()
    {
        string text = txtBroadcast.Text.Trim();
        if (string.IsNullOrEmpty(text)) return;

        if (!_server.IsRunning)
        {
            MessageBox.Show("Duyuru göndermek için önce sunucuyu başlatmalısınız.", "Sunucu Kapalı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        await _server.BroadcastSystemMessageAsync(text);
        txtBroadcast.Clear();
    }

    private void BtnSaveLogs_Click(object? sender, EventArgs e)
    {
        if (rtbLogs.Lines.Length == 0)
        {
            MessageBox.Show("Kaydedilecek günlük satırı bulunmamaktadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var sfd = new SaveFileDialog
        {
            Title = "Sunucu Günlüğünü Kaydet",
            Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*",
            FileName = $"ServerChatLogs_{DateTime.Now:yyyyMMdd_HHmmss}.txt"
        };

        if (sfd.ShowDialog(this) == DialogResult.OK)
        {
            var (success, msg) = _historyService.SaveHistoryToFile(sfd.FileName, rtbLogs.Lines, "YMH219 - TCP Chat Sunucu Günlüğü");
            MessageBox.Show(msg, success ? "Başarılı" : "Hata", MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }
    }

    private void OnLogAdded(string logLine)
    {
        if (InvokeRequired)
        {
            Invoke(new Action<string>(OnLogAdded), logLine);
            return;
        }

        rtbLogs.AppendText(logLine + Environment.NewLine);
        rtbLogs.ScrollToCaret();
    }

    private void OnClientsUpdated(List<ConnectedClientInfo> clients)
    {
        if (InvokeRequired)
        {
            Invoke(new Action<List<ConnectedClientInfo>>(OnClientsUpdated), clients);
            return;
        }

        _clientsTable.Rows.Clear();
        foreach (var c in clients)
        {
            _clientsTable.Rows.Add(c.Username, c.EndPoint, c.ConnectedAt.ToString("HH:mm:ss"));
        }

        grpClients.Text = $"Bağlı İstemciler ({clients.Count})";
        statusLabelClients.Text = $"Bağlı İstemci: {clients.Count} kişi";
    }

    private void OnServerStateChanged(bool isRunning)
    {
        if (InvokeRequired)
        {
            Invoke(new Action<bool>(OnServerStateChanged), isRunning);
            return;
        }

        btnStart.Enabled = !isRunning;
        btnStop.Enabled = isRunning;
        numPort.Enabled = !isRunning;

        if (isRunning)
        {
            lblStatusBadge.Text = $"● ÇALIŞIYOR (Port: {_server.Port})";
            lblStatusBadge.BackColor = Color.FromArgb(39, 174, 96);
            statusLabelState.Text = $"Durum: {_server.Port} Portu Dinleniyor";
        }
        else
        {
            lblStatusBadge.Text = "○ SUNUCU DURDURULDU";
            lblStatusBadge.BackColor = Color.FromArgb(149, 165, 166);
            statusLabelState.Text = "Durum: Durduruldu";
        }
    }

    private void ServerForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        _server.Stop();
    }
}
