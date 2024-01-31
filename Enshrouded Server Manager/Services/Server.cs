using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Enshrouded_Server_Manager.Services;

public class Server
{
    private const string SERVER_PROCESS_NAME = "enshrouded_server";

    [DllImport("user32.dll")]
    static extern int SetWindowText(IntPtr hWnd, string text);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool AttachConsole(uint dwProcessId);

    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    static extern bool FreeConsole();

    [DllImport("kernel32.dll")]
    static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate handler, bool add);

    delegate Boolean ConsoleCtrlDelegate(CtrlTypes type);

    enum CtrlTypes : uint
    {
        CTRL_C_EVENT = 0,
        CTRL_BREAK_EVENT,
        CTRL_CLOSE_EVENT,
        CTRL_LOGOFF_EVENT = 5,
        CTRL_SHUTDOWN_EVENT
    }

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GenerateConsoleCtrlEvent(CtrlTypes dwCtrlEvent, uint dwProcessGroupId);

    /// <summary>
    /// Start Gameserver
    /// </summary>
    public void Start(string pathServerExe, string selectedProfileName)
    {

        try
        {
            Process p = Process.Start(pathServerExe);
            //Thread.Sleep(10000);
            //SetWindowText(p.MainWindowHandle, ServerName);
            int pid = p.Id;

            var serverCachePath = Path.Join(Constants.Paths.CACHE_DIRECTORY, selectedProfileName);

            Directory.CreateDirectory(serverCachePath);
            EnshroudedServerProcess json = new EnshroudedServerProcess()
            {
                Id = pid,
                Profile = selectedProfileName
            };

            var output = JsonConvert.SerializeObject(json);
            var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, selectedProfileName, Constants.Files.PID_JSON);
            File.WriteAllText(pidJsonFile, output);
        }
        catch (Exception ex)
        {
            MessageBox.Show(string.Format(Constants.Errors.SERVER_START_ERROR_MESSAGE, ex.Message),
                Constants.Errors.SERVER_START_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return;
        }
    }

    /// <summary>
    /// Install/Validate/Update GameServer Files
    /// </summary>
    public void InstallUpdate(string steamAppId, string serverProfilePath)
    {
        try
        {
            Process p = Process.Start(Constants.ProcessNames.STEAM_CMD_EXE, $"+force_install_dir {serverProfilePath} +login anonymous +app_update {steamAppId} validate +quit");
        }
        catch (Exception ex)
        {
            MessageBox.Show(string.Format(Constants.Errors.SERVER_UPDATE_ERROR_MESSAGE, ex.Message),
                Constants.Errors.SERVER_UPDATE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    /// <summary>
    /// Stop Gameserver
    /// </summary>
    public void Stop(string selectedProfileName)
    {
        var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, selectedProfileName, Constants.Files.PID_JSON);
        if (!File.Exists(pidJsonFile))
        {
            return;
        }

        // Load pid
        var input = File.ReadAllText(pidJsonFile);

        EnshroudedServerProcess? serverProcessInfo = JsonConvert.DeserializeObject<EnshroudedServerProcess>(input);

        int pid = serverProcessInfo.Id;
        string name = serverProcessInfo.Profile;

        try
        {
            Process p = Process.GetProcessById(pid);
            FreeConsole();
            if (AttachConsole((uint)pid))
            {
                SetConsoleCtrlHandler(null, true);
                GenerateConsoleCtrlEvent(CtrlTypes.CTRL_C_EVENT, 0);
                Thread.Sleep(2000);
                FreeConsole();
                SetConsoleCtrlHandler(null, false);
            }
        }
        catch (ArgumentException)
        {
            return;
        }

        File.Delete(pidJsonFile);
    }

    public static bool IsRunning(string selectedProfileName)
    {
        var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, selectedProfileName, Constants.Files.PID_JSON);
        if (!File.Exists(pidJsonFile))
        {
            return false;
        }

        var input = File.ReadAllText(pidJsonFile);
        EnshroudedServerProcess? serverProcessInfo = JsonConvert.DeserializeObject<EnshroudedServerProcess>(input);

        if (serverProcessInfo == null)
        {
            return false;
        }

        Process p;
        try
        {
            p = Process.GetProcessById(serverProcessInfo.Id);
        }
        catch (ArgumentException)
        {
            // The process doesn't exist anymore, so we can delete the pid file
            File.Delete(pidJsonFile);
            return false;
        }

        return SERVER_PROCESS_NAME == p.ProcessName;
    }
}
