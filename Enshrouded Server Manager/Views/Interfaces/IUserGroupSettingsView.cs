namespace Enshrouded_Server_Manager.Views.Interfaces;

public interface IUserGroupSettingsView
{
    string AdminName { get; }
    string AdminPassword { get; set; }
    bool AdminCanKickBan { get; set; }
    bool AdminCanEditBase { get; set; }
    bool AdminCanExtendBase { get; set; }
    int AdminReservedSlots { get; set; }

    string FriendName { get; }
    string FriendPassword { get; set; }
    bool FriendCanKickBan { get; set; }
    bool FriendCanEditBase { get; set; }
    bool FriendCanExtendBase { get; set; }
    int FriendReservedSlots { get; set; }

    string GuestName { get; }
    string GuestPassword { get; set; }
    bool GuestCanKickBan { get; set; }
    bool GuestCanEditBase { get; set; }
    bool GuestCanExtendBase { get; set; }
    int GuestReservedSlots { get; set; }

    event EventHandler SaveChangesButtonClicked;

    void AnimateSaveButton();
}