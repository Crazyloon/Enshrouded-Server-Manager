using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;
using System.Net;

namespace Enshrouded_Server_Manager.Services;
public class VersionManagementService : IVersionManagementService
{
    private readonly IFileSystemService _fileSystemService;
    private readonly IEventAggregator _eventAggregator;

    // TODO: Use HTTPClient instead of WebClient
    private const int TIMER_INTERVAL = 10;

    public VersionManagementService(IFileSystemService fsm, IEventAggregator eventAggregator)
    {
        _fileSystemService = fsm;
        _eventAggregator = eventAggregator;
    }

    public string SyncVersionText()
    {
        try
        {
            var localVersionFilePath = Path.Join(Constants.Paths.MANAGER_VERSION_DIRECTORY, Constants.Files.LOCAL_GITHUB_VERSION_JSON);
            var localVersionFile = _fileSystemService.ReadFile(localVersionFilePath);
            LauncherVersion deserializedSettings = JsonConvert.DeserializeObject<LauncherVersion>(localVersionFile);
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
        using (WebClient Client = new WebClient())
        {
            try
            {
                Client.DownloadFile(Constants.Urls.REMOTE_VERSION_FILE_URL, Constants.Files.LOCAL_GITHUB_VERSION_JSON);
            }
            catch (Exception)
            {
                LauncherVersion json = new LauncherVersion()
                {
                    Version = currentVersionText,
                };

                var output = JsonConvert.SerializeObject(json);
                _fileSystemService.WriteFile(Constants.Files.LOCAL_GITHUB_VERSION_JSON, output);
            }
        }
        var input = _fileSystemService.ReadFile(Constants.Files.LOCAL_GITHUB_VERSION_JSON);

        LauncherVersion deserializedSettings = JsonConvert.DeserializeObject<LauncherVersion>(input);

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
