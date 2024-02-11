using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;
using System.Net;

namespace Enshrouded_Server_Manager.Services;
public class VersionManagementService : IVersionManagementService
{
    private readonly IFileSystemService _fileSystemService;

    // TODO: Use HTTPClient instead of WebClient
    private const int TIMER_INTERVAL = 10;

    public VersionManagementService(IFileSystemService fsm)
    {
        _fileSystemService = fsm;
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

        if (githubversion != currentVersionText)
        {
            EventAggregator.Instance.Publish(new NewVersionAvailableMessage());
        }

        _fileSystemService.DeleteFile(Constants.Files.LOCAL_GITHUB_VERSION_JSON);
    }

    public async Task<Color> ServerUpdateCheck(string selectedProfileName)
    {
        using (HttpClient Client = new HttpClient())
        {
            try
            {
                // TODO Refactor this into the HTTPClientService so the tests don't 
                // have to send a real request to the server

                // check file for actual version
                string url = "https://api.steamcmd.net/v1/info/2278520";
                HttpResponseMessage response = await Client.GetAsync(url);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(jsonResponse);

                // readout branches>public>buildid of actual version
                dynamic dataData = data["data"];
                dynamic steamidData = dataData[$"{Constants.STEAM_APP_ID}"];
                dynamic depotData = steamidData["depots"];
                dynamic branchesData = depotData["branches"];
                dynamic publicData = branchesData["public"];
                string buildId = publicData["buildid"];

                // readout servers/selectedprofilename/steamapps/appmanifest_$AppID.acf
                var steamappsPath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Paths.GAME_SERVER_STEAMAPPS_FOLDER);
                var file = Path.Join(steamappsPath, Constants.Files.APP_MANIFEST);

                // check if file contains buildId
                if (!AppManifestContainsBuildId(file, buildId))
                {
                    // change update server button border to red
                    return Color.Yellow;
                }
                else
                {
                    return Color.Green;
                }
            }
            catch (Exception)
            {
                return Color.Red;
            }
        }
    }

    private bool AppManifestContainsBuildId(string manifestFile, string buildId)
    {
        string manifestBuildId = string.Empty;
        var lines = _fileSystemService.ReadLines(manifestFile);
        var buildIdLine = lines.FirstOrDefault(line => line.Contains("buildid"));
        manifestBuildId = buildIdLine.Split("\t").Last().Replace("\"", string.Empty);

        return buildId == manifestBuildId;
    }

}
