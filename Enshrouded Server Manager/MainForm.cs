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
public partial class MainForm : Form, IMainFormView
{
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    private Panel _pnlUpdateServerfiles;
    private Label _lblUpdateServerfiles;

    public MainForm(
        //IBackupService backupService,
        //IDiscordService discordService,
        //IEnshroudedServerService enshroudedServerService,
        //IFileLoggerService logService,
        //IFileSystemService fileSystemService,
        //IMessageBoxService messageBoxService,
        //IProfileService profileService,
        //IServerSettingsService serverSettingsService,
        //ISteamCMDInstallerService steamCMDInstallerService,
        //ISystemProcessService systemProcessService,
        //IVersionManagementService versionManagementService,
        //IScheduledRestartService scheduledRestartService,
        //IEventAggregator eventAggregator,
        //Dictionary<string, CountDownTimer> restartTimers
        )

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
        var discordOutputService = new DiscordService();
        var logService = new FileLogger(fileSystemService);
        var enshroudedServerService = new EnshroudedServerService(fileSystemService, eventAggregator);
        var versionManager = new VersionManagementService(fileSystemService, eventAggregator);
        var backupService = new BackupService(fileSystemService, enshroudedServerService, eventAggregator, discordOutputService, restartTimers);
        var profileService = new ProfileService(fileSystemService, messageBoxService);
        var processManager = new SystemProcessService();
        var httpClient = new HttpClientService(new WebClient());
        var serverSettingsService = new ServerSettingsService(fileSystemService, eventAggregator, messageBoxService, enshroudedServerService);
        var steamCMDInstaller = new SteamCMDInstallerService(fileSystemService, processManager, messageBoxService, httpClient);
        var restartScheduler = new ScheduledRestartService(fileSystemService, logService, backupService, enshroudedServerService, eventAggregator, restartTimers);

        // Initialize shared profiles
        BindingList<ServerProfile> profiles = new BindingList<ServerProfile>(profileService.LoadServerProfiles(JsonSettings.Default, true));

        // Initialize Presenters
        adminPanelView.Tag = new AdminPanelPresenter(adminPanelView, eventAggregator, steamCMDInstaller, fileSystemService, versionManager, processManager, serverSettingsService, enshroudedServerService, profileService, discordOutputService, backupService, logService, restartScheduler, restartTimers);
        serverSettingsView.Tag = new ServerSettingsPresenter(serverSettingsView, eventAggregator, serverSettingsService, fileSystemService, enshroudedServerService, logService);
        manageProfilesView.Tag = new ManageProfilesPresenter(manageProfilesView, eventAggregator, profileService, serverSettingsService, fileSystemService, messageBoxService, enshroudedServerService, logService, profiles);
        autoBackupView.Tag = new AutoBackupPresenter(autoBackupView, eventAggregator, processManager, profileService, fileSystemService, messageBoxService, backupService, logService, profiles);
        discordNotificationsView.Tag = new DiscordNotificationsPresenter(discordNotificationsView, eventAggregator, discordOutputService, messageBoxService, profileService, fileSystemService, logService);
        infoPanelView.Tag = new InfoPanelPresenter(infoPanelView, eventAggregator, processManager);
        restoreBackupView.Tag = new RestoreBackupPresenter(restoreBackupView, eventAggregator, fileSystemService, backupService, enshroudedServerService, messageBoxService, logService, profiles);
        scheduleRestartsView.Tag = new ScheduleRestartsPresenter(scheduleRestartsView, eventAggregator, enshroudedServerService, backupService, messageBoxService, fileSystemService, logService, restartScheduler, restartTimers, profiles);



        this.Tag = new MainFormPresenter(this, versionManager);

        // Profile Selector should be created last, because it publishes the selected profile on startup
        profileSelectorView.Tag = new ProfileSelectorPresenter(profileSelectorView, manageProfilesView, eventAggregator, profileService, serverSettingsService, fileSystemService, messageBoxService, enshroudedServerService, logService, profiles);

        _pnlUpdateServerfiles = new Panel();
        _lblUpdateServerfiles = new Label();

        eventAggregator.Subscribe<ServerInstallStartedMessage>(m => OnServerInstallStarted());
        eventAggregator.Subscribe<ServerInstallStoppedMessage>(m => OnServerInstallStopped());

        InitializeServerUpdateOverlay();

        logService.LogInfo("Application started");
    }

    public event EventHandler ViewCreditsButtonClicked
    {
        add => btnOpenCredits.Click += value;
        remove => btnOpenCredits.Click -= value;
    }

    public string CurrentVersionText
    {
        get => lblVersion.Text;
        set => lblVersion.Text = value;
    }

    public void ToggleCredits()
    {
        creditsPanelView.Visible = !creditsPanelView.Visible;
        infoPanelView.Visible = !infoPanelView.Visible;
    }

    private void OnServerInstallStopped()
    {
        _pnlUpdateServerfiles.Visible = false;
    }

    private void OnServerInstallStarted()
    {
        _pnlUpdateServerfiles.Visible = true;
    }

    private void pbxFormHeader_MouseDown(object sender, MouseEventArgs e)
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
        // calculate the top left corner for the panel based on header height
        int pX = pbxLeftBorder.Width;
        int pY = pnlTopBorder.Location.Y + pnlTopBorder.Height;
        // calculate the width of the panel based off the left edge to the start of the infoPanel border
        int pWidth = pnlInfoPanel.Location.X + pnlRightPanel.Location.X - pX;
        // calculate the height of the panel based off the height of the form minus the offset of the top of the panel
        int pHeight = Height - pY - pbxBottomBorder.Height;

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
        _pnlUpdateServerfiles.Location = new Point(pX, pY);
        _pnlUpdateServerfiles.Size = new Size(pWidth, pHeight);
        _pnlUpdateServerfiles.Visible = false;

        this.Controls.Add(_pnlUpdateServerfiles);

        _pnlUpdateServerfiles.BringToFront();
        _pnlUpdateServerfiles.ResumeLayout(false);
        _pnlUpdateServerfiles.PerformLayout();

    }
}
