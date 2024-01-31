using Enshrouded_Server_Manager.Const;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Enshrouded_Server_Manager;

public partial class Form1 : Form
{
    private SteamCMD _steamCMD;
    private Server _server;
    private Backup _backup;
    private FileSystemManager _fileSystemManager;
    private ProfileManager _profileManager;
    private VersionManager _versionManager;
    private JsonSerializerSettings _jsonSerializerSettings;

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
        _fileSystemManager = new FileSystemManager();
        _profileManager = new ProfileManager();
        _versionManager = new VersionManager();

        //Register Custom Events
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
        List<ServerProfile>? profileData = _profileManager.LoadServerProfiles(_jsonSerializerSettings, true);

        if (profileData is not null && profileData.Any())
        {
            cbxProfileSelectionComboBox.Items.Clear();
            lbxServerProfiles.Items.Clear();
            lbxProfileSelectorAutoBackup.Items.Clear();
            foreach (var profile in profileData)
            {
                cbxProfileSelectionComboBox.Items.Add(profile.Name);
                lbxServerProfiles.Items.Add(profile.Name);
                lbxProfileSelectorAutoBackup.Items.Add(profile.Name);
            }

            cbxProfileSelectionComboBox.SelectedIndex = 0;

            if (cbxProfileSelectionComboBox.SelectedItem is not null)
            {
                string selectedProfile = cbxProfileSelectionComboBox.SelectedItem.ToString();
                RefreshServerButtonsVisibility(selectedProfile);
                LoadServerSettings(selectedProfile);
            }
        }

        _versionManager.ManagerUpdate(lblVersion.Text, lblNewVersionAvailableNotification);
    }

    #region ButtonEvents

    private void InstallSteamCMD_Button_Click(object sender, EventArgs e)
    {
        _steamCMD.Install();

        if (File.Exists(Constants.Paths.STEAM_CMD_EXE))
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
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();

            _server.InstallUpdate(Constants.Paths.STEAM_APP_ID, $".{Constants.Paths.SERVER_PATH}{selectedProfileName}");

            btnInstallServer.Visible = false;
            btnUpdateServer.Visible = true;
        }
    }

    private void UpdateServer_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();

            _server.InstallUpdate(Constants.Paths.STEAM_APP_ID, $".{Constants.Paths.SERVER_PATH}{selectedProfileName}");
        }
    }

    private void SaveSettings_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();

            Directory.CreateDirectory($"{Constants.Paths.SERVER_PATH}{selectedProfileName}");

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
            File.WriteAllText($"{Constants.Paths.SERVER_PATH}{selectedProfileName}{Constants.Paths.GAME_SERVER_CONFIG}", output); //needs to be the server tool .json

            Interactions.AnimateSaveChangesButton(btnSaveSettings, "Save Changes", "Saved!");
        }
    }

    private void StartServer_Button_Click(object sender, EventArgs e)
    {
        // Display the Server Settings tab when they click Start Server
        tabServerTabs.SelectTab(0);

        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();

            Directory.CreateDirectory($"{Constants.Paths.SERVER_PATH}{selectedProfileName}");

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
            File.WriteAllText($"{Constants.Paths.SERVER_PATH}{selectedProfileName}{Constants.Paths.GAME_SERVER_CONFIG}", output);

            _server.Start($"{Constants.Paths.SERVER_PATH}{selectedProfileName}{Constants.Paths.GAME_SERVER_EXE}", selectedProfileName);


            // Begin AutoBackup after waiting 5 seconds to ensure the server process has started
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(5000);

                if (Server.IsRunning(selectedProfileName))
                {
                    var profiles = _profileManager.LoadServerProfiles(_jsonSerializerSettings);
                    var profile = profiles?.FirstOrDefault(x => x.Name == selectedProfileName);
                    if (profile != null && profile.AutoBackup != null && profile.AutoBackup.Enabled)
                    {
                        _backup.StartAutoBackup($"{Constants.Paths.SERVER_PATH}{selectedProfileName}{Constants.Paths.GAME_SERVER_SAVE_FOLDER}", selectedProfileName, profile.AutoBackup.Interval, profile.AutoBackup.MaxiumBackups, Constants.Paths.GAME_SERVER_CONFIG, $"{Constants.Paths.SERVER_PATH}{selectedProfileName}");
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
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();

            _backup.Save($"{Constants.Paths.SERVER_PATH}{selectedProfileName}{Constants.Paths.GAME_SERVER_SAVE_FOLDER}", selectedProfileName, Constants.Paths.GAME_SERVER_CONFIG, $"{Constants.Paths.SERVER_PATH}{selectedProfileName}");
        }

    }
    private void lblCloseButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void lblMinimizeButton_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    private void OpenBackupFolder_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();
            string backupserverfolder = $"{Constants.Paths.BACKUPS_FOLDER}/{selectedProfileName}";

            Directory.CreateDirectory(backupserverfolder);

            Process.Start("explorer.exe", backupserverfolder.Replace("/", @"\"));
        }
    }

    private void WindowsFirewall_Button_Click(object sender, EventArgs e)
    {
        Process.Start("explorer.exe", Constants.Paths.FIREWALL_PATH);
    }

    private void OpenSavegameFolder_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();
            string savegamefolder = $"{Constants.Paths.SERVER_PATH}{selectedProfileName}{Constants.Paths.GAME_SERVER_SAVE_FOLDER}";

            Directory.CreateDirectory(savegamefolder);

            Process.Start("explorer.exe", savegamefolder.Replace("/", @"\"));
        }
    }

    private void OpenLogFolder_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();
            string logfolder = $"{Constants.Paths.SERVER_PATH}{selectedProfileName}{Constants.Paths.GAME_SERVER_LOGS_FOLDER}";

            Directory.CreateDirectory(logfolder);

            Process.Start("explorer.exe", logfolder.Replace("/", @"\"));
        }
    }

    private void FormHeader_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, Constants.BUTTON_DOWN, Constants.CAPTION, 0);
        }
    }

    private void AddNewProfile_Button_Click(object sender, EventArgs e)
    {
        // Load Server Profiles
        List<ServerProfile> profiledata = _profileManager.LoadServerProfiles(_jsonSerializerSettings);

        // Generate a new Server name semi-randomly
        var serverName = $"Server{GenerateText.RandomString(6)}";
        while (profiledata.Any(x => x.Name == serverName))
        {
            serverName = $"Server{GenerateText.RandomString(6)}";
        }

        profiledata.Add(new ServerProfile()
        {
            Name = serverName
        });

        // write the new profile to the json file
        var output = JsonConvert.SerializeObject(profiledata, _jsonSerializerSettings);
        File.WriteAllText($"{Constants.Paths.DEFAULT_PROFILES_PATH}{Constants.Paths.SERVER_PROFILES_JSON}", output);

        // Create a folder with for the configuration
        Directory.CreateDirectory($"{Constants.Paths.SERVER_PATH}{serverName}");
        WriteDefaultServerSettings(serverName);

        // reload form1
        Form1_Load(sender, e);
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
            || !_profileManager.IsProfileNameValid(editProfileName)
            || lbxServerProfiles.Items.Contains(editProfileName)
            || reservedProfileNames.Contains(editProfileName))
        {
            return;
        }

        // Load Server Profiles
        List<ServerProfile>? profiledata = _profileManager.LoadServerProfiles(_jsonSerializerSettings);
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

            if (Directory.Exists($"{Constants.Paths.SERVER_PATH}{editProfileName}"))
            {
                // update the name
                selectedProfile.Name = editProfileName;

                // write the new profile to the json file
                var output = JsonConvert.SerializeObject(profiledata, _jsonSerializerSettings);
                File.WriteAllText($"{Constants.Paths.DEFAULT_PROFILES_PATH}{Constants.Paths.SERVER_PROFILES_JSON}", output);

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
            List<ServerProfile> profiledata = _profileManager.LoadServerProfiles(_jsonSerializerSettings);

            // get the selected profile
            string selectedServerProfile = lbxServerProfiles.SelectedItem.ToString();
            var serverProfile = profiledata.FirstOrDefault(x => x.Name == selectedServerProfile);

            if (serverProfile != null)
            {
                // rename directory to check if in use
                try
                {
                    Directory.Move($"{Constants.Paths.SERVER_PATH}{selectedServerProfile}", $"{Constants.Paths.SERVER_PATH}{selectedServerProfile}_delete");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Following error occured while deleting profile: {ex.Message}",
                "Error while deleting profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Delete the server folder
                _fileSystemManager.Delete($"{Constants.Paths.SERVER_PATH}{selectedServerProfile}_delete");

                // remove the profile
                profiledata.Remove(serverProfile);

                // write the new profile to the json file
                var output = JsonConvert.SerializeObject(profiledata, _jsonSerializerSettings);
                File.WriteAllText($"{Constants.Paths.DEFAULT_PROFILES_PATH}{Constants.Paths.SERVER_PROFILES_JSON}", output);

                // Clear UI Elements
                txtEditProfileName.Text = "";
                lbxServerProfiles.Items.Remove(selectedServerProfile);
                cbxProfileSelectionComboBox.Items.Remove(selectedServerProfile);
                RefreshServerButtonsVisibility(selectedServerProfile);

                // reload form1
                Form1_Load(sender, e);

                //clear cache pid file
                if (File.Exists($"{Constants.Paths.CACHE_PATH}{selectedServerProfile}pid.json"))
                {
                    File.Delete($"{Constants.Paths.CACHE_PATH}{selectedServerProfile}pid.json");
                }
            }
        }
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

    private void btnStopServer_Click(object sender, EventArgs e)
    {
        string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();
        _server.Stop(selectedProfileName);
        btnStartServer.Visible = true;
        btnStopServer.Visible = false;
    }

    private void btnSaveAutoBackup_Click(object sender, EventArgs e)
    {
        var enabled = chkEnableBackups.Checked;

        if (lbxProfileSelectorAutoBackup.SelectedItem is not null)
        {
            Interactions.AnimateSaveChangesButton(btnSaveAutoBackup, "Save Settings", "Saved!");

            var selectedProfile = lbxProfileSelectorAutoBackup.SelectedItem.ToString();
            var profiles = _profileManager.LoadServerProfiles(_jsonSerializerSettings);
            var profile = profiles?.FirstOrDefault(x => x.Name == selectedProfile);
            if (profile is not null)
            {
                profile.AutoBackup = new AutoBackup()
                {
                    Interval = Convert.ToInt32(nudBackupInterval.Value),
                    MaxiumBackups = Convert.ToInt32(nudBackupMaxCount.Value),
                    Enabled = enabled
                };

                // write the new profile to the json file
                var output = JsonConvert.SerializeObject(profiles, _jsonSerializerSettings);
                File.WriteAllText($"{Constants.Paths.DEFAULT_PROFILES_PATH}{Constants.Paths.SERVER_PROFILES_JSON}", output);
            }
        }
        else
        {
            MessageBox.Show("Please select a profile to configure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnOpenAutobackupFolder_Click(object sender, EventArgs e)
    {
        Directory.CreateDirectory(Constants.Paths.AUTOBACKUPS_FOLDER);

        Process.Start("explorer.exe", Constants.Paths.AUTOBACKUPS_FOLDER.Replace("/", @"\"));
    }

    private void SaveSettings_Button_EnabledChanged(object sender, EventArgs e)
    {
        var Sender = ((Button)sender);
        Sender.BackColor = Sender.Enabled ? Color.FromArgb(255, 0, 0, 40) : Color.FromArgb(255, 115, 115, 137);
        Sender.FlatAppearance.BorderColor = Sender.Enabled ? Color.FromArgb(255, 115, 115, 137) : Color.FromArgb(255, 0, 0, 40);
    }
    #endregion ButtonEvents


    #region IndexChangeEvents
    private void lbxServerProfiles_IndexChanged(object sender, EventArgs e)
    {
        if (lbxServerProfiles.SelectedItem is not null)
        {
            string selectedProfileName = lbxServerProfiles.SelectedItem.ToString();
            txtEditProfileName.Text = selectedProfileName;
        }
    }

    private void cbxProfileSelectionComboBox_IndexChanged(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            var serverSelectedText = cbxProfileSelectionComboBox.SelectedItem.ToString();
            RefreshServerButtonsVisibility(serverSelectedText);
            LoadServerSettings(serverSelectedText);
        }
    }

    private void lbxProfileSelectorAutoBackup_SelectedIndexChanged(object sender, EventArgs e)
    {
        // get selected item
        var selectedProfile = lbxProfileSelectorAutoBackup.SelectedItem?.ToString();
        if (selectedProfile != null)
        {
            // load profile
            var profile = _profileManager.LoadServerProfiles(_jsonSerializerSettings).FirstOrDefault(x => x.Name == selectedProfile);
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
    #endregion IndexChangeEvents

    #region CustomEvents
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
    #endregion


    private void RefreshServerButtonsVisibility(string selectedProfileName)
    {
        btnStopServer.Visible = false;
        if (File.Exists(Constants.Paths.STEAM_CMD_EXE))
        {
            btnInstallServer.Visible = true;
            btnStartServer.Visible = true;
        }
        if (File.Exists($"{Constants.Paths.SERVER_PATH}{selectedProfileName}{Constants.Paths.GAME_SERVER_EXE}"))
        {
            btnInstallServer.Visible = false;
            btnUpdateServer.Visible = true;
        }
        if (!File.Exists($"{Constants.Paths.SERVER_PATH}{selectedProfileName}{Constants.Paths.GAME_SERVER_EXE}"))
        {
            btnInstallServer.Visible = true;
            btnUpdateServer.Visible = false;
        }
        if (!File.Exists(Constants.Paths.STEAM_CMD_EXE))
        {
            btnInstallServer.Visible = false;
            btnStartServer.Visible = false;
        }

        try
        {
            if (Server.IsRunning(selectedProfileName))
            {
                btnStartServer.Visible = false;
                btnStopServer.Visible = true;
            }
        }
        catch (Exception)
        {
            if (File.Exists($"./cache/{selectedProfileName}pid.json"))
            {
                File.Delete($"./cache/{selectedProfileName}pid.json");
            }
        }
    }

    private void RenameServerSettings(string oldServerName, string newServerName)
    {
        try
        {
            Directory.Move($"{Constants.Paths.SERVER_PATH}{oldServerName}", $"{Constants.Paths.SERVER_PATH}{oldServerName}_temp");
            Directory.Move($"{Constants.Paths.SERVER_PATH}{oldServerName}_temp", $"{Constants.Paths.SERVER_PATH}{newServerName}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Following error occured while changing profilename: {ex.Message}",
        "Error while changing profilename", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    private void RenameBackupFolder(string oldBackupFolderName, string newBackupFolderName)
    {
        // If old backup folder does not exist, create it
        if (!Directory.Exists($"{Constants.Paths.BACKUPS_FOLDER}/{oldBackupFolderName}"))
        {
            Directory.CreateDirectory($"{Constants.Paths.BACKUPS_FOLDER}/{newBackupFolderName}");
            return;
        }
        else
        {
            // Rename the existing Backup folder
            Directory.Move($"{Constants.Paths.BACKUPS_FOLDER}/{oldBackupFolderName}", $"{Constants.Paths.BACKUPS_FOLDER}/{newBackupFolderName}");
        }
    }

    private void RenameAutoBackupFolder(string oldBackupFolderName, string newBackupFolderName)
    {
        // If old backup folder does not exist, create it
        if (!Directory.Exists($"{Constants.Paths.BACKUPS_FOLDER}/AutoBackup/{oldBackupFolderName}"))
        {
            Directory.CreateDirectory($"{Constants.Paths.BACKUPS_FOLDER}/AutoBackup/{newBackupFolderName}");
            return;
        }
        else
        {
            // Rename the existing Backup folder
            Directory.Move($"{Constants.Paths.BACKUPS_FOLDER}/AutoBackup/{oldBackupFolderName}", $"{Constants.Paths.BACKUPS_FOLDER}/AutoBackup/{newBackupFolderName}");
        }
    }


    private void LoadServerSettings(string selectedProfileName)
    {
        if (!File.Exists($"{Constants.Paths.SERVER_PATH}{selectedProfileName}{Constants.Paths.GAME_SERVER_CONFIG}"))
        {
            Directory.CreateDirectory($"{Constants.Paths.SERVER_PATH}{selectedProfileName}");
            WriteDefaultServerSettings(selectedProfileName);
        }

        var input = File.ReadAllText($"{Constants.Paths.SERVER_PATH}{selectedProfileName}{Constants.Paths.GAME_SERVER_CONFIG}");

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
        File.WriteAllText($"{Constants.Paths.SERVER_PATH}{serverName}{Constants.Paths.GAME_SERVER_CONFIG}", output);
    }
}
