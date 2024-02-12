using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Model;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using Newtonsoft.Json;

namespace Enshrouded_Server_Manager.Presenters;
public class AdminPanelPresenter
{
    private readonly IAdminPanelView _adminPanelView;
    private readonly ISteamCMDInstallerService _steamCMDInstaller;
    private readonly IFileSystemService _fileSystemService;
    private readonly IVersionManagementService _versionManagementService;
    private readonly ISystemProcessService _systemProcessService;
    private readonly IServerSettingsService _serverSettingsService;
    private readonly IEnshroudedServerService _enshroudedServerService;
    private readonly IProfileService _profileService;
    private readonly IDiscordService _discordOutputService;
    private readonly IBackupService _backupService;

    private ServerProfile _selectedProfile;

    public AdminPanelPresenter(
        IAdminPanelView adminPanelView,
        ISteamCMDInstallerService steamCMDInstaller,
        IFileSystemService fileSystemManager,
        IVersionManagementService versionManager,
        ISystemProcessService processManager,
        IServerSettingsService serverSettingsService,
        IEnshroudedServerService server,
        IProfileService profileService,
        IDiscordService discordOutputService,
        IBackupService backupService)
    {
        _steamCMDInstaller = steamCMDInstaller;
        _fileSystemService = fileSystemManager;
        _versionManagementService = versionManager;
        _systemProcessService = processManager;
        _serverSettingsService = serverSettingsService;
        _profileService = profileService;
        _enshroudedServerService = server;
        _discordOutputService = discordOutputService;
        _backupService = backupService;
        _adminPanelView = adminPanelView;

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

        EventAggregator.Instance.Subscribe<ProfileSelectedMessage>(p => OnProfileSelected(p.SelectedProfile));
    }

    private async void OnAdminPanelLoaded()
    {
        if (_selectedProfile is not null)
        {
            _adminPanelView.UpdateServerButtonBorderColor = await _versionManagementService.ServerUpdateCheck(_selectedProfile.Name);
        }

        var timer = new PeriodicTimer(TimeSpan.FromMinutes(Constants.TIMER_INTERVAL_SERVER_UPDATE_CHECK));
        while (await timer.WaitForNextTickAsync())
        {
            if (_selectedProfile is not null)
            {
                _adminPanelView.UpdateServerButtonBorderColor = await _versionManagementService.ServerUpdateCheck(_selectedProfile.Name);
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
            var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, _selectedProfile.Name);
            _fileSystemService.CreateDirectory(serverProfilePath);

            var gameServerExe = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_EXE);

            // TODO: Handle the case where the game server can't be found
            if (!_fileSystemService.FileExists(gameServerExe))
            {
                return;
            }

            _enshroudedServerService.Start(gameServerExe, _selectedProfile.Name);

            // Begin AutoBackup after waiting 5 seconds to ensure the server process has started
            if (_enshroudedServerService.IsRunning(_selectedProfile.Name))
            {
                if (_selectedProfile is not null && _selectedProfile.AutoBackup is not null && _selectedProfile.AutoBackup.Enabled)
                {
                    var saveGameFolder = Path.Join(serverProfilePath, Constants.Paths.GAME_SERVER_SAVE_FOLDER);
                    _backupService.StartAutoBackup(saveGameFolder, _selectedProfile.Name, _selectedProfile.AutoBackup.Interval, _selectedProfile.AutoBackup.MaxiumBackups, Constants.Files.GAME_SERVER_CONFIG_JSON, serverProfilePath);
                }
            }

            if (_enshroudedServerService.IsRunning(_selectedProfile.Name))
            {
                _adminPanelView.StartServerButtonVisible = false;
                _adminPanelView.StopServerButtonVisible = true;

                // TODO: Instead of hiding the button, we can disable it
                // Would need to set some styles for a disabled state for this to make sense
                //_adminPanelView.UpdateServerButtonEnabled = false;
                _adminPanelView.UpdateServerButtonVisible = false;
            }

            // discord Output
            var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.DISCORD_JSON);
            if (_fileSystemService.FileExists(discordSettingsFile))
            {
                var discordSettingsText = _fileSystemService.ReadFile(discordSettingsFile);
                DiscordProfile discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, JsonSettings.Default);
                string DiscordUrl = discordProfile.DiscordUrl;

                var gameServerConfig = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_CONFIG_JSON);
                var gameServerConfigText = _fileSystemService.ReadFile(gameServerConfig);
                ServerSettings serverSettings = JsonConvert.DeserializeObject<ServerSettings>(gameServerConfigText, JsonSettings.Default);
                string name = serverSettings.Name;

                if (discordProfile.Enabled)
                {
                    if (discordProfile.StartEnabled)
                    {
                        try
                        {
                            _discordOutputService.ServerOnline(name, DiscordUrl, discordProfile.EmbedEnabled, discordProfile.ServerStartedMsg);
                        }
                        catch
                        {
                            // TODO: Raise an erorr event/Report an error message
                        }
                    }
                }
            }
        }
    }

    private void OnStopServerButtonClicked()
    {
        string selectedProfileName = _selectedProfile.Name;
        _enshroudedServerService.Stop(selectedProfileName);

        _adminPanelView.StartServerButtonVisible = true;
        _adminPanelView.StopServerButtonVisible = false;
        _adminPanelView.UpdateServerButtonVisible = true;

        // TODO: Can we emit an event here and have something else handle discord output?
        // discord Output
        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.DISCORD_JSON);
        if (_fileSystemService.FileExists(discordSettingsFile))
        {
            var discordSettingsText = _fileSystemService.ReadFile(discordSettingsFile);
            DiscordProfile discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, JsonSettings.Default);
            string DiscordUrl = discordProfile.DiscordUrl;

            var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);
            var gameServerConfig = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_CONFIG_JSON);
            var gameServerConfigText = _fileSystemService.ReadFile(gameServerConfig);
            ServerSettings gameServerSettings = JsonConvert.DeserializeObject<ServerSettings>(gameServerConfigText, JsonSettings.Default);
            string name = gameServerSettings.Name;

            if (discordProfile.Enabled)
            {
                if (discordProfile.StopEnabled)
                {
                    Task.Factory.StartNew(async () =>
                    {
                        try
                        {
                            _discordOutputService.ServerOffline(name, DiscordUrl, discordProfile.EmbedEnabled, discordProfile.ServerStoppedMsg);
                        }
                        catch
                        {

                        }
                    });
                }
            }
        }
    }

    private async void OnInstallServerButtonClicked()
    {
        if (_selectedProfile is not null)
        {
            string selectedProfileName = _selectedProfile.Name;
            var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);

            EventAggregator.Instance.Publish(new ServerInstallStartedMessage());

            _adminPanelView.InstallServerButtonVisible = false;
            _adminPanelView.UpdateServerButtonVisible = false;
            _adminPanelView.StartServerButtonVisible = false;

            _enshroudedServerService.InstallUpdate(Constants.STEAM_APP_ID, $"../{serverProfilePath}", selectedProfileName);

            _adminPanelView.UpdateServerButtonBorderColor = await _versionManagementService.ServerUpdateCheck(selectedProfileName);

            EventAggregator.Instance.Publish(new ServerInstallStoppedMessage());

            _adminPanelView.UpdateServerButtonVisible = true;
            _adminPanelView.StartServerButtonVisible = true;
        }
    }

    private async void OnUpdateServerButtonClicked()
    {
        if (_selectedProfile is not null)
        {
            string selectedProfileName = _selectedProfile.Name;
            var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);

            // TODO: Move this into the discord service
            // discord Output
            var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.DISCORD_JSON);
            if (_fileSystemService.FileExists(discordSettingsFile))
            {
                var discordSettingsText = _fileSystemService.ReadFile(discordSettingsFile);
                DiscordProfile discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, JsonSettings.Default);
                string discordUrl = discordProfile.DiscordUrl;

                var gameServerConfig = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_CONFIG_JSON);
                var gameServerConfigText = _fileSystemService.ReadFile(gameServerConfig);
                ServerSettings gameServerSettings = JsonConvert.DeserializeObject<ServerSettings>(gameServerConfigText, JsonSettings.Default);
                string name = gameServerSettings.Name;

                if (discordProfile.Enabled)
                {
                    if (discordProfile.UpdatingEnabled)
                    {

                        try
                        {
                            _discordOutputService.ServerUpdating(name, discordUrl, discordProfile.EmbedEnabled, discordProfile.ServerUpdatingMsg);
                        }
                        catch
                        {

                        }
                    }
                }
            }

            EventAggregator.Instance.Publish(new ServerInstallStartedMessage());
            _adminPanelView.InstallServerButtonVisible = false;
            _adminPanelView.UpdateServerButtonVisible = false;
            _adminPanelView.StartServerButtonVisible = false;

            _enshroudedServerService.InstallUpdate(Constants.STEAM_APP_ID, $"../{serverProfilePath}", selectedProfileName);

            _adminPanelView.UpdateServerButtonBorderColor = await _versionManagementService.ServerUpdateCheck(selectedProfileName);
            EventAggregator.Instance.Publish(new ServerInstallStoppedMessage());
            _adminPanelView.UpdateServerButtonVisible = true;
            _adminPanelView.StartServerButtonVisible = true;
        }
    }

    private void OnSaveBackupButtonClicked()
    {
        if (_selectedProfile is not null)
        {
            string selectedProfileName = _selectedProfile.Name;

            var serverProfileDirectory = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);
            var saveGameDirectory = Path.Join(serverProfileDirectory, Constants.Paths.GAME_SERVER_SAVE_FOLDER);

            _backupService.Save(saveGameDirectory, selectedProfileName, Constants.Files.GAME_SERVER_CONFIG_JSON, serverProfileDirectory);
        }
    }

    private void OnOpenBackupFolderButtonClicked()
    {
        if (_selectedProfile is not null)
        {
            string selectedProfileName = _selectedProfile.Name;
            string backupserverfolder = Path.Join(Constants.Paths.BACKUPS_FOLDER, selectedProfileName);

            _fileSystemService.CreateDirectory(backupserverfolder);

            _systemProcessService.Start(Constants.ProcessNames.EXPLORER_EXE, backupserverfolder);
        }
    }

    private void OnOpenSavegameFolderButtonClicked()
    {
        if (_selectedProfile is not null)
        {
            string selectedProfileName = _selectedProfile.Name;
            string savegamefolder = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Paths.GAME_SERVER_SAVE_FOLDER);
            _fileSystemService.CreateDirectory(savegamefolder);

            _systemProcessService.Start(Constants.ProcessNames.EXPLORER_EXE, savegamefolder);
        }
    }

    private void OnOpenLogFolderButtonClicked()
    {
        if (_selectedProfile is not null)
        {
            string selectedProfileName = _selectedProfile.Name;
            string logfolder = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Paths.GAME_SERVER_LOGS_FOLDER);
            _fileSystemService.CreateDirectory(logfolder);

            _systemProcessService.Start(Constants.ProcessNames.EXPLORER_EXE, logfolder);
        }
    }

    private async void OnProfileSelected(ServerProfile selectedProfile)
    {
        _selectedProfile = selectedProfile;
        if (_selectedProfile is not null)
        {
            RefreshServerButtonsVisibility(selectedProfile.Name);
            // TODO: Could skip this work if we first check if the server is installed, since the update button doesn't show if it's not
            var color = await _versionManagementService.ServerUpdateCheck(selectedProfile.Name);
            _adminPanelView.UpdateServerButtonBorderColor = color;
        }
    }

    private void RefreshServerButtonsVisibility(string selectedProfileName)
    {
        var gameServerExe = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Files.GAME_SERVER_EXE);

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
