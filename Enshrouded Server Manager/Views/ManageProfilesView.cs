using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.UI;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager;
public partial class ManageProfilesView : UserControl, IManageProfilesView
{
    public ManageProfilesView()
    {
        InitializeComponent();

        EventAggregator.Instance.Subscribe<ProfileNameUpdated>(n => OnProfileNameUpdated());
    }

    public event EventHandler SaveProfileNameButtonClicked
    {
        add => btnSaveProfileName.Click += value;
        remove => btnSaveProfileName.Click -= value;
    }

    public ServerProfile? SelectedProfile { get; set; }

    public string EditProfileName
    {
        get => txtEditProfileName.Text;
        set => txtEditProfileName.Text = value;
    }
    public bool IsVisible
    {
        get => this.Visible;
        set => this.Visible = value;
    }

    public Point Position
    {
        get => this.Location;
        set => this.Location = value;
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
