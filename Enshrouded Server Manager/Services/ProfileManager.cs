using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services.Interfaces;
using Newtonsoft.Json;

namespace Enshrouded_Server_Manager.Services;
public class ProfileManager : IProfileManager
{
    private readonly IFileSystemManager _fileSystemManager;
    public ProfileManager(IFileSystemManager fsm)
    {
        _fileSystemManager = fsm;
    }

    public List<ServerProfile>? LoadServerProfiles(JsonSerializerSettings jsonSerializerSettings, bool firstCheck = false)
    {
        var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.SERVER_PROFILES_JSON);

        if (!_fileSystemManager.FileExists(serverProfilesJson))
        {
            _fileSystemManager.CreateDirectory(Constants.Paths.DEFAULT_PROFILES_PATH);

            // First time loading server profiles should, create default profile
            WriteDefaultProfileJson(serverProfilesJson, jsonSerializerSettings);
        }

        var profilesJson = _fileSystemManager.ReadFile(serverProfilesJson);
        List<ServerProfile>? serverProfiles = JsonConvert.DeserializeObject<List<ServerProfile>>(profilesJson, jsonSerializerSettings);

        if (serverProfiles is not null && serverProfiles.Count() <= 0)
        {
            WriteDefaultProfileJson(serverProfilesJson, jsonSerializerSettings);
            profilesJson = _fileSystemManager.ReadFile(serverProfilesJson);
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
        _fileSystemManager.WriteFile(profilePath, output);
    }
}
