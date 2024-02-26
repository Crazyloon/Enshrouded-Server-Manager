using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager.Presenters;
public class AdminPanelPresenter
{
    private readonly IAdminPanelView _adminPanelView;
    private readonly IEventAggregator _eventAggregator;
    private readonly ISteamCMDInstallerService _steamCMDInstaller;
    private readonly IFileSystemService _fileSystemService;
    private readonly IVersionManagementService _versionManagementService;
    private readonly ISystemProcessService _systemProcessService;
    private readonly IServerSettingsService _serverSettingsService;
    private readonly IEnshroudedServerService _enshroudedServerService;
    private readonly IProfileService _profileService;
    private readonly IDiscordService _discordOutputService;
    private readonly IBackupService _backupService;
    private readonly IFileLoggerService _logger;
    private readonly IScheduledRestartService _scheduledRestartService;

    Dictionary<string, CountDownTimer> _restartTimers;
    private ServerProfile _selectedProfile;


    public AdminPanelPresenter(
        IAdminPanelView adminPanelView,
        IEventAggregator eventAggregator,
        ISteamCMDInstallerService steamCMDInstaller,
        IFileSystemService fileSystemManager,
        IVersionManagementService versionManager,
        ISystemProcessService processManager,
        IServerSettingsService serverSettingsService,
        IEnshroudedServerService server,
        IProfileService profileService,
        IDiscordService discordOutputService,
        IBackupService backupService,
        IFileLoggerService fileLogger,
        IScheduledRestartService scheduledRestartService,
        Dictionary<string, CountDownTimer> restartTimers)
    {
        _adminPanelView = adminPanelView;
        _eventAggregator = eventAggregator;
        _steamCMDInstaller = steamCMDInstaller;
        _fileSystemService = fileSystemManager;
        _versionManagementService = versionManager;
        _systemProcessService = processManager;
        _serverSettingsService = serverSettingsService;
        _profileService = profileService;
        _enshroudedServerService = server;
        _discordOutputService = discordOutputService;
        _backupService = backupService;
        _logger = fileLogger;
        _scheduledRestartService = scheduledRestartService;
        _restartTimers = restartTimers;

        adminPanelView.AdminPanelLoaded += (s, e) => OnAdminPanelLoaded();
        adminPanelView.InstallSteamCMDButtonClicked += (s, e) => OnInstallSteamCMDButtonClicked();
        adminPanelView.WindowsFirewallButtonClicked += (s, e) => OnWindowsFirewallButtonClicked();
        adminPanelView.StartServerButtonClicked += (s, e) => OnStartServerButtonClicked();
        adminPanelView.StopServerButtonClicked += (s, e) => OnStopServerButtonClicked();
        adminPanelView.InstallServerButtonClicked += (s, e) => OnInstallServerButtonClicked();
        adminPanelView.UpdateServerButtonClicked += (s, e) => OnUpdateServerButtonClicked();
        adminPanelView.SaveBackupButtonClicked += (s, e) => OnSaveBackupButtonClicked();
        adminPanelView.OpenBackupFolderButtonClicked += (s, e) => OnOpenBackupFolderButtonClicked();
        adminPanelView.OpenSavegameFolderButtonClicked += (s, e) => OnOpenSavegameFolderButtonClicked();
        adminPanelView.OpenLogFolderButtonClicked += (s, e) => OnOpenLogFolderButtonClicked();

        _eventAggregator.Subscribe<ProfileSelectedMessage>(p => OnProfileSelected(p.SelectedProfile));
        _eventAggregator.Subscribe<ServerStartedMessage>(p => OnServerStarted(p.ServerProfile));
        _eventAggregator.Subscribe<ServerStoppedMessage>(p => OnServerStopped(p.ServerProfile));
    }

    private void OnServerStarted(ServerProfile serverProfile)
    {
        // Handle button visibility
        _adminPanelView.StartServerButtonVisible = false;
        _adminPanelView.StopServerButtonVisible = true;
        // TODO: Instead of hiding the button, we can disable it
        // Would need to set some styles for a disabled state for this to make sense
        //_adminPanelView.UpdateServerButtonEnabled = false;
        _adminPanelView.UpdateServerButtonVisible = false;
    }

    private void OnServerStopped(ServerProfile serverProfile)
    {
        _adminPanelView.StartServerButtonVisible = true;
        _adminPanelView.StopServerButtonVisible = false;
        _adminPanelView.UpdateServerButtonVisible = true;
    }

    private async void OnAdminPanelLoaded()
    {
        if (_selectedProfile is not null)
        {
            _adminPanelView.UpdateServerButtonBorderColor = await _enshroudedServerService.ServerUpdateCheck(_selectedProfile.Name);
        }

        var timer = new PeriodicTimer(TimeSpan.FromMinutes(Constants.TIMER_INTERVAL_SERVER_UPDATE_CHECK));
        while (await timer.WaitForNextTickAsync())
        {
            if (_selectedProfile is not null)
            {
                _adminPanelView.UpdateServerButtonBorderColor = await _enshroudedServerService.ServerUpdateCheck(_selectedProfile.Name);
            }
        }
    }

    private void OnInstallSteamCMDButtonClicked()
    {
        _steamCMDInstaller.Install();

        _adminPanelView.StartServerButtonVisible = true;
        _adminPanelView.InstallServerButtonVisible = true;

        _steamCMDInstaller.Start();
    }

    private void OnWindowsFirewallButtonClicked()
    {
        _systemProcessService.Start(Constants.ProcessNames.EXPLORER_EXE, Constants.Files.WINDOWS_FIREWALL);
    }

    private void OnStartServerButtonClicked()
    {
        if (_selectedProfile is not null)
        {
            var serverProfilePath = Path.Join(Constants.Paths.SERVER_DIRECTORY, _selectedProfile.Name);
            _fileSystemService.CreateDirectory(serverProfilePath);

            var gameServerExe = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_EXE);

            // TODO: Handle the case where the game server can't be found
            if (!_fileSystemService.FileExists(gameServerExe))
            {
                return;
            }

            _enshroudedServerService.Start(gameServerExe, _selectedProfile);
            _scheduledRestartService.StartScheduledRestarts(_selectedProfile);


            if (_enshroudedServerService.IsRunning(_selectedProfile.Name))
            {
                // Begin AutoBackup
                if (_selectedProfile.AutoBackup is not null
                    && _selectedProfile.AutoBackup.Enabled)
                {
                    var saveGameFolder = Path.Join(serverProfilePath, Constants.Paths.GAME_SERVER_SAVE_DIRECTORY);
                    _backupService.StartAutoBackup(saveGameFolder, _selectedProfile, _selectedProfile.AutoBackup.Interval, _selectedProfile.AutoBackup.MaxiumBackups, Constants.Files.GAME_SERVER_CONFIG_JSON, serverProfilePath);
                }

                _eventAggregator.Publish(new ServerStartedMessage(_selectedProfile));
            }

            // discord Output
            _discordOutputService.SendMessage(_selectedProfile, DiscordMessageType.ServerStarted);
        }
    }

    private void OnStopServerButtonClicked()
    {
        string selectedProfileName = _selectedProfile.Name;
        _enshroudedServerService.Stop(_selectedProfile);

        // Stop any running auto restart timers
        _restartTimers.TryGetValue(selectedProfileName, out var timer);
        if (timer is not null)
        {
            _logger.LogInfo($"AdminPanelPresenter: OnStopServerButtonClicked: Timer stopped for {_selectedProfile.Name}: TimerTag: {timer.Tag}");
            timer?.EndTimer();
            timer = null;
            _restartTimers.Remove(selectedProfileName);
        }

        _discordOutputService.SendMessage(_selectedProfile, DiscordMessageType.ServerStopped);
    }

    private async void OnInstallServerButtonClicked()
    {
        if (_selectedProfile is not null)
        {
            string selectedProfileName = _selectedProfile.Name;
            var serverProfilePath = Path.Join(Constants.Paths.SERVER_DIRECTORY, selectedProfileName);

            _eventAggregator.Publish(new ServerInstallStartedMessage());

            _adminPanelView.InstallServerButtonVisible = false;
            _adminPanelView.UpdateServerButtonVisible = false;
            _adminPanelView.StartServerButtonVisible = false;

            _enshroudedServerService.Install($"../{serverProfilePath}");

            _adminPanelView.UpdateServerButtonBorderColor = await _enshroudedServerService.ServerUpdateCheck(selectedProfileName);

            _eventAggregator.Publish(new ServerInstallStoppedMessage());

            _adminPanelView.UpdateServerButtonVisible = true;
            _adminPanelView.StartServerButtonVisible = true;
        }
    }

    private async void OnUpdateServerButtonClicked()
    {
        if (_selectedProfile is not null)
        {
            string selectedProfileName = _selectedProfile.Name;

            _discordOutputService.SendMessage(_selectedProfile, DiscordMessageType.ServerUpdating);

            // show update overlay
            _eventAggregator.Publish(new ServerInstallStartedMessage());
            _adminPanelView.InstallServerButtonVisible = false;
            _adminPanelView.UpdateServerButtonVisible = false;
            _adminPanelView.StartServerButtonVisible = false;

            var serverProfilePath = Path.Join(Constants.Paths.SERVER_DIRECTORY, selectedProfileName);
            _enshroudedServerService.Update();

            _adminPanelView.UpdateServerButtonBorderColor = await _enshroudedServerService.ServerUpdateCheck(selectedProfileName);

            // hide update overlay
            _eventAggregator.Publish(new ServerInstallStoppedMessage());
            _adminPanelView.UpdateServerButtonVisible = true;
            _adminPanelView.StartServerButtonVisible = true;
        }
    }

    private void OnSaveBackupButtonClicked()
    {
        if (_selectedProfile is not null)
        {
            var serverProfileDirectory = Path.Join(Constants.Paths.SERVER_DIRECTORY, _selectedProfile.Name);
            var saveGameDirectory = Path.Join(serverProfileDirectory, Constants.Paths.GAME_SERVER_SAVE_DIRECTORY);

            _backupService.Save(saveGameDirectory, _selectedProfile, Constants.Files.GAME_SERVER_CONFIG_JSON, serverProfileDirectory);
        }
    }

    private void OnOpenBackupFolderButtonClicked()
    {
        if (_selectedProfile is not null)
        {
            string selectedProfileName = _selectedProfile.Name;
            string backupserverfolder = Path.Join(Constants.Paths.BACKUPS_DIRECTORY, selectedProfileName);

            _fileSystemService.CreateDirectory(backupserverfolder);

            _systemProcessService.Start(Constants.ProcessNames.EXPLORER_EXE, backupserverfolder);
        }
    }

    private void OnOpenSavegameFolderButtonClicked()
    {
        if (_selectedProfile is not null)
        {
            string selectedProfileName = _selectedProfile.Name;
            string savegamefolder = Path.Join(Constants.Paths.SERVER_DIRECTORY, selectedProfileName, Constants.Paths.GAME_SERVER_SAVE_DIRECTORY);
            _fileSystemService.CreateDirectory(savegamefolder);

            _systemProcessService.Start(Constants.ProcessNames.EXPLORER_EXE, savegamefolder);
        }
    }

    private void OnOpenLogFolderButtonClicked()
    {
        if (_selectedProfile is not null)
        {
            string selectedProfileName = _selectedProfile.Name;
            string logfolder = Path.Join(Constants.Paths.SERVER_DIRECTORY, selectedProfileName, Constants.Paths.GAME_SERVER_LOGS_DIRECTORY);
            _fileSystemService.CreateDirectory(logfolder);

            _systemProcessService.Start(Constants.ProcessNames.EXPLORER_EXE, logfolder);
        }
    }

    public async void OnProfileSelected(ServerProfile selectedProfile)
    {
        _selectedProfile = selectedProfile;
        if (_selectedProfile is not null)
        {
            RefreshServerButtonsVisibility(selectedProfile.Name);
            // TODO: Could skip this work if we first check if the server is installed, since the update button doesn't show if it's not
            var color = await _enshroudedServerService.ServerUpdateCheck(selectedProfile.Name);
            _adminPanelView.UpdateServerButtonBorderColor = color;
        }
    }

    private void RefreshServerButtonsVisibility(string selectedProfileName)
    {
        var gameServerExe = Path.Join(Constants.Paths.SERVER_DIRECTORY, selectedProfileName, Constants.Files.GAME_SERVER_EXE);

        _adminPanelView.StopServerButtonVisible = false;

        if (_fileSystemService.FileExists(Constants.ProcessNames.STEAM_CMD_EXE))
        {
            _adminPanelView.InstallServerButtonVisible = true;
            _adminPanelView.StartServerButtonVisible = true;
        }

        if (_fileSystemService.FileExists(gameServerExe))
        {
            _adminPanelView.InstallServerButtonVisible = false;
            _adminPanelView.UpdateServerButtonVisible = true;
        }
        else
        {
            _adminPanelView.InstallServerButtonVisible = true;
            _adminPanelView.UpdateServerButtonVisible = false;
            _adminPanelView.StartServerButtonVisible = false;
        }

        if (!_fileSystemService.FileExists(Constants.ProcessNames.STEAM_CMD_EXE))
        {
            _adminPanelView.InstallServerButtonVisible = false;
            _adminPanelView.StartServerButtonVisible = false;
        }

        try
        {
            if (_enshroudedServerService.IsRunning(selectedProfileName))
            {
                _adminPanelView.StartServerButtonVisible = false;
                _adminPanelView.StopServerButtonVisible = true;
                _adminPanelView.UpdateServerButtonVisible = false;
            }
        }
        catch (Exception)
        {
            var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, selectedProfileName, Constants.Files.PID_JSON);

            if (_fileSystemService.FileExists(pidJsonFile))
            {
                _fileSystemService.DeleteFile(pidJsonFile);
            }
        }
    }
}
