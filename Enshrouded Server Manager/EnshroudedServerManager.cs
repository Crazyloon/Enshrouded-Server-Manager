using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Presenters;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using System.ComponentModel;
using System.Net;
using System.Runtime.InteropServices;

namespace Enshrouded_Server_Manager;
public partial class EnshroudedServerManager : Form, INewUIFormView
{
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    private Panel _pnlUpdateServerfiles;
    private Label _lblUpdateServerfiles;
    public EnshroudedServerManager()
    {
        InitializeComponent();

        // TODO: Configure all of these services for dependency injection
        // There should only EVER be one instance of the EventAggregator (singleton)
        EventAggregator eventAggregator = new EventAggregator();

        // Initialize shared timers
        Dictionary<string, CountDownTimer> restartTimers = new();

        // Initialize Services
        var fileSystemService = new FileSystemService();
        var messageBoxService = new MessageBoxService();
        var logService = new FileLogger(fileSystemService);
        var discordOutputService = new DiscordService(fileSystemService, logService, eventAggregator);
        var enshroudedServerService = new EnshroudedServerService(fileSystemService, eventAggregator, logService);
        var versionManager = new VersionManagementService(fileSystemService, eventAggregator);
        var backupService = new BackupService(fileSystemService, enshroudedServerService, eventAggregator, discordOutputService, logService, restartTimers);
        var profileService = new ProfileService(fileSystemService, messageBoxService, logService);
        var processManager = new SystemProcessService();
        var httpClient = new HttpClientService(new WebClient());
        var serverSettingsService = new ServerSettingsService(fileSystemService, eventAggregator, messageBoxService, enshroudedServerService);
        var steamCMDInstaller = new SteamCMDInstallerService(fileSystemService, processManager, messageBoxService, httpClient);
        var restartScheduler = new ScheduledRestartService(fileSystemService, logService, backupService, enshroudedServerService, eventAggregator, discordOutputService, restartTimers);

        // Load the profiles for each view the first time they are created
        BindingList<ServerProfile> profiles = new BindingList<ServerProfile>(profileService.LoadServerProfiles(JsonSettings.Default, true));

        // Initialize Presenters
        adminPanelHorizontalView.Tag = new AdminPanelPresenter(adminPanelHorizontalView, eventAggregator, steamCMDInstaller, fileSystemService, versionManager, processManager, serverSettingsService, enshroudedServerService, profileService, discordOutputService, backupService, logService, restartScheduler, restartTimers);
        restoreBackupView.Tag = new RestoreBackupPresenter(restoreBackupView, eventAggregator, fileSystemService, backupService, enshroudedServerService, messageBoxService, logService, profiles);
        serverSettingsView.Tag = new ServerSettingsPresenter(serverSettingsView, eventAggregator, serverSettingsService, fileSystemService, enshroudedServerService, logService);
        manageProfilesView.Tag = new ManageProfilesPresenter(manageProfilesView, eventAggregator, profileService, serverSettingsService, fileSystemService, messageBoxService, enshroudedServerService, logService, profiles);
        autoBackupView.Tag = new AutoBackupPresenter(autoBackupView, eventAggregator, processManager, profileService, fileSystemService, messageBoxService, backupService, logService, profiles);
        discordNotificationsView.Tag = new DiscordNotificationsPresenter(discordNotificationsView, eventAggregator, discordOutputService, messageBoxService, profileService, fileSystemService, logService);
        scheduleRestartsView.Tag = new ScheduleRestartsPresenter(scheduleRestartsView, eventAggregator, enshroudedServerService, backupService, messageBoxService, fileSystemService, logService, restartScheduler, restartTimers, profiles);
        navBarView.Tag = new NavigationPresenter(navBarView, versionManager, eventAggregator);
        infoPanelWideView.Tag = new InfoPanelPresenter(infoPanelWideView, eventAggregator, processManager);
        creditsPanelWideView.Tag = new CreditsPanelPresenter(creditsPanelWideView, processManager);

        this.Tag = new NewUIPresenter(this, versionManager);

        // Profile Selector should be created last, because it publishes the selected profile on startup
        profileSelectorView.Tag = new ProfileSelectorPresenter(profileSelectorView, manageProfilesView, eventAggregator, profileService, serverSettingsService, fileSystemService, messageBoxService, enshroudedServerService, logService, restartTimers, profiles);

        _pnlUpdateServerfiles = new Panel();
        _lblUpdateServerfiles = new Label();

        eventAggregator.Subscribe<ServerInstallStartedMessage>(m => OnServerInstallStarted());
        eventAggregator.Subscribe<ServerInstallStoppedMessage>(m => OnServerInstallStopped());
        eventAggregator.Subscribe<NavigationChangedMessage>(v => OnNavigationChanged(v.ViewSelection));

        InitializeServerUpdateOverlay();
        manageProfilesView.Location = new Point(630, 65);
    }

    private void OnNavigationChanged(ViewSelection viewSelection)
    {
        switch (viewSelection)
        {
            case ViewSelection.Home:
                infoPanelWideView.BringToFront();
                break;
            case ViewSelection.ServerSettings:
                serverSettingsView.BringToFront();
                break;
            case ViewSelection.AutoBackup:
                autoBackupView.BringToFront();
                break;
            case ViewSelection.RestoreBackup:
                restoreBackupView.BringToFront();
                break;
            case ViewSelection.ScheduleRestarts:
                scheduleRestartsView.BringToFront();
                break;
            case ViewSelection.DiscordNotifications:
                discordNotificationsView.BringToFront();
                break;
            case ViewSelection.Credits:
                creditsPanelWideView.BringToFront();
                break;
            default:
                break;
        }
    }

    //public event EventHandler ViewCreditsButtonClicked
    //{
    //    add => btnOpenCredits.Click += value;
    //    remove => btnOpenCredits.Click -= value;
    //}

    //public void ToggleCredits()
    //{
    //    creditsPanelView.Visible = !creditsPanelView.Visible;
    //    infoPanelView.Visible = !infoPanelView.Visible;
    //}

    private void OnServerInstallStopped()
    {
        _pnlUpdateServerfiles.Visible = false;
        _pnlUpdateServerfiles.SendToBack();
    }

    private void OnServerInstallStarted()
    {
        _pnlUpdateServerfiles.Visible = true;
        _pnlUpdateServerfiles.BringToFront();
    }

    private void pnlMenuBar_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, Constants.BUTTON_DOWN, Constants.CAPTION, 0);
        }
    }

    private void lblCloseButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void lblMinimizeButton_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    private void InitializeServerUpdateOverlay()
    {
        //// calculate the top left corner for the panel based on header height
        //int pX = pbxLeftBorder.Width;
        //int pY = pnlTopBorder.Location.Y + pnlTopBorder.Height;
        //// calculate the width of the panel based off the left edge to the start of the infoPanel border
        //int pWidth = pnlInfoPanel.Location.X + pnlRightPanel.Location.X - pX;
        //// calculate the height of the panel based off the height of the form minus the offset of the top of the panel
        //int pHeight = Height - pY - pbxBottomBorder.Height;

        // Label
        _lblUpdateServerfiles.AutoSize = false;
        _lblUpdateServerfiles.Dock = DockStyle.Fill;
        _lblUpdateServerfiles.Location = new Point(0, 0);
        _lblUpdateServerfiles.TextAlign = ContentAlignment.MiddleCenter;
        _lblUpdateServerfiles.Text = "Updating Server Files...";
        _lblUpdateServerfiles.Visible = true;

        // Panel
        _pnlUpdateServerfiles.SuspendLayout();

        _pnlUpdateServerfiles.BackColor = Color.FromArgb(0, 0, 18);
        _pnlUpdateServerfiles.Controls.Add(_lblUpdateServerfiles);
        _pnlUpdateServerfiles.Location = pnlMain.Location;
        _pnlUpdateServerfiles.Dock = DockStyle.Fill;
        _pnlUpdateServerfiles.Visible = true;

        pnlMain.Controls.Add(_pnlUpdateServerfiles);

        _pnlUpdateServerfiles.SendToBack();
        _pnlUpdateServerfiles.ResumeLayout(false);
        _pnlUpdateServerfiles.PerformLayout();
    }
}
