using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Services;

public interface IProfileService
{
    List<ServerProfile>? LoadServerProfiles(JsonSerializerSettings jsonSerializerSettings, bool firstCheck = false);
    bool IsProfileNameValid(string profileName);
    bool RenameProfilePaths(BindingList<ServerProfile> profiles, ServerProfile profile, string newProfileName);
}