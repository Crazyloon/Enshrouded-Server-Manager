using Enshrouded_Server_Manager.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Enshrouded_Server_Manager.Services
{
    public class Server
    {
        private Folder _folder;
        private JsonSerializerSettings _jsonSerializerSettings;
        private string _pathSteamCmdExe = @".\SteamCMD\steamcmd.exe";

        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);

        /// <summary>
        /// Start Gameserver
        /// </summary>
        public void Start(String pathServerExe, String ServerName)
        {
            _folder = new Folder();

            try
            {
                Process p = Process.Start(pathServerExe);
                // Pid
                int pid = p.Id;
                _folder.Create($"./cache/");
                Pid json = new Pid()
                {
                    Id = pid,
                    Profile = ServerName
                };

                var output = JsonConvert.SerializeObject(json, _jsonSerializerSettings);
                File.WriteAllText($"./cache/{ServerName}pid.json", output);
                //
                Thread.Sleep(1000);
                SetWindowText(p.MainWindowHandle, ServerName);
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

            try
            {
                var pidKill = Process.GetProcessById(pid);
                pidKill.Kill();
            }
            catch (ArgumentException)
            {
                return;
            }

        }

    }

}
