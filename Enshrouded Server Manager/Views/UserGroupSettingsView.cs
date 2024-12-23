using Enshrouded_Server_Manager.UI;
using Enshrouded_Server_Manager.Views.Interfaces;

namespace Enshrouded_Server_Manager;
public partial class UserGroupSettingsView : UserControl, IUserGroupSettingsView
{
    public UserGroupSettingsView()
    {
        InitializeComponent();
    }

    public event EventHandler SaveChangesButtonClicked
    {
        add => btnSaveSettings.Click += value;
        remove => btnSaveSettings.Click -= value;
    }

    public void AnimateSaveButton()
    {
        Interactions.AnimateSaveChangesButton(btnSaveSettings, btnSaveSettings.Text, Constants.ButtonText.SAVED_SUCCESS);
    }

    private void btnSaveSettings_EnabledChanged(object sender, EventArgs e)
    {
        var button = ((Button)sender);
        Interactions.HandleEnabledChanged_PrimaryButton(button);
    }
}
