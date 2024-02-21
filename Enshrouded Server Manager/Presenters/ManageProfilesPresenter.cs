using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Presenters;
public class ManageProfilesPresenter
{
    private readonly IManageProfilesView _manageProfilesView;
    private readonly IEventAggregator _eventAggregator;
    private readonly IProfileService _profileService;
    private readonly IServerSettingsService _serverSettingsService;
    private readonly IFileSystemService _fileSystemService;
    private readonly IMessageBoxService _messageBox;
    private readonly IEnshroudedServerService _server;
    private readonly IFileLoggerService _logger;

    private BindingList<ServerProfile>? _profiles;


    public ManageProfilesPresenter(IManageProfilesView manageProfilesView,
        IEventAggregator eventAggregator,
        IProfileService profileManager,
        IServerSettingsService serverSettingsService,
        IFileSystemService fileSystemManager,
        IMessageBoxService messageBox,
        IEnshroudedServerService server,
        IFileLoggerService fileLogger,
        BindingList<ServerProfile>? serverProfiles)
    {
        _manageProfilesView = manageProfilesView;
        _eventAggregator = eventAggregator;
        _profileService = profileManager;
        _serverSettingsService = serverSettingsService;
        _fileSystemService = fileSystemManager;
        _messageBox = messageBox;
        _server = server;
        _logger = fileLogger;

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
        string newProfileName = _manageProfilesView.EditProfileName;
        ServerProfile profile = _manageProfilesView.SelectedProfile;

        var serverProfilePath = Path.Join(Constants.Paths.SERVER_DIRECTORY, newProfileName);
        if (_fileSystemService.DirectoryExists(serverProfilePath))
        {
            return;
        }

        if (profile is null)
        {
            return;
        }


        if (_server.IsRunning(profile.Name))
        {
            _messageBox.Show(Constants.Errors.SERVER_RUNNING_ERROR_MESSAGE, Constants.Errors.SERVER_RUNNING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return;
        }

        // Validate:
        // Not Null
        // Windows File Name Does not have Special Characters
        // Not the same as an existing profile name
        // Not allowed to use ReservedNames
        if (newProfileName is null
            || !_profileService.IsProfileNameValid(newProfileName)
            || profile.Name == newProfileName
            || reservedProfileNames.Contains(newProfileName))
        {
            return;
        }

        // rename the serverProfilePath
        if (!_profileService.RenameProfilePaths(_profiles, profile, newProfileName))
        {
            MessageBox.Show(Constants.Errors.SERVER_PROFILE_RENAME_ERROR_MESSAGE, Constants.Errors.SERVER_PROFILE_RENAME_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        _manageProfilesView.IsVisible = false;
    }
}
