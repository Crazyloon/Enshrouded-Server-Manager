using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Views.Interfaces;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Views;
public partial class ProfileSelectorView : UserControl, IProfileSelectorView
{
    public ProfileSelectorView()
    {
        InitializeComponent();
        cbxProfileSelectionComboBox.SelectedIndexChanged += (sender, args) => SelectedProfileChanged?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler SelectedProfileChanged;
    public ServerProfile SelectedProfile => (ServerProfile)cbxProfileSelectionComboBox.SelectedItem;

    public void SetProfiles(BindingList<ServerProfile> profiles)
    {
        cbxProfileSelectionComboBox.DataSource = profiles;
        cbxProfileSelectionComboBox.DisplayMember = Constants.PropertyName.NAME;
        cbxProfileSelectionComboBox.SelectedIndex = 0;
    }

    public void SetSelectedProfile(ServerProfile profile)
    {
        cbxProfileSelectionComboBox.SelectedItem = profile;
    }
}
