using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using System.Text.Json;

namespace Enshrouded_Server_Manager.Services;
public class VersionManagementService : IVersionManagementService
{
    private readonly IFileSystemService _fileSystemService;
    private readonly IEventAggregator _eventAggregator;
    private readonly IHttpClientService _httpClientService;

    private const int TIMER_INTERVAL = 10;

    public VersionManagementService(IFileSystemService fsm, IEventAggregator eventAggregator, IHttpClientService httpClientService)
    {
        _fileSystemService = fsm;
        _eventAggregator = eventAggregator;
        _httpClientService = httpClientService;
    }

    public string SyncVersionText()
    {
        try
        {
            var localVersionFilePath = Path.Join(Constants.Paths.MANAGER_VERSION_DIRECTORY, Constants.Files.LOCAL_GITHUB_VERSION_JSON);
            var localVersionFile = _fileSystemService.ReadFile(localVersionFilePath);
            LauncherVersion deserializedSettings = JsonSerializer.Deserialize<LauncherVersion>(localVersionFile, JsonSettings.Plain);
            return deserializedSettings.Version;
        }
        catch (Exception)
        {
            return "v0.0.0";
        }
    }

    public async void ManagerUpdate(string currentVersionText)
    {
        CheckManagerVersion(currentVersionText);

        var timer = new PeriodicTimer(TimeSpan.FromMinutes(TIMER_INTERVAL));

        while (await timer.WaitForNextTickAsync())
        {
            CheckManagerVersion(currentVersionText);
        }
    }

    private void CheckManagerVersion(string currentVersionText)
    {
        try
        {
            _httpClientService.Send(Constants.Urls.REMOTE_VERSION_FILE_URL, Constants.Files.LOCAL_GITHUB_VERSION_JSON);
        }
        catch (Exception)
        {
            LauncherVersion json = new LauncherVersion()
            {
                Version = currentVersionText,
            };

            var output = JsonSerializer.Serialize(json, JsonSettings.Plain);
            _fileSystemService.WriteFile(Constants.Files.LOCAL_GITHUB_VERSION_JSON, output);
        }
        var input = _fileSystemService.ReadFile(Constants.Files.LOCAL_GITHUB_VERSION_JSON);

        LauncherVersion deserializedSettings = JsonSerializer.Deserialize<LauncherVersion>(input, JsonSettings.Plain);

        string githubversion = deserializedSettings.Version;
        int.TryParse(githubversion.Substring(1).Replace(".", ""), out int ghVersionInt);
        int.TryParse(currentVersionText.Substring(1).Replace(".", ""), out int currentVersionInt);
        if (ghVersionInt > currentVersionInt)
        {
            _eventAggregator.Publish(new NewVersionAvailableMessage());
        }

        _fileSystemService.DeleteFile(Constants.Files.LOCAL_GITHUB_VERSION_JSON);
    }
}
