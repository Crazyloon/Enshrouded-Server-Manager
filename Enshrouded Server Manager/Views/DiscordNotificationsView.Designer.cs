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
        txtBackupMsg = new TextBox();
        txtServerUpdatingMsg = new TextBox();
        txtServerStoppedMsg = new TextBox();
        txtServerOnlineMsg = new TextBox();
        chkEmbed = new CheckBox();
        chkNotifiBackup = new CheckBox();
        chkNotifiServerUpdating = new CheckBox();
        chkNotifiServerStopped = new CheckBox();
        chkNotifiServerStarted = new CheckBox();
        btnTestDiscord = new Button();
        lblDiscordWebhookUrl = new Label();
        btnSaveDiscordSettings = new Button();
        txtDiscordWebhookUrl = new TextBox();
        chkEnableDiscord = new CheckBox();
        gbxDiscordNotificationSettings.SuspendLayout();
        SuspendLayout();
        // 
        // lblDiscordChanges
        // 
        lblDiscordChanges.AutoSize = true;
        lblDiscordChanges.ForeColor = SystemColors.Info;
        lblDiscordChanges.Location = new Point(100, 350);
        lblDiscordChanges.Name = "lblDiscordChanges";
        lblDiscordChanges.Size = new Size(258, 15);
        lblDiscordChanges.TabIndex = 83;
        lblDiscordChanges.Text = "Changes will take effect on the next server start ";
        // 
        // gbxDiscordNotificationSettings
        // 
        gbxDiscordNotificationSettings.Controls.Add(txtBackupMsg);
        gbxDiscordNotificationSettings.Controls.Add(txtServerUpdatingMsg);
        gbxDiscordNotificationSettings.Controls.Add(txtServerStoppedMsg);
        gbxDiscordNotificationSettings.Controls.Add(txtServerOnlineMsg);
        gbxDiscordNotificationSettings.Controls.Add(chkEmbed);
        gbxDiscordNotificationSettings.Controls.Add(chkNotifiBackup);
        gbxDiscordNotificationSettings.Controls.Add(chkNotifiServerUpdating);
        gbxDiscordNotificationSettings.Controls.Add(chkNotifiServerStopped);
        gbxDiscordNotificationSettings.Controls.Add(chkNotifiServerStarted);
        gbxDiscordNotificationSettings.ForeColor = SystemColors.ControlLight;
        gbxDiscordNotificationSettings.Location = new Point(69, 50);
        gbxDiscordNotificationSettings.Name = "gbxDiscordNotificationSettings";
        gbxDiscordNotificationSettings.Size = new Size(320, 170);
        gbxDiscordNotificationSettings.TabIndex = 82;
        gbxDiscordNotificationSettings.TabStop = false;
        gbxDiscordNotificationSettings.Text = "Notifications";
        // 
        // txtBackupMsg
        // 
        txtBackupMsg.BackColor = Color.FromArgb(6, 6, 48);
        txtBackupMsg.BorderStyle = BorderStyle.FixedSingle;
        txtBackupMsg.ForeColor = SystemColors.Window;
        txtBackupMsg.Location = new Point(127, 134);
        txtBackupMsg.Name = "txtBackupMsg";
        txtBackupMsg.Size = new Size(184, 23);
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
        txtServerUpdatingMsg.Size = new Size(184, 23);
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
        txtServerStoppedMsg.Size = new Size(184, 23);
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
        txtServerOnlineMsg.Size = new Size(184, 23);
        txtServerOnlineMsg.TabIndex = 68;
        txtServerOnlineMsg.Text = "Online!";
        // 
        // chkEmbed
        // 
        chkEmbed.AutoSize = true;
        chkEmbed.Location = new Point(12, 20);
        chkEmbed.Name = "chkEmbed";
        chkEmbed.Size = new Size(117, 19);
        chkEmbed.TabIndex = 67;
        chkEmbed.Text = "Embed Messages";
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
        btnTestDiscord.Location = new Point(237, 301);
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
        lblDiscordWebhookUrl.Location = new Point(165, 248);
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
        btnSaveDiscordSettings.Location = new Point(93, 301);
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
        txtDiscordWebhookUrl.Location = new Point(69, 268);
        txtDiscordWebhookUrl.Name = "txtDiscordWebhookUrl";
        txtDiscordWebhookUrl.Size = new Size(320, 23);
        txtDiscordWebhookUrl.TabIndex = 78;
        // 
        // chkEnableDiscord
        // 
        chkEnableDiscord.AutoSize = true;
        chkEnableDiscord.Location = new Point(142, 20);
        chkEnableDiscord.Name = "chkEnableDiscord";
        chkEnableDiscord.Size = new Size(175, 19);
        chkEnableDiscord.TabIndex = 77;
        chkEnableDiscord.Text = "Enable Discord Notifications";
        chkEnableDiscord.UseVisualStyleBackColor = true;
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
        Controls.Add(chkEnableDiscord);
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
}
