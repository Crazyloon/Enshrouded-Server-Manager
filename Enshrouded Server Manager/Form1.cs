using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Model;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;

namespace Enshrouded_Server_Manager;

public partial class Form1 : Form
{
    private SteamCMD _steamCMD;
    private Server _server;
    private Backup _backup;
    private Folder _folder;
    private JsonSerializerSettings _jsonSerializerSettings;
    private CancellationTokenSource _backupCancellationTokenSource;

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
    private const string CACHE_PATH = @"./cache/";
    private const string PID_CONFIG = $"pid.json";

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

        _backup.AutoBackupSuccess += Backup_AutoBackupSuccess;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        _jsonSerializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            Formatting = Formatting.Indented
        };

        // Load Server Profiles
        List<ServerProfile> profiledata = LoadServerProfiles(firstCheck: true);

        if (profiledata.Any())
        {
            cbxProfileSelectionComboBox.Items.Clear();
            lbxServerProfiles.Items.Clear();
            lbxProfileSelectorAutoBackup.Items.Clear();
            foreach (var profile in profiledata)
            {
                cbxProfileSelectionComboBox.Items.Add(profile.Name);
                lbxServerProfiles.Items.Add(profile.Name);
                lbxProfileSelectorAutoBackup.Items.Add(profile.Name);
            }

            cbxProfileSelectionComboBox.SelectedIndex = 0;

            string ServerSelectText = cbxProfileSelectionComboBox.SelectedItem.ToString();
            RefreshServerButtonsVisibility(ServerSelectText);

            LoadServerSettings(ServerSelectText);
        }

        ManagerUpdate();
    }

    private void RefreshServerButtonsVisibility(string ServerSelectText)
    {
        btnStopServer.Visible = false;
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

        try
        {
            if (Server.IsRunning(ServerSelectText))
            {
                btnStartServer.Visible = false;
                btnStopServer.Visible = true;
            }
        }
        catch (Exception)
        {
            if (File.Exists($"./cache/{ServerSelectText}pid.json"))
            {
                File.Delete($"./cache/{ServerSelectText}pid.json");
            }
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

        _steamCMD.Start();
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
                Ip = txtIpAddress.Text,
                GamePort = Gameport,
                QueryPort = QueryPort,
                SlotCount = SlotCount
            };

            var output = JsonConvert.SerializeObject(json, _jsonSerializerSettings);
            File.WriteAllText($"{SERVER_PATH}{ServerSelectText}{GAME_SERVER_CONFIG}", output); //needs to be the server tool .json

            Interactions.AnimateSaveChangesButton(btnSaveSettings, "Save Changes", "Saved!");
        }
    }

    private void StartServer_Button_Click(object sender, EventArgs e)
    {
        // Display the Server Settings tab when they click Start Server
        tabServerTabs.SelectTab(0);

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
                Ip = txtIpAddress.Text,
                GamePort = Gameport,
                QueryPort = QueryPort,
                SlotCount = SlotCount
            };

            var output = JsonConvert.SerializeObject(json, _jsonSerializerSettings);
            File.WriteAllText($"{SERVER_PATH}{ServerSelectText}{GAME_SERVER_CONFIG}", output);

            _server.Start($"{SERVER_PATH}{ServerSelectText}{GAME_SERVER_EXE}", ServerSelectText);


            // Begin AutoBackup after waiting 5 seconds to ensure the server process has started
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(5000);

                if (Server.IsRunning(ServerSelectText))
                {
                    var profiles = LoadServerProfiles();
                    var profile = profiles?.FirstOrDefault(x => x.Name == ServerSelectText);
                    if (profile != null && profile.AutoBackup != null && profile.AutoBackup.Enabled)
                    {
                        _backupCancellationTokenSource = new CancellationTokenSource();

                        _backup.StartAutoBackup($"{SERVER_PATH}{ServerSelectText}{GAME_SERVER_SAVE_FOLDER}", ServerSelectText, profile.AutoBackup.Interval, profile.AutoBackup.MaxiumBackups, _backupCancellationTokenSource.Token, GAME_SERVER_CONFIG, $"{SERVER_PATH}{ServerSelectText}");
                    }
                }
            });


            btnStartServer.Visible = false;
            btnStopServer.Visible = true;
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
        var output = JsonConvert.SerializeObject(profiledata, _jsonSerializerSettings);
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

        // Check that the profileName does not contain any invalid characters
        if (profileName.IndexOfAny(invalid.ToCharArray()) != -1)
        {
            MessageBox.Show($"Profile name contains invalid characters. Use only those characters acceptable by the Windows File System", "Invalid Characters", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        string selectedServerProfile = lbxServerProfiles.SelectedItem.ToString();

        if (Server.IsRunning(selectedServerProfile))
        {
            MessageBox.Show($"The profilename cant be changed while the server is running!",
                "Server is running", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var reservedProfileNames = new string[] { "AutoBackup" };

        // Validate:
        // Not Null
        // Windows File Name Does not have Special Characters
        // Not the same as an existing profile name
        // Not allowed to use ReservedNames
        string editProfileName = txtEditProfileName.Text;
        if (editProfileName == null
            || !isProfileNameValid(editProfileName)
            || lbxServerProfiles.Items.Contains(editProfileName)
            || reservedProfileNames.Contains(editProfileName))
        {
            return;
        }

        // Load Server Profiles
        List<ServerProfile>? profiledata = LoadServerProfiles();
        if (profiledata is null)
        {
            // TODO: Report an error?
            return;
        }

        // get the selected profile
        var selectedProfile = profiledata.FirstOrDefault(x => x.Name == selectedServerProfile);
        if (selectedProfile != null)
        {
            // rename the server settings folder
            RenameServerSettings(selectedServerProfile, editProfileName);

            if (Directory.Exists($"{SERVER_PATH}{editProfileName}"))
            {
                // update the name
                selectedProfile.Name = editProfileName;

                // write the new profile to the json file
                var output = JsonConvert.SerializeObject(profiledata, _jsonSerializerSettings);
                File.WriteAllText($"{DEFAULT_PROFILES_PATH}server_profiles.json", output);

                // rename backup folder
                RenameBackupFolder(selectedServerProfile, editProfileName);

                // rename autobackup folder
                RenameAutoBackupFolder(selectedServerProfile, editProfileName);

                // ClearProfileName_TextBox
                txtEditProfileName.Text = "";

                Interactions.AnimateSaveChangesButton(btnSaveProfileName, "Save Changes", "Saved!");

                // reload form1
                Form1_Load(sender, e);
            }
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
                var output = JsonConvert.SerializeObject(profiledata, _jsonSerializerSettings);
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

                //clear cache pid file
                if (File.Exists($"{CACHE_PATH}{selectedServerProfile}pid.json"))
                {
                    File.Delete($"{CACHE_PATH}{selectedServerProfile}pid.json");
                }
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
        List<ServerProfile>? serverProfiles = JsonConvert.DeserializeObject<List<ServerProfile>>(profilesJson, _jsonSerializerSettings);

        if (serverProfiles is not null && serverProfiles.Count() <= 0)
        {
            WriteDefaultProfile();
            profilesJson = File.ReadAllText($"{DEFAULT_PROFILES_PATH}server_profiles.json");
            return JsonConvert.DeserializeObject<List<ServerProfile>>(profilesJson, _jsonSerializerSettings);
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

        var output = JsonConvert.SerializeObject(json, _jsonSerializerSettings);
        File.WriteAllText($"{DEFAULT_PROFILES_PATH}server_profiles.json", output);
    }

    private void RenameServerSettings(string oldServerName, string newServerName)
    {
        try
        {
            Directory.Move($"{SERVER_PATH}{oldServerName}", $"{SERVER_PATH}{oldServerName}_temp");
            Directory.Move($"{SERVER_PATH}{oldServerName}_temp", $"{SERVER_PATH}{newServerName}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Following error occured while changing profilename: {ex.Message.ToString()}",
        "Error while changing profilename", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
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

    private void RenameAutoBackupFolder(string oldBackupFolderName, string newBackupFolderName)
    {
        // If old backup folder does not exist, create it
        if (!Directory.Exists($"{BACKUPS_FOLDER}/AutoBackup/{oldBackupFolderName}"))
        {
            _folder.Create($"{BACKUPS_FOLDER}/AutoBackup/{newBackupFolderName}");
            return;
        }
        else
        {
            // Rename the existing Backup folder
            Directory.Move($"{BACKUPS_FOLDER}/AutoBackup/{oldBackupFolderName}", $"{BACKUPS_FOLDER}/AutoBackup/{newBackupFolderName}");
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

        ServerSettings deserializedSettings = JsonConvert.DeserializeObject<ServerSettings>(input, _jsonSerializerSettings);

        txtServerName.Text = deserializedSettings.Name;
        txtServerPassword.Text = deserializedSettings.Password;
        txtIpAddress.Text = deserializedSettings.Ip;
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
            Ip = "0.0.0.0",
            GamePort = 15636,
            QueryPort = 15637,
            SlotCount = 16
        };

        var output = JsonConvert.SerializeObject(json, _jsonSerializerSettings);
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

    private void GithubLabel_Click(object sender, EventArgs e)
    {
        Process.Start("explorer.exe", "https://github.com/ISpaikI/Enshrouded-Server-Manager");
    }

    private async void ManagerUpdate()
    {
        using (WebClient Client = new WebClient())
        {
            try
            {
                Client.DownloadFile("https://raw.githubusercontent.com/ISpaikI/Enshrouded-Server-Manager/master/Enshrouded%20Server%20Manager/Version/githubversion.json", "./githubversion.json");
            }
            catch (Exception ex)
            {
                LauncherVersion json = new LauncherVersion()
                {
                    Version = VersionLabel.Text,
                };

                var output = JsonConvert.SerializeObject(json, _jsonSerializerSettings);
                File.WriteAllText($"./githubversion.json", output);
            }

        }

        var input = File.ReadAllText($"./githubversion.json");

        LauncherVersion deserializedSettings = JsonConvert.DeserializeObject<LauncherVersion>(input, _jsonSerializerSettings);

        string githubversion = deserializedSettings.Version;

        if (githubversion != VersionLabel.Text)
        {
            NewVersionText.Visible = true;
        }

        File.Delete("./githubversion.json");

        var timer = new PeriodicTimer(TimeSpan.FromMinutes(10));

        while (await timer.WaitForNextTickAsync())
        {
            using (WebClient Client = new WebClient())
            {
                try
                {
                    Client.DownloadFile("https://raw.githubusercontent.com/ISpaikI/Enshrouded-Server-Manager/master/Enshrouded%20Server%20Manager/Version/githubversion.json", "./githubversion.json");
                }
                catch (Exception ex)
                {
                    LauncherVersion json = new LauncherVersion()
                    {
                        Version = VersionLabel.Text,
                    };

                    var output = JsonConvert.SerializeObject(json, _jsonSerializerSettings);
                    File.WriteAllText($"./githubversion.json", output);
                }

            }

            var input1 = File.ReadAllText($"./githubversion.json");

            LauncherVersion deserializedSettings1 = JsonConvert.DeserializeObject<LauncherVersion>(input, _jsonSerializerSettings);

            string githubversion1 = deserializedSettings1.Version;

            if (githubversion != VersionLabel.Text)
            {
                NewVersionText.Visible = true;
            }

            File.Delete("./githubversion.json");
        }
    }

    private void lbxProfileSelectorAutoBackup_SelectedIndexChanged(object sender, EventArgs e)
    {
        // get selected item
        var selectedProfile = lbxProfileSelectorAutoBackup.SelectedItem?.ToString();
        if (selectedProfile != null)
        {
            // load profile
            var profile = LoadServerProfiles().FirstOrDefault(x => x.Name == selectedProfile);
            if (profile != null)
            {
                // load auto backup settings
                if (profile.AutoBackup == null)
                {
                    // create new auto backup settings
                    profile.AutoBackup = new AutoBackup()
                    {
                        Interval = 0,
                        MaxiumBackups = 0,
                        Enabled = false
                    };
                }

                // set values                
                chkEnableBackups.Checked = profile.AutoBackup.Enabled;
                nudBackupInterval.Value = profile.AutoBackup.Interval;
                nudBackupMaxCount.Value = profile.AutoBackup.MaxiumBackups;
            }

            var totalBackups = _backup.GetBackupCount(selectedProfile);
            var diskConsumption = _backup.GetDiskConsumption(selectedProfile);

            Interactions.UpdateBackupInfo(lblProfileBackupsStats, totalBackups, diskConsumption);
        }
        else
        {
            lblProfileBackupsStats.Visible = false;
        }
    }

    private void btnStopServer_Click(object sender, EventArgs e)
    {
        if (_backupCancellationTokenSource is not null)
        {
            _backupCancellationTokenSource.Cancel();
            _backupCancellationTokenSource.Dispose();
        }

        string ServerSelectText = cbxProfileSelectionComboBox.SelectedItem.ToString();
        _server.Stop(ServerSelectText);
        btnStartServer.Visible = true;
        btnStopServer.Visible = false;
    }

    private void tabServerTabs_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedtab = tabServerTabs.SelectedTab;
        if (selectedtab == tabAutoBackup)
        {
            pnlBackupExplanation.Visible = true;
        }
        else
        {
            pnlBackupExplanation.Visible = false;
        }
    }

    private void btnSaveAutoBackup_Click(object sender, EventArgs e)
    {
        var enabled = chkEnableBackups.Checked;

        if (lbxProfileSelectorAutoBackup.SelectedItem is not null)
        {
            var selectedProfile = lbxProfileSelectorAutoBackup.SelectedItem.ToString();
            var profiles = LoadServerProfiles();
            var profile = profiles?.FirstOrDefault(x => x.Name == selectedProfile);
            if (profile is not null)
            {
                if (enabled)
                {
                    profile.AutoBackup = new AutoBackup()
                    {
                        Interval = Convert.ToInt32(nudBackupInterval.Value),
                        MaxiumBackups = Convert.ToInt32(nudBackupMaxCount.Value),
                        Enabled = true
                    };
                }
                else
                {
                    profile.AutoBackup = null;
                }

                // write the new profile to the json file
                var output = JsonConvert.SerializeObject(profiles, _jsonSerializerSettings);
                File.WriteAllText($"{DEFAULT_PROFILES_PATH}server_profiles.json", output);

                // restart auto backup if the server is running;
                if (Server.IsRunning(selectedProfile))
                {
                    // Cancel any currently running backup loops
                    if (_backupCancellationTokenSource is not null)
                    {
                        _backupCancellationTokenSource.Cancel();
                        _backupCancellationTokenSource.Dispose();
                    }

                    _backupCancellationTokenSource = new CancellationTokenSource();
                    if (enabled)
                    {
                        _backup.StartAutoBackup($"{SERVER_PATH}{selectedProfile}{GAME_SERVER_SAVE_FOLDER}", selectedProfile, profile.AutoBackup.Interval, profile.AutoBackup.MaxiumBackups, _backupCancellationTokenSource.Token, GAME_SERVER_CONFIG, $"{SERVER_PATH}{selectedProfile}");
                    }
                }

                Interactions.AnimateSaveChangesButton(btnSaveAutoBackup, "Save Settings", "Saved!");
            }
        }
        else
        {
            MessageBox.Show("Please select a profile to configure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Backup_AutoBackupSuccess(object? sender, AutoBackupSuccessEventArgs e)
    {
        // Update the backup stats on the UI if the selected profile
        if (lbxProfileSelectorAutoBackup.InvokeRequired)
        {
            lbxProfileSelectorAutoBackup.BeginInvoke(() =>
            {
                if (lbxProfileSelectorAutoBackup.SelectedItem is null
                || lbxProfileSelectorAutoBackup.SelectedItem.ToString() != e.ProfileName)
                {
                    return;
                }

                Interactions.UpdateBackupInfo(lblProfileBackupsStats, _backup.GetBackupCount(e.ProfileName), _backup.GetDiskConsumption(e.ProfileName));
            });
        }
    }
}
