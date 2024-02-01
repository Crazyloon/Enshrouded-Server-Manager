using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;
using System.Net;

namespace Enshrouded_Server_Manager.Services;
public class VersionManager
{
    private readonly IFileSystemManager _fileSystemManager;
    private const string REMOTE_VERSION_FILE_URL = "https://raw.githubusercontent.com/ISpaikI/Enshrouded-Server-Manager/master/Enshrouded%20Server%20Manager/Version/githubversion.json";
    private const string LOCAL_VERSION_FILE = "./githubversion.json";

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
                Client.DownloadFile(REMOTE_VERSION_FILE_URL, LOCAL_VERSION_FILE);
            }
            catch (Exception)
            {
                LauncherVersion json = new LauncherVersion()
                {
                    Version = currentVersionText,
                };

                var output = JsonConvert.SerializeObject(json);
                _fileSystemManager.WriteFile(LOCAL_VERSION_FILE, output);
            }
        }
        var input = _fileSystemManager.ReadFile(LOCAL_VERSION_FILE);

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
        }

        _fileSystemManager.DeleteFile(LOCAL_VERSION_FILE);
    }
}
