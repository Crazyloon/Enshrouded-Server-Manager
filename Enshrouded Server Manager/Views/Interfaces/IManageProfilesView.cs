using Enshrouded_Server_Manager.Models;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Views;

public interface IManageProfilesView
{
    event EventHandler AddProfileButtonClicked;
    event EventHandler EditProfileButtonClicked;
    event EventHandler DeleteProfileButtonClicked;
    event EventHandler SelectedProfileChanged;

    ServerProfile? SelectedProfile { get; }
    public string EditProfileName { get; set; }

    void SetProfiles(BindingList<ServerProfile> profiles);
}