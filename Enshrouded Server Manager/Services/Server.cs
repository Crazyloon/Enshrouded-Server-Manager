using Enshrouded_Server_Manager.Const;
using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Enshrouded_Server_Manager.Services;

public class Server
{
    private const string PID_JSON = "pid.json";
    private const string CACHE_DIRECTORY = "./cache/";
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
    public void Start(string pathServerExe, string ServerName)
    {

        try
        {
            Process p = Process.Start(pathServerExe);
            //Thread.Sleep(10000);
            //SetWindowText(p.MainWindowHandle, ServerName);
            int pid = p.Id;
            Directory.CreateDirectory($"{CACHE_DIRECTORY}");
            EnshroudedServerProcess json = new EnshroudedServerProcess()
            {
                Id = pid,
                Profile = ServerName
            };

            var output = JsonConvert.SerializeObject(json);
            File.WriteAllText($"{CACHE_DIRECTORY}{ServerName}{PID_JSON}", output);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Following error occured while starting the server: {ex.Message}",
                "Error while starting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    /// <summary>
    /// Install/Validate/Update GameServer Files
    /// </summary>
    public void InstallUpdate(string SteamAppId, string Serverpath)
    {
        try
        {
            Process p = Process.Start(Constants.Paths.STEAM_CMD_EXE, $"+force_install_dir {Serverpath} +login anonymous +app_update {SteamAppId} validate +quit");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Following error occured while updating the server: {ex.Message}",
                "Error while updating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    /// <summary>
    /// Stop Gameserver
    /// </summary>
    public void Stop(string ServerName)
    {
        if (!File.Exists($"{CACHE_DIRECTORY}{ServerName}{PID_JSON}"))
        {
            return;
        }

        // Load pid
        var input = File.ReadAllText($"{CACHE_DIRECTORY}{ServerName}{PID_JSON}");

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

        File.Delete($"{CACHE_DIRECTORY}{ServerName}{PID_JSON}");
    }

    public static bool IsRunning(string ServerName)
    {
        if (!File.Exists($"{CACHE_DIRECTORY}{ServerName}{PID_JSON}"))
        {
            return false;
        }

        var input = File.ReadAllText($"{CACHE_DIRECTORY}{ServerName}{PID_JSON}");
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
            File.Delete($"{CACHE_DIRECTORY}{ServerName}{PID_JSON}");
            return false;
        }

        return SERVER_PROCESS_NAME == p.ProcessName;
    }
}
