using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Model;
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

    private string _dateTimeString;

    public BackupService(IFileSystemService fsm,
        IEnshroudedServerService server,
        IEventAggregator eventAggregator,
        IDiscordService discordService)
    {
        _fileSystemService = fsm;
        _server = server;
        _eventAggregator = eventAggregator;
        _discordService = discordService;
    }

    /// <summary>
    /// Save a zip file of the location you set in "sourcefolder"
    /// </summary>
    public void Save(string saveFileDirectory, string profileName, string serverConfigFileName, string serverConfigDirectory)
    {
        _dateTimeString = DateTime.Now.ToString(Constants.DATE_PATTERN);

        var profileBackupDirectory = Path.Join(Constants.Paths.BACKUPS_DIRECTORY, profileName);
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

            return;
        }

        // remove the config files from the save file directory
        if (_fileSystemService.FileExists(copyOfServerConfigFile))
        {
            _fileSystemService.DeleteFile(copyOfServerConfigFile);
        }


        // discord Output
        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.DISCORD_JSON);
        if (_fileSystemService.FileExists(discordSettingsFile))
        {
            var discordSettingsText = _fileSystemService.ReadFile(discordSettingsFile);
            DiscordProfile discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, JsonSettings.Default);
            string discordUrl = discordProfile.DiscordUrl;

            var serverProfilePath = Path.Join(Constants.Paths.SERVER_DIRECTORY, profileName);
            var gameServerConfig = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_CONFIG_JSON);

            var gameServerConfigText = _fileSystemService.ReadFile(gameServerConfig);
            ServerSettings gameServerSettings = JsonConvert.DeserializeObject<ServerSettings>(gameServerConfigText, JsonSettings.Default);
            string name = gameServerSettings.Name;

            if (discordProfile.Enabled)
            {
                if (discordProfile.BackupEnabled)
                {
                    Task.Factory.StartNew(async () =>
                    {
                        try
                        {
                            _discordService.ServerBackup(name, discordUrl, discordProfile.EmbedEnabled, discordProfile.BackupMsg);
                        }
                        catch
                        {

                        }
                    });
                }
            }
        }
    }

    public async void StartAutoBackup(string saveFileDirectory, string profileName, int interval, int maximumBackups, string serverConfigFileName, string serverConfigDirectory)
    {
        if (interval < 1 || maximumBackups < 1)
        {
            return;
        }

        var profileAutoBackupDirectory = Path.Join(Constants.Paths.AUTOBACKUPS_DIRECTORY, profileName);
        var originalServerConfigFile = Path.Join(serverConfigDirectory, serverConfigFileName);
        var copyOfServerConfigFile = Path.Join(saveFileDirectory, serverConfigFileName);

        _fileSystemService.CreateDirectory(saveFileDirectory);
        _fileSystemService.CreateDirectory(profileAutoBackupDirectory);

        var timer = new PeriodicTimer(TimeSpan.FromMinutes(interval));
        //var timer = new PeriodicTimer(TimeSpan.FromSeconds(interval));
        if (!_server.IsRunning(profileName))
        {
            timer.Dispose();
            return;
        }

        var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, profileName, Constants.Files.PID_JSON);
        var processIdText = _fileSystemService.ReadFile(pidJsonFile);
        EnshroudedServerProcess? serverProcessInfo = JsonConvert.DeserializeObject<EnshroudedServerProcess>(processIdText);

        DiscordProfile discordProfile = null;
        ServerSettings gameServerSettings = null;
        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.DISCORD_JSON);
        var serverProfilePath = Path.Join(Constants.Paths.SERVER_DIRECTORY, profileName);
        var gameServerConfig = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_CONFIG_JSON);
        if (_fileSystemService.FileExists(discordSettingsFile) && _fileSystemService.FileExists(gameServerConfig))
        {
            var discordSettingsText = _fileSystemService.ReadFile(discordSettingsFile);
            discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, JsonSettings.Default);

            var gameServerConfigText = _fileSystemService.ReadFile(gameServerConfig);
            gameServerSettings = JsonConvert.DeserializeObject<ServerSettings>(gameServerConfigText, JsonSettings.Default);
        }

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
                if (_fileSystemService.FileExists(copyOfServerConfigFile))
                {
                    _fileSystemService.DeleteFile(copyOfServerConfigFile);
                }

                if (_fileSystemService.FileExists(originalServerConfigFile))
                {
                    _fileSystemService.CopyFile(originalServerConfigFile, copyOfServerConfigFile);
                }

                _dateTimeString = DateTime.Now.ToString(Constants.DATE_PATTERN);
                // zip all the files together
                // changed backup folder to autobackup folder
                _fileSystemService.CreateZipFromDirectory(saveFileDirectory, Path.Join(profileAutoBackupDirectory, $"backup-{_dateTimeString}.zip"));

                if (_fileSystemService.FileExists(copyOfServerConfigFile))
                {
                    _fileSystemService.DeleteFile(copyOfServerConfigFile);
                }

                DeleteOldestBackup(profileAutoBackupDirectory, maximumBackups);
                _eventAggregator.Publish(new AutoBackupSavedSuccessMessage(profileName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.Errors.AUTOBACKUP_ERROR_MESSAGE, Constants.Errors.AUTOBACKUP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // discord Output
            if (discordProfile is not null && discordProfile.Enabled && gameServerSettings is not null && discordProfile.BackupEnabled)
            {

                try
                {
                    await _discordService.ServerBackup(gameServerSettings.Name, discordProfile.DiscordUrl, discordProfile.EmbedEnabled, discordProfile.BackupMsg);
                }
                catch
                {

                }

            }
        }
    }

    public int GetBackupCount(string profileName)
    {
        var profileAutoBackupDirectory = Path.Join(Constants.Paths.AUTOBACKUPS_DIRECTORY, profileName);
        if (!_fileSystemService.DirectoryExists(profileAutoBackupDirectory))
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
        var profileAutoBackupDirectory = Path.Join(Constants.Paths.AUTOBACKUPS_DIRECTORY, profileName);
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
