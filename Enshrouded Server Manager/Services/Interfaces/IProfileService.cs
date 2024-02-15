using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;

namespace Enshrouded_Server_Manager.Services;

public interface IProfileService
{
    List<ServerProfile>? LoadServerProfiles(JsonSerializerSettings jsonSerializerSettings, bool firstCheck = false);
    bool IsProfileNameValid(string profileName);
    void RenameServerSettings(string oldServerProfileName, string newServerProfileName);
}