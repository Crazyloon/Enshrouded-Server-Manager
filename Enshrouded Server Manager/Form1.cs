using Enshrouded_Server_Manager.Services;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using Enshrouded_Server_Manager.Model;

namespace Enshrouded_Server_Manager
{
    public partial class Form1 : Form
    {
        private SteamCMD _steamCMD;
        private Server _server;
        private Backup _backup;
        private Folder _folder;

        // Server Tool SteamId
        private string _steamAppId = "2278520";
        // Game Server exe Name
        private string _gameServerExe = @"/enshrouded_server.exe";
        // Game Server config Name
        private string _gameServerConfig = "enshrouded_server.json";
        // Savegame folder name after Server folder
        private string _gameServerSaveFolder = @"./savegame";
        // Logs folder name after Server folder
        private string _gameServerLogsFolder = @"./logs";

        private string _steamCmdExe = @"./SteamCMD/steamcmd.exe";
        private string _serverPathInstall = @"../Servers/Server";
        private string _serverPath = @"./Servers/Server";
        private string _defaultJsonPath = @"./ServerConfigs/";
        private string _backupPath = @"./Servers/Backups/";
        private string _firewallPath = @"c:\windows\system32\wf.msc";

        public const int _buttonDown = 0xA1;
        public const int _caption = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);



        public Form1()
        {
            InitializeComponent();

            //Initialize Services
            _steamCMD = new SteamCMD();
            _server = new Server();
            _backup = new Backup();
            _folder = new Folder();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString();

            if (File.Exists(_steamCmdExe))
            {
                InstallServer_Button.Visible = true;
                StartServer_Button.Visible = true;
            }
            if (File.Exists($"{_serverPath}{ServerSelectText}/{_gameServerExe}"))
            {
                InstallServer_Button.Visible = false;
                UpdateServer_Button.Visible = true;
            }
            if (!File.Exists($"{_serverPath}{ServerSelectText}/{_gameServerExe}"))
            {
                InstallServer_Button.Visible = true;
                UpdateServer_Button.Visible = false;
            }
            if (!File.Exists(_steamCmdExe))
            {
                InstallServer_Button.Visible = false;
                StartServer_Button.Visible = false;
            }



            if (!File.Exists($"{_defaultJsonPath}Server{ServerSelectText}.json"))
            {
                _folder.create(_defaultJsonPath);

                Json json = new Json()
                {
                    Name = "Enshrouded Server",
                    Password = "",
                    SaveDirectory = "./savegame",
                    LogDirectory = "./logs",
                    IpAddress = "0.0.0.0",
                    GamePort = 15636,
                    QueryPort = 15637,
                    SlotCount = 16
                };

                var output = JsonConvert.SerializeObject(json);
                File.WriteAllText($"{_defaultJsonPath}Server{ServerSelectText}.json", output);

            }

            var input = File.ReadAllText($"{_defaultJsonPath}Server{ServerSelectText}.json");

            Json deserializedSettings = JsonConvert.DeserializeObject<Json>(input);
            dynamic data = JObject.Parse(input);

            ServerName_TextBox.Text = data.Name;
            ServerPassword_TextBox.Text = data.Password;
            IP_TextBox.Text = data.IpAddress;

            GamePort_input.Text = data.GamePort;
            QueryPort_input.Text = data.QueryPort;
            SlotCount_input.Text = data.SlotCount;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, _buttonDown, _caption, 0);
            }
        }

        private void InstallSteamCMD_Button_Click(object sender, EventArgs e)
        {
            _steamCMD.Install();

            if (File.Exists(_steamCmdExe))
            {
                InstallServer_Button.Visible = true; 
                StartServer_Button.Visible = true;
            }
        }

        private void InstallServer_Button_Click(object sender, EventArgs e)
        {
            string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString();

            _server.InstallUpdate(_steamAppId, $"{_serverPathInstall}{ServerSelectText}");

            InstallServer_Button.Visible = false;
            UpdateServer_Button.Visible = true;

        }

        private void UpdateServer_Button_Click(object sender, EventArgs e)
        {
            string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString();

            _server.InstallUpdate(_steamAppId, $"{_serverPathInstall}{ServerSelectText}");
        }

        private void SaveSettings_Button_Click(object sender, EventArgs e)
        {
            string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString();

            _folder.create($"{_serverPath}{ServerSelectText}");


            int Gameport = Convert.ToInt32(GamePort_input.Text);
            int QueryPort = Convert.ToInt32(QueryPort_input.Text);
            int SlotCount = Convert.ToInt32(SlotCount_input.Text);

            Json json = new Json()
            {
                Name = ServerName_TextBox.Text,
                Password = ServerPassword_TextBox.Text,
                SaveDirectory = "./savegame",
                LogDirectory = "./logs",
                IpAddress = IP_TextBox.Text,
                GamePort = Gameport,
                QueryPort = QueryPort,
                SlotCount = SlotCount
            };

            var output = JsonConvert.SerializeObject(json);
            File.WriteAllText($"{_defaultJsonPath}Server{ServerSelectText}.json", output);
            File.WriteAllText($"{_serverPath}{ServerSelectText}/{_gameServerConfig}", output);                                           //needs to be the server tool .json

            MessageBox.Show("Server Settings saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void StartServer_Button_Click(object sender, EventArgs e)
        {
            string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString();

            _folder.create($"{_serverPath}{ServerSelectText}");

            int Gameport = Convert.ToInt32(GamePort_input.Text);
            int QueryPort = Convert.ToInt32(QueryPort_input.Text);
            int SlotCount = Convert.ToInt32(SlotCount_input.Text);

            Json json = new Json()
            {
                Name = ServerName_TextBox.Text,
                Password = ServerPassword_TextBox.Text,
                SaveDirectory = "./savegame",
                LogDirectory = "./logs",
                IpAddress = IP_TextBox.Text,
                GamePort = Gameport,
                QueryPort = QueryPort,
                SlotCount = SlotCount
            };

            var output = JsonConvert.SerializeObject(json);
            File.WriteAllText($"{_defaultJsonPath}Server{ServerSelectText}.json", output);
            File.WriteAllText($"{_serverPath}{ServerSelectText}/{_gameServerConfig}", output);

            _server.Start($"{_serverPath}{ServerSelectText}/{_gameServerExe}", ServerSelectText, ServerName_TextBox.Text);
        }

        private void SaveBackup_Button_Click(object sender, EventArgs e)
        {
            string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString();

            _backup.Save($"{_serverPath}{ServerSelectText}/{_gameServerSaveFolder}", ServerSelectText);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void OpenBackupFolder_Button_Click(object sender, EventArgs e)
        {
            string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString();
            string backupserverfolder = $"{_backupPath}Server{ServerSelectText}";

            _folder.create(backupserverfolder);

            Process.Start("explorer.exe", backupserverfolder.Replace("/", @"\"));
        }

        private void WindowsFirewall_Button_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", _firewallPath);
        }

        private void OpenSavegameFolder_Button_Click(object sender, EventArgs e)
        {
            string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString();
            string savegamefolder = $"{_serverPath}{ServerSelectText}/{_gameServerSaveFolder}";

            _folder.create(savegamefolder);

            Process.Start("explorer.exe", savegamefolder.Replace("/", @"\"));
        }

        private void OpenLogFolder_Button_Click(object sender, EventArgs e)
        {
            string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString();
            string logfolder = $"{_serverPath}{ServerSelectText}/{_gameServerLogsFolder}";

            _folder.create(logfolder);

            Process.Start("explorer.exe", logfolder.Replace("/", @"\"));
        }

    }
}