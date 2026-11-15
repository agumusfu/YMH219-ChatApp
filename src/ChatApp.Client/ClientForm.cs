using ChatApp.Core.Models;
using ChatApp.Core.Services;
using ChatApp.Client.Services;

namespace ChatApp.Client;

public partial class ClientForm : Form
{
    private TcpChatClient? _client;
    private readonly ChatHistoryService _historyService = new();
    private readonly List<string> _historyLines = new();
    private int _messageCount = 0;

    public ClientForm()
    {
        InitializeComponent();
        try
        {
            if (!string.IsNullOrEmpty(Environment.ProcessPath))
                this.Icon = Icon.ExtractAssociatedIcon(Environment.ProcessPath);
        }
        catch { }
    }

    // ─── Connect / Disconnect ───────────────────────────────────────────────

    private async void btnConnect_Click(object sender, EventArgs e)
    {
        string host = txtHost.Text.Trim();
        int port = (int)nudPort.Value;
        string username = txtUsername.Text.Trim();

        if (string.IsNullOrWhiteSpace(username))
        {
            MessageBox.Show("Lutfen bir kullanici adi girin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnConnect.Enabled = false;
        lblStatus.Text = "Baglaniliyor...";
        lblStatus.ForeColor = Color.Yellow;

        _client = new TcpChatClient();
        _client.MessageReceived += OnMessageReceived;
        _client.ConnectionStateChanged += OnConnectionStateChanged;
        _client.ErrorOccurred += OnErrorOccurred;

        await _client.ConnectAsync(host, port, username);
    }

    private void btnDisconnect_Click(object sender, EventArgs e)
    {
        _client?.Disconnect();
    }

    private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _client?.Disconnect();
    }

    // ─── Message events ─────────────────────────────────────────────────────

    private void OnMessageReceived(ChatMessage msg)
    {
        if (InvokeRequired) { Invoke(() => OnMessageReceived(msg)); return; }

        switch (msg.Type)
        {
            case MessageType.Join:
                AppendColoredMessage($"[+] {msg.Sender} sohbete katildi", Color.LimeGreen);
                break;
            case MessageType.Leave:
                AppendColoredMessage($"[-] {msg.Sender} ayrildi", Color.OrangeRed);
                break;
            case MessageType.System:
                AppendColoredMessage($"[Sistem] {msg.Content}", Color.LightGray);
                break;
            case MessageType.Private:
                AppendColoredMessage($"[Ozel] {msg.Sender} -> {msg.Recipient}: {msg.Content}", Color.Gold);
                break;
            case MessageType.UserList:
                UpdateUserList(msg.Content ?? "");
                return; // don't count as chat message
            case MessageType.Chat:
            default:
                AppendColoredMessage($"[{msg.Timestamp:HH:mm:ss}] {msg.Sender}: {msg.Content}", Color.White);
                break;
        }

        _messageCount++;
        tsslMsgCount.Text = $"Mesajlar: {_messageCount}";
        _historyLines.Add(msg.ToDisplayString());
    }

    private void OnConnectionStateChanged(bool connected, string info)
    {
        if (InvokeRequired) { Invoke(() => OnConnectionStateChanged(connected, info)); return; }

        if (connected)
        {
            lblStatus.Text = $"Baglandi ({txtHost.Text}:{nudPort.Value})";
            lblStatus.ForeColor = Color.LimeGreen;
            tsslState.Text = "Durum: Baglandi";
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
            txtHost.Enabled = false;
            nudPort.Enabled = false;
            txtUsername.Enabled = false;
        }
        else
        {
            AppendSystemMessage($"Baglanti kesildi. {info}");
            ResetConnectionUI();
        }
    }

    private void OnErrorOccurred(string error)
    {
        if (InvokeRequired) { Invoke(() => OnErrorOccurred(error)); return; }
        AppendColoredMessage($"[Hata] {error}", Color.OrangeRed);
        if (!(_client?.IsConnected ?? false))
            ResetConnectionUI();
    }

    // ─── Send ────────────────────────────────────────────────────────────────

    private async void btnSend_Click(object sender, EventArgs e) => await SendMessage();

    private async void txtMessage_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            await SendMessage();
        }
    }

    private async Task SendMessage()
    {
        if (_client == null || !_client.IsConnected) return;
        string text = txtMessage.Text.Trim();
        if (string.IsNullOrWhiteSpace(text)) return;

        string? recipient = chkPrivate.Checked ? cmbRecipient.SelectedItem?.ToString() : null;
        await _client.SendMessageAsync(text, recipient ?? "ALL");
        txtMessage.Clear();
    }

    // ─── Users list ──────────────────────────────────────────────────────────

    private void UpdateUserList(string csv)
    {
        lstUsers.Items.Clear();
        cmbRecipient.Items.Clear();
        string[] users = csv.Split(',', StringSplitOptions.RemoveEmptyEntries);
        foreach (string u in users)
        {
            lstUsers.Items.Add(u);
            if (u != _client?.Username)
                cmbRecipient.Items.Add(u);
        }
    }

    private void chkPrivate_CheckedChanged(object sender, EventArgs e)
    {
        cmbRecipient.Visible = chkPrivate.Checked;
    }

    // ─── Save history ────────────────────────────────────────────────────────

    private void btnSaveHistory_Click(object sender, EventArgs e)
    {
        using var dlg = new SaveFileDialog
        {
            Filter = "Metin Dosyasi (*.txt)|*.txt",
            FileName = $"sohbet_gecmisi_{DateTime.Now:yyyyMMdd_HHmmss}.txt"
        };
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            var result = _historyService.SaveHistoryToFile(dlg.FileName, _historyLines, "YMH219 - İstemci Sohbet Geçmişi");
            MessageBox.Show(result.Message, result.Success ? "Bilgi" : "Uyari", MessageBoxButtons.OK,
                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
    }

    // ─── Helpers ─────────────────────────────────────────────────────────────

    private void AppendSystemMessage(string text)
        => AppendColoredMessage($"[Sistem] {text}", Color.LightGray);

    private void AppendColoredMessage(string text, Color color)
    {
        rtbChat.SelectionStart = rtbChat.TextLength;
        rtbChat.SelectionLength = 0;
        rtbChat.SelectionColor = color;
        rtbChat.AppendText(text + Environment.NewLine);
        rtbChat.SelectionColor = rtbChat.ForeColor;
        rtbChat.ScrollToCaret();
    }

    private void ResetConnectionUI()
    {
        lblStatus.Text = "Bagli Degil";
        lblStatus.ForeColor = Color.OrangeRed;
        tsslState.Text = "Durum: Bagli Degil";
        btnConnect.Enabled = true;
        btnDisconnect.Enabled = false;
        txtHost.Enabled = true;
        nudPort.Enabled = true;
        txtUsername.Enabled = true;
        lstUsers.Items.Clear();
        cmbRecipient.Items.Clear();
    }
}
