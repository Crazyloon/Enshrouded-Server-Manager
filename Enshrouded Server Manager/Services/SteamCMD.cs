using Enshrouded_Server_Manager.Services.Interfaces;
using System.Diagnostics;

namespace Enshrouded_Server_Manager.Services;

public class SteamCMD : ISteamCMDInstaller
{
    private readonly IFileSystemManager _fileSystemManager;
    private readonly IProcessManager _processManager;
    private readonly IMessageBox _messageBox;
    private readonly IHttpClient _httpClient;

    private const string TARGET_FOLDER = "./SteamCMD/";
    private const string STEAM_CMD_ZIP = $"{TARGET_FOLDER}steamcmd.zip";
    private const string STEAM_CMD_EXE = $"{TARGET_FOLDER}steamcmd.exe";

    public SteamCMD(IFileSystemManager fileSystemManager, IProcessManager processManager, IMessageBox messageBox, IHttpClient httpClient)
    {
        _fileSystemManager = fileSystemManager;
        _processManager = processManager;
        _messageBox = messageBox;
        _httpClient = httpClient;
    }

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
            _httpClient.Send(Constants.Urls.STEAM_CMD_CDN_URL, STEAM_CMD_ZIP);

            _fileSystemManager.DeleteFile(STEAM_CMD_EXE);

            _fileSystemManager.ExtractZipToDirectory(STEAM_CMD_ZIP, TARGET_FOLDER);

            _fileSystemManager.DeleteFile(STEAM_CMD_ZIP);
        }
        catch (Exception ex)
        {
            _messageBox.Show(string.Format(Constants.Errors.STEAM_CMD_DOWNLOAD_ERROR_MESSAGE, ex.Message),
                Constants.Errors.STEAM_CMD_DOWNLOAD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
    public void Start()
    {
        try
        {
            Process p = _processManager.Start(STEAM_CMD_EXE, "+quit");
        }
        catch (Exception ex)
        {
            _messageBox.Show(string.Format(Constants.Errors.STEAM_CMD_INSTALL_ERROR_MESSAGE, ex.Message),
                Constants.Errors.STEAM_CMD_INSTALL_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}