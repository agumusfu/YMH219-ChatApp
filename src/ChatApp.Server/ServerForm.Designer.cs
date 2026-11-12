namespace ChatApp.Server;

partial class ServerForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel topPanel;
    private System.Windows.Forms.Label lblPort;
    private System.Windows.Forms.NumericUpDown numPort;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Button btnStop;
    private System.Windows.Forms.Button btnSaveLogs;
    private System.Windows.Forms.Label lblStatusBadge;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.GroupBox grpClients;
    private System.Windows.Forms.DataGridView dgvClients;
    private System.Windows.Forms.GroupBox grpLogs;
    private System.Windows.Forms.RichTextBox rtbLogs;
    private System.Windows.Forms.Panel pnlBroadcast;
    private System.Windows.Forms.TextBox txtBroadcast;
    private System.Windows.Forms.Button btnBroadcast;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel statusLabelState;
    private System.Windows.Forms.ToolStripStatusLabel statusLabelClients;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
        topPanel = new System.Windows.Forms.Panel();
        lblPort = new System.Windows.Forms.Label();
        numPort = new System.Windows.Forms.NumericUpDown();
        btnStart = new System.Windows.Forms.Button();
        btnStop = new System.Windows.Forms.Button();
        btnSaveLogs = new System.Windows.Forms.Button();
        lblStatusBadge = new System.Windows.Forms.Label();
        splitContainer = new System.Windows.Forms.SplitContainer();
        grpClients = new System.Windows.Forms.GroupBox();
        dgvClients = new System.Windows.Forms.DataGridView();
        grpLogs = new System.Windows.Forms.GroupBox();
        rtbLogs = new System.Windows.Forms.RichTextBox();
        pnlBroadcast = new System.Windows.Forms.Panel();
        txtBroadcast = new System.Windows.Forms.TextBox();
        btnBroadcast = new System.Windows.Forms.Button();
        statusStrip = new System.Windows.Forms.StatusStrip();
        statusLabelState = new System.Windows.Forms.ToolStripStatusLabel();
        statusLabelClients = new System.Windows.Forms.ToolStripStatusLabel();
        topPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numPort).BeginInit();
        ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
        splitContainer.Panel1.SuspendLayout();
        splitContainer.Panel2.SuspendLayout();
        splitContainer.SuspendLayout();
        grpClients.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
        grpLogs.SuspendLayout();
        pnlBroadcast.SuspendLayout();
        statusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // topPanel
        // 
        topPanel.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
        topPanel.Controls.Add(lblPort);
        topPanel.Controls.Add(numPort);
        topPanel.Controls.Add(btnStart);
        topPanel.Controls.Add(btnStop);
        topPanel.Controls.Add(btnSaveLogs);
        topPanel.Controls.Add(lblStatusBadge);
        topPanel.Dock = System.Windows.Forms.DockStyle.Top;
        topPanel.Location = new System.Drawing.Point(0, 0);
        topPanel.Name = "topPanel";
        topPanel.Size = new System.Drawing.Size(900, 54);
        topPanel.TabIndex = 0;
        // 
        // lblPort
        // 
        lblPort.AutoSize = true;
        lblPort.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
        lblPort.ForeColor = System.Drawing.Color.White;
        lblPort.Location = new System.Drawing.Point(14, 18);
        lblPort.Name = "lblPort";
        lblPort.Size = new System.Drawing.Size(37, 17);
        lblPort.TabIndex = 0;
        lblPort.Text = "Port:";
        // 
        // numPort
        // 
        numPort.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        numPort.Location = new System.Drawing.Point(56, 15);
        numPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
        numPort.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
        numPort.Name = "numPort";
        numPort.Size = new System.Drawing.Size(75, 24);
        numPort.TabIndex = 1;
        numPort.Value = new decimal(new int[] { 5000, 0, 0, 0 });
        // 
        // btnStart
        // 
        btnStart.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
        btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
        btnStart.FlatAppearance.BorderSize = 0;
        btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnStart.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
        btnStart.ForeColor = System.Drawing.Color.White;
        btnStart.Location = new System.Drawing.Point(145, 11);
        btnStart.Name = "btnStart";
        btnStart.Size = new System.Drawing.Size(135, 32);
        btnStart.TabIndex = 2;
        btnStart.Text = "▶ Sunucuyu Başlat";
        btnStart.UseVisualStyleBackColor = false;
        btnStart.Click += BtnStart_Click;
        // 
        // btnStop
        // 
        btnStop.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
        btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
        btnStop.Enabled = false;
        btnStop.FlatAppearance.BorderSize = 0;
        btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
        btnStop.ForeColor = System.Drawing.Color.White;
        btnStop.Location = new System.Drawing.Point(288, 11);
        btnStop.Name = "btnStop";
        btnStop.Size = new System.Drawing.Size(135, 32);
        btnStop.TabIndex = 3;
        btnStop.Text = "⏹ Sunucuyu Durdur";
        btnStop.UseVisualStyleBackColor = false;
        btnStop.Click += BtnStop_Click;
        // 
        // btnSaveLogs
        // 
        btnSaveLogs.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
        btnSaveLogs.Cursor = System.Windows.Forms.Cursors.Hand;
        btnSaveLogs.FlatAppearance.BorderSize = 0;
        btnSaveLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnSaveLogs.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
        btnSaveLogs.ForeColor = System.Drawing.Color.White;
        btnSaveLogs.Location = new System.Drawing.Point(432, 11);
        btnSaveLogs.Name = "btnSaveLogs";
        btnSaveLogs.Size = new System.Drawing.Size(150, 32);
        btnSaveLogs.TabIndex = 4;
        btnSaveLogs.Text = "💾 Logları Kaydet (.txt)";
        btnSaveLogs.UseVisualStyleBackColor = false;
        btnSaveLogs.Click += BtnSaveLogs_Click;
        // 
        // lblStatusBadge
        // 
        lblStatusBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        lblStatusBadge.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
        lblStatusBadge.Font = new System.Drawing.Font("Segoe UI Bold", 9.5F);
        lblStatusBadge.ForeColor = System.Drawing.Color.White;
        lblStatusBadge.Location = new System.Drawing.Point(676, 12);
        lblStatusBadge.Name = "lblStatusBadge";
        lblStatusBadge.Size = new System.Drawing.Size(212, 30);
        lblStatusBadge.TabIndex = 5;
        lblStatusBadge.Text = "○ SUNUCU DURDURULDU";
        lblStatusBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // splitContainer
        // 
        splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        splitContainer.Location = new System.Drawing.Point(0, 54);
        splitContainer.Name = "splitContainer";
        // 
        // splitContainer.Panel1
        // 
        splitContainer.Panel1.Controls.Add(grpClients);
        splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(8);
        // 
        // splitContainer.Panel2
        // 
        splitContainer.Panel2.Controls.Add(grpLogs);
        splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(8);
        splitContainer.Size = new System.Drawing.Size(900, 480);
        splitContainer.SplitterDistance = 320;
        splitContainer.TabIndex = 1;
        // 
        // grpClients
        // 
        grpClients.Controls.Add(dgvClients);
        grpClients.Dock = System.Windows.Forms.DockStyle.Fill;
        grpClients.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
        grpClients.Location = new System.Drawing.Point(8, 8);
        grpClients.Name = "grpClients";
        grpClients.Padding = new System.Windows.Forms.Padding(6);
        grpClients.Size = new System.Drawing.Size(304, 464);
        grpClients.TabIndex = 0;
        grpClients.TabStop = false;
        grpClients.Text = "Bağlı İstemciler (0)";
        // 
        // dgvClients
        // 
        dgvClients.AllowUserToAddRows = false;
        dgvClients.AllowUserToDeleteRows = false;
        dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvClients.BackgroundColor = System.Drawing.Color.White;
        dgvClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
        dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
        dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
        dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
        dgvClients.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
        dgvClients.ColumnHeadersHeight = 28;
        dgvClients.Dock = System.Windows.Forms.DockStyle.Fill;
        dgvClients.EnableHeadersVisualStyles = false;
        dgvClients.Location = new System.Drawing.Point(6, 23);
        dgvClients.Name = "dgvClients";
        dgvClients.ReadOnly = true;
        dgvClients.RowHeadersVisible = false;
        dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvClients.Size = new System.Drawing.Size(292, 435);
        dgvClients.TabIndex = 0;
        // 
        // grpLogs
        // 
        grpLogs.Controls.Add(rtbLogs);
        grpLogs.Controls.Add(pnlBroadcast);
        grpLogs.Dock = System.Windows.Forms.DockStyle.Fill;
        grpLogs.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
        grpLogs.Location = new System.Drawing.Point(8, 8);
        grpLogs.Name = "grpLogs";
        grpLogs.Padding = new System.Windows.Forms.Padding(6);
        grpLogs.Size = new System.Drawing.Size(560, 464);
        grpLogs.TabIndex = 0;
        grpLogs.TabStop = false;
        grpLogs.Text = "Sunucu Olay ve Mesaj Günlüğü";
        // 
        // rtbLogs
        // 
        rtbLogs.BackColor = System.Drawing.Color.FromArgb(30, 39, 46);
        rtbLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
        rtbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
        rtbLogs.Font = new System.Drawing.Font("Consolas", 9.5F);
        rtbLogs.ForeColor = System.Drawing.Color.FromArgb(210, 218, 226);
        rtbLogs.Location = new System.Drawing.Point(6, 23);
        rtbLogs.Name = "rtbLogs";
        rtbLogs.ReadOnly = true;
        rtbLogs.Size = new System.Drawing.Size(548, 392);
        rtbLogs.TabIndex = 0;
        rtbLogs.Text = "";
        // 
        // pnlBroadcast
        // 
        pnlBroadcast.Controls.Add(txtBroadcast);
        pnlBroadcast.Controls.Add(btnBroadcast);
        pnlBroadcast.Dock = System.Windows.Forms.DockStyle.Bottom;
        pnlBroadcast.Location = new System.Drawing.Point(6, 415);
        pnlBroadcast.Name = "pnlBroadcast";
        pnlBroadcast.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
        pnlBroadcast.Size = new System.Drawing.Size(548, 43);
        pnlBroadcast.TabIndex = 1;
        // 
        // txtBroadcast
        // 
        txtBroadcast.Dock = System.Windows.Forms.DockStyle.Fill;
        txtBroadcast.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtBroadcast.Location = new System.Drawing.Point(0, 6);
        txtBroadcast.Name = "txtBroadcast";
        txtBroadcast.PlaceholderText = "Tüm bağlı istemcilere sistem duyurusu gönder...";
        txtBroadcast.Size = new System.Drawing.Size(423, 25);
        txtBroadcast.TabIndex = 0;
        txtBroadcast.KeyDown += TxtBroadcast_KeyDown;
        // 
        // btnBroadcast
        // 
        btnBroadcast.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
        btnBroadcast.Cursor = System.Windows.Forms.Cursors.Hand;
        btnBroadcast.Dock = System.Windows.Forms.DockStyle.Right;
        btnBroadcast.FlatAppearance.BorderSize = 0;
        btnBroadcast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnBroadcast.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
        btnBroadcast.ForeColor = System.Drawing.Color.White;
        btnBroadcast.Location = new System.Drawing.Point(423, 6);
        btnBroadcast.Name = "btnBroadcast";
        btnBroadcast.Size = new System.Drawing.Size(125, 37);
        btnBroadcast.TabIndex = 1;
        btnBroadcast.Text = "📢 Duyuru Yap";
        btnBroadcast.UseVisualStyleBackColor = false;
        btnBroadcast.Click += BtnBroadcast_Click;
        // 
        // statusStrip
        // 
        statusStrip.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
        statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            statusLabelState,
            statusLabelClients
        });
        statusStrip.Location = new System.Drawing.Point(0, 534);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new System.Drawing.Size(900, 24);
        statusStrip.TabIndex = 2;
        // 
        // statusLabelState
        // 
        statusLabelState.ForeColor = System.Drawing.Color.White;
        statusLabelState.Name = "statusLabelState";
        statusLabelState.Size = new System.Drawing.Size(128, 19);
        statusLabelState.Text = "Durum: Hazır (Beklemede)";
        // 
        // statusLabelClients
        // 
        statusLabelClients.ForeColor = System.Drawing.Color.LightGreen;
        statusLabelClients.Margin = new System.Windows.Forms.Padding(15, 3, 0, 2);
        statusLabelClients.Name = "statusLabelClients";
        statusLabelClients.Size = new System.Drawing.Size(111, 19);
        statusLabelClients.Text = "Bağlı İstemci: 0 kişi";
        // 
        // ServerForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(900, 558);
        Controls.Add(splitContainer);
        Controls.Add(statusStrip);
        Controls.Add(topPanel);
        MinimumSize = new System.Drawing.Size(760, 480);
        Name = "ServerForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "YMH219 - TCP Chat Sunucusu (Server)";
        FormClosing += ServerForm_FormClosing;
        topPanel.ResumeLayout(false);
        topPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numPort).EndInit();
        splitContainer.Panel1.ResumeLayout(false);
        splitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
        splitContainer.ResumeLayout(false);
        grpClients.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
        grpLogs.ResumeLayout(false);
        pnlBroadcast.ResumeLayout(false);
        pnlBroadcast.PerformLayout();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
