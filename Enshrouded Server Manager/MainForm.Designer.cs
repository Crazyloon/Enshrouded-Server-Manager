using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager;

partial class MainForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        pbxFormHeader = new PictureBox();
        lblTitle = new Label();
        lblMinimizeTrayButton = new Label();
        lblCloseButton = new Label();
        pbxLeftBorder = new PictureBox();
        pbxInnerLeftBorder = new PictureBox();
        pbxRightBorder = new PictureBox();
        pbxInnerRightBorder = new PictureBox();
        pbxBottomBorder = new PictureBox();
        pnlLeftPanel = new Panel();
        adminPanelView = new AdminPanelView();
        pnlRightPanel = new Panel();
        manageProfilesView = new ManageProfilesView();
        profileSelectorView = new ProfileSelectorView();
        pnlInfoPanel = new Panel();
        infoPanelView = new InfoPanelView();
        creditsPanelView = new CreditsPanelView();
        tabsServerTabs = new TabControl();
        tabServerSettings = new TabPage();
        serverSettingsView = new ServerSettingsView();
        tabAutoBackup = new TabPage();
        autoBackupView = new AutoBackupView();
        tabBackupRestore = new TabPage();
        restoreBackupView = new RestoreBackupView();
        tabScheduleRestarts = new TabPage();
        scheduleRestartsView = new ScheduleRestartsView();
        tabDiscord = new TabPage();
        discordNotificationsView = new DiscordNotificationsView();
        pnlBottomBorder = new Panel();
        btnOpenCredits = new Label();
        lblVersion = new Label();
        pnlTopBorder = new Panel();
        ((System.ComponentModel.ISupportInitialize)pbxFormHeader).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbxLeftBorder).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbxInnerLeftBorder).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbxRightBorder).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbxInnerRightBorder).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbxBottomBorder).BeginInit();
        pnlLeftPanel.SuspendLayout();
        pnlRightPanel.SuspendLayout();
        pnlInfoPanel.SuspendLayout();
        tabsServerTabs.SuspendLayout();
        tabServerSettings.SuspendLayout();
        tabAutoBackup.SuspendLayout();
        tabBackupRestore.SuspendLayout();
        tabScheduleRestarts.SuspendLayout();
        tabDiscord.SuspendLayout();
        pnlBottomBorder.SuspendLayout();
        pnlTopBorder.SuspendLayout();
        SuspendLayout();
        // 
        // pbxFormHeader
        // 
        pbxFormHeader.BackColor = Color.FromArgb(64, 64, 64);
        pbxFormHeader.Dock = DockStyle.Top;
        pbxFormHeader.Location = new Point(0, 0);
        pbxFormHeader.Margin = new Padding(0);
        pbxFormHeader.Name = "pbxFormHeader";
        pbxFormHeader.Size = new Size(1187, 40);
        pbxFormHeader.TabIndex = 23;
        pbxFormHeader.TabStop = false;
        pbxFormHeader.MouseDown += pbxFormHeader_MouseDown;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.BackColor = Color.FromArgb(64, 64, 64);
        lblTitle.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
        lblTitle.ForeColor = SystemColors.Control;
        lblTitle.Location = new Point(6, 5);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(414, 32);
        lblTitle.TabIndex = 25;
        lblTitle.Text = "ESM - Enshrouded Server Manager";
        lblTitle.MouseDown += pbxFormHeader_MouseDown;
        // 
        // lblMinimizeTrayButton
        // 
        lblMinimizeTrayButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblMinimizeTrayButton.AutoSize = true;
        lblMinimizeTrayButton.BackColor = Color.FromArgb(64, 64, 64);
        lblMinimizeTrayButton.Cursor = Cursors.Hand;
        lblMinimizeTrayButton.Font = new Font("Malgun Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblMinimizeTrayButton.ForeColor = Color.FromArgb(0, 255, 185);
        lblMinimizeTrayButton.Location = new Point(1131, 6);
        lblMinimizeTrayButton.Name = "lblMinimizeTrayButton";
        lblMinimizeTrayButton.Size = new Size(17, 21);
        lblMinimizeTrayButton.TabIndex = 30;
        lblMinimizeTrayButton.Text = "_";
        lblMinimizeTrayButton.TextAlign = ContentAlignment.MiddleCenter;
        lblMinimizeTrayButton.Click += lblMinimizeButton_Click;
        // 
        // lblCloseButton
        // 
        lblCloseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblCloseButton.AutoSize = true;
        lblCloseButton.BackColor = Color.FromArgb(64, 64, 64);
        lblCloseButton.Cursor = Cursors.Hand;
        lblCloseButton.Font = new Font("Malgun Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblCloseButton.ForeColor = Color.FromArgb(0, 255, 185);
        lblCloseButton.Location = new Point(1159, 9);
        lblCloseButton.Name = "lblCloseButton";
        lblCloseButton.Size = new Size(18, 19);
        lblCloseButton.TabIndex = 29;
        lblCloseButton.Text = "X";
        lblCloseButton.TextAlign = ContentAlignment.MiddleCenter;
        lblCloseButton.Click += lblCloseButton_Click;
        // 
        // pbxLeftBorder
        // 
        pbxLeftBorder.BackColor = Color.FromArgb(64, 64, 64);
        pbxLeftBorder.Dock = DockStyle.Left;
        pbxLeftBorder.Location = new Point(0, 0);
        pbxLeftBorder.Name = "pbxLeftBorder";
        pbxLeftBorder.Size = new Size(10, 484);
        pbxLeftBorder.TabIndex = 31;
        pbxLeftBorder.TabStop = false;
        // 
        // pbxInnerLeftBorder
        // 
        pbxInnerLeftBorder.BackColor = Color.FromArgb(64, 64, 64);
        pbxInnerLeftBorder.Dock = DockStyle.Right;
        pbxInnerLeftBorder.Location = new Point(180, 0);
        pbxInnerLeftBorder.Name = "pbxInnerLeftBorder";
        pbxInnerLeftBorder.Size = new Size(10, 484);
        pbxInnerLeftBorder.TabIndex = 38;
        pbxInnerLeftBorder.TabStop = false;
        // 
        // pbxRightBorder
        // 
        pbxRightBorder.BackColor = Color.FromArgb(64, 64, 64);
        pbxRightBorder.Dock = DockStyle.Right;
        pbxRightBorder.Location = new Point(237, 0);
        pbxRightBorder.Name = "pbxRightBorder";
        pbxRightBorder.Size = new Size(10, 484);
        pbxRightBorder.TabIndex = 39;
        pbxRightBorder.TabStop = false;
        // 
        // pbxInnerRightBorder
        // 
        pbxInnerRightBorder.BackColor = Color.FromArgb(64, 64, 64);
        pbxInnerRightBorder.Dock = DockStyle.Left;
        pbxInnerRightBorder.Location = new Point(0, 0);
        pbxInnerRightBorder.Name = "pbxInnerRightBorder";
        pbxInnerRightBorder.Size = new Size(10, 484);
        pbxInnerRightBorder.TabIndex = 41;
        pbxInnerRightBorder.TabStop = false;
        // 
        // pbxBottomBorder
        // 
        pbxBottomBorder.BackColor = Color.FromArgb(64, 64, 64);
        pbxBottomBorder.Dock = DockStyle.Bottom;
        pbxBottomBorder.Location = new Point(0, 0);
        pbxBottomBorder.Name = "pbxBottomBorder";
        pbxBottomBorder.Size = new Size(1187, 21);
        pbxBottomBorder.TabIndex = 42;
        pbxBottomBorder.TabStop = false;
        // 
        // pnlLeftPanel
        // 
        pnlLeftPanel.Controls.Add(adminPanelView);
        pnlLeftPanel.Controls.Add(pbxInnerLeftBorder);
        pnlLeftPanel.Controls.Add(pbxLeftBorder);
        pnlLeftPanel.Dock = DockStyle.Left;
        pnlLeftPanel.Location = new Point(0, 40);
        pnlLeftPanel.Name = "pnlLeftPanel";
        pnlLeftPanel.Size = new Size(190, 484);
        pnlLeftPanel.TabIndex = 49;
        // 
        // adminPanelView
        // 
        adminPanelView.BackColor = Color.FromArgb(0, 0, 18);
        adminPanelView.Dock = DockStyle.Fill;
        adminPanelView.InstallServerButtonEnabled = true;
        adminPanelView.InstallServerButtonVisible = false;
        adminPanelView.InstallSteamCMDButtonEnabled = true;
        adminPanelView.InstallSteamCMDButtonVisible = true;
        adminPanelView.Location = new Point(10, 0);
        adminPanelView.Name = "adminPanelView";
        adminPanelView.OpenBackupFolderButtonEnabled = true;
        adminPanelView.OpenBackupFolderButtonVisible = true;
        adminPanelView.OpenLogFolderButtonEnabled = true;
        adminPanelView.OpenLogFolderButtonVisible = true;
        adminPanelView.OpenSavegameFolderButtonEnabled = true;
        adminPanelView.OpenSavegameFolderButtonVisible = true;
        adminPanelView.SaveBackupButtonEnabled = true;
        adminPanelView.SaveBackupButtonVisible = true;
        adminPanelView.Size = new Size(170, 484);
        adminPanelView.StartServerButtonEnabled = true;
        adminPanelView.StartServerButtonVisible = false;
        adminPanelView.StopServerButtonEnabled = true;
        adminPanelView.StopServerButtonVisible = false;
        adminPanelView.TabIndex = 39;
        adminPanelView.UpdateServerButtonBorderColor = Color.FromArgb(115, 115, 137);
        adminPanelView.UpdateServerButtonEnabled = true;
        adminPanelView.UpdateServerButtonVisible = false;
        adminPanelView.WindowsFirewallButtonEnabled = true;
        adminPanelView.WindowsFirewallButtonVisible = true;
        // 
        // pnlRightPanel
        // 
        pnlRightPanel.Controls.Add(manageProfilesView);
        pnlRightPanel.Controls.Add(profileSelectorView);
        pnlRightPanel.Controls.Add(pnlInfoPanel);
        pnlRightPanel.Controls.Add(tabsServerTabs);
        pnlRightPanel.Dock = DockStyle.Fill;
        pnlRightPanel.Location = new Point(190, 40);
        pnlRightPanel.Name = "pnlRightPanel";
        pnlRightPanel.Size = new Size(997, 484);
        pnlRightPanel.TabIndex = 50;
        // 
        // manageProfilesView
        // 
        manageProfilesView.BackColor = Color.FromArgb(0, 0, 18);
        manageProfilesView.EditProfileName = "";
        manageProfilesView.ForeColor = SystemColors.ButtonHighlight;
        manageProfilesView.IsVisible = true;
        manageProfilesView.Location = new Point(483, 40);
        manageProfilesView.Name = "manageProfilesView";
        manageProfilesView.Position = new Point(483, 40);
        manageProfilesView.SelectedProfile = null;
        manageProfilesView.Size = new Size(243, 151);
        manageProfilesView.TabIndex = 0;
        manageProfilesView.Visible = false;
        // 
        // profileSelectorView
        // 
        profileSelectorView.BackColor = Color.FromArgb(0, 0, 18);
        profileSelectorView.Dock = DockStyle.Top;
        profileSelectorView.Location = new Point(0, 0);
        profileSelectorView.Name = "profileSelectorView";
        profileSelectorView.RenameButtonText = "Rename";
        profileSelectorView.Size = new Size(750, 45);
        profileSelectorView.TabIndex = 1;
        profileSelectorView.TimeLeft = "Next Restart: 00:00";
        profileSelectorView.TimeLeftVisible = false;
        // 
        // pnlInfoPanel
        // 
        pnlInfoPanel.Controls.Add(infoPanelView);
        pnlInfoPanel.Controls.Add(creditsPanelView);
        pnlInfoPanel.Controls.Add(pbxRightBorder);
        pnlInfoPanel.Controls.Add(pbxInnerRightBorder);
        pnlInfoPanel.Dock = DockStyle.Right;
        pnlInfoPanel.Location = new Point(750, 0);
        pnlInfoPanel.Name = "pnlInfoPanel";
        pnlInfoPanel.Size = new Size(247, 484);
        pnlInfoPanel.TabIndex = 0;
        // 
        // infoPanelView
        // 
        infoPanelView.BackColor = Color.FromArgb(0, 0, 18);
        infoPanelView.Dock = DockStyle.Fill;
        infoPanelView.ForeColor = SystemColors.HighlightText;
        infoPanelView.IsNewVersionAvailable = false;
        infoPanelView.Location = new Point(10, 0);
        infoPanelView.Name = "infoPanelView";
        infoPanelView.Size = new Size(227, 484);
        infoPanelView.TabIndex = 42;
        // 
        // creditsPanelView
        // 
        creditsPanelView.BackColor = Color.FromArgb(0, 0, 18);
        creditsPanelView.Dock = DockStyle.Fill;
        creditsPanelView.ForeColor = SystemColors.Control;
        creditsPanelView.Location = new Point(10, 0);
        creditsPanelView.Name = "creditsPanelView";
        creditsPanelView.Padding = new Padding(5);
        creditsPanelView.Size = new Size(227, 484);
        creditsPanelView.TabIndex = 43;
        creditsPanelView.Visible = false;
        // 
        // tabsServerTabs
        // 
        tabsServerTabs.Controls.Add(tabServerSettings);
        tabsServerTabs.Controls.Add(tabAutoBackup);
        tabsServerTabs.Controls.Add(tabBackupRestore);
        tabsServerTabs.Controls.Add(tabScheduleRestarts);
        tabsServerTabs.Controls.Add(tabDiscord);
        tabsServerTabs.ItemSize = new Size(89, 20);
        tabsServerTabs.Location = new Point(-4, 43);
        tabsServerTabs.Name = "tabsServerTabs";
        tabsServerTabs.SelectedIndex = 0;
        tabsServerTabs.Size = new Size(758, 445);
        tabsServerTabs.TabIndex = 2;
        // 
        // tabServerSettings
        // 
        tabServerSettings.BackColor = Color.FromArgb(0, 0, 18);
        tabServerSettings.Controls.Add(serverSettingsView);
        tabServerSettings.ForeColor = SystemColors.ControlLight;
        tabServerSettings.Location = new Point(4, 24);
        tabServerSettings.Name = "tabServerSettings";
        tabServerSettings.Padding = new Padding(3);
        tabServerSettings.Size = new Size(750, 417);
        tabServerSettings.TabIndex = 0;
        tabServerSettings.Text = "Server Settings";
        // 
        // serverSettingsView
        // 
        serverSettingsView.BackColor = Color.FromArgb(0, 0, 18);
        serverSettingsView.Dock = DockStyle.Fill;
        serverSettingsView.ForeColor = SystemColors.ButtonHighlight;
        serverSettingsView.GamePort = 0;
        serverSettingsView.IpAddress = "";
        serverSettingsView.Location = new Point(3, 3);
        serverSettingsView.MaxPlayers = 0;
        serverSettingsView.Name = "serverSettingsView";
        serverSettingsView.QueryPort = 0;
        serverSettingsView.ServerName = "";
        serverSettingsView.Size = new Size(744, 411);
        serverSettingsView.TabIndex = 0;
        // 
        // tabAutoBackup
        // 
        tabAutoBackup.BackColor = Color.FromArgb(0, 0, 18);
        tabAutoBackup.Controls.Add(autoBackupView);
        tabAutoBackup.ForeColor = SystemColors.ControlLight;
        tabAutoBackup.Location = new Point(4, 24);
        tabAutoBackup.Name = "tabAutoBackup";
        tabAutoBackup.Padding = new Padding(3);
        tabAutoBackup.Size = new Size(703, 438);
        tabAutoBackup.TabIndex = 2;
        tabAutoBackup.Text = "Auto Backup";
        // 
        // autoBackupView
        // 
        autoBackupView.BackColor = Color.FromArgb(0, 0, 18);
        autoBackupView.BackupInterval = 0;
        autoBackupView.BackupStats = "Total Backups: 12\r\nDisk Consumption: 200MB\r\n";
        autoBackupView.Dock = DockStyle.Fill;
        autoBackupView.ForeColor = SystemColors.ButtonHighlight;
        autoBackupView.IsAutoBackupEnabled = false;
        autoBackupView.IsAutoBackupStatsVisible = false;
        autoBackupView.Location = new Point(3, 3);
        autoBackupView.MaxAutoBackupCount = 0;
        autoBackupView.Name = "autoBackupView";
        autoBackupView.SelectedProfile = null;
        autoBackupView.Size = new Size(697, 432);
        autoBackupView.TabIndex = 0;
        // 
        // tabBackupRestore
        // 
        tabBackupRestore.BackColor = Color.FromArgb(0, 0, 18);
        tabBackupRestore.Controls.Add(restoreBackupView);
        tabBackupRestore.Location = new Point(4, 24);
        tabBackupRestore.Name = "tabBackupRestore";
        tabBackupRestore.Padding = new Padding(3);
        tabBackupRestore.Size = new Size(703, 438);
        tabBackupRestore.TabIndex = 4;
        tabBackupRestore.Text = "Restore Backup";
        // 
        // restoreBackupView
        // 
        restoreBackupView.BackColor = Color.FromArgb(0, 0, 18);
        restoreBackupView.Dock = DockStyle.Fill;
        restoreBackupView.ForeColor = SystemColors.ButtonHighlight;
        restoreBackupView.IsRestoreOnScheduledRestartChecked = false;
        restoreBackupView.Location = new Point(3, 3);
        restoreBackupView.Name = "restoreBackupView";
        restoreBackupView.RestoreFilePath = "";
        restoreBackupView.Size = new Size(697, 432);
        restoreBackupView.TabIndex = 0;
        // 
        // tabScheduleRestarts
        // 
        tabScheduleRestarts.BackColor = Color.FromArgb(0, 0, 18);
        tabScheduleRestarts.Controls.Add(scheduleRestartsView);
        tabScheduleRestarts.Location = new Point(4, 24);
        tabScheduleRestarts.Name = "tabScheduleRestarts";
        tabScheduleRestarts.Size = new Size(703, 438);
        tabScheduleRestarts.TabIndex = 5;
        tabScheduleRestarts.Text = "Schedule Restarts";
        // 
        // scheduleRestartsView
        // 
        scheduleRestartsView.BackColor = Color.FromArgb(0, 0, 18);
        scheduleRestartsView.ForeColor = SystemColors.ButtonHighlight;
        scheduleRestartsView.IsScheduledRestartEnabled = false;
        scheduleRestartsView.IsScheduledWithServerStart = false;
        scheduleRestartsView.Location = new Point(3, 3);
        scheduleRestartsView.Name = "scheduleRestartsView";
        scheduleRestartsView.RecurrenceInterval = 1;
        scheduleRestartsView.RecurrenceIntervalUnit = "Hours";
        scheduleRestartsView.RestartFrequency = Enums.RestartFrequency.OneTime;
        scheduleRestartsView.Size = new Size(704, 439);
        scheduleRestartsView.StartDate = new DateOnly(2024, 2, 14);
        scheduleRestartsView.StartTime = new TimeOnly(22, 1, 7, 0, 0);
        scheduleRestartsView.TabIndex = 0;
        scheduleRestartsView.Tag = "RestartFrequency.OneTime";
        scheduleRestartsView.TimeLeft = "Next Restart: 00:00";
        // 
        // tabDiscord
        // 
        tabDiscord.BackColor = Color.FromArgb(0, 0, 18);
        tabDiscord.Controls.Add(discordNotificationsView);
        tabDiscord.ForeColor = SystemColors.ControlLight;
        tabDiscord.Location = new Point(4, 24);
        tabDiscord.Name = "tabDiscord";
        tabDiscord.Padding = new Padding(3);
        tabDiscord.Size = new Size(703, 438);
        tabDiscord.TabIndex = 3;
        tabDiscord.Text = "Discord";
        // 
        // discordNotificationsView
        // 
        discordNotificationsView.BackColor = Color.FromArgb(0, 0, 18);
        discordNotificationsView.BackupCreatedMessage = "Backup created!";
        discordNotificationsView.BackupRestoredMessage = "Backup restored!";
        discordNotificationsView.Dock = DockStyle.Fill;
        discordNotificationsView.ForeColor = SystemColors.ButtonHighlight;
        discordNotificationsView.IsDiscordNotificationsEnabled = false;
        discordNotificationsView.IsEmbedsEnabled = false;
        discordNotificationsView.IsImminentResetMessageEnabled = false;
        discordNotificationsView.IsLongResetMessageEnabled = false;
        discordNotificationsView.IsMediumResetMessageEnabled = false;
        discordNotificationsView.IsNotifyOnBackupEnabled = false;
        discordNotificationsView.IsNotifyOnBackupRestoreEnabled = false;
        discordNotificationsView.IsNotifyOnServerRestartEnabled = false;
        discordNotificationsView.IsNotifyOnStartEnabled = false;
        discordNotificationsView.IsNotifyOnStopEnabled = false;
        discordNotificationsView.IsNotifyOnUpdateEnabled = false;
        discordNotificationsView.IsShortResetMessageEnabled = false;
        discordNotificationsView.IsSoonResetMessageEnabled = false;
        discordNotificationsView.Location = new Point(3, 3);
        discordNotificationsView.Name = "discordNotificationsView";
        discordNotificationsView.ServerRestartMessage = "Server Reset In {TIME_LEFT}";
        discordNotificationsView.ServerStartedMessage = "Online!";
        discordNotificationsView.ServerStoppedMessage = "Offline!";
        discordNotificationsView.ServerUpdatingMessage = "Updating...";
        discordNotificationsView.Size = new Size(697, 432);
        discordNotificationsView.TabIndex = 0;
        discordNotificationsView.WebhookUrl = "";
        // 
        // pnlBottomBorder
        // 
        pnlBottomBorder.Controls.Add(btnOpenCredits);
        pnlBottomBorder.Controls.Add(lblVersion);
        pnlBottomBorder.Controls.Add(pbxBottomBorder);
        pnlBottomBorder.Dock = DockStyle.Bottom;
        pnlBottomBorder.Location = new Point(0, 524);
        pnlBottomBorder.Name = "pnlBottomBorder";
        pnlBottomBorder.Size = new Size(1187, 21);
        pnlBottomBorder.TabIndex = 1;
        // 
        // btnOpenCredits
        // 
        btnOpenCredits.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnOpenCredits.AutoSize = true;
        btnOpenCredits.BackColor = Color.FromArgb(64, 64, 64);
        btnOpenCredits.Cursor = Cursors.Hand;
        btnOpenCredits.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
        btnOpenCredits.ForeColor = Color.FromArgb(0, 255, 185);
        btnOpenCredits.Location = new Point(1136, 4);
        btnOpenCredits.Name = "btnOpenCredits";
        btnOpenCredits.Size = new Size(43, 13);
        btnOpenCredits.TabIndex = 61;
        btnOpenCredits.Text = "Credits";
        btnOpenCredits.TextAlign = ContentAlignment.BottomLeft;
        // 
        // lblVersion
        // 
        lblVersion.AutoSize = true;
        lblVersion.BackColor = Color.FromArgb(64, 64, 64);
        lblVersion.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
        lblVersion.ForeColor = Color.FromArgb(0, 204, 204);
        lblVersion.Location = new Point(8, 4);
        lblVersion.Name = "lblVersion";
        lblVersion.Size = new Size(37, 13);
        lblVersion.TabIndex = 56;
        lblVersion.Text = "v0.0.0";
        // 
        // pnlTopBorder
        // 
        pnlTopBorder.Controls.Add(lblMinimizeTrayButton);
        pnlTopBorder.Controls.Add(lblCloseButton);
        pnlTopBorder.Controls.Add(lblTitle);
        pnlTopBorder.Controls.Add(pbxFormHeader);
        pnlTopBorder.Dock = DockStyle.Top;
        pnlTopBorder.Location = new Point(0, 0);
        pnlTopBorder.Name = "pnlTopBorder";
        pnlTopBorder.Size = new Size(1187, 40);
        pnlTopBorder.TabIndex = 51;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        ClientSize = new Size(1187, 545);
        ControlBox = false;
        Controls.Add(pnlRightPanel);
        Controls.Add(pnlLeftPanel);
        Controls.Add(pnlTopBorder);
        Controls.Add(pnlBottomBorder);
        ForeColor = SystemColors.ButtonHighlight;
        FormBorderStyle = FormBorderStyle.None;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "MainForm";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pbxFormHeader).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbxLeftBorder).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbxInnerLeftBorder).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbxRightBorder).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbxInnerRightBorder).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbxBottomBorder).EndInit();
        pnlLeftPanel.ResumeLayout(false);
        pnlRightPanel.ResumeLayout(false);
        pnlInfoPanel.ResumeLayout(false);
        tabsServerTabs.ResumeLayout(false);
        tabServerSettings.ResumeLayout(false);
        tabAutoBackup.ResumeLayout(false);
        tabBackupRestore.ResumeLayout(false);
        tabScheduleRestarts.ResumeLayout(false);
        tabDiscord.ResumeLayout(false);
        pnlBottomBorder.ResumeLayout(false);
        pnlBottomBorder.PerformLayout();
        pnlTopBorder.ResumeLayout(false);
        pnlTopBorder.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private Label lblTitle;
    private Label lblMinimizeTrayButton;
    private Label lblCloseButton;
    private PictureBox pbxFormHeader;
    private PictureBox pbxLeftBorder;
    private PictureBox pbxInnerLeftBorder;
    private PictureBox pbxRightBorder;
    private PictureBox pbxRightPanel;
    private PictureBox pbxInnerRightBorder;
    private PictureBox pbxBottomBorder;
    private Panel pnlLeftPanel;
    private Panel pnlRightPanel;
    private Panel pnlInfoPanel;
    private Panel pnlBottomBorder;
    private Panel pnlTopBorder;
    private TabControl tabsServerTabs;
    private TabPage tabServerSettings;
    private TabPage tabAutoBackup;
    private TabPage tabDiscord;
    private AdminPanelView adminPanelView;
    private ProfileSelectorView profileSelectorView;
    private InfoPanelView infoPanelView;
    private ServerSettingsView serverSettingsView;
    private ManageProfilesView manageProfilesView;
    private AutoBackupView autoBackupView;
    private DiscordNotificationsView discordNotificationsView;
    private Label lblVersion;
    private Label btnOpenCredits;
    private CreditsPanelView creditsPanelView;
    private TabPage tabBackupRestore;
    private RestoreBackupView restoreBackupView;
    private TabPage tabScheduleRestarts;
    private ScheduleRestartsView scheduleRestartsView;
}