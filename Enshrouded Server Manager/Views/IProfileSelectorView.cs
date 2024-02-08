using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Views;
public interface IProfileSelectorView
{
    ServerProfile SelectedProfile { get; }

    void SetProfiles(List<ServerProfile> profiles);
    void SetSelectedProfile(ServerProfile profileName);

    event EventHandler SelectedProfileChanged;

}
