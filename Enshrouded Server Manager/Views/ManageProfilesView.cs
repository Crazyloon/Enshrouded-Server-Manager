using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.UI;
using Enshrouded_Server_Manager.Views;
using System.ComponentModel;

namespace Enshrouded_Server_Manager;
public partial class ManageProfilesView : UserControl, IManageProfilesView
{
    public ManageProfilesView()
    {
        InitializeComponent();

        EventAggregator.Instance.Subscribe<ProfileNameUpdated>(n => OnProfileNameUpdated());
    }

    public event EventHandler AddProfileButtonClicked
    {
        add => btnAddNewProfile.Click += value;
        remove => btnAddNewProfile.Click -= value;
    }

    public event EventHandler EditProfileButtonClicked
    {
        add => btnSaveProfileName.Click += value;
        remove => btnSaveProfileName.Click -= value;
    }

    public event EventHandler DeleteProfileButtonClicked
    {
        add => btnDeleteProfile.Click += value;
        remove => btnDeleteProfile.Click -= value;
    }

    public event EventHandler SelectedProfileChanged
    {
        add => lbxServerProfiles.SelectedIndexChanged += value;
        remove => lbxServerProfiles.SelectedIndexChanged -= value;
    }


    public ServerProfile? SelectedProfile => (ServerProfile?)lbxServerProfiles.SelectedItem;

    public string EditProfileName
    {
        get => txtEditProfileName.Text;
        set => txtEditProfileName.Text = value;
    }

    public void SetProfiles(BindingList<ServerProfile> profiles)
    {
        lbxServerProfiles.DataSource = profiles;
        lbxServerProfiles.DisplayMember = Constants.PropertyName.NAME;
    }

    public void SetSelectedProfile(ServerProfile profileName)
    {
        lbxServerProfiles.SelectedItem = profileName;
    }
    private void OnProfileNameUpdated()
    {
        Interactions.AnimateSaveChangesButton(btnSaveProfileName, btnSaveProfileName.Text, Constants.ButtonText.SAVED_SUCCESS);
    }

    private void btnSaveProfileName_EnabledChanged(object sender, EventArgs e)
    {
        Interactions.HandleEnabledChanged_PrimaryButton((Button)sender);
    }
}
