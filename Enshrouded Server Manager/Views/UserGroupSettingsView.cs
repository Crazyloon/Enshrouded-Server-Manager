using Enshrouded_Server_Manager.UI;
using Enshrouded_Server_Manager.Views.Interfaces;

namespace Enshrouded_Server_Manager;
public partial class UserGroupSettingsView : UserControl, IUserGroupSettingsView
{
    public UserGroupSettingsView()
    {
        InitializeComponent();
    }

    public string AdminName
    {
        get => "Admin";
    }

    public string AdminPassword
    {
        get => txtAdminPassword.Text;
        set => txtAdminPassword.Text = value;
    }

    public bool AdminCanKickBan
    {
        get => chkCanAdminKickBan.Checked;
        set => chkCanAdminKickBan.Checked = value;
    }

    public bool AdminCanEditBase
    {
        get => chkCanAdminEditBase.Checked;
        set => chkCanAdminEditBase.Checked = value;
    }

    public bool AdminCanExtendBase
    {
        get => chkCanAdminEditBase.Checked;
        set => chkCanAdminEditBase.Checked = value;
    }

    public int AdminReservedSlots
    {
        get => (int)nudAdminReservedSlots.Value;
        set => nudAdminReservedSlots.Value = value;
    }

    public string FriendName
    {
        get => "Friend";
    }

    public string FriendPassword
    {
        get => txtFriendPassword.Text;
        set => txtFriendPassword.Text = value;
    }

    public bool FriendCanKickBan
    {
        get => chkCanFriendKickBan.Checked;
        set => chkCanFriendKickBan.Checked = value;
    }

    public bool FriendCanEditBase
    {
        get => chkCanFriendEditBase.Checked;
        set => chkCanFriendEditBase.Checked = value;
    }

    public bool FriendCanExtendBase
    {
        get => chkCanFriendEditBase.Checked;
        set => chkCanFriendEditBase.Checked = value;
    }

    public int FriendReservedSlots
    {
        get => (int)nudFriendReservedSlots.Value;
        set => nudFriendReservedSlots.Value = value;
    }

    public string GuestName
    {
        get => "Guest";
    }

    public string GuestPassword
    {
        get => txtGuestPassword.Text;
        set => txtGuestPassword.Text = value;
    }

    public bool GuestCanKickBan
    {
        get => chkCanGuestKickBan.Checked;
        set => chkCanGuestKickBan.Checked = value;
    }

    public bool GuestCanEditBase
    {
        get => chkCanGuestEditBase.Checked;
        set => chkCanGuestEditBase.Checked = value;
    }

    public bool GuestCanExtendBase
    {
        get => chkCanGuestEditBase.Checked;
        set => chkCanGuestEditBase.Checked = value;
    }

    public int GuestReservedSlots
    {
        get => (int)nudGuestReservedSlots.Value;
        set => nudGuestReservedSlots.Value = value;
    }


    public event EventHandler btnSaveSettingsClicked;

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
