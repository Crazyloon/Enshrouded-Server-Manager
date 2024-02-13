using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Presenters;
public class ManageProfilesPresenter
{
    private readonly IManageProfilesView _manageProfilesView;
    private readonly IEventAggregator _eventAggregator;
    private readonly IProfileService _profileManager;
    private readonly IServerSettingsService _serverSettingsService;
    private readonly IFileSystemService _fileSystemService;
    private readonly IMessageBoxService _messageBox;
    private readonly IEnshroudedServerService _server;

    private BindingList<ServerProfile>? _profiles;


    public ManageProfilesPresenter(IManageProfilesView manageProfilesView,
        IEventAggregator eventAggregator,
        IProfileService profileManager,
        IServerSettingsService serverSettingsService,
        IFileSystemService fileSystemManager,
        IMessageBoxService messageBox,
        IEnshroudedServerService server,
        BindingList<ServerProfile>? serverProfiles)
    {
        _manageProfilesView = manageProfilesView;
        _eventAggregator = eventAggregator;
        _profileManager = profileManager;
        _serverSettingsService = serverSettingsService;
        _fileSystemService = fileSystemManager;
        _messageBox = messageBox;
        _server = server;

        _profiles = serverProfiles;

        _manageProfilesView.SaveProfileNameButtonClicked += (sender, args) => OnSaveProfileNameClicked();

        _eventAggregator.Subscribe<ProfileSelectedMessage>(m => OnProfileSelected(m.SelectedProfile));
    }

    private void OnProfileSelected(ServerProfile selectedProfile)
    {
        _manageProfilesView.SelectedProfile = selectedProfile;
        _manageProfilesView.EditProfileName = _manageProfilesView.SelectedProfile?.Name;
    }

    public void OnSaveProfileNameClicked()
    {
        var reservedProfileNames = new string[] { "AutoBackup" };
        string editProfileName = _manageProfilesView.EditProfileName;

        var serverProfilePath = Path.Join(Constants.Paths.SERVER_DIRECTORY, editProfileName);
        if (_fileSystemService.DirectoryExists(serverProfilePath))
        {
            return;
        }

        if (_manageProfilesView.SelectedProfile is null)
        {
            return;
        }

        string selectedServerProfile = _manageProfilesView.SelectedProfile.Name;

        if (_server.IsRunning(selectedServerProfile))
        {
            _messageBox.Show(Constants.Errors.SERVER_RUNNING_ERROR_MESSAGE, Constants.Errors.SERVER_RUNNING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return;
        }

        // Validate:
        // Not Null
        // Windows File Name Does not have Special Characters
        // Not the same as an existing profile name
        // Not allowed to use ReservedNames
        if (editProfileName is null
            || !_profileManager.IsProfileNameValid(editProfileName)
            || selectedServerProfile == editProfileName
            || reservedProfileNames.Contains(editProfileName))
        {
            return;
        }

        // get the selected profile

        // rename the server settings folder
        _profileManager.RenameServerSettings(selectedServerProfile, editProfileName);

        if (_fileSystemService.DirectoryExists(serverProfilePath))
        {
            // update the name
            _manageProfilesView.SelectedProfile.Name = editProfileName;

            // write the new profile to the json file
            var output = JsonConvert.SerializeObject(_profiles, JsonSettings.Default);
            var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.SERVER_PROFILES_JSON);

            _fileSystemService.WriteFile(serverProfilesJson, output);

            // rename backup folder
            var oldBackupFolder = Path.Join(Constants.Paths.BACKUPS_DIRECTORY, selectedServerProfile);
            var newBackupFolder = Path.Join(Constants.Paths.BACKUPS_DIRECTORY, editProfileName);
            if (!_fileSystemService.DirectoryExists(oldBackupFolder))
            {
                _fileSystemService.CreateDirectory(oldBackupFolder);
            }
            if (!_fileSystemService.RenameDirectory(oldBackupFolder, newBackupFolder))
            {
                _messageBox.Show(Constants.Errors.BACKUP_ERROR_MESSAGE, Constants.Errors.BACKUP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // rename autobackup folder
            var oldAutoBackupFolder = Path.Join(Constants.Paths.AUTOBACKUPS_DIRECTORY, selectedServerProfile);
            var newAutoBackupFolder = Path.Join(Constants.Paths.AUTOBACKUPS_DIRECTORY, editProfileName);
            if (!_fileSystemService.DirectoryExists(oldAutoBackupFolder))
            {
                _fileSystemService.CreateDirectory(oldAutoBackupFolder);
            }
            if (!_fileSystemService.RenameDirectory(oldAutoBackupFolder, newAutoBackupFolder))
            {
                _messageBox.Show(Constants.Errors.AUTOBACKUP_ERROR_MESSAGE, Constants.Errors.AUTOBACKUP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Hide the panel
            _manageProfilesView.IsVisible = false;
        }

    }
}
