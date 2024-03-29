using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Enshrouded_Server_Manager.Services;

public class BackupService : IBackupService
{
    private readonly IFileSystemService _fileSystemService;
    private readonly IEventAggregator _eventAggregator;
    private readonly IEnshroudedServerService _server;
    private readonly IDiscordService _discordService;
    private readonly IFileLoggerService _logger;

    Dictionary<string, CountDownTimer> _restartTimers;
    private string _dateTimeString;

    public BackupService(IFileSystemService fsm,
        IEnshroudedServerService server,
        IEventAggregator eventAggregator,
        IDiscordService discordService,
        IFileLoggerService fileLogger,
        Dictionary<string, CountDownTimer> restartTimers)
    {
        _fileSystemService = fsm;
        _server = server;
        _eventAggregator = eventAggregator;
        _discordService = discordService;
        _logger = fileLogger;
        _restartTimers = restartTimers;
    }

    /// <summary>
    /// Save a zip file of the location you set in "sourcefolder"
    /// </summary>
    public void Save(string saveFileDirectory, ServerProfile profile, string serverConfigFileName, string serverConfigDirectory)
    {
        _dateTimeString = DateTime.Now.ToString(Constants.DATE_PATTERN);

        var profileBackupDirectory = Path.Join(Constants.Paths.BACKUPS_DIRECTORY, profile.Name);
        var originalServerConfigFile = Path.Join(serverConfigDirectory, serverConfigFileName);
        var copyOfServerConfigFile = Path.Join(saveFileDirectory, serverConfigFileName);

        _fileSystemService.CreateDirectory(saveFileDirectory);
        _fileSystemService.CreateDirectory(profileBackupDirectory);

        // Copy the configuration file to the savefile directory so it can get zipped with the world files
        if (_fileSystemService.FileExists(copyOfServerConfigFile))
        {
            _fileSystemService.DeleteFile(copyOfServerConfigFile);
        }
        if (_fileSystemService.FileExists(originalServerConfigFile))
        {
            _fileSystemService.CopyFile(originalServerConfigFile, copyOfServerConfigFile);
        }

        // Delete all -index/-# files from the save directory
        RemoveAllDashFiles(saveFileDirectory);

        // zip all the files
        var zipFileName = Path.Join(profileBackupDirectory, $"backup-{_dateTimeString}.zip");
        try
        {
            _fileSystemService.CreateZipFromDirectory(saveFileDirectory, zipFileName);
            MessageBox.Show(string.Format(Constants.Success.BACKUP_SAVED_SUCCESS_MESSAGE, zipFileName),
                Constants.Success.BACKUP_SAVED_SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception)
        {
            MessageBox.Show(Constants.Errors.BACKUP_ERROR_MESSAGE, Constants.Errors.BACKUP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError($"Backup failed for {profile.Name}");
            return;
        }

        // remove the config files from the save file directory
        if (_fileSystemService.FileExists(copyOfServerConfigFile))
        {
            _fileSystemService.DeleteFile(copyOfServerConfigFile);
        }

        // discord Output
        _discordService.SendMessage(profile, DiscordMessageType.Backup);
    }

    public async void StartAutoBackup(string saveFileDirectory, ServerProfile profile, int interval, int maximumBackups, string serverConfigFileName, string serverConfigDirectory)
    {
        if (interval < 1 || maximumBackups < 1)
        {
            return;
        }

        var profileAutoBackupDirectory = Path.Join(Constants.Paths.AUTOBACKUPS_DIRECTORY, profile.Name);
        var originalServerConfigFile = Path.Join(serverConfigDirectory, serverConfigFileName);
        var copyOfServerConfigFile = Path.Join(saveFileDirectory, serverConfigFileName);

        _fileSystemService.CreateDirectory(saveFileDirectory);
        _fileSystemService.CreateDirectory(profileAutoBackupDirectory);

        var timer = new PeriodicTimer(TimeSpan.FromMinutes(interval));
        //var timer = new PeriodicTimer(TimeSpan.FromSeconds(interval));
        if (!_server.IsRunning(profile.Name))
        {
            timer.Dispose();
            return;
        }

        var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, profile.Name, Constants.Files.PID_JSON);
        var processIdText = _fileSystemService.ReadFile(pidJsonFile);
        EnshroudedServerProcess? serverProcessInfo = JsonConvert.DeserializeObject<EnshroudedServerProcess>(processIdText);

        while (await timer.WaitForNextTickAsync())
        {
            // check if the server is running
            try
            {
                Process.GetProcessById(serverProcessInfo.Id);
            }
            catch
            {
                _logger.LogInfo("Server is not running. AutoBackup timer canceled.");
                timer.Dispose();
                return;
            }

            try
            {
                // Copy the configuration file to the savefile directory so it can get zipped with the world files
                if (_fileSystemService.FileExists(copyOfServerConfigFile))
                {
                    _fileSystemService.DeleteFile(copyOfServerConfigFile);
                }

                if (_fileSystemService.FileExists(originalServerConfigFile))
                {
                    _fileSystemService.CopyFile(originalServerConfigFile, copyOfServerConfigFile);
                }

                _dateTimeString = DateTime.Now.ToString(Constants.DATE_PATTERN);

                // Delete all -index/-# files from the save directory
                RemoveAllDashFiles(saveFileDirectory);

                // zip all the files together
                // changed backup folder to autobackup folder
                _fileSystemService.CreateZipFromDirectory(saveFileDirectory, Path.Join(profileAutoBackupDirectory, $"backup-{_dateTimeString}.zip"));

                if (_fileSystemService.FileExists(copyOfServerConfigFile))
                {
                    _fileSystemService.DeleteFile(copyOfServerConfigFile);
                }

                DeleteOldestBackup(profileAutoBackupDirectory, maximumBackups);
                _eventAggregator.Publish(new AutoBackupSavedSuccessMessage(profile));
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.Errors.AUTOBACKUP_ERROR_MESSAGE, Constants.Errors.AUTOBACKUP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.LogError($"AutoBackup failed for {profile.Name}. Error: {ex.Message}");
                return;
            }


            try
            {
                _discordService.SendMessage(profile, DiscordMessageType.Backup);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Discord message failed to send during autobackup. Error: {ex.Message}");
            }
        }
    }

    private void RemoveAllDashFiles(string saveFileDirectory)
    {
        // Delete all -index/-# files from the save directory
        var files = _fileSystemService.GetFiles(saveFileDirectory);
        foreach (var file in files)
        {
            if (file.Name.Contains("-"))
            {
                _fileSystemService.DeleteFile(file.FullName);
            }
        }
    }

    public bool RestoreBackup(ServerProfile profile, string backupFilePath)
    {
        var restoreSuccess = false;

        var saveDirectory = Path.Combine(Constants.Paths.SERVER_DIRECTORY, profile.Name, Constants.Paths.ENSHROUDED_SAVE_GAME_DIRECTORY);

        RemoveAllDashFiles(saveDirectory);
        if (backupFilePath.EndsWith(".zip"))
        {
            restoreSuccess = RestoreBackupFromZip(backupFilePath, saveDirectory);
        }
        else if (_fileSystemService.DirectoryExists(backupFilePath))
        {
            restoreSuccess = RestoreBackupFromLatestZip(backupFilePath, saveDirectory);
        }
        else
        {
            restoreSuccess = RestoreBackupFromSaveFile(backupFilePath, saveDirectory);
        }

        if (restoreSuccess)
        {
            _discordService.SendMessage(profile, DiscordMessageType.BackupRestored);
        }


        return restoreSuccess;
    }

    private bool RestoreBackupFromLatestZip(string backupFilePath, string saveDirectory)
    {
        try
        {
            var directory = new DirectoryInfo(backupFilePath);
            var files = directory.GetFiles("*.zip");
            var newestFile = files.OrderByDescending(f => f.LastWriteTime).FirstOrDefault();
            if (newestFile != null)
            {
                return RestoreBackupFromZip(newestFile.FullName, saveDirectory);
            }

            return false;
        }
        catch (Exception e)
        {
            _logger.LogError($"Restore backup from latest zip failed with error: {e.Message}");
            return false;
        }
    }

    private bool RestoreBackupFromSaveFile(string backupFilePath, string saveDirectory)
    {
        try
        {
            var saveFile = Path.Combine(saveDirectory, Constants.SaveSlots.SLOT1);
            _fileSystemService.CopyFile(backupFilePath, saveFile, true);

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"Restore backup from file failed with error: {e.Message}");
            return false;
        }
    }

    private bool RestoreBackupFromZip(string backupFilePath, string saveDirectory)
    {
        try
        {
            // extract the zipped files to a temp directory
            var tempDir = Path.Combine(saveDirectory, "temp");
            _fileSystemService.ExtractZipToDirectory(backupFilePath, tempDir, true);

            // copy the save file in the temp directory to the savegame directory
            var tempFile = Path.Combine(tempDir, Constants.SaveSlots.SLOT1);
            var saveFile = Path.Combine(saveDirectory, Constants.SaveSlots.SLOT1);
            _fileSystemService.CopyFile(tempFile, saveFile, true);

            // delete temp
            _fileSystemService.DeleteDirectory(tempDir);

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"Restore backup from zip failed with error: {e.Message}");
            return false;
        }
    }

    public int GetBackupCount(ServerProfile profile)
    {
        var profileAutoBackupDirectory = Path.Join(Constants.Paths.AUTOBACKUPS_DIRECTORY, profile.Name);
        if (!_fileSystemService.DirectoryExists(profileAutoBackupDirectory))
        {
            return 0;
        }

        // find the number of backups for the selected profile
        var directory = new DirectoryInfo(profileAutoBackupDirectory);
        var files = directory.GetFiles("*.zip");

        return files.Length;
    }

    public long GetDiskConsumption(ServerProfile profile)
    {
        var profileAutoBackupDirectory = Path.Join(Constants.Paths.AUTOBACKUPS_DIRECTORY, profile.Name);
        if (!_fileSystemService.DirectoryExists(profileAutoBackupDirectory))
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
            if (oldestZip is not null)
            {
                oldestZip.Delete();
            }
        }
    }
}
