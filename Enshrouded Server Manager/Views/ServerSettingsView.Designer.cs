namespace Enshrouded_Server_Manager;

partial class ServerSettingsView
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtIpAddress = new TextBox();
        txtServerName = new TextBox();
        nudGamePort = new NumericUpDown();
        nudQueryPort = new NumericUpDown();
        nudSlotCount = new NumericUpDown();
        lblServername = new Label();
        lblIpAddress = new Label();
        lblGamePort = new Label();
        lblQueryPort = new Label();
        lblMaxPlayers = new Label();
        btnSaveSettings = new Button();
        lblServerMustBeStoppedMessage = new Label();
        chkEnableVoiceChat = new CheckBox();
        chkEnableTextChat = new CheckBox();
        label1 = new Label();
        cbxGameSettingsPreset = new ComboBox();
        ((System.ComponentModel.ISupportInitialize)nudGamePort).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudQueryPort).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudSlotCount).BeginInit();
        SuspendLayout();
        // 
        // txtIpAddress
        // 
        txtIpAddress.BackColor = Color.FromArgb(6, 6, 48);
        txtIpAddress.BorderStyle = BorderStyle.FixedSingle;
        txtIpAddress.ForeColor = SystemColors.Window;
        txtIpAddress.Location = new Point(296, 113);
        txtIpAddress.Name = "txtIpAddress";
        txtIpAddress.Size = new Size(134, 23);
        txtIpAddress.TabIndex = 43;
        // 
        // txtServerName
        // 
        txtServerName.BackColor = Color.FromArgb(6, 6, 48);
        txtServerName.BorderStyle = BorderStyle.FixedSingle;
        txtServerName.ForeColor = SystemColors.Window;
        txtServerName.Location = new Point(296, 84);
        txtServerName.Name = "txtServerName";
        txtServerName.Size = new Size(170, 23);
        txtServerName.TabIndex = 41;
        // 
        // nudGamePort
        // 
        nudGamePort.BackColor = Color.FromArgb(6, 6, 48);
        nudGamePort.BorderStyle = BorderStyle.FixedSingle;
        nudGamePort.ForeColor = SystemColors.Window;
        nudGamePort.Location = new Point(296, 142);
        nudGamePort.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
        nudGamePort.Name = "nudGamePort";
        nudGamePort.Size = new Size(62, 23);
        nudGamePort.TabIndex = 44;
        // 
        // nudQueryPort
        // 
        nudQueryPort.BackColor = Color.FromArgb(6, 6, 48);
        nudQueryPort.BorderStyle = BorderStyle.FixedSingle;
        nudQueryPort.ForeColor = SystemColors.Window;
        nudQueryPort.Location = new Point(296, 171);
        nudQueryPort.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
        nudQueryPort.Name = "nudQueryPort";
        nudQueryPort.Size = new Size(62, 23);
        nudQueryPort.TabIndex = 45;
        // 
        // nudSlotCount
        // 
        nudSlotCount.BackColor = Color.FromArgb(6, 6, 48);
        nudSlotCount.BorderStyle = BorderStyle.FixedSingle;
        nudSlotCount.ForeColor = SystemColors.Window;
        nudSlotCount.Location = new Point(296, 200);
        nudSlotCount.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
        nudSlotCount.Name = "nudSlotCount";
        nudSlotCount.Size = new Size(35, 23);
        nudSlotCount.TabIndex = 46;
        // 
        // lblServername
        // 
        lblServername.AutoSize = true;
        lblServername.ForeColor = SystemColors.ButtonHighlight;
        lblServername.Location = new Point(221, 86);
        lblServername.Name = "lblServername";
        lblServername.Size = new Size(69, 15);
        lblServername.TabIndex = 47;
        lblServername.Text = "Servername";
        // 
        // lblIpAddress
        // 
        lblIpAddress.AutoSize = true;
        lblIpAddress.ForeColor = SystemColors.ButtonHighlight;
        lblIpAddress.Location = new Point(228, 115);
        lblIpAddress.Name = "lblIpAddress";
        lblIpAddress.Size = new Size(62, 15);
        lblIpAddress.TabIndex = 49;
        lblIpAddress.Text = "Ip Address";
        // 
        // lblGamePort
        // 
        lblGamePort.AutoSize = true;
        lblGamePort.ForeColor = SystemColors.ButtonHighlight;
        lblGamePort.Location = new Point(230, 144);
        lblGamePort.Name = "lblGamePort";
        lblGamePort.Size = new Size(60, 15);
        lblGamePort.TabIndex = 50;
        lblGamePort.Text = "GamePort";
        // 
        // lblQueryPort
        // 
        lblQueryPort.AutoSize = true;
        lblQueryPort.ForeColor = SystemColors.ButtonHighlight;
        lblQueryPort.Location = new Point(229, 173);
        lblQueryPort.Name = "lblQueryPort";
        lblQueryPort.Size = new Size(61, 15);
        lblQueryPort.TabIndex = 51;
        lblQueryPort.Text = "QueryPort";
        // 
        // lblMaxPlayers
        // 
        lblMaxPlayers.AutoSize = true;
        lblMaxPlayers.ForeColor = SystemColors.ButtonHighlight;
        lblMaxPlayers.Location = new Point(224, 202);
        lblMaxPlayers.Name = "lblMaxPlayers";
        lblMaxPlayers.Size = new Size(66, 15);
        lblMaxPlayers.TabIndex = 52;
        lblMaxPlayers.Text = "MaxPlayers";
        // 
        // btnSaveSettings
        // 
        btnSaveSettings.Cursor = Cursors.Hand;
        btnSaveSettings.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnSaveSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnSaveSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnSaveSettings.FlatStyle = FlatStyle.Flat;
        btnSaveSettings.ForeColor = Color.FromArgb(0, 255, 185);
        btnSaveSettings.Location = new Point(410, 342);
        btnSaveSettings.Name = "btnSaveSettings";
        btnSaveSettings.Size = new Size(128, 30);
        btnSaveSettings.TabIndex = 53;
        btnSaveSettings.Text = "Save Settings";
        btnSaveSettings.UseCompatibleTextRendering = true;
        btnSaveSettings.UseVisualStyleBackColor = true;
        btnSaveSettings.EnabledChanged += btnSaveSettings_EnabledChanged;
        // 
        // lblServerMustBeStoppedMessage
        // 
        lblServerMustBeStoppedMessage.AutoSize = true;
        lblServerMustBeStoppedMessage.ForeColor = SystemColors.Info;
        lblServerMustBeStoppedMessage.Location = new Point(258, 385);
        lblServerMustBeStoppedMessage.Name = "lblServerMustBeStoppedMessage";
        lblServerMustBeStoppedMessage.Size = new Size(229, 15);
        lblServerMustBeStoppedMessage.TabIndex = 60;
        lblServerMustBeStoppedMessage.Text = "Server must be stopped to update settings\r\n";
        lblServerMustBeStoppedMessage.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // chkEnableVoiceChat
        // 
        chkEnableVoiceChat.AutoSize = true;
        chkEnableVoiceChat.Location = new Point(296, 258);
        chkEnableVoiceChat.Name = "chkEnableVoiceChat";
        chkEnableVoiceChat.Size = new Size(120, 19);
        chkEnableVoiceChat.TabIndex = 61;
        chkEnableVoiceChat.Text = "Enable Voice Chat";
        chkEnableVoiceChat.UseVisualStyleBackColor = true;
        // 
        // chkEnableTextChat
        // 
        chkEnableTextChat.AutoSize = true;
        chkEnableTextChat.Location = new Point(296, 283);
        chkEnableTextChat.Name = "chkEnableTextChat";
        chkEnableTextChat.Size = new Size(113, 19);
        chkEnableTextChat.TabIndex = 62;
        chkEnableTextChat.Text = "Enable Text Chat";
        chkEnableTextChat.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.ForeColor = SystemColors.ButtonHighlight;
        label1.Location = new Point(172, 232);
        label1.Name = "label1";
        label1.Size = new Size(118, 15);
        label1.TabIndex = 64;
        label1.Text = "Game Settings Preset";
        // 
        // cbxGameSettingsPreset
        // 
        cbxGameSettingsPreset.Anchor = AnchorStyles.Top;
        cbxGameSettingsPreset.BackColor = Color.FromArgb(6, 6, 48);
        cbxGameSettingsPreset.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxGameSettingsPreset.FlatStyle = FlatStyle.Flat;
        cbxGameSettingsPreset.ForeColor = SystemColors.Window;
        cbxGameSettingsPreset.FormattingEnabled = true;
        cbxGameSettingsPreset.Location = new Point(296, 229);
        cbxGameSettingsPreset.Name = "cbxGameSettingsPreset";
        cbxGameSettingsPreset.Size = new Size(175, 23);
        cbxGameSettingsPreset.TabIndex = 131;
        // 
        // ServerSettingsView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(cbxGameSettingsPreset);
        Controls.Add(label1);
        Controls.Add(chkEnableTextChat);
        Controls.Add(chkEnableVoiceChat);
        Controls.Add(lblServerMustBeStoppedMessage);
        Controls.Add(txtIpAddress);
        Controls.Add(txtServerName);
        Controls.Add(nudGamePort);
        Controls.Add(nudQueryPort);
        Controls.Add(nudSlotCount);
        Controls.Add(lblServername);
        Controls.Add(lblIpAddress);
        Controls.Add(lblGamePort);
        Controls.Add(lblQueryPort);
        Controls.Add(lblMaxPlayers);
        Controls.Add(btnSaveSettings);
        ForeColor = SystemColors.ButtonHighlight;
        Name = "ServerSettingsView";
        Size = new Size(744, 411);
        ((System.ComponentModel.ISupportInitialize)nudGamePort).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudQueryPort).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudSlotCount).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private TextBox txtIpAddress;
    private TextBox txtServerName;
    private NumericUpDown nudGamePort;
    private NumericUpDown nudQueryPort;
    private NumericUpDown nudSlotCount;
    private Label lblServername;
    private Label lblIpAddress;
    private Label lblGamePort;
    private Label lblQueryPort;
    private Label lblMaxPlayers;
    private Button btnSaveSettings;
    private Label lblServerMustBeStoppedMessage;
    private CheckBox chkEnableVoiceChat;
    private CheckBox chkEnableTextChat;
    private Label label1;
    private ComboBox cbxGameSettingsPreset;
}
