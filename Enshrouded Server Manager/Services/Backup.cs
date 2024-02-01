using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Enshrouded_Server_Manager.Services;

public class Backup
{
    private readonly IFileSystemManager _fileSystemManager;
    private readonly Server _server; // TODO: Make this an interface
    private string _dateTimeString;

    public event EventHandler<AutoBackupSuccessEventArgs> AutoBackupSuccess;

    public Backup(IFileSystemManager fsm)
    {
        _fileSystemManager = fsm;
        _server = new Server(fsm); // TODO: Inject this dependency
    }

    /// <summary>
    /// Save a zip file of the location you set in "sourcefolder"
    /// </summary>
    public void Save(string saveFileDirectory, string profileName, string serverConfigFileName, string serverConfigDirectory)
    {
        _dateTimeString = DateTime.Now.ToString(Constants.DATE_PATTERN);

        var profileBackupDirectory = Path.Join(Constants.Paths.BACKUPS_FOLDER, profileName);
        var originalServerConfigFile = Path.Join(serverConfigDirectory, serverConfigFileName);
        var copyOfServerConfigFile = Path.Join(saveFileDirectory, serverConfigFileName);

        _fileSystemManager.CreateDirectory(saveFileDirectory);
        _fileSystemManager.CreateDirectory(profileBackupDirectory);

        // Copy the configuration file to the savefile directory so it can get zipped with the world files
        if (_fileSystemManager.FileExists(copyOfServerConfigFile))
        {
            _fileSystemManager.DeleteFile(copyOfServerConfigFile);
        }
        if (_fileSystemManager.FileExists(originalServerConfigFile))
        {
            _fileSystemManager.CopyFile(originalServerConfigFile, copyOfServerConfigFile);
        }

        // zip all the files
        var zipFileName = Path.Join(profileBackupDirectory, $"backup-{_dateTimeString}.zip");
        try
        {
            _fileSystemManager.CreateZipFromDirectory(saveFileDirectory, zipFileName);
            MessageBox.Show(string.Format(Constants.Success.BACKUP_SAVED_SUCCESS_MESSAGE, zipFileName),
                Constants.Success.BACKUP_SAVED_SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception)
        {
            MessageBox.Show(Constants.Errors.BACKUP_ERROR_MESSAGE, Constants.Errors.BACKUP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return;
        }

        // remove the config files from the save file directory
        if (_fileSystemManager.FileExists(copyOfServerConfigFile))
        {
            _fileSystemManager.DeleteFile(copyOfServerConfigFile);
        }
    }

    public async void StartAutoBackup(string saveFileDirectory, string profileName, int interval, int maximumBackups, string serverConfigFileName, string serverConfigDirectory)
    {
        if (interval < 1 || maximumBackups < 1)
        {
            return;
        }

        var profileAutoBackupDirectory = Path.Join(Constants.Paths.AUTOBACKUPS_FOLDER, profileName);
        var originalServerConfigFile = Path.Join(serverConfigDirectory, serverConfigFileName);
        var copyOfServerConfigFile = Path.Join(saveFileDirectory, serverConfigFileName);

        _fileSystemManager.CreateDirectory(saveFileDirectory);
        _fileSystemManager.CreateDirectory(profileAutoBackupDirectory);

        var timer = new PeriodicTimer(TimeSpan.FromMinutes(interval));
        if (!_server.IsRunning(profileName))
        {
            timer.Dispose();
            return;
        }

        var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, profileName, Constants.Files.PID_JSON);
        var input = _fileSystemManager.ReadFile(pidJsonFile);
        EnshroudedServerProcess? serverProcessInfo = JsonConvert.DeserializeObject<EnshroudedServerProcess>(input);


        while (await timer.WaitForNextTickAsync())
        {
            // check if the server is running

            try
            {
                Process.GetProcessById(serverProcessInfo.Id);

            }
            catch
            {
                timer.Dispose();
                return;
            }

            try
            {
                // Copy the configuration file to the savefile directory so it can get zipped with the world files
                if (_fileSystemManager.FileExists(copyOfServerConfigFile))
                {
                    _fileSystemManager.DeleteFile(copyOfServerConfigFile);
                }

                if (_fileSystemManager.FileExists(originalServerConfigFile))
                {
                    _fileSystemManager.CopyFile(originalServerConfigFile, copyOfServerConfigFile);
                }

                _dateTimeString = DateTime.Now.ToString(Constants.DATE_PATTERN);
                // zip all the files together
                // changed backup folder to autobackup folder
                _fileSystemManager.CreateZipFromDirectory(saveFileDirectory, Path.Join(profileAutoBackupDirectory, $"backup-{_dateTimeString}.zip"));

                if (_fileSystemManager.FileExists(copyOfServerConfigFile))
                {
                    _fileSystemManager.DeleteFile(copyOfServerConfigFile);
                }

                DeleteOldestBackup(profileAutoBackupDirectory, maximumBackups);
                OnAutoBackupSuccess(new AutoBackupSuccessEventArgs { ProfileName = profileName });
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.Errors.AUTOBACKUP_ERROR_MESSAGE, Constants.Errors.AUTOBACKUP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }

    public int GetBackupCount(string profileName)
    {
        var profileAutoBackupDirectory = Path.Join(Constants.Paths.AUTOBACKUPS_FOLDER, profileName);
        if (!_fileSystemManager.DirectoryExists(profileAutoBackupDirectory))
        {
            return 0;
        }

        // find the number of backups for the selected profile
        var directory = new DirectoryInfo(profileAutoBackupDirectory);
        var files = directory.GetFiles("*.zip");

        return files.Length;
    }

    public long GetDiskConsumption(string profileName)
    {
        var profileAutoBackupDirectory = Path.Join(Constants.Paths.AUTOBACKUPS_FOLDER, profileName);
        if (!_fileSystemManager.DirectoryExists(profileAutoBackupDirectory))
        {
            return 0;
        }

        // find all backups for the selected profile
        var directory = new DirectoryInfo(profileAutoBackupDirectory);
        var files = directory.GetFiles("*.zip");

        // sum up the size of all backups
        long size = 0;
        foreach (var file in files)
        {
            size += file.Length;
        }

        return size;
    }

    private void DeleteOldestBackup(string backupDirectory, int maximumBackups)
    {
        var directory = new DirectoryInfo(backupDirectory);
        var zipFiles = directory.GetFiles("*.zip");
        if (zipFiles.Length > maximumBackups)
        {
            var oldestZip = zipFiles.FirstOrDefault();
            if (oldestZip != null)
            {
                oldestZip.Delete();
            }
        }
    }

    protected virtual void OnAutoBackupSuccess(AutoBackupSuccessEventArgs e)
    {
        AutoBackupSuccess?.Invoke(this, e);
    }
}
