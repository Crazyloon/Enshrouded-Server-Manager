using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;

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

        _serverSettingsView.ShowPasswordButtonClicked += (sender, e) => TogglePasswordVisiblity();
        _serverSettingsView.SaveChangesButtonClicked += (sender, e) => SaveServerSettings();

        _eventAggregator.Subscribe<ProfileSelectedMessage>(p => OnServerProfileSelected(p.SelectedProfile));
    }

    public void SetServerSettings(ServerSettings serverSettings)
    {
        _serverSettingsView.ServerName = serverSettings.Name;
        _serverSettingsView.Password = serverSettings.Password;
        _serverSettingsView.IpAddress = serverSettings.Ip;
        _serverSettingsView.GamePort = serverSettings.GamePort;
        _serverSettingsView.QueryPort = serverSettings.QueryPort;
        _serverSettingsView.MaxPlayers = serverSettings.SlotCount;
    }

    public void OnServerProfileSelected(ServerProfile serverProfile)
    {
        _serverProfile = serverProfile;
        if (serverProfile is not null)
        {
            var settings = _serverSettingsService.LoadServerSettings(serverProfile.Name);
            SetServerSettings(settings);
        }
    }

    private void TogglePasswordVisiblity()
    {
        var text = _serverSettingsView.ShowPasswordButtonText;
        // \0 is a null character, which is used to show the password
        // * is the character displayed instead of each character in the password
        _serverSettingsView.PasswordChar = text == Constants.ButtonText.SHOW_PASSWORD ? '\0' : '*';

        _serverSettingsView.ShowPasswordButtonText = text == Constants.ButtonText.SHOW_PASSWORD ? Constants.ButtonText.HIDE_PASSWORD : Constants.ButtonText.SHOW_PASSWORD;
    }

    private void SaveServerSettings()
    {
        ServerSettings json = new ServerSettings()
        {
            Name = _serverSettingsView.ServerName,
            Password = _serverSettingsView.Password,
            SaveDirectory = Constants.Paths.ENSHROUDED_SAVE_GAME_DIRECTORY,
            LogDirectory = Constants.Paths.ENSHROUDED_LOGS_DIRECTORY,
            Ip = _serverSettingsView.IpAddress,
            GamePort = Convert.ToInt32(_serverSettingsView.GamePort),
            QueryPort = Convert.ToInt32(_serverSettingsView.QueryPort),
            SlotCount = Convert.ToInt32(_serverSettingsView.MaxPlayers)
        };

        if (_serverSettingsService.SaveServerSettings(json, _serverProfile))
        {
            _serverSettingsView.AnimateSaveButton();
        }
    }
}
