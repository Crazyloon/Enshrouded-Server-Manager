using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;

namespace Enshrouded_Server_Manager.Services.Interfaces;

public interface IProfileManager
{
    List<ServerProfile>? LoadServerProfiles(JsonSerializerSettings jsonSerializerSettings, bool firstCheck = false);
    bool IsProfileNameValid(string profileName);
}