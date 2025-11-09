using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views.Interfaces;
using System.Text;

namespace Enshrouded_Server_Manager.Presenters;
public class UserGroupSettingsPresenter
{
    private readonly IUserGroupSettingsView _userGroupSettingsView;
    private readonly IServerSettingsService _serverSettingsService;
    private readonly IFileSystemService _fileSystemService;
    private readonly IMessageBoxService _messageBox;
    private readonly IEnshroudedServerService _server;
    private readonly IEventAggregator _eventAggregator;
    private readonly IFileLoggerService _logger;

    private ServerProfile _serverProfile;
    private ServerSettings _serverSettings;
    List<UserGroupSettings> userGroupSettings;

    public UserGroupSettingsPresenter(
        IUserGroupSettingsView userGroupSettingsView,
        IServerSettingsService serverSettingsService,
        IFileSystemService fileSystemService,
        IMessageBoxService messageBox,
        IEnshroudedServerService server,
        IEventAggregator eventAggregator,
        IFileLoggerService logger)
    {
        _userGroupSettingsView = userGroupSettingsView;
        _serverSettingsService = serverSettingsService;
        _fileSystemService = fileSystemService;
        _messageBox = messageBox;
        _server = server;
        _eventAggregator = eventAggregator;
        _logger = logger;

        _userGroupSettingsView.SaveChangesButtonClicked += (sender, e) => SaveServerSettings();

        _eventAggregator.Subscribe<ProfileSelectedMessage>(p => OnServerProfileSelected(p.SelectedProfile));
        _eventAggregator.Subscribe<ServerSettingsSavedSuccessMessage>(m =>
        {
            _serverSettings = m.ServerSettings;
        });
    }

    public void SetUserSettings(ServerSettings serverSettings)
    {
        userGroupSettings = serverSettings.UserGroups;

        if (userGroupSettings is null || userGroupSettings.Count < 3)
        {
            userGroupSettings = new List<UserGroupSettings>
            {
                new UserGroupSettings {
                    Name = UserGroup.Admin.ToString(),
                    Password = GetRandomPassword(8),
                    CanKickBan = true,
                    CanAccessInventories = true,
                    CanEditBase = true,
                    CanExtendBase = true,
                    ReservedSlots = 1,
                },
                new UserGroupSettings {
                    Name = UserGroup.Friend.ToString(),
                    Password = GetRandomPassword(8),
                    CanKickBan = false,
                    CanAccessInventories = true,
                    CanEditBase = true,
                    CanExtendBase = true,
                    ReservedSlots = 1,
                },
                new UserGroupSettings {
                    Name = UserGroup.Guest.ToString(),
                    Password = GetRandomPassword(8),
                    CanKickBan = false,
                    CanAccessInventories = false,
                    CanEditBase = false,
                    CanExtendBase = false,
                    ReservedSlots = 0,
                }
            };
        }

        var adminSettings = userGroupSettings.FirstOrDefault(ugs => ugs.Name == UserGroup.Admin.ToString());
        _userGroupSettingsView.AdminPassword = adminSettings.Password;
        _userGroupSettingsView.AdminCanKickBan = adminSettings.CanKickBan;
        _userGroupSettingsView.AdminCanAccessInventories = adminSettings.CanAccessInventories;
        _userGroupSettingsView.AdminCanEditBase = adminSettings.CanEditBase;
        _userGroupSettingsView.AdminCanExtendBase = adminSettings.CanExtendBase;
        _userGroupSettingsView.AdminReservedSlots = adminSettings.ReservedSlots;

        var friendSettings = userGroupSettings.FirstOrDefault(ugs => ugs.Name == UserGroup.Friend.ToString());
        _userGroupSettingsView.FriendPassword = friendSettings.Password;
        _userGroupSettingsView.FriendCanKickBan = friendSettings.CanKickBan;
        _userGroupSettingsView.FriendCanAccessInventories = friendSettings.CanAccessInventories;
        _userGroupSettingsView.FriendCanEditBase = friendSettings.CanEditBase;
        _userGroupSettingsView.FriendCanExtendBase = friendSettings.CanExtendBase;
        _userGroupSettingsView.FriendReservedSlots = friendSettings.ReservedSlots;

        var guestSettings = userGroupSettings.FirstOrDefault(ugs => ugs.Name == UserGroup.Guest.ToString());
        _userGroupSettingsView.GuestPassword = guestSettings.Password;
        _userGroupSettingsView.GuestCanKickBan = guestSettings.CanKickBan;
        _userGroupSettingsView.GuestCanAccessInventories = guestSettings.CanAccessInventories;
        _userGroupSettingsView.GuestCanEditBase = guestSettings.CanEditBase;
        _userGroupSettingsView.GuestCanExtendBase = guestSettings.CanExtendBase;
        _userGroupSettingsView.GuestReservedSlots = guestSettings.ReservedSlots;

    }

    public void OnServerProfileSelected(ServerProfile serverProfile)
    {
        _serverProfile = serverProfile;
        if (serverProfile is not null)
        {
            _serverSettings = _serverSettingsService.LoadServerSettings(serverProfile.Name);
            SetUserSettings(_serverSettings);
        }
    }

    private void SaveServerSettings()
    {
        _serverSettings.UserGroups = new List<UserGroupSettings>()
        {
            new UserGroupSettings()
            {
                Name = UserGroup.Admin.ToString(),
                Password = _userGroupSettingsView.AdminPassword,
                CanKickBan = _userGroupSettingsView.AdminCanKickBan,
                CanAccessInventories = _userGroupSettingsView.AdminCanAccessInventories,
                CanEditBase = _userGroupSettingsView.AdminCanEditBase,
                CanExtendBase = _userGroupSettingsView.AdminCanExtendBase,
                ReservedSlots = _userGroupSettingsView.AdminReservedSlots,
            },
            new UserGroupSettings()
            {
                Name = UserGroup.Friend.ToString(),
                Password = _userGroupSettingsView.FriendPassword,
                CanKickBan = _userGroupSettingsView.FriendCanKickBan,
                CanAccessInventories = _userGroupSettingsView.FriendCanAccessInventories,
                CanEditBase = _userGroupSettingsView.FriendCanEditBase,
                CanExtendBase = _userGroupSettingsView.FriendCanExtendBase,
                ReservedSlots = _userGroupSettingsView.FriendReservedSlots,
            },
            new UserGroupSettings()
            {
                Name = UserGroup.Guest.ToString(),
                Password = _userGroupSettingsView.GuestPassword,
                CanKickBan = _userGroupSettingsView.GuestCanKickBan,
                CanAccessInventories = _userGroupSettingsView.GuestCanAccessInventories,
                CanEditBase = _userGroupSettingsView.GuestCanEditBase,
                CanExtendBase = _userGroupSettingsView.GuestCanExtendBase,
                ReservedSlots = _userGroupSettingsView.GuestReservedSlots,
            }
        };

        if (_serverSettingsService.SaveServerSettings(_serverSettings, _serverProfile))
        {
            _userGroupSettingsView.AnimateSaveButton();
            _eventAggregator.Publish(new ServerSettingsSavedSuccessMessage(_serverSettings));
        }
    }

    /// <summary>
    /// Generates a random string of the specified length using characters from:
    /// - Uppercase and lowercase English letters (A-Z, a-z)
    /// - Digits (0-9)
    /// - Special characters: !@#$%^&*()
    /// </summary>
    public string GetRandomPassword(int length)
    {
        if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
        const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";
        var rnd = new Random();
        var sb = new StringBuilder(length);
        for (int i = 0; i < length; ++i)
        {
            char c = allowedChars[rnd.Next(allowedChars.Length)];
            sb.Append(c);
        }
        return sb.ToString();
    }
}
