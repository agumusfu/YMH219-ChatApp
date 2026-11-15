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
        pnlTop.Height = 80;
        pnlTop.BackColor = Color.FromArgb(40, 40, 50);
        pnlTop.Padding = new Padding(8);

        int x = 8;
        lblHost.Text = "Sunucu:";
        lblHost.ForeColor = Color.LightGray;
        lblHost.Location = new Point(x, 12);
        lblHost.AutoSize = true;
        pnlTop.Controls.Add(lblHost);

        txtHost.Text = "127.0.0.1";
        txtHost.Location = new Point(x + 55, 8);
        txtHost.Width = 120;
        txtHost.BackColor = Color.FromArgb(60, 60, 70);
        txtHost.ForeColor = Color.White;
        pnlTop.Controls.Add(txtHost);

        lblPort.Text = "Port:";
        lblPort.ForeColor = Color.LightGray;
        lblPort.Location = new Point(x + 185, 12);
        lblPort.AutoSize = true;
        pnlTop.Controls.Add(lblPort);

        nudPort.Location = new Point(x + 220, 8);
        nudPort.Width = 70;
        nudPort.Minimum = 1024;
        nudPort.Maximum = 65535;
        nudPort.Value = 5000;
        nudPort.BackColor = Color.FromArgb(60, 60, 70);
        nudPort.ForeColor = Color.White;
        pnlTop.Controls.Add(nudPort);

        lblUsername.Text = "Kullanici Adi:";
        lblUsername.ForeColor = Color.LightGray;
        lblUsername.Location = new Point(x + 300, 12);
        lblUsername.AutoSize = true;
        pnlTop.Controls.Add(lblUsername);

        txtUsername.Location = new Point(x + 390, 8);
        txtUsername.Width = 120;
        txtUsername.BackColor = Color.FromArgb(60, 60, 70);
        txtUsername.ForeColor = Color.White;
        pnlTop.Controls.Add(txtUsername);

        btnConnect.Text = "Baglan";
        btnConnect.Location = new Point(x + 520, 6);
        btnConnect.Size = new Size(90, 30);
        btnConnect.BackColor = Color.FromArgb(0, 150, 100);
        btnConnect.ForeColor = Color.White;
        btnConnect.FlatStyle = FlatStyle.Flat;
        btnConnect.Click += btnConnect_Click;
        pnlTop.Controls.Add(btnConnect);

        btnDisconnect.Text = "Ayril";
        btnDisconnect.Location = new Point(x + 620, 6);
        btnDisconnect.Size = new Size(90, 30);
        btnDisconnect.BackColor = Color.FromArgb(180, 50, 50);
        btnDisconnect.ForeColor = Color.White;
        btnDisconnect.FlatStyle = FlatStyle.Flat;
        btnDisconnect.Enabled = false;
        btnDisconnect.Click += btnDisconnect_Click;
        pnlTop.Controls.Add(btnDisconnect);

        btnSaveHistory.Text = "Gecmisi Kaydet";
        btnSaveHistory.Location = new Point(x + 720, 6);
        btnSaveHistory.Size = new Size(110, 30);
        btnSaveHistory.BackColor = Color.FromArgb(50, 100, 180);
        btnSaveHistory.ForeColor = Color.White;
        btnSaveHistory.FlatStyle = FlatStyle.Flat;
        btnSaveHistory.Click += btnSaveHistory_Click;
        pnlTop.Controls.Add(btnSaveHistory);

        lblStatus.Text = "Bagli Degil";
        lblStatus.ForeColor = Color.OrangeRed;
        lblStatus.Location = new Point(8, 48);
        lblStatus.AutoSize = true;
        pnlTop.Controls.Add(lblStatus);

        // splitMain
        splitMain.Dock = DockStyle.Fill;
        splitMain.Size = new Size(1000, 560);
        splitMain.Panel1MinSize = 150;
        splitMain.Panel2MinSize = 300;
        splitMain.SplitterDistance = 190;

        // pnlUsers (left panel)
        pnlUsers.Dock = DockStyle.Fill;
        pnlUsers.BackColor = Color.FromArgb(30, 30, 40);

        lblOnlineUsers.Text = "Cevrimici Kullanicilar";
        lblOnlineUsers.ForeColor = Color.LightGray;
        lblOnlineUsers.Dock = DockStyle.Top;
        lblOnlineUsers.Height = 25;
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
        pnlSend.Height = 70;
        pnlSend.BackColor = Color.FromArgb(40, 40, 50);
        pnlSend.Padding = new Padding(6);

        chkPrivate.Text = "Ozel Mesaj";
        chkPrivate.ForeColor = Color.LightGray;
        chkPrivate.Location = new Point(6, 6);
        chkPrivate.AutoSize = true;
        chkPrivate.CheckedChanged += chkPrivate_CheckedChanged;
        pnlSend.Controls.Add(chkPrivate);

        cmbRecipient.Location = new Point(100, 4);
        cmbRecipient.Width = 130;
        cmbRecipient.BackColor = Color.FromArgb(60, 60, 70);
        cmbRecipient.ForeColor = Color.White;
        cmbRecipient.FlatStyle = FlatStyle.Flat;
        cmbRecipient.Visible = false;
        pnlSend.Controls.Add(cmbRecipient);

        txtMessage.Location = new Point(6, 36);
        txtMessage.Width = 500;
        txtMessage.Height = 24;
        txtMessage.BackColor = Color.FromArgb(60, 60, 70);
        txtMessage.ForeColor = Color.White;
        txtMessage.KeyDown += txtMessage_KeyDown;
        pnlSend.Controls.Add(txtMessage);

        btnSend.Text = "Gonder";
        btnSend.Location = new Point(515, 34);
        btnSend.Size = new Size(90, 28);
        btnSend.BackColor = Color.FromArgb(0, 150, 100);
        btnSend.ForeColor = Color.White;
        btnSend.FlatStyle = FlatStyle.Flat;
        btnSend.Click += btnSend_Click;
        pnlSend.Controls.Add(btnSend);

        // statusStrip
        statusStrip.BackColor = Color.FromArgb(30, 30, 40);
        tsslState.Text = "Durum: Bagli Degil";
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
        this.Text = "ChatApp - Istemci";
        this.Size = new Size(1000, 680);
        this.MinimumSize = new Size(800, 500);
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
