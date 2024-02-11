using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Presenters;
public class AutoBackupPresenter
{
    private readonly IAutoBackupView _autoBackupView;
    private readonly IProfileService _profileManager;
    private readonly IFileSystemService _fileSystemService;
    private readonly IMessageBoxService _messageBox;
    private readonly IBackupService _backupService;

    private BindingList<ServerProfile>? _profiles;

    public AutoBackupPresenter(IAutoBackupView autoBackupView,
        IProfileService profileManager,
        IFileSystemService fileSystemManager,
        IMessageBoxService messageBox,
        IBackupService backupService,
        BindingList<ServerProfile>? serverProfiles)
    {
        _autoBackupView = autoBackupView;
        _profileManager = profileManager;
        _fileSystemService = fileSystemManager;
        _messageBox = messageBox;
        _backupService = backupService;

        _profiles = serverProfiles;

        _autoBackupView.SaveAutoBackupSettingsClicked += OnSaveAutoBackupSettingsClicked;
        //_autoBackupView.SelectedProfileChanged += (sender, e) => OnProfileSelected(SelectedProfile);
        EventAggregator.Instance.Subscribe<AutoBackupSuccessMessage>(n => OnAutoBackupSuccess(n.ProfileName));
        EventAggregator.Instance.Subscribe<ProfileSelectedMessage>(s => OnProfileSelected(s.SelectedProfile));

        SetProfiles(serverProfiles);
    }

    private void OnSelectedProfileChanged()
    {
        throw new NotImplementedException();
    }

    private void OnAutoBackupSuccess(string profileName)
    {
        _autoBackupView.UpdateBackupInfo(profileName, _backupService.GetBackupCount(profileName), _backupService.GetDiskConsumption(profileName));
    }

    private void OnSaveAutoBackupSettingsClicked(object? sender, EventArgs e)
    {
        var enabled = _autoBackupView.IsAutoBackupEnabled;

        if (_autoBackupView.SelectedProfile is not null)
        {
            //Interactions.AnimateSaveChangesButton(btnSaveAutoBackup, btnSaveAutoBackup.Text, Constants.ButtonText.SAVED_SUCCESS);

            var selectedProfile = _autoBackupView.SelectedProfile.Name;
            var profiles = _profileManager.LoadServerProfiles(JsonSettings.Default);
            var profile = profiles?.FirstOrDefault(x => x.Name == selectedProfile);
            if (profile is not null)
            {
                profile.AutoBackup = new AutoBackup()
                {
                    Interval = _autoBackupView.BackupInterval,
                    MaxiumBackups = _autoBackupView.MaxAutoBackupCount,
                    Enabled = enabled
                };

                // write the new profile to the json file
                var output = JsonConvert.SerializeObject(profiles, JsonSettings.Default);
                var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.SERVER_PROFILES_JSON);
                _fileSystemService.WriteFile(serverProfilesJson, output);
            }
        }
        else
        {
            _messageBox.Show(Constants.Errors.BACKUP_CONFIGURATION_ERROR_MESSAGE, Constants.Errors.BACKUP_CONFIGURATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SetProfiles(BindingList<ServerProfile>? serverProfiles)
    {
        _autoBackupView.SetProfiles(serverProfiles);
    }

    private void OnProfileSelected(ServerProfile selectedProfile)
    {
        // get selected item
        if (selectedProfile is not null)
        {
            var profileName = selectedProfile.Name;
            // load profile
            var profile = _profileManager.LoadServerProfiles(JsonSettings.Default).FirstOrDefault(x => x.Name == profileName);
            if (profile is not null)
            {
                // load auto backup settings
                if (profile.AutoBackup is null)
                {
                    // create new auto backup settings
                    profile.AutoBackup = new AutoBackup()
                    {
                        Interval = 0,
                        MaxiumBackups = 0,
                        Enabled = false
                    };
                }

                // set values
                _autoBackupView.IsAutoBackupEnabled = profile.AutoBackup.Enabled;
                _autoBackupView.BackupInterval = profile.AutoBackup.Interval;
                _autoBackupView.MaxAutoBackupCount = profile.AutoBackup.MaxiumBackups;
            }

            var totalBackups = _backupService.GetBackupCount(profileName);
            var diskConsumption = _backupService.GetDiskConsumption(profileName);

            _autoBackupView.UpdateBackupInfo(profileName, _backupService.GetBackupCount(profileName), _backupService.GetDiskConsumption(profileName));
        }
        else
        {
            _autoBackupView.IsAutoBackupStatsVisible = false;
        }
    }
}
