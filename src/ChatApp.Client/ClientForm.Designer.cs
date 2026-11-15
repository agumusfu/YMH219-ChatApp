namespace ChatApp.Client;

partial class ClientForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        this.pnlTop = new Panel();
        this.lblHost = new Label();
        this.txtHost = new TextBox();
        this.lblPort = new Label();
        this.nudPort = new NumericUpDown();
        this.lblUsername = new Label();
        this.txtUsername = new TextBox();
        this.btnConnect = new Button();
        this.btnDisconnect = new Button();
        this.lblStatus = new Label();
        this.splitMain = new SplitContainer();
        this.pnlUsers = new Panel();
        this.lblOnlineUsers = new Label();
        this.lstUsers = new ListBox();
        this.pnlChat = new Panel();
        this.rtbChat = new RichTextBox();
        this.pnlSend = new Panel();
        this.chkPrivate = new CheckBox();
        this.cmbRecipient = new ComboBox();
        this.txtMessage = new TextBox();
        this.btnSend = new Button();
        this.btnSaveHistory = new Button();
        this.statusStrip = new StatusStrip();
        this.tsslState = new ToolStripStatusLabel();
        this.tsslMsgCount = new ToolStripStatusLabel();

        // pnlTop
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Height = 92;
        pnlTop.BackColor = Color.FromArgb(40, 40, 50);
        pnlTop.Padding = new Padding(8);

        lblHost.Text = "Sunucu:";
        lblHost.ForeColor = Color.LightGray;
        lblHost.Location = new Point(10, 15);
        lblHost.AutoSize = true;
        pnlTop.Controls.Add(lblHost);

        txtHost.Text = "127.0.0.1";
        txtHost.Location = new Point(82, 11);
        txtHost.Width = 130;
        txtHost.BackColor = Color.FromArgb(60, 60, 70);
        txtHost.ForeColor = Color.White;
        pnlTop.Controls.Add(txtHost);

        lblPort.Text = "Port:";
        lblPort.ForeColor = Color.LightGray;
        lblPort.Location = new Point(226, 15);
        lblPort.AutoSize = true;
        pnlTop.Controls.Add(lblPort);

        nudPort.Location = new Point(274, 11);
        nudPort.Width = 78;
        nudPort.Minimum = 1024;
        nudPort.Maximum = 65535;
        nudPort.Value = 5000;
        nudPort.BackColor = Color.FromArgb(60, 60, 70);
        nudPort.ForeColor = Color.White;
        pnlTop.Controls.Add(nudPort);

        lblUsername.Text = "Kullanıcı Adı:";
        lblUsername.ForeColor = Color.LightGray;
        lblUsername.Location = new Point(368, 15);
        lblUsername.AutoSize = true;
        pnlTop.Controls.Add(lblUsername);

        txtUsername.Location = new Point(485, 11);
        txtUsername.Width = 135;
        txtUsername.BackColor = Color.FromArgb(60, 60, 70);
        txtUsername.ForeColor = Color.White;
        pnlTop.Controls.Add(txtUsername);

        btnConnect.Text = "Bağlan";
        btnConnect.Location = new Point(634, 8);
        btnConnect.Size = new Size(95, 34);
        btnConnect.BackColor = Color.FromArgb(0, 150, 100);
        btnConnect.ForeColor = Color.White;
        btnConnect.FlatStyle = FlatStyle.Flat;
        btnConnect.Click += btnConnect_Click;
        pnlTop.Controls.Add(btnConnect);

        btnDisconnect.Text = "Ayrıl";
        btnDisconnect.Location = new Point(737, 8);
        btnDisconnect.Size = new Size(85, 34);
        btnDisconnect.BackColor = Color.FromArgb(180, 50, 50);
        btnDisconnect.ForeColor = Color.White;
        btnDisconnect.FlatStyle = FlatStyle.Flat;
        btnDisconnect.Enabled = false;
        btnDisconnect.Click += btnDisconnect_Click;
        pnlTop.Controls.Add(btnDisconnect);

        btnSaveHistory.Text = "Geçmişi Kaydet";
        btnSaveHistory.Location = new Point(830, 8);
        btnSaveHistory.Size = new Size(155, 34);
        btnSaveHistory.BackColor = Color.FromArgb(50, 100, 180);
        btnSaveHistory.ForeColor = Color.White;
        btnSaveHistory.FlatStyle = FlatStyle.Flat;
        btnSaveHistory.Click += btnSaveHistory_Click;
        pnlTop.Controls.Add(btnSaveHistory);

        lblStatus.Text = "Bağlı Değil";
        lblStatus.ForeColor = Color.OrangeRed;
        lblStatus.Location = new Point(10, 58);
        lblStatus.AutoSize = true;
        pnlTop.Controls.Add(lblStatus);

        // splitMain
        splitMain.Dock = DockStyle.Fill;
        splitMain.Size = new Size(1020, 560);
        splitMain.Panel1MinSize = 150;
        splitMain.Panel2MinSize = 400;
        splitMain.SplitterDistance = 190;

        // pnlUsers (left panel)
        pnlUsers.Dock = DockStyle.Fill;
        pnlUsers.BackColor = Color.FromArgb(30, 30, 40);

        lblOnlineUsers.Text = "Çevrimiçi Kullanıcılar";
        lblOnlineUsers.ForeColor = Color.LightGray;
        lblOnlineUsers.Dock = DockStyle.Top;
        lblOnlineUsers.Height = 28;
        lblOnlineUsers.TextAlign = ContentAlignment.MiddleCenter;
        lblOnlineUsers.BackColor = Color.FromArgb(50, 50, 60);
        pnlUsers.Controls.Add(lstUsers);
        pnlUsers.Controls.Add(lblOnlineUsers);

        lstUsers.Dock = DockStyle.Fill;
        lstUsers.BackColor = Color.FromArgb(35, 35, 45);
        lstUsers.ForeColor = Color.LightCyan;
        lstUsers.BorderStyle = BorderStyle.None;
        lstUsers.Font = new Font("Consolas", 10f);

        // pnlChat (right panel)
        pnlChat.Dock = DockStyle.Fill;
        pnlChat.BackColor = Color.FromArgb(25, 25, 35);

        rtbChat.Dock = DockStyle.Fill;
        rtbChat.ReadOnly = true;
        rtbChat.BackColor = Color.FromArgb(25, 25, 35);
        rtbChat.ForeColor = Color.White;
        rtbChat.Font = new Font("Consolas", 10f);
        rtbChat.BorderStyle = BorderStyle.None;
        rtbChat.ScrollBars = RichTextBoxScrollBars.Vertical;

        // pnlSend
        pnlSend.Dock = DockStyle.Bottom;
        pnlSend.Height = 86;
        pnlSend.BackColor = Color.FromArgb(40, 40, 50);
        pnlSend.Padding = new Padding(8);

        chkPrivate.Text = "Özel Mesaj";
        chkPrivate.ForeColor = Color.LightGray;
        chkPrivate.Location = new Point(10, 10);
        chkPrivate.AutoSize = true;
        chkPrivate.CheckedChanged += chkPrivate_CheckedChanged;
        pnlSend.Controls.Add(chkPrivate);

        cmbRecipient.Location = new Point(125, 7);
        cmbRecipient.Width = 160;
        cmbRecipient.BackColor = Color.FromArgb(60, 60, 70);
        cmbRecipient.ForeColor = Color.White;
        cmbRecipient.FlatStyle = FlatStyle.Flat;
        cmbRecipient.Visible = false;
        pnlSend.Controls.Add(cmbRecipient);

        txtMessage.Location = new Point(10, 42);
        txtMessage.Width = 680;
        txtMessage.Height = 28;
        txtMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtMessage.BackColor = Color.FromArgb(60, 60, 70);
        txtMessage.ForeColor = Color.White;
        txtMessage.KeyDown += txtMessage_KeyDown;
        pnlSend.Controls.Add(txtMessage);

        btnSend.Text = "Gönder";
        btnSend.Location = new Point(700, 40);
        btnSend.Size = new Size(105, 32);
        btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSend.BackColor = Color.FromArgb(0, 150, 100);
        btnSend.ForeColor = Color.White;
        btnSend.FlatStyle = FlatStyle.Flat;
        btnSend.Click += btnSend_Click;
        pnlSend.Controls.Add(btnSend);

        // statusStrip
        statusStrip.BackColor = Color.FromArgb(30, 30, 40);
        tsslState.Text = "Durum: Bağlı Değil";
        tsslState.ForeColor = Color.LightGray;
        tsslMsgCount.Text = "Mesajlar: 0";
        tsslMsgCount.ForeColor = Color.LightGray;
        statusStrip.Items.Add(tsslState);
        statusStrip.Items.Add(new ToolStripSeparator());
        statusStrip.Items.Add(tsslMsgCount);

        // Assemble panels
        pnlChat.Controls.Add(rtbChat);
        pnlChat.Controls.Add(pnlSend);
        splitMain.Panel1.Controls.Add(pnlUsers);
        splitMain.Panel2.Controls.Add(pnlChat);

        // Form
        this.Text = "ChatApp - İstemci";
        this.Size = new Size(1040, 700);
        this.MinimumSize = new Size(1010, 540);
        this.BackColor = Color.FromArgb(25, 25, 35);
        this.Controls.Add(splitMain);
        this.Controls.Add(pnlTop);
        this.Controls.Add(statusStrip);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.FormClosing += ClientForm_FormClosing;
    }

    private Panel pnlTop;
    private Label lblHost, lblPort, lblUsername, lblStatus, lblOnlineUsers;
    private TextBox txtHost, txtUsername, txtMessage;
    private NumericUpDown nudPort;
    private Button btnConnect, btnDisconnect, btnSend, btnSaveHistory;
    private SplitContainer splitMain;
    private Panel pnlUsers, pnlChat, pnlSend;
    private ListBox lstUsers;
    private RichTextBox rtbChat;
    private CheckBox chkPrivate;
    private ComboBox cmbRecipient;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel tsslState, tsslMsgCount;

    #endregion
}
