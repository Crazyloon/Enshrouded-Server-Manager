using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Presenters;
public class ProfileSelectorPresenter
{
    private readonly IProfileSelectorView _profileSelectorView;
    private readonly IManageProfilesView _manageProfilesView;
    private readonly IEventAggregator _eventAggregator;
    private readonly IProfileService _profileManager;
    private readonly IServerSettingsService _serverSettingsService;
    private readonly IFileSystemService _fileSystemService;
    private readonly IMessageBoxService _messageBox;
    private readonly IEnshroudedServerService _server;
    private readonly IFileLoggerService _logger;

    private BindingList<ServerProfile>? _profiles;

    public ProfileSelectorPresenter(IProfileSelectorView profileSelectorView,
        IManageProfilesView manageProfilesView,
        IEventAggregator eventAggregator,
        IProfileService profileManager,
        IServerSettingsService serverSettingsService,
        IFileSystemService fileSystemManager,
        IMessageBoxService messageBox,
        IEnshroudedServerService server,
        IFileLoggerService fileLogger,
        BindingList<ServerProfile>? serverProfiles)
    {
        _profileSelectorView = profileSelectorView;
        _manageProfilesView = manageProfilesView;
        _eventAggregator = eventAggregator;
        _profileManager = profileManager;
        _serverSettingsService = serverSettingsService;
        _fileSystemService = fileSystemManager;
        _messageBox = messageBox;
        _server = server;
        _profiles = serverProfiles;
        _logger = fileLogger;

        profileSelectorView.SelectedProfileChanged += (sender, args) => OnSelectedProfileChanged();
        profileSelectorView.AddProfileButtonClicked += (sender, args) => OnAddProfileClicked();
        profileSelectorView.DeleteProfileButtonClicked += (sender, args) => OnDeleteProfileClicked();
        profileSelectorView.RenameProfileButtonClicked += (sender, args) => OnRenameProfileClicked();

        LoadProfiles(_profiles);
        _manageProfilesView.Position = new Point(207, 40);
    }

    private void OnSelectedProfileChanged()
    {
        _eventAggregator.Publish(new ProfileSelectedMessage(_profileSelectorView.SelectedProfile));
    }

    private void OnAddProfileClicked()
    {
        // Generate a new Server name semi-randomly, avoiding duplicates
        var profileName = GenerateText.RandomServerName(6);
        while (_profiles.Any(x => x.Name == profileName))
        {
            profileName = GenerateText.RandomServerName(6);
        }

        _profiles.Add(new ServerProfile()
        {
            Name = profileName
        });

        // write the new profile to the json file
        _fileSystemService.WriteFile(
            Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.SERVER_PROFILES_JSON),
            JsonConvert.SerializeObject(_profiles, JsonSettings.Default));

        // Create the server profile directory and load it's settings
        _serverSettingsService.LoadServerSettings(profileName);

        _eventAggregator.Publish(new ProfileSelectedMessage(_profileSelectorView.SelectedProfile));
    }

    private void OnDeleteProfileClicked()
    {
        if (_profileSelectorView.SelectedProfile is not null)
        {
            if (_server.IsRunning(_profileSelectorView.SelectedProfile.Name))
            {
                _messageBox.Show(Constants.Errors.SERVER_RUNNING_ERROR_MESSAGE, Constants.Errors.SERVER_RUNNING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = _messageBox.Show(Constants.Warnings.DELETE_PROFILE_WARNING_MESSAGE, Constants.Warnings.DELETE_PROFILE_WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
            {
                return;
            }

            var serverProfilePath = Path.Join(Constants.Paths.SERVER_DIRECTORY, _profileSelectorView.SelectedProfile.Name);
            var autoBackupPath = Path.Join(Constants.Paths.AUTOBACKUPS_DIRECTORY, _profileSelectorView.SelectedProfile.Name);
            var backupPath = Path.Join(Constants.Paths.BACKUPS_DIRECTORY, _profileSelectorView.SelectedProfile.Name);

            // rename directory to check if in use
            try
            {
                if (_fileSystemService.DirectoryExists(serverProfilePath))
                {
                    _fileSystemService.MoveDirectory(serverProfilePath, $"{serverProfilePath}_delete");
                }
                if (_fileSystemService.DirectoryExists(autoBackupPath))
                {
                    _fileSystemService.MoveDirectory(autoBackupPath, $"{autoBackupPath}_delete");
                }
                if (_fileSystemService.DirectoryExists(backupPath))
                {
                    _fileSystemService.MoveDirectory(backupPath, $"{backupPath}_delete");
                }

            }
            catch (Exception ex)
            {
                _messageBox.Show(string.Format(Constants.Errors.DELETE_PROFILE_ERROR_MESSAGE, ex.Message),
                    Constants.Errors.DELETE_PROFILE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (_fileSystemService.DirectoryExists($"{autoBackupPath}_delete"))
            {
                _fileSystemService.DeleteDirectory($"{autoBackupPath}_delete");
            }
            if (_fileSystemService.DirectoryExists($"{backupPath}_delete"))
            {
                _fileSystemService.DeleteDirectory($"{backupPath}_delete");
            }

            if (_fileSystemService.DirectoryExists($"{serverProfilePath}_delete"))
            {
                // Delete the server folder
                _fileSystemService.DeleteDirectory($"{serverProfilePath}_delete");

                // remove the profile
                // if the deleted profile is not last, need to select the next profile
                var index = _profiles.IndexOf(_profileSelectorView.SelectedProfile);
                var nextProfile = _profiles.ElementAtOrDefault(index + 1);

                _profiles.Remove(_profileSelectorView.SelectedProfile);

                // write the new profile to the json file
                _fileSystemService.WriteFile(
                    Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.SERVER_PROFILES_JSON),
                    JsonConvert.SerializeObject(_profiles, JsonSettings.Default));

                //clear cache pid file
                var pidJsonFile = $"{Constants.Paths.CACHE_DIRECTORY}{_profileSelectorView.SelectedProfile}{Constants.Files.PID_JSON}";

                if (_fileSystemService.FileExists(pidJsonFile))
                {
                    _fileSystemService.DeleteFile(pidJsonFile);
                }

                if (nextProfile is not null)
                {
                    _eventAggregator.Publish(new ProfileSelectedMessage(nextProfile));
                }
            }

        }
    }

    private void OnRenameProfileClicked()
    {
        _manageProfilesView.IsVisible = !_manageProfilesView.IsVisible;
        _manageProfilesView.FocuseEditProfileName();
    }

    private void LoadProfiles(BindingList<ServerProfile>? profiles)
    {
        if (profiles is not null && profiles.Any())
        {
            _profiles = profiles;
        }
        else
        {
            _profiles = new BindingList<ServerProfile>(_profileManager.LoadServerProfiles(JsonSettings.Default));
        }

        if (_profiles is not null && _profiles.Any())
        {
            _profileSelectorView.SetProfiles(_profiles);
        }
    }
}
