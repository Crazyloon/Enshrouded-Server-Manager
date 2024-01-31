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

        if (File.Exists(Constants.ProcessNames.STEAM_CMD_EXE))
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
            var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);

            _server.InstallUpdate(Constants.STEAM_APP_ID, serverProfilePath);

            btnInstallServer.Visible = false;
            btnUpdateServer.Visible = true;
        }
    }

    private void UpdateServer_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();
            var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);

            _server.InstallUpdate(Constants.STEAM_APP_ID, serverProfilePath);
        }
    }

    private void SaveSettings_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();

            var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);
            Directory.CreateDirectory(serverProfilePath);

            int Gameport = Convert.ToInt32(nudGamePort.Text);
            int QueryPort = Convert.ToInt32(nudQueryPort.Text);
            int SlotCount = Convert.ToInt32(nudSlotCount.Text);

            ServerSettings json = new ServerSettings()
            {
                Name = txtServerName.Text,
                Password = txtServerPassword.Text,
                SaveDirectory = Constants.Paths.ENSHROUDED_SAVE_GAME_DIRECTORY,
                LogDirectory = Constants.Paths.ENSHROUDED_LOGS_DIRECTORY,
                Ip = txtIpAddress.Text,
                GamePort = Gameport,
                QueryPort = QueryPort,
                SlotCount = SlotCount
            };

            var output = JsonConvert.SerializeObject(json, _jsonSerializerSettings);

            var gameServerConfig = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Files.GAME_SERVER_CONFIG_JSON);
            File.WriteAllText(gameServerConfig, output); //needs to be the server tool .json

            Interactions.AnimateSaveChangesButton(btnSaveSettings, btnSaveSettings.Text, Constants.ButtonText.SAVED_SUCCESS);
        }
    }

    private void StartServer_Button_Click(object sender, EventArgs e)
    {
        // Display the Server Settings tab when they click Start Server
        tabServerTabs.SelectTab(0);

        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();

            var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);
            Directory.CreateDirectory(serverProfilePath);

            int Gameport = Convert.ToInt32(nudGamePort.Text);
            int QueryPort = Convert.ToInt32(nudQueryPort.Text);
            int SlotCount = Convert.ToInt32(nudSlotCount.Text);

            ServerSettings json = new ServerSettings()
            {
                Name = txtServerName.Text,
                Password = txtServerPassword.Text,
                SaveDirectory = Constants.Paths.ENSHROUDED_SAVE_GAME_DIRECTORY,
                LogDirectory = Constants.Paths.ENSHROUDED_LOGS_DIRECTORY,
                Ip = txtIpAddress.Text,
                GamePort = Gameport,
                QueryPort = QueryPort,
                SlotCount = SlotCount
            };

            var output = JsonConvert.SerializeObject(json, _jsonSerializerSettings);

            var gameServerConfig = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Files.GAME_SERVER_CONFIG_JSON);
            File.WriteAllText(gameServerConfig, output);

            var gameServerExe = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Files.GAME_SERVER_EXE);
            _server.Start(gameServerExe, selectedProfileName);


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
                        var saveGameFolder = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Paths.GAME_SERVER_SAVE_FOLDER);
                        var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);

                        _backup.StartAutoBackup(saveGameFolder, selectedProfileName, profile.AutoBackup.Interval, profile.AutoBackup.MaxiumBackups, Constants.Files.GAME_SERVER_CONFIG_JSON, serverProfilePath);
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

            var saveGameFolder = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Paths.GAME_SERVER_SAVE_FOLDER);
            var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);

            _backup.Save(saveGameFolder, selectedProfileName, Constants.Files.GAME_SERVER_CONFIG_JSON, serverProfilePath);
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
            string backupserverfolder = Path.Join(Constants.Paths.BACKUPS_FOLDER, selectedProfileName);

            Directory.CreateDirectory(backupserverfolder);

            Process.Start(Constants.ProcessNames.EXPLORER_EXE, backupserverfolder);
        }
    }

    private void WindowsFirewall_Button_Click(object sender, EventArgs e)
    {
        Process.Start(Constants.ProcessNames.EXPLORER_EXE, Constants.Files.WINDOWS_FIREWALL);
    }

    private void OpenSavegameFolder_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();
            string savegamefolder = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Paths.GAME_SERVER_SAVE_FOLDER);

            Directory.CreateDirectory(savegamefolder);

            Process.Start(Constants.ProcessNames.EXPLORER_EXE, savegamefolder);
        }
    }

    private void OpenLogFolder_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();
            string logfolder = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Paths.GAME_SERVER_LOGS_FOLDER);
            Directory.CreateDirectory(logfolder);

            Process.Start(Constants.ProcessNames.EXPLORER_EXE, logfolder);
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
        var profileName = GenerateText.RandomServerName(6);
        while (profiledata.Any(x => x.Name == profileName))
        {
            profileName = GenerateText.RandomServerName(6);
        }

        profiledata.Add(new ServerProfile()
        {
            Name = profileName
        });

        // write the new profile to the json file
        var output = JsonConvert.SerializeObject(profiledata, _jsonSerializerSettings);
        var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.SERVER_PROFILES_JSON);
        File.WriteAllText(serverProfilesJson, output);

        // Create a folder with for the configuration
        var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, profileName);
        Directory.CreateDirectory(serverProfilePath);
        WriteDefaultServerSettings(profileName);

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
            MessageBox.Show(Constants.Errors.SERVER_RUNNING_ERROR_MESSAGE,
                Constants.Errors.SERVER_RUNNING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var reservedProfileNames = new string[] { Constants.ReservedProfileNames.AUTO_BACKCUP };

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

            var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, editProfileName);
            if (Directory.Exists(serverProfilePath))
            {
                // update the name
                selectedProfile.Name = editProfileName;

                // write the new profile to the json file
                var output = JsonConvert.SerializeObject(profiledata, _jsonSerializerSettings);
                var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.SERVER_PROFILES_JSON);

                File.WriteAllText(serverProfilesJson, output);

                // rename backup folder
                var oldBackupFolder = Path.Join(Constants.Paths.BACKUPS_FOLDER, selectedServerProfile);
                var newBackupFolder = Path.Join(Constants.Paths.BACKUPS_FOLDER, editProfileName);
                if (!_fileSystemManager.RenameDirectory(oldBackupFolder, newBackupFolder))
                {
                    MessageBox.Show(Constants.Errors.BACKUP_ERROR_MESSAGE, Constants.Errors.BACKUP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // rename autobackup folder
                var oldAutoBackupFolder = Path.Join(Constants.Paths.AUTOBACKUPS_FOLDER, selectedServerProfile);
                var newAutoBackupFolder = Path.Join(Constants.Paths.AUTOBACKUPS_FOLDER, editProfileName);
                if (!_fileSystemManager.RenameDirectory(oldAutoBackupFolder, newAutoBackupFolder))
                {
                    MessageBox.Show(Constants.Errors.AUTOBACKUP_ERROR_MESSAGE, Constants.Errors.AUTOBACKUP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // ClearProfileName_TextBox
                txtEditProfileName.Text = "";

                Interactions.AnimateSaveChangesButton(btnSaveProfileName, btnSaveProfileName.Text, Constants.ButtonText.SAVED_SUCCESS);

                // reload form1
                Form1_Load(sender, e);
            }
        }
    }

    private void DeleteProfile_Button_Click(object sender, EventArgs e)
    {
        if (lbxServerProfiles.SelectedItem is not null)
        {
            var result = MessageBox.Show(Constants.Warnings.DELETE_PROFILE_WARNING_MESSAGE, Constants.Warnings.DELETE_PROFILE_WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
                var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedServerProfile);
                // rename directory to check if in use
                try
                {
                    Directory.Move(serverProfilePath, $"{serverProfilePath}_delete");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format(Constants.Errors.DELETE_PROFILE_ERROR_MESSAGE, ex.Message),
                        Constants.Errors.DELETE_PROFILE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (Directory.Exists($"{serverProfilePath}_delete"))
                {
                    // Delete the server folder
                    _fileSystemManager.DeleteDirectory($"{serverProfilePath}_delete");

                    // remove the profile
                    profiledata.Remove(serverProfile);

                    // write the new profile to the json file
                    var output = JsonConvert.SerializeObject(profiledata, _jsonSerializerSettings);
                    var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.SERVER_PROFILES_JSON);
                    File.WriteAllText(serverProfilesJson, output);

                    // Clear UI Elements
                    txtEditProfileName.Text = "";
                    lbxServerProfiles.Items.Remove(selectedServerProfile);
                    cbxProfileSelectionComboBox.Items.Remove(selectedServerProfile);
                    RefreshServerButtonsVisibility(selectedServerProfile);

                    // reload form1
                    Form1_Load(sender, e);

                    //clear cache pid file
                    var pidJsonFile = $"{Constants.Paths.CACHE_DIRECTORY}{selectedServerProfile}{Constants.Files.PID_JSON}";

                    if (File.Exists(pidJsonFile))
                    {
                        File.Delete(pidJsonFile);
                    }
                }
            }
        }
    }

    private void btnShowPassword_Click(object sender, EventArgs e)
    {
        var text = btnShowPassword.Text;
        // \0 is a null character, which is used to show the password
        // * is the character displayed instead of each character in the password
        txtServerPassword.PasswordChar = text == Constants.ButtonText.SHOW_PASSWORD ? '\0' : '*';

        btnShowPassword.Text = text == Constants.ButtonText.SHOW_PASSWORD ? Constants.ButtonText.HIDE_PASSWORD : Constants.ButtonText.SHOW_PASSWORD;
    }

    private void GithubLabel_Click(object sender, EventArgs e)
    {
        Process.Start(Constants.ProcessNames.EXPLORER_EXE, "https://github.com/ISpaikI/Enshrouded-Server-Manager");
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
            Interactions.AnimateSaveChangesButton(btnSaveAutoBackup, btnSaveAutoBackup.Text, Constants.ButtonText.SAVED_SUCCESS);

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
                var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.SERVER_PROFILES_JSON);
                File.WriteAllText(serverProfilesJson, output);
            }
        }
        else
        {
            MessageBox.Show(Constants.Errors.BACKUP_CONFIGURATION_ERROR_MESSAGE, Constants.Errors.BACKUP_CONFIGURATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnOpenAutobackupFolder_Click(object sender, EventArgs e)
    {
        Directory.CreateDirectory(Constants.Paths.AUTOBACKUPS_FOLDER);

        Process.Start(Constants.ProcessNames.EXPLORER_EXE, Constants.Paths.AUTOBACKUPS_FOLDER);
    }

    private void SaveSettings_Button_EnabledChanged(object sender, EventArgs e)
    {
        var Sender = ((Button)sender);
        Sender.BackColor = Sender.Enabled ? Constants.Colors.BUTTON_BACKGROUND : Constants.Colors.BUTTON_BACKGROUND_DISABLED;
        Sender.FlatAppearance.BorderColor = Sender.Enabled ? Constants.Colors.BUTTON_BORDER : Constants.Colors.BUTTON_BORDER_DISABLED;
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
        var gameServerExe = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Files.GAME_SERVER_EXE);

        btnStopServer.Visible = false;
        if (File.Exists(Constants.ProcessNames.STEAM_CMD_EXE))
        {
            btnInstallServer.Visible = true;
            btnStartServer.Visible = true;
        }

        if (File.Exists(gameServerExe))
        {
            btnInstallServer.Visible = false;
            btnUpdateServer.Visible = true;
        }
        else
        {
            btnInstallServer.Visible = true;
            btnUpdateServer.Visible = false;
        }

        if (!File.Exists(Constants.ProcessNames.STEAM_CMD_EXE))
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
            var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, selectedProfileName, Constants.Files.PID_JSON);

            if (File.Exists(pidJsonFile))
            {
                File.Delete(pidJsonFile);
            }
        }
    }

    private void RenameServerSettings(string oldServerProfileName, string newServerProfileName)
    {
        try
        {
            var oldServerProfilePath = Path.Join(Constants.Paths.SERVER_PATH, oldServerProfileName);
            var newServerProfilePath = Path.Join(Constants.Paths.SERVER_PATH, newServerProfileName);
            Directory.Move(oldServerProfilePath, $"{oldServerProfilePath}_temp");
            Directory.Move($"{oldServerProfilePath}_temp", newServerProfilePath);
        }
        catch (Exception ex)
        {
            MessageBox.Show(string.Format(Constants.Errors.PROFILE_NAME_CHANGE_ERROR_MESSAGE, ex.Message),
                Constants.Errors.PROFILE_NAME_CHANGE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return;
        }
    }

    private void LoadServerSettings(string selectedProfileName)
    {
        var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);
        var gameServerConfig = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_CONFIG_JSON);

        if (!File.Exists(gameServerConfig))
        {
            Directory.CreateDirectory(serverProfilePath);
            WriteDefaultServerSettings(selectedProfileName);
        }
        var input = File.ReadAllText(gameServerConfig);

        ServerSettings deserializedSettings = JsonConvert.DeserializeObject<ServerSettings>(input, _jsonSerializerSettings);


        txtServerName.Text = deserializedSettings.Name;
        txtServerPassword.Text = deserializedSettings.Password;
        txtIpAddress.Text = deserializedSettings.Ip;
        nudGamePort.Text = deserializedSettings.GamePort.ToString();
        nudQueryPort.Text = deserializedSettings.QueryPort.ToString();
        nudSlotCount.Text = deserializedSettings.SlotCount.ToString();
    }

    private void WriteDefaultServerSettings(string profileName)
    {
        ServerSettings json = new ServerSettings()
        {
            Name = "Enshrouded Server",
            Password = "",
            SaveDirectory = Constants.Paths.ENSHROUDED_SAVE_GAME_DIRECTORY,
            LogDirectory = Constants.Paths.ENSHROUDED_LOGS_DIRECTORY,
            Ip = "0.0.0.0",
            GamePort = 15636,
            QueryPort = 15637,
            SlotCount = 16
        };

        var output = JsonConvert.SerializeObject(json, _jsonSerializerSettings);
        var gameServerConfig = Path.Join(Constants.Paths.SERVER_PATH, profileName, Constants.Files.GAME_SERVER_CONFIG_JSON);

        File.WriteAllText(gameServerConfig, output);
    }
}
