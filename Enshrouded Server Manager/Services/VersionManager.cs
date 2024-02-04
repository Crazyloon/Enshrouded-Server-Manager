using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;
using System.Net;

namespace Enshrouded_Server_Manager.Services;
public class VersionManager
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

    public async Task ServerUpdateCheck(string selectedProfileName)
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
                dynamic branchesData = data["branches"];
                dynamic publicData = branchesData["public"];
                string buildId = publicData["buildid"];

                // readout servers/selectedprofilename/steamapps/appmanifest_$AppID.acf
                var steamappsPath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Paths.GAME_SERVER_STEAMAPPS_FOLDER);
                var file = Path.Join(steamappsPath, Constants.Files.APP_MANIFEST);

                // readout buildid out of app manifest of the server
                dynamic dataFile = JsonConvert.DeserializeObject(file);
                string buildIdFile = dataFile["buildid"];


                //check if not !=
                if (buildId != buildIdFile)
                {
                    // change update Server btn border to red
                    // btnUpdateServer.FlatAppearance.BorderColor = Color.Red;
                }
            }
            catch (Exception)
            {

            }
        }
    }

}
