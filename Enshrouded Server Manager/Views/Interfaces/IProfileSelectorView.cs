using Enshrouded_Server_Manager.Models;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Views;
public interface IProfileSelectorView
{
    ServerProfile SelectedProfile { get; }

    void SetProfiles(BindingList<ServerProfile> profiles);
    void SetSelectedProfile(ServerProfile profileName);

    event EventHandler SelectedProfileChanged;

}
