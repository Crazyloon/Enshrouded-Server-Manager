using System.Diagnostics;
using System.IO.Compression;
using System.Net;

namespace Enshrouded_Server_Manager.Services;

public class SteamCMD
{

    FileSystemManager _fileSystemManager = new FileSystemManager();
    private const string TARGET_FOLDER = "./SteamCMD/";
    private const string STEAM_CMD_ZIP = $"{TARGET_FOLDER}steamcmd.zip";
    private const string STEAM_CMD_EXE = $"{TARGET_FOLDER}steamcmd.exe";
    private const string STEAM_CMD_CDN_URL = "https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip";

    /// <summary>
    /// Download and installation of SteamCMD in the same folder as the Executeable
    /// </summary>
    public void Install()
    {
        try
        {
            _fileSystemManager.CreateDirectory(TARGET_FOLDER);
            _fileSystemManager.DeleteFile(STEAM_CMD_ZIP);

            //Download of SteamCMD Client
            using (WebClient Client = new WebClient())
            {
                Client.DownloadFile(STEAM_CMD_CDN_URL, STEAM_CMD_ZIP);
            }

            _fileSystemManager.DeleteFile(STEAM_CMD_EXE);

            ZipFile.ExtractToDirectory(STEAM_CMD_ZIP, TARGET_FOLDER);

            _fileSystemManager.DeleteFile(STEAM_CMD_ZIP);
        }
        catch (Exception ex)
        {
            MessageBox.Show(string.Format(Constants.Errors.STEAM_CMD_DOWNLOAD_ERROR_MESSAGE, ex.Message),
                Constants.Errors.STEAM_CMD_DOWNLOAD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

    }
    public void Start()
    {
        try
        {
            Process p = Process.Start(STEAM_CMD_EXE, "+quit");
        }
        catch (Exception ex)
        {
            MessageBox.Show(string.Format(Constants.Errors.STEAM_CMD_INSTALL_ERROR_MESSAGE, ex.Message),
                Constants.Errors.STEAM_CMD_INSTALL_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return;
        }
    }
}