using System.Diagnostics;
using System.IO.Compression;
using System.Net;

namespace Enshrouded_Server_Manager.Services;

public class SteamCMD
{
    private const string TARGET_FOLDER = "./SteamCMD/";
    private const string STEAM_CMD_ZIP = $"{TARGET_FOLDER}steamcmd.zip";
    private const string STEAM_CMD_EXE = $"{TARGET_FOLDER}steamcmd.exe";
    private const string STEAM_CMD_CDN_URL = "https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip";

    /// <summary>
    /// Download and installation of SteamCMD in the same folder as the Executeable
    /// </summary>
    public void Install()
    {
        Directory.CreateDirectory(TARGET_FOLDER);

        if (File.Exists(STEAM_CMD_ZIP))
        {
            try
            {
                File.Delete(STEAM_CMD_ZIP);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Following error appeared while extracting: {ex.Message}",
                "Error while extracting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //Download of SteamCMD Client
        using (WebClient Client = new WebClient())
        {
            Client.DownloadFile(STEAM_CMD_CDN_URL, STEAM_CMD_ZIP);
        }

        if (File.Exists(STEAM_CMD_EXE))
        {
            try
            {
                File.Delete(STEAM_CMD_EXE);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Following error appeared while extracting: {ex.Message}",
                "Error while extracting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        try
        {
            ZipFile.ExtractToDirectory(STEAM_CMD_ZIP, TARGET_FOLDER);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Following error appeared while extracting: {ex.Message}",
                "Error while extracting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (File.Exists(STEAM_CMD_ZIP))
        {
            try
            {
                File.Delete(STEAM_CMD_ZIP);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Following error appeared while extracting: {ex.Message}",
                "Error while extracting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
    public void Start()
    {
        try
        {
            Process p = Process.Start(STEAM_CMD_EXE, $"+quit");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Following error occured while installing SteamCMD: {ex.Message}",
                "Error while installing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }
}