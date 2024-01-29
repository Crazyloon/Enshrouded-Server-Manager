using Enshrouded_Server_Manager.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Enshrouded_Server_Manager.Services;

public class Server
{
    private Folder _folder;
    private const string PATH_STEAM_CMD_EXE = @".\SteamCMD\steamcmd.exe";
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
    public void Start(String pathServerExe, String ServerName)
    {
        _folder = new Folder();

        try
        {
            Process p = Process.Start(pathServerExe);
            //Thread.Sleep(10000);
            //SetWindowText(p.MainWindowHandle, ServerName);
            int pid = p.Id;
            _folder.Create($"./cache/");
            EnshroudedServerProcess json = new EnshroudedServerProcess()
            {
                Id = pid,
                Profile = ServerName
            };

            var output = JsonConvert.SerializeObject(json);
            File.WriteAllText($"./cache/{ServerName}pid.json", output);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Following error occured while starting the server: {ex.Message.ToString()}",
                "Error while starting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    /// <summary>
    /// Install/Validate/Update GameServer Files
    /// </summary>
    public void InstallUpdate(String SteamAppId, String Serverpath)
    {
        try
        {
            Process p = Process.Start(PATH_STEAM_CMD_EXE, $"+force_install_dir {Serverpath} +login anonymous +app_update {SteamAppId} validate +quit");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Following error occured while updating the server: {ex.Message.ToString()}",
                "Error while updating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    /// <summary>
    /// Stop Gameserver
    /// </summary>
    public void Stop(String ServerName)
    {
        if (!File.Exists($"./cache/{ServerName}pid.json"))
        {
            return;
        }

        // Load pid
        var input = File.ReadAllText($"./cache/{ServerName}pid.json");

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

        File.Delete($"./cache/{ServerName}pid.json");
    }

    public static int? GetServerProcessId(string profileName)
    {
        if (!File.Exists($"./cache/{profileName}pid.json"))
        {
            return null;
        }

        var input = File.ReadAllText($"./cache/{profileName}pid.json");
        EnshroudedServerProcess? serverProcessInfo = JsonConvert.DeserializeObject<EnshroudedServerProcess>(input);

        if (serverProcessInfo == null)
        {
            return null;
        }

        Process p;
        try
        {
            p = Process.GetProcessById(serverProcessInfo.Id);

        }
        catch (ArgumentException)
        {
            // The process doesn't exist anymore, so we can delete the pid file
            File.Delete($"./cache/{profileName}pid.json");
            return null;
        }

        return p.Id;
    }

    public static bool IsRunning(int pid)
    {
        Process p;
        try
        {
            p = Process.GetProcessById(pid);

        }
        catch (ArgumentException)
        {
            return false;
        }

        return SERVER_PROCESS_NAME == p.ProcessName;
    }

    public static bool IsRunning(string profileName)
    {
        var pid = GetServerProcessId(profileName);
        if (pid is null)
        {
            return false;
        }

        return IsRunning(pid.Value);
    }

}
