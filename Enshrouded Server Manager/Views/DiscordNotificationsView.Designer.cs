namespace Enshrouded_Server_Manager;

partial class DiscordNotificationsView
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
        lblDiscordChanges = new Label();
        gbxDiscordNotificationSettings = new GroupBox();
        chkImminent = new CheckBox();
        chkSoon = new CheckBox();
        chkShort = new CheckBox();
        chkMed = new CheckBox();
        chkLong = new CheckBox();
        txtRestartMsg = new TextBox();
        chkNotifyRestart = new CheckBox();
        txtBackupMsg = new TextBox();
        txtServerUpdatingMsg = new TextBox();
        txtServerStoppedMsg = new TextBox();
        txtServerOnlineMsg = new TextBox();
        chkEnableDiscord = new CheckBox();
        chkEmbed = new CheckBox();
        chkNotifiBackup = new CheckBox();
        chkNotifiServerUpdating = new CheckBox();
        chkNotifiServerStopped = new CheckBox();
        chkNotifiServerStarted = new CheckBox();
        btnTestDiscord = new Button();
        lblDiscordWebhookUrl = new Label();
        btnSaveDiscordSettings = new Button();
        txtDiscordWebhookUrl = new TextBox();
        txtBackupRestoreMsg = new TextBox();
        chkNotifiBackupRestore = new CheckBox();
        gbxDiscordNotificationSettings.SuspendLayout();
        SuspendLayout();
        // 
        // lblDiscordChanges
        // 
        lblDiscordChanges.AutoSize = true;
        lblDiscordChanges.ForeColor = SystemColors.Info;
        lblDiscordChanges.Location = new Point(100, 360);
        lblDiscordChanges.Name = "lblDiscordChanges";
        lblDiscordChanges.Size = new Size(0, 15);
        lblDiscordChanges.TabIndex = 83;
        // 
        // gbxDiscordNotificationSettings
        // 
        gbxDiscordNotificationSettings.Controls.Add(txtBackupRestoreMsg);
        gbxDiscordNotificationSettings.Controls.Add(chkNotifiBackupRestore);
        gbxDiscordNotificationSettings.Controls.Add(chkImminent);
        gbxDiscordNotificationSettings.Controls.Add(chkSoon);
        gbxDiscordNotificationSettings.Controls.Add(chkShort);
        gbxDiscordNotificationSettings.Controls.Add(chkMed);
        gbxDiscordNotificationSettings.Controls.Add(chkLong);
        gbxDiscordNotificationSettings.Controls.Add(txtRestartMsg);
        gbxDiscordNotificationSettings.Controls.Add(chkNotifyRestart);
        gbxDiscordNotificationSettings.Controls.Add(txtBackupMsg);
        gbxDiscordNotificationSettings.Controls.Add(txtServerUpdatingMsg);
        gbxDiscordNotificationSettings.Controls.Add(txtServerStoppedMsg);
        gbxDiscordNotificationSettings.Controls.Add(txtServerOnlineMsg);
        gbxDiscordNotificationSettings.Controls.Add(chkEnableDiscord);
        gbxDiscordNotificationSettings.Controls.Add(chkEmbed);
        gbxDiscordNotificationSettings.Controls.Add(chkNotifiBackup);
        gbxDiscordNotificationSettings.Controls.Add(chkNotifiServerUpdating);
        gbxDiscordNotificationSettings.Controls.Add(chkNotifiServerStopped);
        gbxDiscordNotificationSettings.Controls.Add(chkNotifiServerStarted);
        gbxDiscordNotificationSettings.ForeColor = SystemColors.ControlLight;
        gbxDiscordNotificationSettings.Location = new Point(37, 5);
        gbxDiscordNotificationSettings.Name = "gbxDiscordNotificationSettings";
        gbxDiscordNotificationSettings.Size = new Size(384, 244);
        gbxDiscordNotificationSettings.TabIndex = 82;
        gbxDiscordNotificationSettings.TabStop = false;
        gbxDiscordNotificationSettings.Text = "Notifications";
        // 
        // chkImminent
        // 
        chkImminent.AutoSize = true;
        chkImminent.Location = new Point(280, 220);
        chkImminent.Name = "chkImminent";
        chkImminent.RightToLeft = RightToLeft.No;
        chkImminent.Size = new Size(53, 19);
        chkImminent.TabIndex = 82;
        chkImminent.Text = "5min";
        chkImminent.UseVisualStyleBackColor = true;
        // 
        // chkSoon
        // 
        chkSoon.AutoSize = true;
        chkSoon.Location = new Point(215, 220);
        chkSoon.Name = "chkSoon";
        chkSoon.RightToLeft = RightToLeft.No;
        chkSoon.Size = new Size(59, 19);
        chkSoon.TabIndex = 81;
        chkSoon.Text = "10min";
        chkSoon.UseVisualStyleBackColor = true;
        // 
        // chkShort
        // 
        chkShort.AutoSize = true;
        chkShort.Location = new Point(150, 220);
        chkShort.Name = "chkShort";
        chkShort.RightToLeft = RightToLeft.No;
        chkShort.Size = new Size(59, 19);
        chkShort.TabIndex = 80;
        chkShort.Text = "30min";
        chkShort.UseVisualStyleBackColor = true;
        // 
        // chkMed
        // 
        chkMed.AutoSize = true;
        chkMed.Location = new Point(101, 220);
        chkMed.Name = "chkMed";
        chkMed.RightToLeft = RightToLeft.No;
        chkMed.Size = new Size(43, 19);
        chkMed.TabIndex = 79;
        chkMed.Text = "1hr";
        chkMed.UseVisualStyleBackColor = true;
        // 
        // chkLong
        // 
        chkLong.AutoSize = true;
        chkLong.Location = new Point(52, 220);
        chkLong.Name = "chkLong";
        chkLong.RightToLeft = RightToLeft.No;
        chkLong.Size = new Size(43, 19);
        chkLong.TabIndex = 78;
        chkLong.Text = "2hr";
        chkLong.UseVisualStyleBackColor = true;
        // 
        // txtRestartMsg
        // 
        txtRestartMsg.BackColor = Color.FromArgb(6, 6, 48);
        txtRestartMsg.BorderStyle = BorderStyle.FixedSingle;
        txtRestartMsg.ForeColor = SystemColors.Window;
        txtRestartMsg.Location = new Point(127, 192);
        txtRestartMsg.Name = "txtRestartMsg";
        txtRestartMsg.Size = new Size(245, 23);
        txtRestartMsg.TabIndex = 73;
        txtRestartMsg.Text = "Server Reset In {TIME_LEFT}";
        // 
        // chkNotifyRestart
        // 
        chkNotifyRestart.AutoSize = true;
        chkNotifyRestart.Location = new Point(12, 195);
        chkNotifyRestart.Name = "chkNotifyRestart";
        chkNotifyRestart.Size = new Size(97, 19);
        chkNotifyRestart.TabIndex = 72;
        chkNotifyRestart.Text = "Server Restart";
        chkNotifyRestart.UseVisualStyleBackColor = true;
        // 
        // txtBackupMsg
        // 
        txtBackupMsg.BackColor = Color.FromArgb(6, 6, 48);
        txtBackupMsg.BorderStyle = BorderStyle.FixedSingle;
        txtBackupMsg.ForeColor = SystemColors.Window;
        txtBackupMsg.Location = new Point(127, 134);
        txtBackupMsg.Name = "txtBackupMsg";
        txtBackupMsg.Size = new Size(245, 23);
        txtBackupMsg.TabIndex = 71;
        txtBackupMsg.Text = "Backup created!";
        // 
        // txtServerUpdatingMsg
        // 
        txtServerUpdatingMsg.BackColor = Color.FromArgb(6, 6, 48);
        txtServerUpdatingMsg.BorderStyle = BorderStyle.FixedSingle;
        txtServerUpdatingMsg.ForeColor = SystemColors.Window;
        txtServerUpdatingMsg.Location = new Point(127, 105);
        txtServerUpdatingMsg.Name = "txtServerUpdatingMsg";
        txtServerUpdatingMsg.Size = new Size(245, 23);
        txtServerUpdatingMsg.TabIndex = 70;
        txtServerUpdatingMsg.Text = "Updating...";
        // 
        // txtServerStoppedMsg
        // 
        txtServerStoppedMsg.BackColor = Color.FromArgb(6, 6, 48);
        txtServerStoppedMsg.BorderStyle = BorderStyle.FixedSingle;
        txtServerStoppedMsg.ForeColor = SystemColors.Window;
        txtServerStoppedMsg.Location = new Point(127, 76);
        txtServerStoppedMsg.Name = "txtServerStoppedMsg";
        txtServerStoppedMsg.Size = new Size(245, 23);
        txtServerStoppedMsg.TabIndex = 69;
        txtServerStoppedMsg.Text = "Offline!";
        // 
        // txtServerOnlineMsg
        // 
        txtServerOnlineMsg.BackColor = Color.FromArgb(6, 6, 48);
        txtServerOnlineMsg.BorderStyle = BorderStyle.FixedSingle;
        txtServerOnlineMsg.ForeColor = SystemColors.Window;
        txtServerOnlineMsg.Location = new Point(127, 47);
        txtServerOnlineMsg.Name = "txtServerOnlineMsg";
        txtServerOnlineMsg.Size = new Size(245, 23);
        txtServerOnlineMsg.TabIndex = 68;
        txtServerOnlineMsg.Text = "Online!";
        // 
        // chkEnableDiscord
        // 
        chkEnableDiscord.AutoSize = true;
        chkEnableDiscord.Location = new Point(12, 22);
        chkEnableDiscord.Name = "chkEnableDiscord";
        chkEnableDiscord.Size = new Size(175, 19);
        chkEnableDiscord.TabIndex = 77;
        chkEnableDiscord.Text = "Enable Discord Notifications";
        chkEnableDiscord.UseVisualStyleBackColor = true;
        // 
        // chkEmbed
        // 
        chkEmbed.AutoSize = true;
        chkEmbed.Location = new Point(233, 22);
        chkEmbed.Name = "chkEmbed";
        chkEmbed.Size = new Size(139, 19);
        chkEmbed.TabIndex = 67;
        chkEmbed.Text = "Use Embed Messages";
        chkEmbed.UseVisualStyleBackColor = true;
        // 
        // chkNotifiBackup
        // 
        chkNotifiBackup.AutoSize = true;
        chkNotifiBackup.Location = new Point(12, 137);
        chkNotifiBackup.Name = "chkNotifiBackup";
        chkNotifiBackup.Size = new Size(109, 19);
        chkNotifiBackup.TabIndex = 64;
        chkNotifiBackup.Text = "Backup Created";
        chkNotifiBackup.UseVisualStyleBackColor = true;
        // 
        // chkNotifiServerUpdating
        // 
        chkNotifiServerUpdating.AutoSize = true;
        chkNotifiServerUpdating.Location = new Point(12, 108);
        chkNotifiServerUpdating.Name = "chkNotifiServerUpdating";
        chkNotifiServerUpdating.Size = new Size(110, 19);
        chkNotifiServerUpdating.TabIndex = 63;
        chkNotifiServerUpdating.Text = "Server Updating";
        chkNotifiServerUpdating.UseVisualStyleBackColor = true;
        // 
        // chkNotifiServerStopped
        // 
        chkNotifiServerStopped.AutoSize = true;
        chkNotifiServerStopped.Location = new Point(12, 78);
        chkNotifiServerStopped.Name = "chkNotifiServerStopped";
        chkNotifiServerStopped.Size = new Size(105, 19);
        chkNotifiServerStopped.TabIndex = 62;
        chkNotifiServerStopped.Text = "Server Stopped";
        chkNotifiServerStopped.UseVisualStyleBackColor = true;
        // 
        // chkNotifiServerStarted
        // 
        chkNotifiServerStarted.AutoSize = true;
        chkNotifiServerStarted.Location = new Point(12, 49);
        chkNotifiServerStarted.Name = "chkNotifiServerStarted";
        chkNotifiServerStarted.Size = new Size(98, 19);
        chkNotifiServerStarted.TabIndex = 61;
        chkNotifiServerStarted.Text = "Server Started";
        chkNotifiServerStarted.UseVisualStyleBackColor = true;
        // 
        // btnTestDiscord
        // 
        btnTestDiscord.Cursor = Cursors.Hand;
        btnTestDiscord.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnTestDiscord.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnTestDiscord.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnTestDiscord.FlatStyle = FlatStyle.Flat;
        btnTestDiscord.ForeColor = SystemColors.Control;
        btnTestDiscord.Location = new Point(68, 315);
        btnTestDiscord.Name = "btnTestDiscord";
        btnTestDiscord.Size = new Size(128, 30);
        btnTestDiscord.TabIndex = 81;
        btnTestDiscord.Text = "Test Discord Msg";
        btnTestDiscord.UseCompatibleTextRendering = true;
        btnTestDiscord.UseVisualStyleBackColor = true;
        // 
        // lblDiscordWebhookUrl
        // 
        lblDiscordWebhookUrl.AutoSize = true;
        lblDiscordWebhookUrl.Location = new Point(165, 266);
        lblDiscordWebhookUrl.Name = "lblDiscordWebhookUrl";
        lblDiscordWebhookUrl.Size = new Size(128, 15);
        lblDiscordWebhookUrl.TabIndex = 80;
        lblDiscordWebhookUrl.Text = "Your Discord Webhook";
        // 
        // btnSaveDiscordSettings
        // 
        btnSaveDiscordSettings.Cursor = Cursors.Hand;
        btnSaveDiscordSettings.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnSaveDiscordSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnSaveDiscordSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnSaveDiscordSettings.FlatStyle = FlatStyle.Flat;
        btnSaveDiscordSettings.ForeColor = Color.FromArgb(0, 255, 185);
        btnSaveDiscordSettings.Location = new Point(263, 315);
        btnSaveDiscordSettings.Name = "btnSaveDiscordSettings";
        btnSaveDiscordSettings.Size = new Size(128, 30);
        btnSaveDiscordSettings.TabIndex = 79;
        btnSaveDiscordSettings.Text = "Save Changes";
        btnSaveDiscordSettings.UseCompatibleTextRendering = true;
        btnSaveDiscordSettings.UseVisualStyleBackColor = true;
        btnSaveDiscordSettings.EnabledChanged += btnSaveDiscordSettings_EnabledChanged;
        // 
        // txtDiscordWebhookUrl
        // 
        txtDiscordWebhookUrl.BackColor = Color.FromArgb(6, 6, 48);
        txtDiscordWebhookUrl.BorderStyle = BorderStyle.FixedSingle;
        txtDiscordWebhookUrl.ForeColor = SystemColors.Window;
        txtDiscordWebhookUrl.Location = new Point(68, 286);
        txtDiscordWebhookUrl.Name = "txtDiscordWebhookUrl";
        txtDiscordWebhookUrl.Size = new Size(323, 23);
        txtDiscordWebhookUrl.TabIndex = 78;
        // 
        // txtBackupRestoreMsg
        // 
        txtBackupRestoreMsg.BackColor = Color.FromArgb(6, 6, 48);
        txtBackupRestoreMsg.BorderStyle = BorderStyle.FixedSingle;
        txtBackupRestoreMsg.ForeColor = SystemColors.Window;
        txtBackupRestoreMsg.Location = new Point(127, 163);
        txtBackupRestoreMsg.Name = "txtBackupRestoreMsg";
        txtBackupRestoreMsg.Size = new Size(245, 23);
        txtBackupRestoreMsg.TabIndex = 84;
        txtBackupRestoreMsg.Text = "Backup restored!";
        // 
        // chkNotifiBackupRestore
        // 
        chkNotifiBackupRestore.AutoSize = true;
        chkNotifiBackupRestore.Location = new Point(12, 166);
        chkNotifiBackupRestore.Name = "chkNotifiBackupRestore";
        chkNotifiBackupRestore.Size = new Size(114, 19);
        chkNotifiBackupRestore.TabIndex = 83;
        chkNotifiBackupRestore.Text = "Backup Restored";
        chkNotifiBackupRestore.UseVisualStyleBackColor = true;
        // 
        // DiscordNotificationsView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(lblDiscordChanges);
        Controls.Add(gbxDiscordNotificationSettings);
        Controls.Add(btnTestDiscord);
        Controls.Add(lblDiscordWebhookUrl);
        Controls.Add(btnSaveDiscordSettings);
        Controls.Add(txtDiscordWebhookUrl);
        ForeColor = SystemColors.ButtonHighlight;
        Name = "DiscordNotificationsView";
        Size = new Size(459, 384);
        gbxDiscordNotificationSettings.ResumeLayout(false);
        gbxDiscordNotificationSettings.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblDiscordChanges;
    private GroupBox gbxDiscordNotificationSettings;
    private TextBox txtBackupMsg;
    private TextBox txtServerUpdatingMsg;
    private TextBox txtServerStoppedMsg;
    private TextBox txtServerOnlineMsg;
    private CheckBox chkEmbed;
    private CheckBox chkNotifiBackup;
    private CheckBox chkNotifiServerUpdating;
    private CheckBox chkNotifiServerStopped;
    private CheckBox chkNotifiServerStarted;
    private Button btnTestDiscord;
    private Label lblDiscordWebhookUrl;
    private Button btnSaveDiscordSettings;
    private TextBox txtDiscordWebhookUrl;
    private CheckBox chkEnableDiscord;
    private TextBox txtRestartMsg;
    private CheckBox chkNotifyRestart;
    private CheckBox chkSoon;
    private CheckBox chkShort;
    private CheckBox chkMed;
    private CheckBox chkLong;
    private CheckBox chkImminent;
    private TextBox txtBackupRestoreMsg;
    private CheckBox chkNotifiBackupRestore;
}
