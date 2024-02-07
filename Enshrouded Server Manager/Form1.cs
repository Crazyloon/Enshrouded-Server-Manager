using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Model;
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
    private DiscordOutput _discordOutput;

    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);



    public Form1()
    {
        InitializeComponent();
        InitializePanelPositions();

        //Initialize Services
        _fileSystemManager = new FileSystemManager();
        _steamCMD = new SteamCMD(_fileSystemManager);
        _server = new Server(_fileSystemManager);
        _backup = new Backup(_fileSystemManager);
        _versionManager = new VersionManager(_fileSystemManager);
        _profileManager = new ProfileManager(_fileSystemManager);
        _discordOutput = new DiscordOutput();

        //Register Custom Events
        _backup.AutoBackupSuccess += Backup_AutoBackupSuccess;
    }

    private void InitializePanelPositions()
    {
        pnlBackupExplanation.Location = new Point(550, 40);
        pnlCredits.Location = new Point(560, 40);
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
                LoadDiscordSettings();
            }
        }
        ServerUpdateCheckTimer();
        _versionManager.ManagerUpdate(lblVersion.Text, lblNewVersionAvailableNotification);
    }

    #region ButtonEvents

    private void InstallSteamCMD_Button_Click(object sender, EventArgs e)
    {
        _steamCMD.Install();

        if (_fileSystemManager.FileExists(Constants.ProcessNames.STEAM_CMD_EXE))
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

            _server.InstallUpdate(Constants.STEAM_APP_ID, $"../{serverProfilePath}", selectedProfileName, btnInstallServer, btnUpdateServer, btnStartServer);
            _versionManager.ServerUpdateCheck(selectedProfileName, btnUpdateServer);
            btnUpdateServer.Visible = true;
            btnStartServer.Visible = true;
        }
    }

    private void UpdateServer_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();
            var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);

            // discord Output
            var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.DISCORD_JSON);
            if (_fileSystemManager.FileExists(discordSettingsFile))
            {
                var discordSettingsText = _fileSystemManager.ReadFile(discordSettingsFile);
                DiscordProfile discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, _jsonSerializerSettings);
                string discordUrl = discordProfile.DiscordUrl;

                var gameServerConfig = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_CONFIG_JSON);
                var gameServerConfigText = _fileSystemManager.ReadFile(gameServerConfig);
                ServerSettings gameServerSettings = JsonConvert.DeserializeObject<ServerSettings>(gameServerConfigText, _jsonSerializerSettings);
                string name = gameServerSettings.Name;

                if (discordProfile.Enabled)
                {
                    if (discordProfile.UpdatingEnabled)
                    {
                        Task.Factory.StartNew(async () =>
                        {
                            try
                            {
                                _discordOutput.ServerUpdating(name, discordUrl, discordProfile.EmbedEnabled, discordProfile.ServerUpdatingMsg);
                            }
                            catch
                            {

                            }
                        });
                    }
                }
            }
            _server.InstallUpdate(Constants.STEAM_APP_ID, $"../{serverProfilePath}", selectedProfileName, btnInstallServer, btnUpdateServer, btnStartServer);
            _versionManager.ServerUpdateCheck(selectedProfileName, btnUpdateServer);
            btnUpdateServer.Visible = true;
            btnStartServer.Visible = true;
    }
    }

    private void SaveSettings_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();

            if (_server.IsRunning(selectedProfileName))
            {
                MessageBox.Show(Constants.Errors.SERVER_RUNNING_ERROR_MESSAGE, Constants.Errors.SERVER_RUNNING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbxProfileSelectionComboBox_IndexChanged(sender, e);
                return;
            }

            var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);
            _fileSystemManager.CreateDirectory(serverProfilePath);

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
            _fileSystemManager.WriteFile(gameServerConfig, output); //needs to be the server tool .json

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
            _fileSystemManager.CreateDirectory(serverProfilePath);

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

            var gameServerConfig = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_CONFIG_JSON);
            _fileSystemManager.WriteFile(gameServerConfig, output);

            var gameServerExe = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_EXE);
            _server.Start(gameServerExe, selectedProfileName);


            // Begin AutoBackup after waiting 5 seconds to ensure the server process has started
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(5000);

                if (_server.IsRunning(selectedProfileName))
                {
                    var profiles = _profileManager.LoadServerProfiles(_jsonSerializerSettings);
                    var profile = profiles?.FirstOrDefault(x => x.Name == selectedProfileName);
                    if (profile is not null && profile.AutoBackup is not null && profile.AutoBackup.Enabled)
                    {
                        var saveGameFolder = Path.Join(serverProfilePath, Constants.Paths.GAME_SERVER_SAVE_FOLDER);

                        _backup.StartAutoBackup(saveGameFolder, selectedProfileName, profile.AutoBackup.Interval, profile.AutoBackup.MaxiumBackups, Constants.Files.GAME_SERVER_CONFIG_JSON, serverProfilePath);
                    }
                }
            });

            if (_server.IsRunning(selectedProfileName))
            {
                btnStartServer.Visible = false;
                btnStopServer.Visible = true;
            }

            // discord Output
            var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.DISCORD_JSON);
            if (_fileSystemManager.FileExists(discordSettingsFile))
            {
                var discordSettingsText = _fileSystemManager.ReadFile(discordSettingsFile);
                DiscordProfile discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, _jsonSerializerSettings);
                string DiscordUrl = discordProfile.DiscordUrl;

                var gameServerConfigText = _fileSystemManager.ReadFile(gameServerConfig);
                ServerSettings serverSettings = JsonConvert.DeserializeObject<ServerSettings>(gameServerConfigText, _jsonSerializerSettings);
                string name = serverSettings.Name;

                if (discordProfile.Enabled)
                {
                    if (discordProfile.StartEnabled)
                    {
                        Task.Factory.StartNew(async () =>
                        {
                            try
                            {
                                _discordOutput.ServerOnline(name, DiscordUrl, discordProfile.EmbedEnabled, discordProfile.ServerOnlineMsg);
                            }
                            catch
                            {

                            }
                        });
                    }
                }
            }
        }
    }

    private void SaveBackup_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();

            var serverProfileDirectory = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);
            var saveGameDirectory = Path.Join(serverProfileDirectory, Constants.Paths.GAME_SERVER_SAVE_FOLDER);

            _backup.Save(saveGameDirectory, selectedProfileName, Constants.Files.GAME_SERVER_CONFIG_JSON, serverProfileDirectory);
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

            _fileSystemManager.CreateDirectory(backupserverfolder);

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

            _fileSystemManager.CreateDirectory(savegamefolder);

            Process.Start(Constants.ProcessNames.EXPLORER_EXE, savegamefolder);
        }
    }

    private void OpenLogFolder_Button_Click(object sender, EventArgs e)
    {
        if (cbxProfileSelectionComboBox.SelectedItem is not null)
        {
            string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();
            string logfolder = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Paths.GAME_SERVER_LOGS_FOLDER);
            _fileSystemManager.CreateDirectory(logfolder);

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
        _fileSystemManager.WriteFile(serverProfilesJson, output);

        // Create a folder with for the configuration
        var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, profileName);
        _fileSystemManager.CreateDirectory(serverProfilePath);
        WriteDefaultServerSettings(profileName);

        // reload form1
        Form1_Load(sender, e);
    }

    private void SaveProfileName_Button_Click(object sender, EventArgs e)
    {
        var reservedProfileNames = new string[] { "AutoBackup" };
        string editProfileName = txtEditProfileName.Text;
        var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, editProfileName);
        if (_fileSystemManager.DirectoryExists(serverProfilePath))
        {
            return;
        }

        if (lbxServerProfiles.SelectedItem is null)
        {
            return;
        }

        string selectedServerProfile = lbxServerProfiles.SelectedItem.ToString();

        if (_server.IsRunning(selectedServerProfile))
        {
            MessageBox.Show(Constants.Errors.SERVER_RUNNING_ERROR_MESSAGE, Constants.Errors.SERVER_RUNNING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return;
        }

        // Validate:
        // Not Null
        // Windows File Name Does not have Special Characters
        // Not the same as an existing profile name
        // Not allowed to use ReservedNames
        if (editProfileName is null
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
        if (selectedProfile is not null)
        {
            // rename the server settings folder
            RenameServerSettings(selectedServerProfile, editProfileName);

            if (_fileSystemManager.DirectoryExists(serverProfilePath))
            {
                // update the name
                selectedProfile.Name = editProfileName;

                // write the new profile to the json file
                var output = JsonConvert.SerializeObject(profiledata, _jsonSerializerSettings);
                var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.SERVER_PROFILES_JSON);

                _fileSystemManager.WriteFile(serverProfilesJson, output);

                // rename backup folder
                var oldBackupFolder = Path.Join(Constants.Paths.BACKUPS_FOLDER, selectedServerProfile);
                var newBackupFolder = Path.Join(Constants.Paths.BACKUPS_FOLDER, editProfileName);
                if (!_fileSystemManager.DirectoryExists(oldBackupFolder))
                {
                    _fileSystemManager.CreateDirectory(oldBackupFolder);
                }
                if (!_fileSystemManager.RenameDirectory(oldBackupFolder, newBackupFolder))
                {
                    MessageBox.Show(Constants.Errors.BACKUP_ERROR_MESSAGE, Constants.Errors.BACKUP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // rename autobackup folder
                var oldAutoBackupFolder = Path.Join(Constants.Paths.AUTOBACKUPS_FOLDER, selectedServerProfile);
                var newAutoBackupFolder = Path.Join(Constants.Paths.AUTOBACKUPS_FOLDER, editProfileName);
                if (!_fileSystemManager.DirectoryExists(oldAutoBackupFolder))
                {
                    _fileSystemManager.CreateDirectory(oldAutoBackupFolder);
                }
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
            // get the selected profile
            string selectedServerProfile = lbxServerProfiles.SelectedItem.ToString();

            if (_server.IsRunning(selectedServerProfile))
            {
                MessageBox.Show(Constants.Errors.SERVER_RUNNING_ERROR_MESSAGE, Constants.Errors.SERVER_RUNNING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var result = MessageBox.Show(Constants.Warnings.DELETE_PROFILE_WARNING_MESSAGE, Constants.Warnings.DELETE_PROFILE_WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            // Load Server Profiles
            List<ServerProfile> profiledata = _profileManager.LoadServerProfiles(_jsonSerializerSettings);
            var serverProfile = profiledata.FirstOrDefault(x => x.Name == selectedServerProfile);
            if (serverProfile is not null)
            {
                var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedServerProfile);
                var autoBackupPath = Path.Join(Constants.Paths.AUTOBACKUPS_FOLDER, selectedServerProfile);
                var backupPath = Path.Join(Constants.Paths.BACKUPS_FOLDER, selectedServerProfile);

                // rename directory to check if in use
                try
                {
                    if (_fileSystemManager.DirectoryExists(serverProfilePath))
                    {
                        _fileSystemManager.MoveDirectory(serverProfilePath, $"{serverProfilePath}_delete");
                    }
                    if (_fileSystemManager.DirectoryExists(autoBackupPath))
                    {
                        _fileSystemManager.MoveDirectory(autoBackupPath, $"{autoBackupPath}_delete");
                    }
                    if (_fileSystemManager.DirectoryExists(backupPath))
                    {
                        _fileSystemManager.MoveDirectory(backupPath, $"{backupPath}_delete");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format(Constants.Errors.DELETE_PROFILE_ERROR_MESSAGE, ex.Message),
                        Constants.Errors.DELETE_PROFILE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (_fileSystemManager.DirectoryExists($"{autoBackupPath}_delete"))
                {
                    _fileSystemManager.DeleteDirectory($"{autoBackupPath}_delete");
                }
                if (_fileSystemManager.DirectoryExists($"{backupPath}_delete"))
                {
                    _fileSystemManager.DeleteDirectory($"{backupPath}_delete");
                }

                if (_fileSystemManager.DirectoryExists($"{serverProfilePath}_delete"))
                {
                    // Delete the server folder
                    _fileSystemManager.DeleteDirectory($"{serverProfilePath}_delete");

                    // remove the profile
                    profiledata.Remove(serverProfile);

                    // write the new profile to the json file
                    var output = JsonConvert.SerializeObject(profiledata, _jsonSerializerSettings);
                    var serverProfilesJson = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.SERVER_PROFILES_JSON);
                    _fileSystemManager.WriteFile(serverProfilesJson, output);

                    // Clear UI Elements
                    txtEditProfileName.Text = "";
                    lbxServerProfiles.Items.Remove(selectedServerProfile);
                    cbxProfileSelectionComboBox.Items.Remove(selectedServerProfile);
                    RefreshServerButtonsVisibility(selectedServerProfile);

                    // reload form1
                    Form1_Load(sender, e);

                    //clear cache pid file
                    var pidJsonFile = $"{Constants.Paths.CACHE_DIRECTORY}{selectedServerProfile}{Constants.Files.PID_JSON}";

                    if (_fileSystemManager.FileExists(pidJsonFile))
                    {
                        _fileSystemManager.DeleteFile(pidJsonFile);
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
        Process.Start(Constants.ProcessNames.EXPLORER_EXE, Constants.Urls.ESM_GITHUB_LINK);
    }

    private void btnStopServer_Click(object sender, EventArgs e)
    {
        string selectedProfileName = cbxProfileSelectionComboBox.SelectedItem.ToString();
        _server.Stop(selectedProfileName);
        btnStartServer.Visible = true;
        btnStopServer.Visible = false;

        // discord Output
        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.DISCORD_JSON);
        if (_fileSystemManager.FileExists(discordSettingsFile))
        {
            var discordSettingsText = _fileSystemManager.ReadFile(discordSettingsFile);
            DiscordProfile discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, _jsonSerializerSettings);
            string DiscordUrl = discordProfile.DiscordUrl;

            var serverProfilePath = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName);
            var gameServerConfig = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_CONFIG_JSON);
            var gameServerConfigText = _fileSystemManager.ReadFile(gameServerConfig);
            ServerSettings gameServerSettings = JsonConvert.DeserializeObject<ServerSettings>(gameServerConfigText, _jsonSerializerSettings);
            string name = gameServerSettings.Name;

            if (discordProfile.Enabled)
            {
                if (discordProfile.StopEnabled)
                {
                    Task.Factory.StartNew(async () =>
                    {
                        try
                        {
                            _discordOutput.ServerOffline(name, DiscordUrl, discordProfile.EmbedEnabled, discordProfile.ServerStoppedMsg);
                        }
                        catch
                        {

                        }
                    });
                }
            }
        }
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
                _fileSystemManager.WriteFile(serverProfilesJson, output);
            }
        }
        else
        {
            MessageBox.Show(Constants.Errors.BACKUP_CONFIGURATION_ERROR_MESSAGE, Constants.Errors.BACKUP_CONFIGURATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnOpenAutobackupFolder_Click(object sender, EventArgs e)
    {
        _fileSystemManager.CreateDirectory(Constants.Paths.AUTOBACKUPS_FOLDER);

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
            _versionManager.ServerUpdateCheck(serverSelectedText, btnUpdateServer);
        }
    }

    private void lbxProfileSelectorAutoBackup_SelectedIndexChanged(object sender, EventArgs e)
    {
        // get selected item
        var selectedProfile = lbxProfileSelectorAutoBackup.SelectedItem?.ToString();
        if (selectedProfile is not null)
        {
            // load profile
            var profile = _profileManager.LoadServerProfiles(_jsonSerializerSettings).FirstOrDefault(x => x.Name == selectedProfile);
            if (profile is not null)
            {
                // load auto backup settings
                if (profile.AutoBackup is null)
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
        if (selectedtab == tabAutoBackup && !pnlCredits.Visible)
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
        if (_fileSystemManager.FileExists(Constants.ProcessNames.STEAM_CMD_EXE))
        {
            btnInstallServer.Visible = true;
            btnStartServer.Visible = true;
        }

        if (_fileSystemManager.FileExists(gameServerExe))
        {
            btnInstallServer.Visible = false;
            btnUpdateServer.Visible = true;
        }
        else
        {
            btnInstallServer.Visible = true;
            btnUpdateServer.Visible = false;
        }

        if (!_fileSystemManager.FileExists(Constants.ProcessNames.STEAM_CMD_EXE))
        {
            btnInstallServer.Visible = false;
            btnStartServer.Visible = false;
        }

        try
        {
            if (_server.IsRunning(selectedProfileName))
            {
                btnStartServer.Visible = false;
                btnStopServer.Visible = true;
            }
        }
        catch (Exception)
        {
            var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, selectedProfileName, Constants.Files.PID_JSON);

            if (_fileSystemManager.FileExists(pidJsonFile))
            {
                _fileSystemManager.DeleteFile(pidJsonFile);
            }
        }
    }

    private void RenameServerSettings(string oldServerProfileName, string newServerProfileName)
    {
        try
        {
            var oldServerProfilePath = Path.Join(Constants.Paths.SERVER_PATH, oldServerProfileName);
            var newServerProfilePath = Path.Join(Constants.Paths.SERVER_PATH, newServerProfileName);
            _fileSystemManager.MoveDirectory(oldServerProfilePath, $"{oldServerProfilePath}_temp");
            _fileSystemManager.MoveDirectory($"{oldServerProfilePath}_temp", newServerProfilePath);
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

        if (!_fileSystemManager.FileExists(gameServerConfig))
        {
            _fileSystemManager.CreateDirectory(serverProfilePath);
            WriteDefaultServerSettings(selectedProfileName);
        }
        var input = _fileSystemManager.ReadFile(gameServerConfig);

        ServerSettings deserializedSettings = JsonConvert.DeserializeObject<ServerSettings>(input, _jsonSerializerSettings);


        txtServerName.Text = deserializedSettings.Name;
        txtServerPassword.Text = deserializedSettings.Password;
        txtIpAddress.Text = deserializedSettings.Ip;
        nudGamePort.Text = deserializedSettings.GamePort.ToString();
        nudQueryPort.Text = deserializedSettings.QueryPort.ToString();
        nudSlotCount.Text = deserializedSettings.SlotCount.ToString();
    }

    private void LoadDiscordSettings()
    {
        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.DISCORD_JSON);
        if (!_fileSystemManager.FileExists(discordSettingsFile))
        {
            return;
        }
        var discordSettingsText = _fileSystemManager.ReadFile(discordSettingsFile);
        DiscordProfile discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, _jsonSerializerSettings);

        txtDiscordWebhookUrl.Text = discordProfile.DiscordUrl;
        chkEnableDiscord.Checked = discordProfile.Enabled;
        chkNotifiServerStarted.Checked = discordProfile.StartEnabled;
        chkNotifiServerStopped.Checked = discordProfile.StopEnabled;
        chkNotifiServerUpdating.Checked = discordProfile.UpdatingEnabled;
        chkNotifiBackup.Checked = discordProfile.BackupEnabled;
        chkEmbed.Checked = discordProfile.EmbedEnabled;
        txtServerOnlineMsg.Text = discordProfile.ServerOnlineMsg;
        txtServerStoppedMsg.Text = discordProfile.ServerStoppedMsg;
        txtServerUpdatingMsg.Text = discordProfile.ServerUpdatingMsg;
        txtBackupMsg.Text = discordProfile.BackupMsg;
    }

    private void WriteDefaultServerSettings(string profileName)
    {
        ServerSettings json = new ServerSettings()
        {
            Name = Constants.ServerSettings.DEFAULT_SERVER_NAME,
            Password = Constants.ServerSettings.DEFAULT_SERVER_PASSWORD,
            SaveDirectory = Constants.Paths.ENSHROUDED_SAVE_GAME_DIRECTORY,
            LogDirectory = Constants.Paths.ENSHROUDED_LOGS_DIRECTORY,
            Ip = Constants.ServerSettings.DEFAULT_SERVER_IP,
            GamePort = Constants.ServerSettings.DEFAULT_SERVER_GAME_PORT,
            QueryPort = Constants.ServerSettings.DEFAULT_SERVER_QUERY_PORT,
            SlotCount = Constants.ServerSettings.DEFAULT_SERVER_SLOT_COUNT
        };

        var output = JsonConvert.SerializeObject(json, _jsonSerializerSettings);
        var gameServerConfig = Path.Join(Constants.Paths.SERVER_PATH, profileName, Constants.Files.GAME_SERVER_CONFIG_JSON);

        _fileSystemManager.WriteFile(gameServerConfig, output);
    }

    private void btnSaveDiscordSettings_Click(object sender, EventArgs e)
    {
        var enabled = chkEnableDiscord.Checked;
        var startedEnabled = chkNotifiServerStarted.Checked;
        var stoppedEnabled = chkNotifiServerStopped.Checked;
        var updatingEnabled = chkNotifiServerUpdating.Checked;
        var backupEnabled = chkNotifiBackup.Checked;
        string url = txtDiscordWebhookUrl.Text;
        string serverOnlineMsg = txtServerOnlineMsg.Text;
        string serverStoppedMsg = txtServerStoppedMsg.Text;
        string serverUpdatingMsg = txtServerUpdatingMsg.Text;
        string backupMsg = txtBackupMsg.Text;
        var embedEnabled = chkEmbed.Checked;
        DiscordProfile discordProfile = new DiscordProfile()
        {
            DiscordUrl = url,
            Enabled = enabled,
            StartEnabled = startedEnabled,
            StopEnabled = stoppedEnabled,
            UpdatingEnabled = updatingEnabled,
            BackupEnabled = backupEnabled,
            EmbedEnabled = embedEnabled,
            ServerOnlineMsg = serverOnlineMsg,
            ServerStoppedMsg = serverStoppedMsg,
            ServerUpdatingMsg = serverUpdatingMsg,
            BackupMsg = backupMsg
        };

        // write the new discord profile to the json file
        var discordProfileJson = JsonConvert.SerializeObject(discordProfile, _jsonSerializerSettings);
        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.DISCORD_JSON);
        _fileSystemManager.WriteFile(discordSettingsFile, discordProfileJson);

        Interactions.AnimateSaveChangesButton(btnSaveDiscordSettings, btnSaveDiscordSettings.Text, Constants.ButtonText.SAVED_SUCCESS);
    }

    private void btnTestDiscord_Click(object sender, EventArgs e)
    {
        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.DISCORD_JSON);
        if (_fileSystemManager.FileExists(discordSettingsFile)) ;
        var discordSettingsText = _fileSystemManager.ReadFile(discordSettingsFile);
        DiscordProfile discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, _jsonSerializerSettings);
        string DiscordUrl = discordProfile.DiscordUrl;
        if (_fileSystemManager.FileExists(discordSettingsFile))
        {
            _discordOutput.TestMsg(DiscordUrl, discordProfile.EmbedEnabled);
        }
    }

    #region Update Serverbutton Timer
    public async void ServerUpdateCheckTimer()
    {
        int TIMER_INTERVAL_SERVER_UPDATE_CHECK = 5;

        string selectedProfile = cbxProfileSelectionComboBox.SelectedItem.ToString();
        _versionManager.ServerUpdateCheck(selectedProfile, btnUpdateServer);

        var timer = new PeriodicTimer(TimeSpan.FromMinutes(TIMER_INTERVAL_SERVER_UPDATE_CHECK));

        while (await timer.WaitForNextTickAsync())
        {
            selectedProfile = cbxProfileSelectionComboBox.SelectedItem.ToString();
            _versionManager.ServerUpdateCheck(selectedProfile, btnUpdateServer);
        }
    }
    #endregion

    private void btnToggleCredits_Click(object sender, EventArgs e)
    {
        pnlCredits.Visible = !pnlCredits.Visible;
        if (pnlCredits.Visible)
        {
            pbxCreditsBorder.Visible = true;

            if (tabServerTabs.SelectedTab == tabAutoBackup)
            {
                pnlBackupExplanation.Visible = false;
            }
        }
        else
        {
            pbxCreditsBorder.Visible = false;
            if (tabServerTabs.SelectedTab == tabAutoBackup)
            {
                pnlBackupExplanation.Visible = true;
            }
        }
    }
}

