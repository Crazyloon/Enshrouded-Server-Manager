using Enshrouded_Server_Manager.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Enshrouded_Server_Manager.Services
{
    public class Server
    {
        private Folder _folder;
        private JsonSerializerSettings _jsonSerializerSettings;
        private string _pathSteamCmdExe = @".\SteamCMD\steamcmd.exe";

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
                Pid json = new Pid()
                {
                    Id = pid,
                    Profile = ServerName
                };

                var output = JsonConvert.SerializeObject(json, _jsonSerializerSettings);
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
                Process p = Process.Start(_pathSteamCmdExe, $"+force_install_dir {Serverpath} +login anonymous +app_update {SteamAppId} validate +quit");
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
            // Load pid
            var input = File.ReadAllText($"./cache/{ServerName}pid.json");

            Pid deserializedSettings = JsonConvert.DeserializeObject<Pid>(input, _jsonSerializerSettings);

            int pid = deserializedSettings.Id;
            string name = deserializedSettings.Profile;

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

        }

    }

}
