using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Services;
public class ProfileService : IProfileService
{
    private readonly IFileSystemService _fileSystemService;
    private readonly IMessageBoxService _messageBoxService;
    private readonly IFileLoggerService _logger;
    public ProfileService(IFileSystemService fsm,
        IMessageBoxService messageBoxService,
        IFileLoggerService fileLoggerService)
    {
        _fileSystemService = fsm;
        _messageBoxService = messageBoxService;
        _logger = fileLoggerService;
    }


    public List<ServerProfile>? LoadServerProfiles(JsonSerializerSettings jsonSerializerSettings, bool firstCheck = false)
    {
        var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.SERVER_PROFILES_JSON);

        if (!_fileSystemService.FileExists(serverProfilesJson))
        {
            _fileSystemService.CreateDirectory(Constants.Paths.DEFAULT_PROFILES_DIRECTORY);

            // First time loading server profiles should, create default profile
            WriteDefaultProfileJson(serverProfilesJson, jsonSerializerSettings);
        }

        var profilesJson = _fileSystemService.ReadFile(serverProfilesJson);
        List<ServerProfile>? serverProfiles = JsonConvert.DeserializeObject<List<ServerProfile>>(profilesJson, jsonSerializerSettings);

        if (serverProfiles is not null && serverProfiles.Count() <= 0)
        {
            WriteDefaultProfileJson(serverProfilesJson, jsonSerializerSettings);
            profilesJson = _fileSystemService.ReadFile(serverProfilesJson);
            return JsonConvert.DeserializeObject<List<ServerProfile>>(profilesJson, jsonSerializerSettings);
        }

        return serverProfiles;
    }

    public bool IsProfileNameValid(string profileName)
    {
        // Validate that the profileName is not empty, and does not contain any characters
        // that are not allowed in a Windows file name
        if (string.IsNullOrWhiteSpace(profileName))
        {
            MessageBox.Show(Constants.Errors.SERVER_PROFILE_EMPTY_ERROR_MESSAGE, Constants.Errors.SERVER_PROFILE_EMPTY_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

        // Check that the profileName does not contain any invalid characters
        if (profileName.IndexOfAny(invalid.ToCharArray()) != -1)
        {
            MessageBox.Show(Constants.Errors.SERVER_PROFILE_INVALID_CHARACTERS_ERROR_MESSAGE, Constants.Errors.SERVER_PROFILE_INVALID_CHARACTERS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    public bool RenameProfilePaths(BindingList<ServerProfile> profiles, ServerProfile profile, string newProfileName)
    {
        _logger.LogInfo("Renaming profile paths");
        bool success = false;
        try
        {
            var oldServerProfilePath = Path.Join(Constants.Paths.SERVER_DIRECTORY, profile.Name);
            var newServerProfilePath = Path.Join(Constants.Paths.SERVER_DIRECTORY, newProfileName);
            _fileSystemService.MoveDirectory(oldServerProfilePath, $"{oldServerProfilePath}_temp");
            _fileSystemService.MoveDirectory($"{oldServerProfilePath}_temp", newServerProfilePath);

            if (_fileSystemService.DirectoryExists(newServerProfilePath))
            {
                // update the name
                string oldProfileName = profile.Name;
                profile.Name = newProfileName;

                // write the new profile to the json file
                var output = JsonConvert.SerializeObject(profiles, JsonSettings.Default);
                var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.SERVER_PROFILES_JSON);
                _logger.LogInfo($"Writing new profile data to {serverProfilesJson}");
                _fileSystemService.WriteFile(serverProfilesJson, output);
                _logger.LogInfo($"Profile data written");

                // rename backup folder
                var oldBackupFolder = Path.Join(Constants.Paths.BACKUPS_DIRECTORY, oldProfileName);
                var newBackupFolder = Path.Join(Constants.Paths.BACKUPS_DIRECTORY, newProfileName);
                _logger.LogInfo($"Renaming backup directories from {oldBackupFolder} to {newBackupFolder}");
                _fileSystemService.RenameDirectory(oldBackupFolder, newBackupFolder);
                _logger.LogInfo($"Backup directories renamed");

                // rename autobackup folder
                var oldAutoBackupFolder = Path.Join(Constants.Paths.AUTOBACKUPS_DIRECTORY, oldProfileName);
                var newAutoBackupFolder = Path.Join(Constants.Paths.AUTOBACKUPS_DIRECTORY, newProfileName);
                _logger.LogInfo($"Renaming backup directories from {oldAutoBackupFolder} to {newAutoBackupFolder}");
                _fileSystemService.RenameDirectory(oldAutoBackupFolder, newAutoBackupFolder);
                _logger.LogInfo($"Auto backup directories renamed");

                // rename cache folder
                var oldCacheFolder = Path.Join(Constants.Paths.CACHE_DIRECTORY, oldProfileName);
                var newCacheFolder = Path.Join(Constants.Paths.CACHE_DIRECTORY, newProfileName);
                _logger.LogInfo($"Renaming cache directories from {oldCacheFolder} to {newCacheFolder}");
                _fileSystemService.RenameDirectory(oldCacheFolder, newCacheFolder);
                _logger.LogInfo($"Cache directories renamed");

                // rename the restore backup folder path and write it back to the file
                if (profile.RestoreBackup.BackupFilePath.Contains(oldProfileName))
                {
                    _logger.LogInfo($"Renaming restore directory from {profile.RestoreBackup.BackupFilePath} to {profile.RestoreBackup.BackupFilePath.Replace(oldProfileName, newProfileName)}");
                    profile.RestoreBackup.BackupFilePath = profile.RestoreBackup.BackupFilePath.Replace(oldProfileName, newProfileName);
                    _fileSystemService.WriteFile(Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.SERVER_PROFILES_JSON),
                        JsonConvert.SerializeObject(profiles, JsonSettings.Default));
                    _logger.LogInfo("Restore directory renamed");
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            _messageBoxService.Show(string.Format(Constants.Errors.PROFILE_NAME_CHANGE_ERROR_MESSAGE, ex.Message),
                Constants.Errors.PROFILE_NAME_CHANGE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError($"Unable to rename all profile directories. {ex.Message}");

            return false;
        }
    }

    private void WriteDefaultProfileJson(string profilePath, JsonSerializerSettings settings)
    {
        var json = new List<ServerProfile>
        {
            new ServerProfile()
            {
                Name = GenerateText.RandomServerName(6)
            }
        };

        var output = JsonConvert.SerializeObject(json, settings);
        _fileSystemService.WriteFile(profilePath, output);
    }
}
