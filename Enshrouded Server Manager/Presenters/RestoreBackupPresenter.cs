using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Presenters;
public class RestoreBackupPresenter
{
    private readonly IRestoreBackupView _restoreBackupView;
    private readonly IEventAggregator _eventAggregator;
    private readonly IFileSystemService _fileSystemService;
    private readonly IBackupService _backupService;
    private readonly IEnshroudedServerService _server;
    private readonly IMessageBoxService _messageBox;
    private readonly IFileLoggerService _logger;

    private BindingList<ServerProfile>? _profiles;

    private ServerProfile _selectedProfile;

    public RestoreBackupPresenter(IRestoreBackupView view,
        IEventAggregator eventAggregator,
        IFileSystemService fileSystemService,
        IBackupService backupService,
        IEnshroudedServerService server,
        IMessageBoxService messageBox,
        IFileLoggerService fileLogger,
        BindingList<ServerProfile>? profiles)
    {
        _restoreBackupView = view;
        _eventAggregator = eventAggregator;
        _fileSystemService = fileSystemService;
        _backupService = backupService;
        _server = server;
        _messageBox = messageBox;
        _profiles = profiles;
        _logger = fileLogger;

        _restoreBackupView.SelectFileToRestoreClicked += (sender, e) => OnSelectFileToRestoreClicked();
        _restoreBackupView.FileToRestoreSelected += (sender, e) => OnFileToRestoreSelected();
        _restoreBackupView.RestoreSelectedFileClicked += (sender, e) => OnRestoreSelectedFileClicked();
        _restoreBackupView.SaveSettingsClicked += (sender, e) => OnSaveSettingsClicked();

        _eventAggregator.Subscribe<ProfileSelectedMessage>(p => OnProfileSelected(p.SelectedProfile));
    }

    private void OnSaveSettingsClicked()
    {

        _selectedProfile.RestoreBackup = new RestoreBackup()
        {
            BackupFilePath = _restoreBackupView.RestoreFilePath,
            RestoreOnScheduledRestart = _restoreBackupView.IsRestoreOnScheduledRestartChecked
        };

        // write the updated profile to the json file
        _fileSystemService.WriteFile(
            Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.SERVER_PROFILES_JSON),
            JsonConvert.SerializeObject(_profiles, JsonSettings.Default));

        _restoreBackupView.AnimateSaveButton();
    }

    private void OnProfileSelected(ServerProfile selectedProfile)
    {
        _selectedProfile = selectedProfile;

        var backupDirectory = Path.Join(Directory.GetCurrentDirectory(), Constants.Paths.BACKUPS_DIRECTORY, _selectedProfile.Name);
        _restoreBackupView.FileDialog.InitialDirectory = backupDirectory;

        if (_selectedProfile.RestoreBackup is null)
        {
            _selectedProfile.RestoreBackup = new RestoreBackup()
            {
                BackupFilePath = "",
                RestoreOnScheduledRestart = false
            };
        }

        _restoreBackupView.RestoreFilePath = _selectedProfile.RestoreBackup.BackupFilePath;
        _restoreBackupView.IsRestoreOnScheduledRestartChecked = _selectedProfile.RestoreBackup.RestoreOnScheduledRestart;
    }

    private void OnFileToRestoreSelected()
    {
        _restoreBackupView.RestoreFilePath = _restoreBackupView.FileDialog.FileName;
    }

    private void OnSelectFileToRestoreClicked()
    {
        _restoreBackupView.FileDialog.ShowDialog();
    }

    private void OnRestoreSelectedFileClicked()
    {
        if (_server.IsRunning(_selectedProfile.Name))
        {
            _messageBox.Show(Constants.Errors.SERVER_RUNNING_ERROR_MESSAGE, Constants.Errors.SERVER_RUNNING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (_fileSystemService.FileExists(_restoreBackupView.RestoreFilePath)
            || _fileSystemService.DirectoryExists(_restoreBackupView.RestoreFilePath))
        {
            _backupService.RestoreBackup(_selectedProfile.Name, _restoreBackupView.RestoreFilePath);
            _restoreBackupView.AnimateRestoreButton();
        }
    }
}
