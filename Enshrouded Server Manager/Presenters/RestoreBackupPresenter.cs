using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager.Presenters;
public class RestoreBackupPresenter
{
    private readonly IRestoreBackupView _restoreBackupView;
    private readonly IEventAggregator _eventAggregator;
    private readonly IFileSystemService _fileSystemService;
    private readonly IBackupService _backupService;
    private readonly IEnshroudedServerService _server;
    private readonly IMessageBoxService _messageBox;

    private ServerProfile _selectedProfile;

    public RestoreBackupPresenter(IRestoreBackupView view,
        IEventAggregator eventAggregator,
        IFileSystemService fileSystemService,
        IBackupService backupService,
        IEnshroudedServerService server,
        IMessageBoxService messageBox)
    {
        _restoreBackupView = view;
        _eventAggregator = eventAggregator;
        _fileSystemService = fileSystemService;
        _backupService = backupService;
        _server = server;
        _messageBox = messageBox;

        _restoreBackupView.RestoreSelectedFileClicked += (sender, e) => RestoreSelectedFileClicked();
        _restoreBackupView.SelectFileToRestoreClicked += (sender, e) => SelectFileToRestoreClicked();
        _restoreBackupView.FileToRestoreSelected += (sender, e) => FileToRestoreSelected();

        _eventAggregator.Subscribe<ProfileSelectedMessage>(p => OnProfileSelected(p.SelectedProfile));
        _eventAggregator.Subscribe<BackupRestoredMessage>(p => OnBackupRestored());
    }

    private void OnBackupRestored()
    {
        _restoreBackupView.AnimateSaveButton();
    }

    private void OnProfileSelected(ServerProfile selectedProfile)
    {
        _selectedProfile = selectedProfile;

        var backupDirectory = Path.Join(Directory.GetCurrentDirectory(), Constants.Paths.BACKUPS_DIRECTORY, _selectedProfile.Name);
        _restoreBackupView.FileDialog.InitialDirectory = backupDirectory;
    }

    private void FileToRestoreSelected()
    {
        _restoreBackupView.RestoreFilePath = _restoreBackupView.FileDialog.FileName;
    }

    private void SelectFileToRestoreClicked()
    {
        _restoreBackupView.FileDialog.ShowDialog();
    }

    private void RestoreSelectedFileClicked()
    {
        if (_server.IsRunning(_selectedProfile.Name))
        {
            _messageBox.Show(Constants.Errors.SERVER_RUNNING_ERROR_MESSAGE, Constants.Errors.SERVER_RUNNING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (_fileSystemService.FileExists(_restoreBackupView.RestoreFilePath))
        {
            _backupService.RestoreBackup(_selectedProfile.Name, _restoreBackupView.RestoreFilePath);
            _restoreBackupView.AnimateSaveButton();
        }
    }
}
