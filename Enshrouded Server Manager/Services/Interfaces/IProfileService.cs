using Enshrouded_Server_Manager.Models;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Services;

public interface IProfileService
{
    List<ServerProfile>? LoadServerProfiles(bool firstCheck = false);
    bool IsProfileNameValid(string profileName);
    bool RenameProfilePaths(BindingList<ServerProfile> profiles, ServerProfile profile, string newProfileName);
}