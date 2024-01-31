using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;

namespace Enshrouded_Server_Manager.Services;
public class ProfileManager
{
    public List<ServerProfile>? LoadServerProfiles(JsonSerializerSettings jsonSerializerSettings, bool firstCheck = false)
    {
        var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.SERVER_PROFILES_JSON);

        if (!File.Exists(serverProfilesJson))
        {
            Directory.CreateDirectory(Constants.Paths.DEFAULT_PROFILES_PATH);

            // First time loading server profiles should, create default profile
            if (firstCheck)
            {
                WriteDefaultProfileJson(serverProfilesJson, jsonSerializerSettings);
            }
            else
            {
                MessageBox.Show(Constants.Errors.SERVER_PROFILES_NOT_FOUND_ERROR_MESSAGE, Constants.Errors.SERVER_PROFILES_NOT_FOUND_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        var profilesJson = File.ReadAllText(serverProfilesJson);
        List<ServerProfile>? serverProfiles = JsonConvert.DeserializeObject<List<ServerProfile>>(profilesJson, jsonSerializerSettings);

        if (serverProfiles is not null && serverProfiles.Count() <= 0)
        {
            WriteDefaultProfileJson(serverProfilesJson, jsonSerializerSettings);
            profilesJson = File.ReadAllText(serverProfilesJson);
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

    public void WriteDefaultProfileJson(string profilePath, JsonSerializerSettings settings)
    {
        var json = new List<ServerProfile>
        {
            new ServerProfile()
            {
                Name = GenerateText.RandomServerName(6)
            }
        };

        var output = JsonConvert.SerializeObject(json, settings);
        File.WriteAllText(profilePath, output);
    }
}
