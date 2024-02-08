using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services.Interfaces;
using Newtonsoft.Json;
using System.Net;

namespace Enshrouded_Server_Manager.Services;
public class VersionManager : IVersionManager
{
    private readonly IFileSystemManager _fileSystemManager;

    // TODO: Use HTTPClient instead of WebClient
    private const int TIMER_INTERVAL = 10;

    public VersionManager(IFileSystemManager fsm)
    {
        _fileSystemManager = fsm;
    }

    public async void ManagerUpdate(string currentVersionText, Label lblNewVersionText)
    {
        CheckManagerVersion(currentVersionText, lblNewVersionText);

        var timer = new PeriodicTimer(TimeSpan.FromMinutes(TIMER_INTERVAL));

        while (await timer.WaitForNextTickAsync())
        {
            CheckManagerVersion(currentVersionText, lblNewVersionText);
        }
    }

    public void CheckManagerVersion(string currentVersionText, Label lblNewVersionText)
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
                _fileSystemManager.WriteFile(Constants.Files.LOCAL_GITHUB_VERSION_JSON, output);
            }
        }
        var input = _fileSystemManager.ReadFile(Constants.Files.LOCAL_GITHUB_VERSION_JSON);

        LauncherVersion deserializedSettings = JsonConvert.DeserializeObject<LauncherVersion>(input);

        string githubversion = deserializedSettings.Version;

        if (githubversion != currentVersionText)
        {
            if (lblNewVersionText.InvokeRequired)
            {
                lblNewVersionText.BeginInvoke(() =>
                {
                    lblNewVersionText.Visible = true;
                });
            }
            else
            {
                lblNewVersionText.Visible = true;
            }
        }

        _fileSystemManager.DeleteFile(Constants.Files.LOCAL_GITHUB_VERSION_JSON);
    }

    public async Task ServerUpdateCheck(string selectedProfileName, Button btnUpdateServer)
    {
        using (HttpClient Client = new HttpClient())
        {
            try
            {
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
                if (!File.ReadLines(file).Any(line => line.Contains($"\"buildid\"		\"{buildId}\"")))
                {
                    // change update server button border to red
                    btnUpdateServer.FlatAppearance.BorderColor = Color.Yellow;
                }
                else
                {
                    btnUpdateServer.FlatAppearance.BorderColor = Color.Green;
                }
            }
            catch (Exception)
            {
                btnUpdateServer.FlatAppearance.BorderColor = Color.Red;
            }
        }
    }

}
