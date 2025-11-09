using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Presenters;
public class ServerSettingsPresenter
{
    private readonly IServerSettingsView _serverSettingsView;
    private readonly IServerSettingsService _serverSettingsService;
    private readonly IFileSystemService _fileSystemService;
    private readonly IMessageBoxService _messageBox;
    private readonly IEnshroudedServerService _server;
    private readonly IEventAggregator _eventAggregator;
    private readonly IFileLoggerService _logger;

    private ServerProfile _serverProfile;
    private ServerSettings _serverSettings;

    public ServerSettingsPresenter(IServerSettingsView serverSettingsView,
        IEventAggregator eventAggregator,
        IServerSettingsService serverSettingsService,
        IFileSystemService fileSystemManager,
        IEnshroudedServerService server,
        IFileLoggerService fileLogger)
    {
        _serverSettingsView = serverSettingsView;
        _eventAggregator = eventAggregator;
        _serverSettingsService = serverSettingsService;
        _fileSystemService = fileSystemManager;
        _server = server;
        _logger = fileLogger;

        _serverSettingsView.SetGameSettingsPreset(new BindingList<GameSettingsPreset>(Enum.GetValues<GameSettingsPreset>().ToList()));

        //_serverSettingsView.ShowPasswordButtonClicked += (sender, e) => TogglePasswordVisiblity();
        _serverSettingsView.SaveChangesButtonClicked += (sender, e) => SaveServerSettings();

        _eventAggregator.Subscribe<ProfileSelectedMessage>(p => OnServerProfileSelected(p.SelectedProfile));
        _eventAggregator.Subscribe<ServerSettingsSavedSuccessMessage>(m =>
        {
            _serverSettings = m.ServerSettings;
        });
    }

    public void SetServerSettings(ServerSettings serverSettings)
    {
        _serverSettingsView.ServerName = serverSettings.Name;
        _serverSettingsView.IpAddress = serverSettings.Ip;
        _serverSettingsView.GamePort = serverSettings.GamePort;
        _serverSettingsView.QueryPort = serverSettings.QueryPort;
        _serverSettingsView.MaxPlayers = serverSettings.SlotCount;
        _serverSettingsView.GameSettingsPreset = serverSettings.GameSettingsPreset ?? "Default";
        _serverSettingsView.EnableTextChat = serverSettings.EnableTextChat;
        _serverSettingsView.EnableVoiceChat = serverSettings.EnableVoiceChat;
    }

    public void OnServerProfileSelected(ServerProfile serverProfile)
    {
        _serverProfile = serverProfile;
        if (serverProfile is not null)
        {
            _serverSettings = _serverSettingsService.LoadServerSettings(serverProfile.Name);
            SetServerSettings(_serverSettings);
        }
    }

    //private void TogglePasswordVisiblity()
    //{
    //    var text = _serverSettingsView.ShowPasswordButtonText;
    //    // \0 is a null character, which is used to show the password
    //    // * is the character displayed instead of each character in the password
    //    _serverSettingsView.PasswordChar = text == Constants.ButtonText.SHOW_PASSWORD ? '\0' : '*';

    //    _serverSettingsView.ShowPasswordButtonText = text == Constants.ButtonText.SHOW_PASSWORD ? Constants.ButtonText.HIDE_PASSWORD : Constants.ButtonText.SHOW_PASSWORD;
    //}

    private void SaveServerSettings()
    {
        ServerSettings serverSettings = new ServerSettings()
        {
            Name = _serverSettingsView.ServerName,
            //Password = _serverSettingsView.Password,
            SaveDirectory = Constants.Paths.ENSHROUDED_SAVE_GAME_DIRECTORY,
            LogDirectory = Constants.Paths.ENSHROUDED_LOGS_DIRECTORY,
            Ip = _serverSettingsView.IpAddress,
            GamePort = Convert.ToInt32(_serverSettingsView.GamePort),
            QueryPort = Convert.ToInt32(_serverSettingsView.QueryPort),
            SlotCount = Convert.ToInt32(_serverSettingsView.MaxPlayers),
            EnableVoiceChat = _serverSettingsView.EnableVoiceChat,
            EnableTextChat = _serverSettingsView.EnableTextChat,
            GameSettingsPreset = _serverSettingsView.GameSettingsPreset,
            GameSettings = _serverSettings.GameSettings,
            UserGroups = _serverSettings.UserGroups,
        };

        if (_serverSettingsService.SaveServerSettings(serverSettings, _serverProfile))
        {
            _serverSettingsView.AnimateSaveButton();
            _eventAggregator.Publish(new ServerSettingsSavedSuccessMessage(serverSettings));
        }
    }
}
