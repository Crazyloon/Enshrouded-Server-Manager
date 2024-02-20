using Enshrouded_Server_Manager.Models;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Views;
public interface IProfileSelectorView
{
    event EventHandler SelectedProfileChanged;
    event EventHandler AddProfileButtonClicked;
    event EventHandler DeleteProfileButtonClicked;
    event EventHandler RenameProfileButtonClicked;

    string RenameButtonText { get; set; }
    string TimeLeft { get; set; }
    bool TimeLeftVisible { get; set; }
    ServerProfile SelectedProfile { get; }

    void SetProfiles(BindingList<ServerProfile> profiles);
}
