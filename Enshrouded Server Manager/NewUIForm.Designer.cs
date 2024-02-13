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
        pnlNavBar = new Panel();
        navBarView = new Views.NavBarView();
        pnlTopHeader = new Panel();
        profileSelectorView = new Views.ProfileSelectorView();
        pnlAdminControls = new Panel();
        adminPanelHorizontalView = new Views.AdminPanelHorizontalView();
        pnlMain = new Panel();
        creditsPanelView = new Views.CreditsPanelView();
        serverSettingsView = new ServerSettingsView();
        manageProfilesView = new ManageProfilesView();
        infoPanelView = new InfoPanelView();
        discordNotificationsView = new DiscordNotificationsView();
        autoBackupView = new AutoBackupView();
        pnlNavBar.SuspendLayout();
        pnlTopHeader.SuspendLayout();
        pnlAdminControls.SuspendLayout();
        pnlMain.SuspendLayout();
        SuspendLayout();
        // 
        // pnlNavBar
        // 
        pnlNavBar.Controls.Add(navBarView);
        pnlNavBar.Dock = DockStyle.Left;
        pnlNavBar.Location = new Point(0, 40);
        pnlNavBar.Name = "pnlNavBar";
        pnlNavBar.Size = new Size(200, 491);
        pnlNavBar.TabIndex = 0;
        // 
        // navBarView
        // 
        navBarView.BackColor = Color.FromArgb(0, 0, 18);
        navBarView.Dock = DockStyle.Fill;
        navBarView.ForeColor = SystemColors.Control;
        navBarView.Location = new Point(0, 0);
        navBarView.Name = "navBarView";
        navBarView.Size = new Size(200, 491);
        navBarView.TabIndex = 0;
        // 
        // pnlTopHeader
        // 
        pnlTopHeader.Controls.Add(profileSelectorView);
        pnlTopHeader.Dock = DockStyle.Top;
        pnlTopHeader.Location = new Point(0, 0);
        pnlTopHeader.Name = "pnlTopHeader";
        pnlTopHeader.Size = new Size(944, 40);
        pnlTopHeader.TabIndex = 1;
        // 
        // profileSelectorView
        // 
        profileSelectorView.BackColor = Color.FromArgb(0, 0, 18);
        profileSelectorView.Location = new Point(247, 0);
        profileSelectorView.Name = "profileSelectorView";
        profileSelectorView.RenameButtonText = "Rename";
        profileSelectorView.Size = new Size(450, 40);
        profileSelectorView.TabIndex = 0;
        // 
        // pnlAdminControls
        // 
        pnlAdminControls.Controls.Add(adminPanelHorizontalView);
        pnlAdminControls.Dock = DockStyle.Bottom;
        pnlAdminControls.Location = new Point(200, 476);
        pnlAdminControls.Name = "pnlAdminControls";
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
        adminPanelHorizontalView.Location = new Point(0, 0);
        adminPanelHorizontalView.Name = "adminPanelHorizontalView";
        adminPanelHorizontalView.OpenBackupFolderButtonEnabled = true;
        adminPanelHorizontalView.OpenBackupFolderButtonVisible = true;
        adminPanelHorizontalView.OpenLogFolderButtonEnabled = true;
        adminPanelHorizontalView.OpenLogFolderButtonVisible = true;
        adminPanelHorizontalView.OpenSavegameFolderButtonEnabled = true;
        adminPanelHorizontalView.OpenSavegameFolderButtonVisible = true;
        adminPanelHorizontalView.SaveBackupButtonEnabled = true;
        adminPanelHorizontalView.SaveBackupButtonVisible = true;
        adminPanelHorizontalView.Size = new Size(744, 55);
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
        pnlMain.Controls.Add(serverSettingsView);
        pnlMain.Controls.Add(creditsPanelView);
        pnlMain.Controls.Add(manageProfilesView);
        pnlMain.Controls.Add(infoPanelView);
        pnlMain.Controls.Add(discordNotificationsView);
        pnlMain.Controls.Add(autoBackupView);
        pnlMain.Dock = DockStyle.Fill;
        pnlMain.Location = new Point(200, 40);
        pnlMain.Name = "pnlMain";
        pnlMain.Size = new Size(744, 436);
        pnlMain.TabIndex = 3;
        // 
        // creditsPanelView
        // 
        creditsPanelView.BackColor = Color.FromArgb(0, 0, 18);
        creditsPanelView.Dock = DockStyle.Fill;
        creditsPanelView.ForeColor = SystemColors.Control;
        creditsPanelView.Location = new Point(0, 0);
        creditsPanelView.Name = "creditsPanelView";
        creditsPanelView.Padding = new Padding(5);
        creditsPanelView.Size = new Size(744, 436);
        creditsPanelView.TabIndex = 5;
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
        serverSettingsView.Size = new Size(744, 436);
        serverSettingsView.TabIndex = 4;
        // 
        // manageProfilesView
        // 
        manageProfilesView.BackColor = Color.FromArgb(0, 0, 18);
        manageProfilesView.EditProfileName = "";
        manageProfilesView.ForeColor = SystemColors.ButtonHighlight;
        manageProfilesView.IsVisible = true;
        manageProfilesView.Location = new Point(243, 3);
        manageProfilesView.Name = "manageProfilesView";
        manageProfilesView.Position = new Point(243, 3);
        manageProfilesView.SelectedProfile = null;
        manageProfilesView.Size = new Size(249, 156);
        manageProfilesView.TabIndex = 3;
        // 
        // infoPanelView
        // 
        infoPanelView.BackColor = Color.FromArgb(0, 0, 18);
        infoPanelView.Dock = DockStyle.Fill;
        infoPanelView.ForeColor = SystemColors.HighlightText;
        infoPanelView.IsNewVersionAvailable = false;
        infoPanelView.Location = new Point(0, 0);
        infoPanelView.Name = "infoPanelView";
        infoPanelView.Size = new Size(744, 436);
        infoPanelView.TabIndex = 2;
        // 
        // discordNotificationsView
        // 
        discordNotificationsView.BackColor = Color.FromArgb(0, 0, 18);
        discordNotificationsView.BackupCreatedMessage = "Backup created!";
        discordNotificationsView.Dock = DockStyle.Fill;
        discordNotificationsView.ForeColor = SystemColors.ButtonHighlight;
        discordNotificationsView.IsDiscordNotificationsEnabled = false;
        discordNotificationsView.IsEmbedsEnabled = false;
        discordNotificationsView.IsNotifyOnBackupEnabled = false;
        discordNotificationsView.IsNotifyOnStartEnabled = false;
        discordNotificationsView.IsNotifyOnStopEnabled = false;
        discordNotificationsView.IsNotifyOnUpdateEnabled = false;
        discordNotificationsView.Location = new Point(0, 0);
        discordNotificationsView.Name = "discordNotificationsView";
        discordNotificationsView.ServerStartedMessage = "Online!";
        discordNotificationsView.ServerStoppedMessage = "Offline!";
        discordNotificationsView.ServerUpdatingMessage = "Updating...";
        discordNotificationsView.Size = new Size(744, 436);
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
        autoBackupView.Size = new Size(744, 436);
        autoBackupView.TabIndex = 0;
        // 
        // NewUIForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        ClientSize = new Size(944, 531);
        Controls.Add(pnlMain);
        Controls.Add(pnlAdminControls);
        Controls.Add(pnlNavBar);
        Controls.Add(pnlTopHeader);
        ForeColor = SystemColors.ButtonHighlight;
        FormBorderStyle = FormBorderStyle.None;
        Name = "NewUIForm";
        Text = "NewUIForm";
        pnlNavBar.ResumeLayout(false);
        pnlTopHeader.ResumeLayout(false);
        pnlAdminControls.ResumeLayout(false);
        pnlMain.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlNavBar;
    private Panel pnlTopHeader;
    private Panel pnlAdminControls;
    private Panel pnlMain;
    private Views.NavBarView navBarView;
    private Views.ProfileSelectorView profileSelectorView;
    private Views.AdminPanelHorizontalView adminPanelHorizontalView;
    private Views.CreditsPanelView creditsPanelView;
    private ServerSettingsView serverSettingsView;
    private ManageProfilesView manageProfilesView;
    private InfoPanelView infoPanelView;
    private DiscordNotificationsView discordNotificationsView;
    private AutoBackupView autoBackupView;
}