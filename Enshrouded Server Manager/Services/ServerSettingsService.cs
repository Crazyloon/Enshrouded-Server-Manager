using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services.Interfaces;
using Newtonsoft.Json;

namespace Enshrouded_Server_Manager.Services;
public class ServerSettingsService : IServerSettingsService
{
    private readonly IFileSystemManager _fileSystemManager;
    private readonly IMessageBox _messageBox;
    private readonly IServer _server;

    public ServerSettingsService(IFileSystemManager fileSystemManager,
        IMessageBox messageBox,
        IServer server)
    {
        _fileSystemManager = fileSystemManager;
        _messageBox = messageBox;
        _server = server;
    }

    public ServerSettings? LoadServerSettings(string selectedProfileName)
    {
        var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);
        var gameServerConfig = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_CONFIG_JSON);

        if (!_fileSystemManager.FileExists(gameServerConfig))
        {
            _fileSystemManager.CreateDirectory(serverProfilePath);
            WriteDefaultServerSettings(selectedProfileName);
        }
        var input = _fileSystemManager.ReadFile(gameServerConfig);

        return JsonConvert.DeserializeObject<ServerSettings>(input, JsonSettings.Default);
    }

    public void SaveServerSettings(ServerSettings serverSettings, ServerProfile selectedProfile)
    {
        if (_server.IsRunning(selectedProfile.Name))
        {
            _messageBox.Show(Constants.Errors.SERVER_RUNNING_ERROR_MESSAGE, Constants.Errors.SERVER_RUNNING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Reset to original settings by reloading the profile data
            EventAggregator.Instance.Publish(new ProfileSelectedMessage(selectedProfile));
            return;
        }

        // create the server profile directory if it doesn't exist
        var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfile.Name);
        _fileSystemManager.CreateDirectory(serverProfilePath);

        // serialize the data and write it to a file
        var output = JsonConvert.SerializeObject(serverSettings, JsonSettings.Default);
        var gameServerConfig = Path.Join(Constants.Paths.SERVER_PATH, selectedProfile.Name, Constants.Files.GAME_SERVER_CONFIG_JSON);
        _fileSystemManager.WriteFile(gameServerConfig, output);
    }

    private void WriteDefaultServerSettings(string profileName)
    {
        ServerSettings json = new ServerSettings()
        {
            Name = Constants.ServerSettings.DEFAULT_SERVER_NAME,
            Password = Constants.ServerSettings.DEFAULT_SERVER_PASSWORD,
            SaveDirectory = Constants.Paths.ENSHROUDED_SAVE_GAME_DIRECTORY,
            LogDirectory = Constants.Paths.ENSHROUDED_LOGS_DIRECTORY,
            Ip = Constants.ServerSettings.DEFAULT_SERVER_IP,
            GamePort = Constants.ServerSettings.DEFAULT_SERVER_GAME_PORT,
            QueryPort = Constants.ServerSettings.DEFAULT_SERVER_QUERY_PORT,
            SlotCount = Constants.ServerSettings.DEFAULT_SERVER_SLOT_COUNT
        };

        var output = JsonConvert.SerializeObject(json, JsonSettings.Default);
        var gameServerConfig = Path.Join(Constants.Paths.SERVER_PATH, profileName, Constants.Files.GAME_SERVER_CONFIG_JSON);

        _fileSystemManager.WriteFile(gameServerConfig, output);
    }
}
