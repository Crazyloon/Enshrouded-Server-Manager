using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Views;

public interface IManageProfilesView
{
    event EventHandler SaveProfileNameButtonClicked;

    Point Position { get; set; }
    ServerProfile? SelectedProfile { get; set; }
    public string EditProfileName { get; set; }
    public bool IsVisible { get; set; }

    void OnProfileNameUpdated();
}