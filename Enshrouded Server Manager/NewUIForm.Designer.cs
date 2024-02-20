namespace Enshrouded_Server_Manager;

partial class NewUIForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewUIForm));
        pnlNavBar = new Panel();
        navBarView = new Views.NavigationView();
        pnlProfileSelector = new Panel();
        profileSelectorView = new Views.ProfileSelectorView();
        pnlAdminControls = new Panel();
        adminPanelHorizontalView = new Views.AdminPanelHorizontalView();
        pnlMain = new Panel();
        infoPanelWideView = new InfoPanelWideView();
        restoreBackupView = new RestoreBackupView();
        scheduleRestartsView = new Views.ScheduleRestartsView();
        serverSettingsView = new ServerSettingsView();
        discordNotificationsView = new DiscordNotificationsView();
        autoBackupView = new AutoBackupView();
        manageProfilesView = new ManageProfilesView();
        pnlMenuBar = new Panel();
        lblMinimizeTrayButton = new Label();
        lblCloseButton = new Label();
        pnlNavBar.SuspendLayout();
        pnlProfileSelector.SuspendLayout();
        pnlAdminControls.SuspendLayout();
        pnlMain.SuspendLayout();
        pnlMenuBar.SuspendLayout();
        SuspendLayout();
        // 
        // pnlNavBar
        // 
        pnlNavBar.BackColor = Color.FromArgb(64, 64, 64);
        pnlNavBar.Controls.Add(navBarView);
        pnlNavBar.Dock = DockStyle.Left;
        pnlNavBar.Location = new Point(0, 65);
        pnlNavBar.Name = "pnlNavBar";
        pnlNavBar.Padding = new Padding(1, 0, 1, 1);
        pnlNavBar.Size = new Size(200, 466);
        pnlNavBar.TabIndex = 0;
        // 
        // navBarView
        // 
        navBarView.BackColor = Color.FromArgb(0, 0, 18);
        navBarView.CurrentVersionText = "v.0.4.1";
        navBarView.Dock = DockStyle.Fill;
        navBarView.ForeColor = SystemColors.Control;
        navBarView.IsNewVersionAvailable = false;
        navBarView.Location = new Point(1, 0);
        navBarView.Name = "navBarView";
        navBarView.SelectedView = Enums.ViewSelection.Home;
        navBarView.Size = new Size(198, 465);
        navBarView.TabIndex = 0;
        // 
        // pnlProfileSelector
        // 
        pnlProfileSelector.BackColor = Color.FromArgb(64, 64, 64);
        pnlProfileSelector.Controls.Add(profileSelectorView);
        pnlProfileSelector.Dock = DockStyle.Top;
        pnlProfileSelector.Location = new Point(0, 25);
        pnlProfileSelector.Name = "pnlProfileSelector";
        pnlProfileSelector.Padding = new Padding(1, 0, 1, 1);
        pnlProfileSelector.Size = new Size(944, 40);
        pnlProfileSelector.TabIndex = 1;
        // 
        // profileSelectorView
        // 
        profileSelectorView.BackColor = Color.FromArgb(0, 0, 18);
        profileSelectorView.Dock = DockStyle.Fill;
        profileSelectorView.Location = new Point(1, 0);
        profileSelectorView.Name = "profileSelectorView";
        profileSelectorView.RenameButtonText = "Rename";
        profileSelectorView.Size = new Size(942, 39);
        profileSelectorView.TabIndex = 0;
        profileSelectorView.TimeLeft = "Next Restart: 00:00";
        profileSelectorView.TimeLeftVisible = false;
        // 
        // pnlAdminControls
        // 
        pnlAdminControls.BackColor = Color.FromArgb(64, 64, 64);
        pnlAdminControls.Controls.Add(adminPanelHorizontalView);
        pnlAdminControls.Dock = DockStyle.Bottom;
        pnlAdminControls.Location = new Point(200, 476);
        pnlAdminControls.Name = "pnlAdminControls";
        pnlAdminControls.Padding = new Padding(0, 1, 1, 1);
        pnlAdminControls.Size = new Size(744, 55);
        pnlAdminControls.TabIndex = 2;
        // 
        // adminPanelHorizontalView
        // 
        adminPanelHorizontalView.BackColor = Color.FromArgb(0, 0, 18);
        adminPanelHorizontalView.Dock = DockStyle.Fill;
        adminPanelHorizontalView.InstallServerButtonEnabled = true;
        adminPanelHorizontalView.InstallServerButtonVisible = false;
        adminPanelHorizontalView.InstallSteamCMDButtonEnabled = true;
        adminPanelHorizontalView.InstallSteamCMDButtonVisible = true;
        adminPanelHorizontalView.Location = new Point(0, 1);
        adminPanelHorizontalView.Name = "adminPanelHorizontalView";
        adminPanelHorizontalView.OpenBackupFolderButtonEnabled = true;
        adminPanelHorizontalView.OpenBackupFolderButtonVisible = true;
        adminPanelHorizontalView.OpenLogFolderButtonEnabled = true;
        adminPanelHorizontalView.OpenLogFolderButtonVisible = true;
        adminPanelHorizontalView.OpenSavegameFolderButtonEnabled = true;
        adminPanelHorizontalView.OpenSavegameFolderButtonVisible = true;
        adminPanelHorizontalView.SaveBackupButtonEnabled = true;
        adminPanelHorizontalView.SaveBackupButtonVisible = true;
        adminPanelHorizontalView.Size = new Size(743, 53);
        adminPanelHorizontalView.StartServerButtonEnabled = true;
        adminPanelHorizontalView.StartServerButtonVisible = false;
        adminPanelHorizontalView.StopServerButtonEnabled = true;
        adminPanelHorizontalView.StopServerButtonVisible = false;
        adminPanelHorizontalView.TabIndex = 0;
        adminPanelHorizontalView.UpdateServerButtonBorderColor = Color.FromArgb(115, 115, 137);
        adminPanelHorizontalView.UpdateServerButtonEnabled = true;
        adminPanelHorizontalView.UpdateServerButtonVisible = false;
        adminPanelHorizontalView.WindowsFirewallButtonEnabled = true;
        adminPanelHorizontalView.WindowsFirewallButtonVisible = true;
        // 
        // pnlMain
        // 
        pnlMain.BackColor = Color.FromArgb(64, 64, 64);
        pnlMain.Controls.Add(infoPanelWideView);
        pnlMain.Controls.Add(restoreBackupView);
        pnlMain.Controls.Add(scheduleRestartsView);
        pnlMain.Controls.Add(serverSettingsView);
        pnlMain.Controls.Add(discordNotificationsView);
        pnlMain.Controls.Add(autoBackupView);
        pnlMain.Dock = DockStyle.Fill;
        pnlMain.Location = new Point(200, 65);
        pnlMain.Name = "pnlMain";
        pnlMain.Padding = new Padding(0, 0, 1, 0);
        pnlMain.Size = new Size(744, 411);
        pnlMain.TabIndex = 3;
        // 
        // infoPanelWideView
        // 
        infoPanelWideView.BackColor = Color.FromArgb(0, 0, 18);
        infoPanelWideView.Dock = DockStyle.Fill;
        infoPanelWideView.ForeColor = SystemColors.HighlightText;
        infoPanelWideView.IsNewVersionAvailable = false;
        infoPanelWideView.Location = new Point(0, 0);
        infoPanelWideView.Name = "infoPanelWideView";
        infoPanelWideView.Size = new Size(743, 411);
        infoPanelWideView.TabIndex = 9;
        // 
        // restoreBackupView
        // 
        restoreBackupView.BackColor = Color.FromArgb(0, 0, 18);
        restoreBackupView.Dock = DockStyle.Fill;
        restoreBackupView.ForeColor = SystemColors.ButtonHighlight;
        restoreBackupView.IsRestoreOnScheduledRestartChecked = false;
        restoreBackupView.Location = new Point(0, 0);
        restoreBackupView.Name = "restoreBackupView";
        restoreBackupView.RestoreFilePath = "";
        restoreBackupView.Size = new Size(743, 411);
        restoreBackupView.TabIndex = 8;
        // 
        // scheduleRestartsView
        // 
        scheduleRestartsView.BackColor = Color.FromArgb(0, 0, 18);
        scheduleRestartsView.Dock = DockStyle.Fill;
        scheduleRestartsView.ForeColor = SystemColors.ButtonHighlight;
        scheduleRestartsView.IsScheduledRestartEnabled = false;
        scheduleRestartsView.IsScheduledWithServerStart = false;
        scheduleRestartsView.Location = new Point(0, 0);
        scheduleRestartsView.Name = "scheduleRestartsView";
        scheduleRestartsView.RecurrenceInterval = 1;
        scheduleRestartsView.RecurrenceIntervalUnit = "Hours";
        scheduleRestartsView.RestartFrequency = Enums.RestartFrequency.None;
        scheduleRestartsView.Size = new Size(743, 411);
        scheduleRestartsView.StartDate = new DateOnly(2024, 2, 20);
        scheduleRestartsView.StartTime = new TimeOnly(7, 53, 27, 0, 0);
        scheduleRestartsView.TabIndex = 7;
        scheduleRestartsView.TimeLeft = "Next Restart: 00:00";
        // 
        // serverSettingsView
        // 
        serverSettingsView.BackColor = Color.FromArgb(0, 0, 18);
        serverSettingsView.Dock = DockStyle.Fill;
        serverSettingsView.ForeColor = SystemColors.ButtonHighlight;
        serverSettingsView.GamePort = 0;
        serverSettingsView.IpAddress = "";
        serverSettingsView.IsPasswordShown = false;
        serverSettingsView.Location = new Point(0, 0);
        serverSettingsView.MaxPlayers = 0;
        serverSettingsView.Name = "serverSettingsView";
        serverSettingsView.Password = "";
        serverSettingsView.PasswordChar = '*';
        serverSettingsView.QueryPort = 0;
        serverSettingsView.ServerName = "";
        serverSettingsView.ShowPasswordButtonText = "Show";
        serverSettingsView.Size = new Size(743, 411);
        serverSettingsView.TabIndex = 4;
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
        discordNotificationsView.Location = new Point(0, 0);
        discordNotificationsView.Name = "discordNotificationsView";
        discordNotificationsView.ServerRestartMessage = "Server Reset In {TIME_LEFT}";
        discordNotificationsView.ServerStartedMessage = "Online!";
        discordNotificationsView.ServerStoppedMessage = "Offline!";
        discordNotificationsView.ServerUpdatingMessage = "Updating...";
        discordNotificationsView.Size = new Size(743, 411);
        discordNotificationsView.TabIndex = 1;
        discordNotificationsView.WebhookUrl = "";
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
        autoBackupView.Location = new Point(0, 0);
        autoBackupView.MaxAutoBackupCount = 0;
        autoBackupView.Name = "autoBackupView";
        autoBackupView.SelectedProfile = null;
        autoBackupView.Size = new Size(743, 411);
        autoBackupView.TabIndex = 0;
        // 
        // manageProfilesView
        // 
        manageProfilesView.BackColor = Color.FromArgb(0, 0, 18);
        manageProfilesView.EditProfileName = "";
        manageProfilesView.ForeColor = SystemColors.ButtonHighlight;
        manageProfilesView.IsVisible = true;
        manageProfilesView.Location = new Point(630, 65);
        manageProfilesView.Name = "manageProfilesView";
        manageProfilesView.Position = new Point(630, 65);
        manageProfilesView.SelectedProfile = null;
        manageProfilesView.Size = new Size(241, 159);
        manageProfilesView.TabIndex = 3;
        // 
        // pnlMenuBar
        // 
        pnlMenuBar.BackColor = Color.FromArgb(64, 64, 64);
        pnlMenuBar.Controls.Add(lblMinimizeTrayButton);
        pnlMenuBar.Controls.Add(lblCloseButton);
        pnlMenuBar.Dock = DockStyle.Top;
        pnlMenuBar.Location = new Point(0, 0);
        pnlMenuBar.Name = "pnlMenuBar";
        pnlMenuBar.Size = new Size(944, 25);
        pnlMenuBar.TabIndex = 2;
        pnlMenuBar.MouseDown += pnlMenuBar_MouseDown;
        // 
        // lblMinimizeTrayButton
        // 
        lblMinimizeTrayButton.AutoSize = true;
        lblMinimizeTrayButton.BackColor = Color.FromArgb(64, 64, 64);
        lblMinimizeTrayButton.Cursor = Cursors.Hand;
        lblMinimizeTrayButton.Font = new Font("Malgun Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblMinimizeTrayButton.ForeColor = Color.FromArgb(0, 255, 185);
        lblMinimizeTrayButton.Location = new Point(892, -1);
        lblMinimizeTrayButton.Name = "lblMinimizeTrayButton";
        lblMinimizeTrayButton.Size = new Size(17, 21);
        lblMinimizeTrayButton.TabIndex = 31;
        lblMinimizeTrayButton.Text = "_";
        lblMinimizeTrayButton.TextAlign = ContentAlignment.MiddleCenter;
        lblMinimizeTrayButton.Click += lblMinimizeButton_Click;
        // 
        // lblCloseButton
        // 
        lblCloseButton.AutoSize = true;
        lblCloseButton.BackColor = Color.FromArgb(64, 64, 64);
        lblCloseButton.Cursor = Cursors.Hand;
        lblCloseButton.Font = new Font("Malgun Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblCloseButton.ForeColor = Color.FromArgb(0, 255, 185);
        lblCloseButton.Location = new Point(919, 3);
        lblCloseButton.Name = "lblCloseButton";
        lblCloseButton.Size = new Size(18, 19);
        lblCloseButton.TabIndex = 30;
        lblCloseButton.Text = "X";
        lblCloseButton.TextAlign = ContentAlignment.MiddleCenter;
        lblCloseButton.Click += lblCloseButton_Click;
        // 
        // NewUIForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        ClientSize = new Size(944, 531);
        Controls.Add(manageProfilesView);
        Controls.Add(pnlMain);
        Controls.Add(pnlAdminControls);
        Controls.Add(pnlNavBar);
        Controls.Add(pnlProfileSelector);
        Controls.Add(pnlMenuBar);
        ForeColor = SystemColors.ButtonHighlight;
        FormBorderStyle = FormBorderStyle.None;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "NewUIForm";
        Text = "NewUIForm";
        pnlNavBar.ResumeLayout(false);
        pnlProfileSelector.ResumeLayout(false);
        pnlAdminControls.ResumeLayout(false);
        pnlMain.ResumeLayout(false);
        pnlMenuBar.ResumeLayout(false);
        pnlMenuBar.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlNavBar;
    private Panel pnlProfileSelector;
    private Panel pnlAdminControls;
    private Panel pnlMain;
    private Views.NavigationView navBarView;
    private Views.ProfileSelectorView profileSelectorView;
    private Views.AdminPanelHorizontalView adminPanelHorizontalView;
    private ServerSettingsView serverSettingsView;
    private ManageProfilesView manageProfilesView;
    private DiscordNotificationsView discordNotificationsView;
    private AutoBackupView autoBackupView;
    private Panel pnlMenuBar;
    private Label lblCloseButton;
    private Label lblMinimizeTrayButton;
    private Views.ScheduleRestartsView scheduleRestartsView;
    private RestoreBackupView restoreBackupView;
    private InfoPanelWideView infoPanelWideView;
}