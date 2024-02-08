using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Services.Interfaces;
using Newtonsoft.Json;

namespace Enshrouded_Server_Manager.Presenters;
public class ServerSettingsPresenter
{
    private readonly IServerSettingsView _serverSettingsView;
    private readonly IServerSettingsService _serverSettingsService;
    private readonly IFileSystemManager _fileSystemManager;
    private readonly IMessageBox _messageBox;
    private readonly IServer _server;
    private ServerProfile _serverProfile;

    public ServerSettingsPresenter(IServerSettingsView serverSettingsView,
        IServerSettingsService serverSettingsService,
        IFileSystemManager fileSystemManager,
        IServer server)
    {
        _serverSettingsView = serverSettingsView;
        _serverSettingsService = serverSettingsService;
        _fileSystemManager = fileSystemManager;
        _server = server;

        _serverSettingsView.ShowPasswordButtonClicked += (sender, e) => TogglePasswordVisiblity();
        _serverSettingsView.SaveChangesButtonClicked += (sender, e) => SaveServerSettings();

        EventAggregator.Instance.Subscribe<ProfileSelectedMessage>(p => OnServerProfileSelected(p.SelectedProfile));
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

    private void OnServerProfileSelected(ServerProfile serverProfile)
    {
        _serverProfile = serverProfile;
        var settings = _serverSettingsService.LoadServerSettings(serverProfile.Name);
        SetServerSettings(settings);
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
        string selectedProfileName = _serverProfile.Name;

        if (_server.IsRunning(selectedProfileName))
        {
            _messageBox.Show(Constants.Errors.SERVER_RUNNING_ERROR_MESSAGE, Constants.Errors.SERVER_RUNNING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

            // TODO:
            //cbxProfileSelectionComboBox_IndexChanged(sender, e);
            return;
        }

        var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);
        _fileSystemManager.CreateDirectory(serverProfilePath);

        int Gameport = Convert.ToInt32(_serverSettingsView.GamePort);
        int QueryPort = Convert.ToInt32(_serverSettingsView.QueryPort);
        int SlotCount = Convert.ToInt32(_serverSettingsView.MaxPlayers);

        ServerSettings json = new ServerSettings()
        {
            Name = _serverSettingsView.ServerName,
            Password = _serverSettingsView.Password,
            SaveDirectory = Constants.Paths.ENSHROUDED_SAVE_GAME_DIRECTORY,
            LogDirectory = Constants.Paths.ENSHROUDED_LOGS_DIRECTORY,
            Ip = _serverSettingsView.IpAddress,
            GamePort = Gameport,
            QueryPort = QueryPort,
            SlotCount = SlotCount
        };

        var output = JsonConvert.SerializeObject(json, JsonSettings.Default);

        var gameServerConfig = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Files.GAME_SERVER_CONFIG_JSON);
        _fileSystemManager.WriteFile(gameServerConfig, output); //needs to be the server tool .json

        // TODO:
        //Interactions.AnimateSaveChangesButton(btnSaveSettings, btnSaveSettings.Text, Constants.ButtonText.SAVED_SUCCESS);


    }
}
