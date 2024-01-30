using Enshrouded_Server_Manager.Const;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;

namespace Enshrouded_Server_Manager.Services;
public class ProfileManager
{
    public List<ServerProfile>? LoadServerProfiles(JsonSerializerSettings jsonSerializerSettings, bool firstCheck = false)
    {
        if (!File.Exists($"{Constants.Paths.DEFAULT_PROFILES_PATH}{Constants.Paths.SERVER_PROFILES_JSON}"))
        {
            Directory.CreateDirectory(Constants.Paths.DEFAULT_PROFILES_PATH);

            // First time loading server profiles should, create default profile
            if (firstCheck)
            {
                WriteDefaultProfileJson($"{Constants.Paths.DEFAULT_PROFILES_PATH}{Constants.Paths.SERVER_PROFILES_JSON}", jsonSerializerSettings);
            }
            else
            {
                MessageBox.Show($"Critical Error. {Constants.Paths.DEFAULT_PROFILES_PATH}{Constants.Paths.SERVER_PROFILES_JSON} not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        var profilesJson = File.ReadAllText($"{Constants.Paths.DEFAULT_PROFILES_PATH}{Constants.Paths.SERVER_PROFILES_JSON}");
        List<ServerProfile>? serverProfiles = JsonConvert.DeserializeObject<List<ServerProfile>>(profilesJson, jsonSerializerSettings);

        if (serverProfiles is not null && serverProfiles.Count() <= 0)
        {
            WriteDefaultProfileJson($"{Constants.Paths.DEFAULT_PROFILES_PATH}{Constants.Paths.SERVER_PROFILES_JSON}", jsonSerializerSettings);
            profilesJson = File.ReadAllText($"{Constants.Paths.DEFAULT_PROFILES_PATH}{Constants.Paths.SERVER_PROFILES_JSON}");
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
            MessageBox.Show("Profile name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

        // Check that the profileName does not contain any invalid characters
        if (profileName.IndexOfAny(invalid.ToCharArray()) != -1)
        {
            MessageBox.Show($"Profile name contains invalid characters. Use only those characters acceptable by the Windows File System", "Invalid Characters", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Name = $"Server{GenerateText.RandomString(6)}"
            }
        };

        var output = JsonConvert.SerializeObject(json, settings);
        File.WriteAllText(profilePath, output);
    }
}
