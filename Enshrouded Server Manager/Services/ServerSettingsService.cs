using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services.Interfaces;
using Newtonsoft.Json;

namespace Enshrouded_Server_Manager.Services;
public class ServerSettingsService : IServerSettingsService
{
    private readonly IFileSystemManager _fileSystemManager;

    public ServerSettingsService(IFileSystemManager fileSystemManager)
    {
        _fileSystemManager = fileSystemManager;
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
