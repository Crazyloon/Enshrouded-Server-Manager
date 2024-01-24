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
    private const string STEAM_APP_ID = "2278520";
    // Game Server exe Name
    private const string GAME_SERVER_EXE = @"/enshrouded_server.exe";
    // Game Server config Name
    private const string GAME_SERVER_CONFIG = @"/enshrouded_server.json";
    // Savegame folder name after Server folder
    private const string GAME_SERVER_SAVE_FOLDER = @"/savegame";
    // Logs folder name after Server folder
    private const string GAME_SERVER_LOGS_FOLDER = @"/logs";

    private const string STEAM_CMD_EXE = @"./SteamCMD/steamcmd.exe";
    private const string SERVER_PATH = @"./Servers/";
    private const string DEFAULT_PROFILES_PATH = @"./ServerProfiles/";
    private const string FIREWALL_PATH = @"c:\windows\system32\wf.msc";
    private const string BACKUPS_FOLDER = "./Backups";
    private const string SAVE_GAME_FOLDER = "/Savegame";

    public const int BUTTON_DOWN = 0xA1;
    public const int CAPTION = 0x2;

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
            cbxProfileSelectionComboBox.Items.Clear();
            lbxServerProfiles.Items.Clear();
            foreach (var profile in profiledata)
            {
                cbxProfileSelectionComboBox.Items.Add(profile.Name);
                lbxServerProfiles.Items.Add(profile.Name);
            }

            cbxProfileSelectionComboBox.SelectedIndex = 0;

            string ServerSelectText = cbxProfileSelectionComboBox.SelectedItem.ToString();
            RefreshServerButtonsVisibility(ServerSelectText);

            LoadServerSettings(ServerSelectText);
        }
    }

    private void RefreshServerButtonsVisibility(string ServerSelectText)
    {
        if (File.Exists(STEAM_CMD_EXE))
        {
            btnInstallServer.Visible = true;
            btnStartServer.Visible = true;
        }
        if (File.Exists($"{SERVER_PATH}{ServerSelectText}{GAME_SERVER_EXE}"))
        {
            btnInstallServer.Visible = false;
            btnUpdateServer.Visible = true;
        }
        if (!File.Exists($"{SERVER_PATH}{ServerSelectText}{GAME_SERVER_EXE}"))
        {
            btnInstallServer.Visible = true;
            btnUpdateServer.Visible = false;
        }
        if (!File.Exists(STEAM_CMD_EXE))
        {
            btnInstallServer.Visible = false;
            btnStartServer.Visible = false;
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
            SendMessage(Handle, BUTTON_DOWN, CAPTION, 0);
        }
    }

    private void InstallSteamCMD_Button_Click(object sender, EventArgs e)
    {
        _steamCMD.Install();

        if (File.Exists(STEAM_CMD_EXE))
        {
            btnInstallServer.Visible = true;
            btnStartServer.Visible = true;
        }
    }

    private void InstallServer_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string ServerSelectText = cbxProfileSelectionComboBox.SelectedItem.ToString();

            _server.InstallUpdate(STEAM_APP_ID, $".{SERVER_PATH}{ServerSelectText}");

            btnInstallServer.Visible = false;
            btnUpdateServer.Visible = true;
        }
    }

    private void UpdateServer_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string ServerSelectText = cbxProfileSelectionComboBox.SelectedItem.ToString();

            _server.InstallUpdate(STEAM_APP_ID, $".{SERVER_PATH}{ServerSelectText}");
        }
    }

    private void SaveSettings_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string ServerSelectText = cbxProfileSelectionComboBox.SelectedItem.ToString();

            _folder.Create($"{SERVER_PATH}{ServerSelectText}");

            int Gameport = Convert.ToInt32(nudGamePort.Text);
            int QueryPort = Convert.ToInt32(nudQueryPort.Text);
            int SlotCount = Convert.ToInt32(nudSlotCount.Text);

            ServerSettings json = new ServerSettings()
            {
                Name = txtServerName.Text,
                Password = txtServerPassword.Text,
                SaveDirectory = "./savegame",
                LogDirectory = "./logs",
                IpAddress = txtIpAddress.Text,
                GamePort = Gameport,
                QueryPort = QueryPort,
                SlotCount = SlotCount
            };

            var output = JsonConvert.SerializeObject(json);
            File.WriteAllText($"{SERVER_PATH}{ServerSelectText}{GAME_SERVER_CONFIG}", output); //needs to be the server tool .json

            btnSaveSettings.Text = "Saved!";
            btnSaveSettings.Enabled = false;

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                btnSaveSettings.Invoke(new Action(() =>
                {
                    btnSaveSettings.Text = "Save Settings";
                    btnSaveSettings.Enabled = true;
                }));
            });
        }
    }

    private void StartServer_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string ServerSelectText = cbxProfileSelectionComboBox.SelectedItem.ToString();

            _folder.Create($"{SERVER_PATH}{ServerSelectText}");

            int Gameport = Convert.ToInt32(nudGamePort.Text);
            int QueryPort = Convert.ToInt32(nudQueryPort.Text);
            int SlotCount = Convert.ToInt32(nudSlotCount.Text);

            ServerSettings json = new ServerSettings()
            {
                Name = txtServerName.Text,
                Password = txtServerPassword.Text,
                SaveDirectory = "./savegame",
                LogDirectory = "./logs",
                IpAddress = txtIpAddress.Text,
                GamePort = Gameport,
                QueryPort = QueryPort,
                SlotCount = SlotCount
            };

            var output = JsonConvert.SerializeObject(json);
            File.WriteAllText($"{SERVER_PATH}{ServerSelectText}{GAME_SERVER_CONFIG}", output);

            _server.Start($"{SERVER_PATH}{ServerSelectText}{GAME_SERVER_EXE}", ServerSelectText);
        }
    }

    private void SaveBackup_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string ServerSelectText = cbxProfileSelectionComboBox.SelectedItem.ToString();

            _backup.Save($"{SERVER_PATH}{ServerSelectText}{GAME_SERVER_SAVE_FOLDER}", ServerSelectText, GAME_SERVER_CONFIG, $"{SERVER_PATH}{ServerSelectText}");
        }

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
        string ServerSelectText = cbxProfileSelectionComboBox.SelectedItem.ToString();
        string backupserverfolder = $"{BACKUPS_FOLDER}/{ServerSelectText}";

        _folder.Create(backupserverfolder);

        Process.Start("explorer.exe", backupserverfolder.Replace("/", @"\"));
    }

    private void WindowsFirewall_Button_Click(object sender, EventArgs e)
    {
        Process.Start("explorer.exe", FIREWALL_PATH);
    }

    private void OpenSavegameFolder_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string ServerSelectText = cbxProfileSelectionComboBox.SelectedItem.ToString();
            string savegamefolder = $"{SERVER_PATH}{ServerSelectText}{GAME_SERVER_SAVE_FOLDER}";

            _folder.Create(savegamefolder);

            Process.Start("explorer.exe", savegamefolder.Replace("/", @"\"));
        }
    }

    private void OpenLogFolder_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string ServerSelectText = cbxProfileSelectionComboBox.SelectedItem.ToString();
            string logfolder = $"{SERVER_PATH}{ServerSelectText}{GAME_SERVER_LOGS_FOLDER}";

            _folder.Create(logfolder);

            Process.Start("explorer.exe", logfolder.Replace("/", @"\"));
        }
    }

    private void ServerProfilesListBox_IndexChanged(object sender, EventArgs e)
    {
        if (lbxServerProfiles.SelectedItem is not null)
        {
            string ServerSelectText = lbxServerProfiles.SelectedItem.ToString();
            txtEditProfileName.Text = ServerSelectText;
        }
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
        File.WriteAllText($"{DEFAULT_PROFILES_PATH}server_profiles.json", output);

        // Create a folder with for the configuration
        _folder.Create($"{SERVER_PATH}{serverName}");
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
        if (lbxServerProfiles.SelectedItem is null)
        {
            return;
        }

        // Validate Windows File Name Does not have Special Characters
        string editProfileName = txtEditProfileName.Text;
        if (editProfileName == null || !isProfileNameValid(editProfileName) || lbxServerProfiles.SelectedItem.ToString() == editProfileName)
        {
            return;
        }

        // Load Server Profiles
        List<ServerProfile>? profiledata = LoadServerProfiles();
        if (profiledata is null)
        {
            return;
        }

        // get the selected profile
        string selectedServerName = lbxServerProfiles.SelectedItem.ToString();
        var selectedProfile = profiledata.FirstOrDefault(x => x.Name == selectedServerName);
        if (selectedProfile != null)
        {
            // update the name
            selectedProfile.Name = editProfileName;

            // write the new profile to the json file
            var output = JsonConvert.SerializeObject(profiledata);
            File.WriteAllText($"{DEFAULT_PROFILES_PATH}server_profiles.json", output);

            // rename the server settings file
            RenameServerSettings(selectedServerName, editProfileName);

            // rename backup folder
            RenameBackupFolder(selectedServerName, editProfileName);

            // ClearProfileName_TextBox
            txtEditProfileName.Text = "";

            btnSaveProfileName.Text = "Saved!";
            btnSaveProfileName.Enabled = false;

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                btnSaveProfileName.Invoke(new Action(() =>
                {
                    btnSaveProfileName.Text = "Save Changes";
                    btnSaveProfileName.Enabled = true;
                }));
            });

            // reload form1
            Form1_Load(sender, e);
        }
    }

    private void DeleteProfile_Button_Click(object sender, EventArgs e)
    {
        if (lbxServerProfiles.SelectedItem is not null)
        {
            var result = MessageBox.Show("Are you sure you want to delete this profile and all server files related to it?", "Delete Profile?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            // Load Server Profiles
            List<ServerProfile> profiledata = LoadServerProfiles();

            // get the selected profile
            string selectedServerProfile = lbxServerProfiles.SelectedItem.ToString();
            var serverProfile = profiledata.FirstOrDefault(x => x.Name == selectedServerProfile);

            if (serverProfile != null)
            {
                // remove the profile
                profiledata.Remove(serverProfile);

                // write the new profile to the json file
                var output = JsonConvert.SerializeObject(profiledata);
                File.WriteAllText($"{DEFAULT_PROFILES_PATH}server_profiles.json", output);

                // Delete the server folder
                _folder.Delete($"{SERVER_PATH}{selectedServerProfile}");

                // Clear UI Elements
                txtEditProfileName.Text = "";
                lbxServerProfiles.Items.Remove(selectedServerProfile);
                cbxProfileSelectionComboBox.Items.Remove(selectedServerProfile);
                RefreshServerButtonsVisibility(selectedServerProfile);

                // reload form1
                Form1_Load(sender, e);
            }
        }
    }

    private string GenerateRandomString(int length)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
                     .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    private List<ServerProfile>? LoadServerProfiles(bool firstCheck = false)
    {
        if (!File.Exists($"{DEFAULT_PROFILES_PATH}server_profiles.json"))
        {
            _folder.Create(DEFAULT_PROFILES_PATH);

            if (firstCheck)
            {
                WriteDefaultProfile();
            }
            else
            {
                MessageBox.Show($"Critical Error. {DEFAULT_PROFILES_PATH}server_profiles.json not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        var profilesJson = File.ReadAllText($"{DEFAULT_PROFILES_PATH}server_profiles.json");
        List<ServerProfile>? serverProfiles = JsonConvert.DeserializeObject<List<ServerProfile>>(profilesJson);

        if (serverProfiles is not null && serverProfiles.Count() <= 0)
        {
            WriteDefaultProfile();
            profilesJson = File.ReadAllText($"{DEFAULT_PROFILES_PATH}server_profiles.json");
            return JsonConvert.DeserializeObject<List<ServerProfile>>(profilesJson);
        }

        return serverProfiles;
    }

    private void WriteDefaultProfile()
    {
        var json = new List<ServerProfile>
        {
            new ServerProfile()
            {
                Name = $"Server{GenerateRandomString(6)}"
            }
        };

        var output = JsonConvert.SerializeObject(json);
        File.WriteAllText($"{DEFAULT_PROFILES_PATH}server_profiles.json", output);
    }

    private void RenameServerSettings(string oldServerName, string newServerName)
    {
        // If old settings do not exist, write defaults
        if (!File.Exists($"{SERVER_PATH}{oldServerName}{GAME_SERVER_CONFIG}"))
        {
            _folder.Create($"{SERVER_PATH}{newServerName}");
            WriteDefaultServerSettings(newServerName);
            return;
        }

        // Read the existing settings file
        var input = File.ReadAllText($"{SERVER_PATH}{oldServerName}{GAME_SERVER_CONFIG}");

        // Write the new settings file
        _folder.Create($"{SERVER_PATH}{newServerName}");
        File.WriteAllText($"{SERVER_PATH}{newServerName}{GAME_SERVER_CONFIG}", input);

        // Delete the old settings file
        _folder.Delete($"{SERVER_PATH}{oldServerName}");
    }

    private void RenameBackupFolder(string oldBackupFolderName, string newBackupFolderName)
    {
        // If old backup folder does not exist, create it
        if (!Directory.Exists($"{BACKUPS_FOLDER}/{oldBackupFolderName}"))
        {
            _folder.Create($"{BACKUPS_FOLDER}/{newBackupFolderName}");
            return;
        }
        else
        {
            // Rename the existing Backup folder
            Directory.Move($"{BACKUPS_FOLDER}/{oldBackupFolderName}", $"{BACKUPS_FOLDER}/{newBackupFolderName}");
        }
    }

    private void ServerProfileComboBox_IndexChanged(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            var serverSelectedText = cbxProfileSelectionComboBox.SelectedItem.ToString();
            RefreshServerButtonsVisibility(serverSelectedText);
            LoadServerSettings(serverSelectedText);
        }
    }

    private void LoadServerSettings(string ServerSelectText)
    {
        if (!File.Exists($"{SERVER_PATH}{ServerSelectText}{GAME_SERVER_CONFIG}"))
        {
            _folder.Create($"{SERVER_PATH}{ServerSelectText}");
            WriteDefaultServerSettings(ServerSelectText);
        }

        var input = File.ReadAllText($"{SERVER_PATH}{ServerSelectText}{GAME_SERVER_CONFIG}");

        ServerSettings deserializedSettings = JsonConvert.DeserializeObject<ServerSettings>(input);

        txtServerName.Text = deserializedSettings.Name;
        txtServerPassword.Text = deserializedSettings.Password;
        txtIpAddress.Text = deserializedSettings.IpAddress;
        nudGamePort.Text = deserializedSettings.GamePort.ToString();
        nudQueryPort.Text = deserializedSettings.QueryPort.ToString();
        nudSlotCount.Text = deserializedSettings.SlotCount.ToString();
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
        File.WriteAllText($"{SERVER_PATH}{serverName}{GAME_SERVER_CONFIG}", output);
    }

    private void SaveSettings_Button_EnabledChanged(object sender, EventArgs e)
    {
        var Sender = ((Button)sender);
        Sender.BackColor = Sender.Enabled ? Color.FromArgb(255, 0, 0, 40) : Color.FromArgb(255, 115, 115, 137);
        Sender.FlatAppearance.BorderColor = Sender.Enabled ? Color.FromArgb(255, 115, 115, 137) : Color.FromArgb(255, 0, 0, 40);
    }

    private void btnShowPassword_Click(object sender, EventArgs e)
    {
        var text = btnShowPassword.Text;
        txtServerPassword.PasswordChar = text == "Show" ? '\0' : '*';

        btnShowPassword.Text = text == "Show" ? "Hide" : "Show";
    }
}
