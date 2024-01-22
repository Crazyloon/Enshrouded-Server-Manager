using Enshrouded_Server_Manager.Model;
using Enshrouded_Server_Manager.Services;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Enshrouded_Server_Manager;

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
    private string _serverPath = @"./Servers/";
    private string _defaultProfilesPath = @"./ServerProfiles/";
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
        // Load Server Profiles
        List<ServerProfile> profiledata = LoadServerProfiles(firstCheck: true);

        if (profiledata.Any())
        {
            ServerSelectionComboBox.Items.Clear();
            ServerProfilesListBox.Items.Clear();
            foreach (var profile in profiledata)
            {
                ServerSelectionComboBox.Items.Add(profile.Name);
                ServerProfilesListBox.Items.Add(profile.Name);
            }

            ServerSelectionComboBox.SelectedIndex = 0;

            string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString()!;

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

            LoadServerSettings(ServerSelectText);
        }
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
        string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString()!;

        _server.InstallUpdate(_steamAppId, $"{_serverPathInstall}{ServerSelectText}");

        InstallServer_Button.Visible = false;
        UpdateServer_Button.Visible = true;

    }

    private void UpdateServer_Button_Click(object sender, EventArgs e)
    {
        string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString()!;

        _server.InstallUpdate(_steamAppId, $"{_serverPathInstall}{ServerSelectText}");
    }

    private void SaveSettings_Button_Click(object sender, EventArgs e)
    {
        string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString()!;

        _folder.Create($"{_serverPath}{ServerSelectText}");

        int Gameport;
        Gameport = Convert.ToInt32(GamePort_input.Text);

        int QueryPort;
        QueryPort = Convert.ToInt32(QueryPort_input.Text);

        int SlotCount;
        SlotCount = Convert.ToInt32(SlotCount_input.Text);

        ServerSettings json = new ServerSettings()
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
        File.WriteAllText($"{_serverPath}{ServerSelectText}/{_gameServerConfig}", output); //needs to be the server tool .json

        SaveSettings_Button.Text = "Saved!";
        SaveSettings_Button.Enabled = false;

        Task.Factory.StartNew(() =>
        {
            Thread.Sleep(3000);
            SaveSettings_Button.Invoke(new Action(() =>
            {
                SaveSettings_Button.Text = "Save Settings";
                SaveSettings_Button.Enabled = true;
            }));
        });
    }

    private void StartServer_Button_Click(object sender, EventArgs e)
    {
        string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString()!;

        _folder.Create($"{_serverPath}{ServerSelectText}");


        int Gameport;
        Gameport = Convert.ToInt32(GamePort_input.Text);

        int QueryPort;
        QueryPort = Convert.ToInt32(QueryPort_input.Text);

        int SlotCount;
        SlotCount = Convert.ToInt32(SlotCount_input.Text);

        ServerSettings json = new ServerSettings()
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
        File.WriteAllText($"{_serverPath}{ServerSelectText}/{_gameServerConfig}", output);

        _server.Start($"{_serverPath}{ServerSelectText}/{_gameServerExe}", ServerSelectText, ServerName_TextBox.Text);
    }

    private void SaveBackup_Button_Click(object sender, EventArgs e)
    {
        string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString()!;

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
        string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString()!;
        string backupserverfolder = $"{_backupPath}{ServerSelectText}";

        _folder.Create(backupserverfolder);

        Process.Start("explorer.exe", backupserverfolder.Replace("/", @"\"));
    }

    private void WindowsFirewall_Button_Click(object sender, EventArgs e)
    {
        Process.Start("explorer.exe", _firewallPath);
    }

    private void OpenSavegameFolder_Button_Click(object sender, EventArgs e)
    {
        string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString()!;
        string savegamefolder = $"{_serverPath}{ServerSelectText}/{_gameServerSaveFolder}";

        _folder.Create(savegamefolder);

        Process.Start("explorer.exe", savegamefolder.Replace("/", @"\"));
    }

    private void OpenLogFolder_Button_Click(object sender, EventArgs e)
    {
        string ServerSelectText = ServerSelectionComboBox.SelectedItem.ToString()!;
        string logfolder = $"{_serverPath}{ServerSelectText}/{_gameServerLogsFolder}";

        _folder.Create(logfolder);

        Process.Start("explorer.exe", logfolder.Replace("/", @"\"));
    }

    private void ServerProfiles_IndexChanged(object sender, EventArgs e)
    {
        string ServerSelectText = ServerProfilesListBox.SelectedItem!.ToString()!;
        EditProfileName_TextBox.Text = ServerSelectText;
    }

    private void AddNewProfile_Button_Click(object sender, EventArgs e)
    {
        // Load Server Profiles
        List<ServerProfile> profiledata = LoadServerProfiles();

        // Generate a new Server name semi-randomly
        var serverName = $"Server{GenerateRandomString(6)}";
        while (profiledata.Any(x => x.Name == serverName))
        {
            serverName = $"Server{GenerateRandomString(6)}";
        }

        profiledata.Add(new ServerProfile()
        {
            Name = serverName
        });

        // write the new profile to the json file
        var output = JsonConvert.SerializeObject(profiledata);
        File.WriteAllText($"{_defaultProfilesPath}server_profiles.json", output);

        // Create a folder with for the configuration
        _folder.Create($"{_serverPath}{serverName}");
        WriteDefaultServerSettings(serverName);

        // reload form1
        Form1_Load(sender, e);
    }

    private bool isProfileNameValid(string profileName)
    {
        // Validate that the profileName is not empty, and does not contain any characters
        // that are not allowed in a Windows file name
        if (string.IsNullOrWhiteSpace(profileName))
        {
            MessageBox.Show("Profile name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

        // regex that tests a string only contains letters, numbers, underscore, and dash
        Regex regex = new Regex(@"^[a-zA-Z0-9_-]*$");
        if (!regex.Match(profileName).Success)
        {
            MessageBox.Show($"Profile name may only contain alphanumeric characters, underscore, and dash", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    private void SaveProfileName_Button_Click(object sender, EventArgs e)
    {
        if (ServerProfilesListBox.SelectedItem is null)
        {
            return;
        }

        // Validate Windows File Name Does not have Special Characters
        string editProfileName = EditProfileName_TextBox.Text;
        if (editProfileName == null || !isProfileNameValid(editProfileName))
        {

            return;
        }

        // Load Server Profiles
        List<ServerProfile> profiledata = LoadServerProfiles();

        // get the selected profile
        string ServerSelectText = ServerProfilesListBox.SelectedItem.ToString()!;
        var selectedProfile = profiledata.FirstOrDefault(x => x.Name == ServerSelectText);
        if (selectedProfile != null)
        {
            // update the name
            selectedProfile.Name = editProfileName;

            // write the new profile to the json file
            var output = JsonConvert.SerializeObject(profiledata);
            File.WriteAllText($"{_defaultProfilesPath}server_profiles.json", output);

            // rename the server settings file
            RenameServerSettings(ServerSelectText, editProfileName);

            // ClearProfileName_TextBox
            EditProfileName_TextBox.Text = "";

            SaveProfileName_Button.Text = "Saved!";
            SaveProfileName_Button.Enabled = false;

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                SaveProfileName_Button.Invoke(new Action(() =>
                {
                    SaveProfileName_Button.Text = "Save Changes";
                    SaveProfileName_Button.Enabled = true;
                }));
            });

            // reload form1
            Form1_Load(sender, e);
        }
    }

    private void DeleteProfile_Button_Click(object sender, EventArgs e)
    {
        MessageBox.Show(Text, "Are you sure you want to delete this profile?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


        // Load Server Profiles
        List<ServerProfile> profiledata = LoadServerProfiles();

        // get the selected profile
        string selectedServerProfile = ServerProfilesListBox.SelectedItem.ToString()!;
        var serverProfile = profiledata.FirstOrDefault(x => x.Name == selectedServerProfile);

        if (serverProfile != null)
        {
            // remove the profile
            profiledata.Remove(serverProfile);

            // write the new profile to the json file
            var output = JsonConvert.SerializeObject(profiledata);
            File.WriteAllText($"{_defaultProfilesPath}server_profiles.json", output);

            // ClearProfileName_TextBox
            EditProfileName_TextBox.Text = "";

            // Delete the server folder
            _folder.Delete($"{_serverPath}{selectedServerProfile}");

            // reload form1
            Form1_Load(sender, e);
        }
    }

    private string GenerateRandomString(int length)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
                     .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    private List<ServerProfile> LoadServerProfiles(bool firstCheck = false)
    {
        if (!File.Exists($"{_defaultProfilesPath}server_profiles.json"))
        {
            if (firstCheck)
            {
                _folder.Create(_defaultProfilesPath);

                var json = new List<ServerProfile>
                {
                    new ServerProfile()
                    {
                        Name = $"Server{GenerateRandomString(6)}"
                    }
                };

                var output = JsonConvert.SerializeObject(json);
                File.WriteAllText($"{_defaultProfilesPath}server_profiles.json", output);
            }
            else
            {
                MessageBox.Show($"Critical Error. {_defaultProfilesPath}server_profiles.json not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        var profiles = File.ReadAllText($"{_defaultProfilesPath}server_profiles.json");
        List<ServerProfile> profiledata = JsonConvert.DeserializeObject<List<ServerProfile>>(profiles)!;

        return profiledata;
    }

    private void RenameServerSettings(string oldServerName, string newServerName)
    {
        // If old settings do not exist, write defaults
        if (!File.Exists($"{_serverPath}{oldServerName}/{_gameServerConfig}"))
        {
            _folder.Create($"{_serverPath}{newServerName}");
            WriteDefaultServerSettings(newServerName);
            return;
        }

        // Read the existing settings file
        var input = File.ReadAllText($"{_serverPath}{oldServerName}/{_gameServerConfig}");

        // Write the new settings file
        _folder.Create($"{_serverPath}{newServerName}");
        File.WriteAllText($"{_serverPath}{newServerName}/{_gameServerConfig}", input);

        // Delete the old settings file
        _folder.Delete($"{_serverPath}{oldServerName}");
    }

    private void ServerProfile_IndexChanged(object sender, EventArgs e)
    {
        LoadServerSettings(ServerSelectionComboBox.SelectedItem.ToString()!);
    }

    private void LoadServerSettings(string ServerSelectText)
    {
        if (!File.Exists($"{_serverPath}{ServerSelectText}/{_gameServerConfig}"))
        {
            _folder.Create($"{_serverPath}{ServerSelectText}");
            WriteDefaultServerSettings(ServerSelectText);
        }

        var input = File.ReadAllText($"{_serverPath}{ServerSelectText}/{_gameServerConfig}");

        ServerSettings deserializedSettings = JsonConvert.DeserializeObject<ServerSettings>(input);

        var Name = deserializedSettings.Name;
        ServerName_TextBox.Text = Name;
        var Password = deserializedSettings.Password;
        ServerPassword_TextBox.Text = Password;
        var IpAddress = deserializedSettings.IpAddress;
        IP_TextBox.Text = IpAddress;
        var GamePort = deserializedSettings.GamePort;
        GamePort_input.Text = GamePort.ToString();
        var QueryPort = deserializedSettings.QueryPort;
        QueryPort_input.Text = QueryPort.ToString();
        var SlotCount = deserializedSettings.SlotCount;
        SlotCount_input.Text = SlotCount.ToString();
    }

    private void WriteDefaultServerSettings(string serverName)
    {
        ServerSettings json = new ServerSettings()
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
        File.WriteAllText($"{_serverPath}{serverName}/{_gameServerConfig}", output);
    }
}