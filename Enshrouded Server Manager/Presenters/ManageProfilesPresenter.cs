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
    private readonly IProfileService _profileManager;
    private readonly IServerSettingsService _serverSettingsService;
    private readonly IFileSystemService _fileSystemService;
    private readonly IMessageBoxService _messageBox;
    private readonly IEnshroudedServerService _server;

    private BindingList<ServerProfile>? _profiles;


    public ManageProfilesPresenter(IManageProfilesView manageProfilesView,
        IProfileService profileManager,
        IServerSettingsService serverSettingsService,
        IFileSystemService fileSystemManager,
        IMessageBoxService messageBox,
        IEnshroudedServerService server,
        BindingList<ServerProfile>? serverProfiles)
    {
        _manageProfilesView = manageProfilesView;
        _profileManager = profileManager;
        _serverSettingsService = serverSettingsService;
        _fileSystemService = fileSystemManager;
        _messageBox = messageBox;
        _server = server;

        _profiles = serverProfiles;

        _manageProfilesView.AddProfileButtonClicked += (sender, e) => OnAddProfileClicked();
        _manageProfilesView.EditProfileButtonClicked += (sender, e) => OnEditProfileClicked();
        _manageProfilesView.DeleteProfileButtonClicked += (sender, e) => OnDeleteProfileClicked();
        _manageProfilesView.SelectedProfileChanged += (sender, e) => OnSelectedProfileChanged();

        SetProfiles(serverProfiles);
    }

    private void OnSelectedProfileChanged()
    {
        _manageProfilesView.EditProfileName = _manageProfilesView.SelectedProfile?.Name;
    }

    private void OnDeleteProfileClicked()
    {
        if (_manageProfilesView.SelectedProfile is not null)
        {
            // get the selected profile
            string selectedServerProfile = _manageProfilesView.SelectedProfile.Name;

            if (_server.IsRunning(selectedServerProfile))
            {
                _messageBox.Show(Constants.Errors.SERVER_RUNNING_ERROR_MESSAGE, Constants.Errors.SERVER_RUNNING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var result = _messageBox.Show(Constants.Warnings.DELETE_PROFILE_WARNING_MESSAGE, Constants.Warnings.DELETE_PROFILE_WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            // Load Server Profiles
            var serverProfile = _profiles.FirstOrDefault(x => x.Name == selectedServerProfile);
            if (serverProfile is not null)
            {
                var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedServerProfile);
                var autoBackupPath = Path.Join(Constants.Paths.AUTOBACKUPS_FOLDER, selectedServerProfile);
                var backupPath = Path.Join(Constants.Paths.BACKUPS_FOLDER, selectedServerProfile);

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
                    _profiles.Remove(serverProfile);

                    // write the new profile to the json file
                    var output = JsonConvert.SerializeObject(_profiles, JsonSettings.Default);
                    var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.SERVER_PROFILES_JSON);
                    _fileSystemService.WriteFile(serverProfilesJson, output);

                    // Clear UI Elements
                    _manageProfilesView.EditProfileName = ""; // Should all be handled

                    // reload form1
                    //Form1_Load(sender, e); // TODO: Is this still necessary?

                    //clear cache pid file
                    var pidJsonFile = $"{Constants.Paths.CACHE_DIRECTORY}{selectedServerProfile}{Constants.Files.PID_JSON}";

                    if (_fileSystemService.FileExists(pidJsonFile))
                    {
                        _fileSystemService.DeleteFile(pidJsonFile);
                    }
                }
            }
        }
    }

    public void SetProfiles(BindingList<ServerProfile> profiles)
    {
        _manageProfilesView.SetProfiles(profiles);
    }

    public void OnAddProfileClicked()
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

        _manageProfilesView.SetProfiles(_profiles);

        // write the new profile to the json file
        var output = JsonConvert.SerializeObject(_profiles, JsonSettings.Default);
        var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.SERVER_PROFILES_JSON);
        _fileSystemService.WriteFile(serverProfilesJson, output);

        // Create the server profile directory and load it's settings
        _serverSettingsService.LoadServerSettings(profileName);

        // reload form1
        // TODO: Do we still need this with new architecture?
        //Form1_Load(sender, e);
    }

    public void OnEditProfileClicked()
    {
        var reservedProfileNames = new string[] { "AutoBackup" };
        string editProfileName = _manageProfilesView.EditProfileName;

        var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, editProfileName);
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
        var selectedProfile = _profiles.FirstOrDefault(x => x.Name == selectedServerProfile);
        if (selectedProfile is not null)
        {
            // rename the server settings folder
            _profileManager.RenameServerSettings(selectedServerProfile, editProfileName);

            if (_fileSystemService.DirectoryExists(serverProfilePath))
            {
                // update the name
                selectedProfile.Name = editProfileName;

                // write the new profile to the json file
                var output = JsonConvert.SerializeObject(_profiles, JsonSettings.Default);
                var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.SERVER_PROFILES_JSON);

                _fileSystemService.WriteFile(serverProfilesJson, output);

                // rename backup folder
                var oldBackupFolder = Path.Join(Constants.Paths.BACKUPS_FOLDER, selectedServerProfile);
                var newBackupFolder = Path.Join(Constants.Paths.BACKUPS_FOLDER, editProfileName);
                if (!_fileSystemService.DirectoryExists(oldBackupFolder))
                {
                    _fileSystemService.CreateDirectory(oldBackupFolder);
                }
                if (!_fileSystemService.RenameDirectory(oldBackupFolder, newBackupFolder))
                {
                    _messageBox.Show(Constants.Errors.BACKUP_ERROR_MESSAGE, Constants.Errors.BACKUP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // rename autobackup folder
                var oldAutoBackupFolder = Path.Join(Constants.Paths.AUTOBACKUPS_FOLDER, selectedServerProfile);
                var newAutoBackupFolder = Path.Join(Constants.Paths.AUTOBACKUPS_FOLDER, editProfileName);
                if (!_fileSystemService.DirectoryExists(oldAutoBackupFolder))
                {
                    _fileSystemService.CreateDirectory(oldAutoBackupFolder);
                }
                if (!_fileSystemService.RenameDirectory(oldAutoBackupFolder, newAutoBackupFolder))
                {
                    _messageBox.Show(Constants.Errors.AUTOBACKUP_ERROR_MESSAGE, Constants.Errors.AUTOBACKUP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // ClearProfileName_TextBox
                _manageProfilesView.EditProfileName = "";

                // Used to update the button styles
                EventAggregator.Instance.Publish(new ProfileNameUpdated());

                // reload form1
                // TODO: Still needed?
                //Form1_Load(sender, e);
            }
        }
    }
}
