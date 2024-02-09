using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Model;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

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
        ISteamCMDInstallerService steamCMDInstaller,
        IFileSystemService fileSystemManager,
        IVersionManagementService versionManager,
        ISystemProcessService processManager,
        IServerSettingsService serverSettingsService,
        IEnshroudedServerService server,
        IProfileService profileService,
        IDiscordService discordOutputService,
        IAdminPanelView adminPanelView)
    {
        _steamCMDInstaller = steamCMDInstaller;
        _fileSystemService = fileSystemManager;
        _versionManagementService = versionManager;
        _systemProcessService = processManager;
        _serverSettingsService = serverSettingsService;
        _profileService = profileService;
        _enshroudedServerService = server;
        _discordOutputService = discordOutputService;
        _adminPanelView = adminPanelView;

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

    private void OnInstallSteamCMDButtonClicked()
    {
        _steamCMDInstaller.Install();

        _adminPanelView.StartServerButtonState.Visible = true;
        _adminPanelView.InstallServerButtonState.Visible = true;

        _steamCMDInstaller.Start();
    }

    private void OnWindowsFirewallButtonClicked()
    {
        _systemProcessService.Start(Constants.ProcessNames.EXPLORER_EXE, Constants.Files.WINDOWS_FIREWALL);
    }

    private void OnStartServerButtonClicked()
    {
        // Display the Server Settings tab when they click Start Server
        // TODO: Dispatch a ServerStartedMessage so the main form can change the tab

        if (_selectedProfile is not null)
        {
            string selectedProfileName = _selectedProfile.Name;

            var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);
            _fileSystemService.CreateDirectory(serverProfilePath);

            var gameServerExe = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_EXE);

            // TODO: Handle the case where the game server can't be found
            if (!_fileSystemService.FileExists(gameServerExe))
            {
                return;
            }

            // TODO: Do we need to handle the case where the server is running? Generally the Start button
            // would not be displayed, but the stop button would in this case.
            _enshroudedServerService.Start(gameServerExe, selectedProfileName);

            // Begin AutoBackup after waiting 5 seconds to ensure the server process has started
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(5000);

                if (_enshroudedServerService.IsRunning(selectedProfileName))
                {
                    var profiles = _profileService.LoadServerProfiles(JsonSettings.Default);
                    var profile = profiles?.FirstOrDefault(x => x.Name == selectedProfileName);
                    if (profile is not null && profile.AutoBackup is not null && profile.AutoBackup.Enabled)
                    {
                        var saveGameFolder = Path.Join(serverProfilePath, Constants.Paths.GAME_SERVER_SAVE_FOLDER);

                        _backupService.StartAutoBackup(saveGameFolder, selectedProfileName, profile.AutoBackup.Interval, profile.AutoBackup.MaxiumBackups, Constants.Files.GAME_SERVER_CONFIG_JSON, serverProfilePath);
                    }
                }
            });

            if (_enshroudedServerService.IsRunning(selectedProfileName))
            {
                _adminPanelView.StartServerButtonState.Visible = false;
                _adminPanelView.StopServerButtonState.Visible = true;

                // TODO: Instead of hiding the button, we can disable it
                // Would need to set some styles for a disabled state for this to make sense
                _adminPanelView.UpdateServerButtonState.Visible = false;
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
                        Task.Factory.StartNew(async () =>
                        {
                            try
                            {
                                _discordOutputService.ServerOnline(name, DiscordUrl, discordProfile.EmbedEnabled, discordProfile.ServerOnlineMsg);
                            }
                            catch
                            {
                                // TODO: Raise an erorr event/Report an error message
                            }
                        });
                    }
                }
            }
        }
    }

    private void OnStopServerButtonClicked()
    {
        string selectedProfileName = _selectedProfile.Name;
        _enshroudedServerService.Stop(selectedProfileName);

        _adminPanelView.StartServerButtonState.Visible = true;
        _adminPanelView.StopServerButtonState.Visible = false;
        _adminPanelView.UpdateServerButtonState.Visible = true;

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

            _adminPanelView.InstallServerButtonState.Visible = false;
            _adminPanelView.UpdateServerButtonState.Visible = false;
            _adminPanelView.StartServerButtonState.Visible = false;

            _enshroudedServerService.InstallUpdate(Constants.STEAM_APP_ID, $"../{serverProfilePath}", selectedProfileName);

            _adminPanelView.UpdateServerButtonState.BorderColor = await _versionManagementService.ServerUpdateCheck(selectedProfileName);

            EventAggregator.Instance.Publish(new ServerInstallStoppedMessage());

            _adminPanelView.UpdateServerButtonState.Visible = true;
            _adminPanelView.StartServerButtonState.Visible = true;
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

            _adminPanelView.InstallServerButtonState.Visible = false;
            _adminPanelView.UpdateServerButtonState.Visible = false;
            _adminPanelView.StartServerButtonState.Visible = false;

            _enshroudedServerService.InstallUpdate(Constants.STEAM_APP_ID, $"../{serverProfilePath}", selectedProfileName);

            _adminPanelView.UpdateServerButtonState.BorderColor = await _versionManagementService.ServerUpdateCheck(selectedProfileName);

            EventAggregator.Instance.Publish(new ServerInstallStoppedMessage());

            _adminPanelView.UpdateServerButtonState.Visible = true;
            _adminPanelView.StartServerButtonState.Visible = true;
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

            Process.Start(Constants.ProcessNames.EXPLORER_EXE, backupserverfolder);
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
        RefreshServerButtonsVisibility(selectedProfile.Name);
        var color = await _versionManagementService.ServerUpdateCheck(selectedProfile.Name);
        _adminPanelView.UpdateServerButtonState = _adminPanelView.UpdateServerButtonState with
        {
            BorderColor = color
        };
    }

    private void RefreshServerButtonsVisibility(string selectedProfileName)
    {
        var gameServerExe = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Files.GAME_SERVER_EXE);

        _adminPanelView.StopServerButtonState.Visible = false;

        if (_fileSystemService.FileExists(Constants.ProcessNames.STEAM_CMD_EXE))
        {
            _adminPanelView.InstallServerButtonState.Visible = true;
            _adminPanelView.StartServerButtonState.Visible = true;
        }

        if (_fileSystemService.FileExists(gameServerExe))
        {
            _adminPanelView.InstallServerButtonState.Visible = false;
            _adminPanelView.UpdateServerButtonState.Visible = true;
        }
        else
        {
            _adminPanelView.InstallServerButtonState.Visible = true;
            _adminPanelView.UpdateServerButtonState.Visible = false;
        }

        if (!_fileSystemService.FileExists(Constants.ProcessNames.STEAM_CMD_EXE))
        {
            _adminPanelView.InstallServerButtonState.Visible = false;
            _adminPanelView.StartServerButtonState.Visible = false;
        }

        try
        {
            if (_enshroudedServerService.IsRunning(selectedProfileName))
            {
                _adminPanelView.StartServerButtonState.Visible = false;
                _adminPanelView.StopServerButtonState.Visible = true;
                _adminPanelView.UpdateServerButtonState.Visible = false;
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
