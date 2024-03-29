﻿namespace Enshrouded_Server_Manager;

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
        btnShowPassword = new Button();
        txtIpAddress = new TextBox();
        txtServerName = new TextBox();
        txtServerPassword = new TextBox();
        nudGamePort = new NumericUpDown();
        nudQueryPort = new NumericUpDown();
        nudSlotCount = new NumericUpDown();
        lblServername = new Label();
        lblPassword = new Label();
        lblIpAddress = new Label();
        lblGamePort = new Label();
        lblQueryPort = new Label();
        lblMaxPlayers = new Label();
        btnSaveSettings = new Button();
        lblServerMustBeStoppedMessage = new Label();
        ((System.ComponentModel.ISupportInitialize)nudGamePort).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudQueryPort).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudSlotCount).BeginInit();
        SuspendLayout();
        // 
        // btnShowPassword
        // 
        btnShowPassword.Cursor = Cursors.Hand;
        btnShowPassword.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnShowPassword.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnShowPassword.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnShowPassword.FlatStyle = FlatStyle.Flat;
        btnShowPassword.ForeColor = SystemColors.Control;
        btnShowPassword.Location = new Point(472, 113);
        btnShowPassword.Name = "btnShowPassword";
        btnShowPassword.Size = new Size(48, 23);
        btnShowPassword.TabIndex = 54;
        btnShowPassword.Text = "Show";
        btnShowPassword.UseCompatibleTextRendering = true;
        btnShowPassword.UseVisualStyleBackColor = true;
        // 
        // txtIpAddress
        // 
        txtIpAddress.BackColor = Color.FromArgb(6, 6, 48);
        txtIpAddress.BorderStyle = BorderStyle.FixedSingle;
        txtIpAddress.ForeColor = SystemColors.Window;
        txtIpAddress.Location = new Point(296, 142);
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
        // txtServerPassword
        // 
        txtServerPassword.BackColor = Color.FromArgb(6, 6, 48);
        txtServerPassword.BorderStyle = BorderStyle.FixedSingle;
        txtServerPassword.ForeColor = SystemColors.Window;
        txtServerPassword.Location = new Point(296, 113);
        txtServerPassword.Name = "txtServerPassword";
        txtServerPassword.PasswordChar = '*';
        txtServerPassword.Size = new Size(170, 23);
        txtServerPassword.TabIndex = 42;
        // 
        // nudGamePort
        // 
        nudGamePort.BackColor = Color.FromArgb(6, 6, 48);
        nudGamePort.BorderStyle = BorderStyle.FixedSingle;
        nudGamePort.ForeColor = SystemColors.Window;
        nudGamePort.Location = new Point(296, 172);
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
        nudQueryPort.Location = new Point(296, 201);
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
        nudSlotCount.Location = new Point(296, 230);
        nudSlotCount.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
        nudSlotCount.Name = "nudSlotCount";
        nudSlotCount.Size = new Size(35, 23);
        nudSlotCount.TabIndex = 46;
        // 
        // lblServername
        // 
        lblServername.AutoSize = true;
        lblServername.ForeColor = SystemColors.ButtonHighlight;
        lblServername.Location = new Point(225, 87);
        lblServername.Name = "lblServername";
        lblServername.Size = new Size(69, 15);
        lblServername.TabIndex = 47;
        lblServername.Text = "Servername";
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.ForeColor = SystemColors.ButtonHighlight;
        lblPassword.Location = new Point(237, 116);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(57, 15);
        lblPassword.TabIndex = 48;
        lblPassword.Text = "Password";
        // 
        // lblIpAddress
        // 
        lblIpAddress.AutoSize = true;
        lblIpAddress.ForeColor = SystemColors.ButtonHighlight;
        lblIpAddress.Location = new Point(232, 145);
        lblIpAddress.Name = "lblIpAddress";
        lblIpAddress.Size = new Size(62, 15);
        lblIpAddress.TabIndex = 49;
        lblIpAddress.Text = "Ip Address";
        // 
        // lblGamePort
        // 
        lblGamePort.AutoSize = true;
        lblGamePort.ForeColor = SystemColors.ButtonHighlight;
        lblGamePort.Location = new Point(234, 174);
        lblGamePort.Name = "lblGamePort";
        lblGamePort.Size = new Size(60, 15);
        lblGamePort.TabIndex = 50;
        lblGamePort.Text = "GamePort";
        // 
        // lblQueryPort
        // 
        lblQueryPort.AutoSize = true;
        lblQueryPort.ForeColor = SystemColors.ButtonHighlight;
        lblQueryPort.Location = new Point(233, 203);
        lblQueryPort.Name = "lblQueryPort";
        lblQueryPort.Size = new Size(61, 15);
        lblQueryPort.TabIndex = 51;
        lblQueryPort.Text = "QueryPort";
        // 
        // lblMaxPlayers
        // 
        lblMaxPlayers.AutoSize = true;
        lblMaxPlayers.ForeColor = SystemColors.ButtonHighlight;
        lblMaxPlayers.Location = new Point(227, 232);
        lblMaxPlayers.Name = "lblMaxPlayers";
        lblMaxPlayers.Size = new Size(67, 15);
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
        // ServerSettingsView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(lblServerMustBeStoppedMessage);
        Controls.Add(btnShowPassword);
        Controls.Add(txtIpAddress);
        Controls.Add(txtServerName);
        Controls.Add(txtServerPassword);
        Controls.Add(nudGamePort);
        Controls.Add(nudQueryPort);
        Controls.Add(nudSlotCount);
        Controls.Add(lblServername);
        Controls.Add(lblPassword);
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

    private Button btnShowPassword;
    private TextBox txtIpAddress;
    private TextBox txtServerName;
    private TextBox txtServerPassword;
    private NumericUpDown nudGamePort;
    private NumericUpDown nudQueryPort;
    private NumericUpDown nudSlotCount;
    private Label lblServername;
    private Label lblPassword;
    private Label lblIpAddress;
    private Label lblGamePort;
    private Label lblQueryPort;
    private Label lblMaxPlayers;
    private Button btnSaveSettings;
    private Label lblServerMustBeStoppedMessage;
}
