namespace Enshrouded_Server_Manager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            cbxProfileSelectionComboBox = new ComboBox();
            lblProfileSelectionLabel = new Label();
            btnInstallSteamCMD = new Button();
            btnInstallServer = new Button();
            txtServerName = new TextBox();
            txtServerPassword = new TextBox();
            txtIpAddress = new TextBox();
            nudGamePort = new NumericUpDown();
            nudQueryPort = new NumericUpDown();
            nudSlotCount = new NumericUpDown();
            lblServername = new Label();
            lblPassword = new Label();
            lblIpAddress = new Label();
            lblGamePort = new Label();
            lblQueryPort = new Label();
            lblMaxPlayers = new Label();
            btnSaveSettings = new Button();
            btnStartServer = new Button();
            pictureBox2 = new PictureBox();
            lblAdminPanel = new Label();
            lblTitle = new Label();
            lblServerSettings = new Label();
            lblCloseButton = new Label();
            lblMinimizeTrayButton = new Label();
            pictureBox5 = new PictureBox();
            lblNews = new Label();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox8 = new PictureBox();
            pbxCreditsBorder = new PictureBox();
            pictureBox9 = new PictureBox();
            btnSaveBackup = new Button();
            btnOpenBackupFolder = new Button();
            btnWindowsFirewall = new Button();
            label7 = new Label();
            lblServerProfileSpecific = new Label();
            pictureBox10 = new PictureBox();
            btnOpenSavegameFolder = new Button();
            btnOpenLogFolder = new Button();
            btnUpdateServer = new Button();
            lblLogo = new Label();
            tabServerTabs = new TabControl();
            tabServerSettings = new TabPage();
            btnShowPassword = new Button();
            tabProfileManager = new TabPage();
            lblAddNewProfile = new Label();
            lblProfileManager = new Label();
            pnlProfileNameUpdate = new Panel();
            lblProfileNameInfo = new Label();
            btnSaveProfileName = new Button();
            txtEditProfileName = new TextBox();
            lblProfileNameInputHeading = new Label();
            btnDeleteProfile = new Button();
            btnAddNewProfile = new Button();
            lbxServerProfiles = new ListBox();
            tabAutoBackup = new TabPage();
            lblAutoBackupChangesInfo = new Label();
            btnSaveAutoBackup = new Button();
            chkEnableBackups = new CheckBox();
            lblProfileBackupsStats = new Label();
            lblProfileBackupsInstruction = new Label();
            nudBackupMaxCount = new NumericUpDown();
            label2 = new Label();
            lblBackupFrequency = new Label();
            nudBackupInterval = new NumericUpDown();
            lblScheduleBackups = new Label();
            lbxProfileSelectorAutoBackup = new ListBox();
            tabDiscord = new TabPage();
            lblDiscordChanges = new Label();
            gbxDiscordNotificationSettings = new GroupBox();
            txtBackupMsg = new TextBox();
            txtServerUpdatingMsg = new TextBox();
            txtServerStoppedMsg = new TextBox();
            txtServerOnlineMsg = new TextBox();
            chkEmbed = new CheckBox();
            chkNotifiBackup = new CheckBox();
            chkNotifiServerUpdating = new CheckBox();
            chkNotifiServerStopped = new CheckBox();
            chkNotifiServerStarted = new CheckBox();
            btnTestDiscord = new Button();
            lblDiscordWebhookUrl = new Label();
            btnSaveDiscordSettings = new Button();
            txtDiscordWebhookUrl = new TextBox();
            chkEnableDiscord = new CheckBox();
            lblNewsText = new Label();
            lblVersion = new Label();
            GithubLabel = new Label();
            lblNewVersionAvailableNotification = new Label();
            pnlBackupExplanation = new Panel();
            btnOpenAutobackupFolder = new Button();
            label3 = new Label();
            pictureBox4 = new PictureBox();
            label1 = new Label();
            pnlCredits = new Panel();
            lblCreditsSponsorsList = new Label();
            lblCreditsSupportedBy = new Label();
            btnCreditsClose = new Label();
            lblCreditsLogo = new Label();
            lblHeadingSpecialThanks = new Label();
            lblHeadingMadeBy = new Label();
            lblCreditsContributors = new Label();
            lblCreditsMadeBy = new Label();
            btnStopServer = new Button();
            pictureBox1 = new PictureBox();
            pbxFormHeader = new PictureBox();
            btnOpenCredits = new Label();
            ((System.ComponentModel.ISupportInitialize)nudGamePort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQueryPort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSlotCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCreditsBorder).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            tabServerTabs.SuspendLayout();
            tabServerSettings.SuspendLayout();
            tabProfileManager.SuspendLayout();
            pnlProfileNameUpdate.SuspendLayout();
            tabAutoBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudBackupMaxCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudBackupInterval).BeginInit();
            tabDiscord.SuspendLayout();
            gbxDiscordNotificationSettings.SuspendLayout();
            pnlBackupExplanation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            pnlCredits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxFormHeader).BeginInit();
            SuspendLayout();
            // 
            // cbxProfileSelectionComboBox
            // 
            cbxProfileSelectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxProfileSelectionComboBox.FlatStyle = FlatStyle.System;
            cbxProfileSelectionComboBox.FormattingEnabled = true;
            cbxProfileSelectionComboBox.Location = new Point(322, 54);
            cbxProfileSelectionComboBox.Name = "cbxProfileSelectionComboBox";
            cbxProfileSelectionComboBox.Size = new Size(175, 23);
            cbxProfileSelectionComboBox.TabIndex = 0;
            cbxProfileSelectionComboBox.SelectedIndexChanged += cbxProfileSelectionComboBox_IndexChanged;
            // 
            // lblProfileSelectionLabel
            // 
            lblProfileSelectionLabel.AutoSize = true;
            lblProfileSelectionLabel.Location = new Point(240, 57);
            lblProfileSelectionLabel.Name = "lblProfileSelectionLabel";
            lblProfileSelectionLabel.Size = new Size(76, 15);
            lblProfileSelectionLabel.TabIndex = 1;
            lblProfileSelectionLabel.Text = "Server Profile";
            // 
            // btnInstallSteamCMD
            // 
            btnInstallSteamCMD.Cursor = Cursors.Hand;
            btnInstallSteamCMD.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnInstallSteamCMD.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnInstallSteamCMD.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnInstallSteamCMD.FlatStyle = FlatStyle.Flat;
            btnInstallSteamCMD.ForeColor = SystemColors.Control;
            btnInstallSteamCMD.Location = new Point(33, 57);
            btnInstallSteamCMD.Name = "btnInstallSteamCMD";
            btnInstallSteamCMD.Size = new Size(127, 23);
            btnInstallSteamCMD.TabIndex = 2;
            btnInstallSteamCMD.TabStop = false;
            btnInstallSteamCMD.Text = "Install SteamCMD";
            btnInstallSteamCMD.UseVisualStyleBackColor = true;
            btnInstallSteamCMD.Click += InstallSteamCMD_Button_Click;
            // 
            // btnInstallServer
            // 
            btnInstallServer.Cursor = Cursors.Hand;
            btnInstallServer.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnInstallServer.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnInstallServer.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnInstallServer.FlatStyle = FlatStyle.Flat;
            btnInstallServer.ForeColor = SystemColors.Control;
            btnInstallServer.Location = new Point(33, 196);
            btnInstallServer.Name = "btnInstallServer";
            btnInstallServer.Size = new Size(127, 25);
            btnInstallServer.TabIndex = 3;
            btnInstallServer.Text = "Install Server";
            btnInstallServer.UseVisualStyleBackColor = true;
            btnInstallServer.Visible = false;
            btnInstallServer.Click += InstallServer_Button_Click;
            // 
            // txtServerName
            // 
            txtServerName.BackColor = Color.FromArgb(6, 6, 48);
            txtServerName.BorderStyle = BorderStyle.FixedSingle;
            txtServerName.ForeColor = SystemColors.Window;
            txtServerName.Location = new Point(112, 41);
            txtServerName.Name = "txtServerName";
            txtServerName.Size = new Size(170, 23);
            txtServerName.TabIndex = 4;
            // 
            // txtServerPassword
            // 
            txtServerPassword.BackColor = Color.FromArgb(6, 6, 48);
            txtServerPassword.BorderStyle = BorderStyle.FixedSingle;
            txtServerPassword.ForeColor = SystemColors.Window;
            txtServerPassword.Location = new Point(112, 70);
            txtServerPassword.Name = "txtServerPassword";
            txtServerPassword.PasswordChar = '*';
            txtServerPassword.Size = new Size(170, 23);
            txtServerPassword.TabIndex = 5;
            // 
            // txtIpAddress
            // 
            txtIpAddress.BackColor = Color.FromArgb(6, 6, 48);
            txtIpAddress.BorderStyle = BorderStyle.FixedSingle;
            txtIpAddress.ForeColor = SystemColors.Window;
            txtIpAddress.Location = new Point(112, 99);
            txtIpAddress.Name = "txtIpAddress";
            txtIpAddress.Size = new Size(134, 23);
            txtIpAddress.TabIndex = 6;
            // 
            // nudGamePort
            // 
            nudGamePort.BackColor = Color.FromArgb(6, 6, 48);
            nudGamePort.BorderStyle = BorderStyle.FixedSingle;
            nudGamePort.ForeColor = SystemColors.Window;
            nudGamePort.Location = new Point(112, 129);
            nudGamePort.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            nudGamePort.Name = "nudGamePort";
            nudGamePort.Size = new Size(62, 23);
            nudGamePort.TabIndex = 7;
            // 
            // nudQueryPort
            // 
            nudQueryPort.BackColor = Color.FromArgb(6, 6, 48);
            nudQueryPort.BorderStyle = BorderStyle.FixedSingle;
            nudQueryPort.ForeColor = SystemColors.Window;
            nudQueryPort.Location = new Point(112, 158);
            nudQueryPort.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            nudQueryPort.Name = "nudQueryPort";
            nudQueryPort.Size = new Size(62, 23);
            nudQueryPort.TabIndex = 8;
            // 
            // nudSlotCount
            // 
            nudSlotCount.BackColor = Color.FromArgb(6, 6, 48);
            nudSlotCount.BorderStyle = BorderStyle.FixedSingle;
            nudSlotCount.ForeColor = SystemColors.Window;
            nudSlotCount.Location = new Point(112, 187);
            nudSlotCount.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            nudSlotCount.Name = "nudSlotCount";
            nudSlotCount.Size = new Size(35, 23);
            nudSlotCount.TabIndex = 9;
            // 
            // lblServername
            // 
            lblServername.AutoSize = true;
            lblServername.ForeColor = SystemColors.ButtonHighlight;
            lblServername.Location = new Point(41, 44);
            lblServername.Name = "lblServername";
            lblServername.Size = new Size(69, 15);
            lblServername.TabIndex = 10;
            lblServername.Text = "Servername";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = SystemColors.ButtonHighlight;
            lblPassword.Location = new Point(53, 73);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 11;
            lblPassword.Text = "Password";
            // 
            // lblIpAddress
            // 
            lblIpAddress.AutoSize = true;
            lblIpAddress.ForeColor = SystemColors.ButtonHighlight;
            lblIpAddress.Location = new Point(48, 102);
            lblIpAddress.Name = "lblIpAddress";
            lblIpAddress.Size = new Size(62, 15);
            lblIpAddress.TabIndex = 12;
            lblIpAddress.Text = "Ip Address";
            // 
            // lblGamePort
            // 
            lblGamePort.AutoSize = true;
            lblGamePort.ForeColor = SystemColors.ButtonHighlight;
            lblGamePort.Location = new Point(50, 131);
            lblGamePort.Name = "lblGamePort";
            lblGamePort.Size = new Size(60, 15);
            lblGamePort.TabIndex = 13;
            lblGamePort.Text = "GamePort";
            // 
            // lblQueryPort
            // 
            lblQueryPort.AutoSize = true;
            lblQueryPort.ForeColor = SystemColors.ButtonHighlight;
            lblQueryPort.Location = new Point(49, 160);
            lblQueryPort.Name = "lblQueryPort";
            lblQueryPort.Size = new Size(61, 15);
            lblQueryPort.TabIndex = 14;
            lblQueryPort.Text = "QueryPort";
            // 
            // lblMaxPlayers
            // 
            lblMaxPlayers.AutoSize = true;
            lblMaxPlayers.Location = new Point(43, 189);
            lblMaxPlayers.Name = "lblMaxPlayers";
            lblMaxPlayers.Size = new Size(67, 15);
            lblMaxPlayers.TabIndex = 15;
            lblMaxPlayers.Text = "MaxPlayers";
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Cursor = Cursors.Hand;
            btnSaveSettings.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnSaveSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnSaveSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnSaveSettings.FlatStyle = FlatStyle.Flat;
            btnSaveSettings.ForeColor = Color.FromArgb(0, 255, 185);
            btnSaveSettings.Location = new Point(127, 243);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(124, 30);
            btnSaveSettings.TabIndex = 17;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseCompatibleTextRendering = true;
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.EnabledChanged += SaveSettings_Button_EnabledChanged;
            btnSaveSettings.Click += SaveSettings_Button_Click;
            // 
            // btnStartServer
            // 
            btnStartServer.Cursor = Cursors.Hand;
            btnStartServer.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnStartServer.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnStartServer.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnStartServer.FlatStyle = FlatStyle.Flat;
            btnStartServer.ForeColor = SystemColors.Control;
            btnStartServer.Location = new Point(33, 165);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(127, 25);
            btnStartServer.TabIndex = 1;
            btnStartServer.Text = "Start Server";
            btnStartServer.UseCompatibleTextRendering = true;
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Visible = false;
            btnStartServer.Click += StartServer_Button_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(0, 0, 18);
            pictureBox2.Dock = DockStyle.Left;
            pictureBox2.Location = new Point(10, 40);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(171, 390);
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // lblAdminPanel
            // 
            lblAdminPanel.BackColor = Color.Transparent;
            lblAdminPanel.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblAdminPanel.ForeColor = SystemColors.Control;
            lblAdminPanel.Location = new Point(16, 369);
            lblAdminPanel.Name = "lblAdminPanel";
            lblAdminPanel.Size = new Size(153, 32);
            lblAdminPanel.TabIndex = 23;
            lblAdminPanel.Text = "AdminPanel";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(64, 64, 64);
            lblTitle.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = SystemColors.Control;
            lblTitle.Location = new Point(6, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(414, 32);
            lblTitle.TabIndex = 24;
            lblTitle.Text = "ESM - Enshrouded Server Manager";
            lblTitle.MouseDown += FormHeader_MouseDown;
            // 
            // lblServerSettings
            // 
            lblServerSettings.AutoSize = true;
            lblServerSettings.BackColor = Color.Transparent;
            lblServerSettings.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblServerSettings.ForeColor = SystemColors.Control;
            lblServerSettings.Location = new Point(6, 305);
            lblServerSettings.Name = "lblServerSettings";
            lblServerSettings.Size = new Size(186, 32);
            lblServerSettings.TabIndex = 25;
            lblServerSettings.Text = "Server Settings";
            // 
            // lblCloseButton
            // 
            lblCloseButton.AutoSize = true;
            lblCloseButton.BackColor = Color.FromArgb(64, 64, 64);
            lblCloseButton.Cursor = Cursors.Hand;
            lblCloseButton.Font = new Font("Malgun Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblCloseButton.ForeColor = Color.FromArgb(0, 255, 185);
            lblCloseButton.Location = new Point(771, 9);
            lblCloseButton.Name = "lblCloseButton";
            lblCloseButton.Size = new Size(18, 19);
            lblCloseButton.TabIndex = 27;
            lblCloseButton.Text = "X";
            lblCloseButton.Click += lblCloseButton_Click;
            // 
            // lblMinimizeTrayButton
            // 
            lblMinimizeTrayButton.AutoSize = true;
            lblMinimizeTrayButton.BackColor = Color.FromArgb(64, 64, 64);
            lblMinimizeTrayButton.Cursor = Cursors.Hand;
            lblMinimizeTrayButton.Font = new Font("Malgun Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMinimizeTrayButton.ForeColor = Color.FromArgb(0, 255, 185);
            lblMinimizeTrayButton.Location = new Point(741, 6);
            lblMinimizeTrayButton.Name = "lblMinimizeTrayButton";
            lblMinimizeTrayButton.Size = new Size(17, 21);
            lblMinimizeTrayButton.TabIndex = 28;
            lblMinimizeTrayButton.Text = "_";
            lblMinimizeTrayButton.Click += lblMinimizeButton_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox5.Dock = DockStyle.Left;
            pictureBox5.Location = new Point(0, 40);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(10, 390);
            pictureBox5.TabIndex = 29;
            pictureBox5.TabStop = false;
            // 
            // lblNews
            // 
            lblNews.AutoSize = true;
            lblNews.BackColor = Color.Transparent;
            lblNews.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblNews.ForeColor = SystemColors.Control;
            lblNews.Location = new Point(572, 369);
            lblNews.Name = "lblNews";
            lblNews.Size = new Size(76, 32);
            lblNews.TabIndex = 30;
            lblNews.Text = "News";
            // 
            // pictureBox7
            // 
            pictureBox7.Anchor = AnchorStyles.Bottom;
            pictureBox7.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox7.Location = new Point(6, 409);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(790, 21);
            pictureBox7.TabIndex = 33;
            pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox6.Dock = DockStyle.Right;
            pictureBox6.Location = new Point(790, 40);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(10, 390);
            pictureBox6.TabIndex = 34;
            pictureBox6.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox8.Dock = DockStyle.Right;
            pictureBox8.Location = new Point(550, 40);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(10, 390);
            pictureBox8.TabIndex = 36;
            pictureBox8.TabStop = false;
            // 
            // pbxCreditsBorder
            // 
            pbxCreditsBorder.BackColor = Color.FromArgb(64, 64, 64);
            pbxCreditsBorder.Dock = DockStyle.Right;
            pbxCreditsBorder.Location = new Point(550, 40);
            pbxCreditsBorder.Name = "pbxCreditsBorder";
            pbxCreditsBorder.Size = new Size(10, 390);
            pbxCreditsBorder.TabIndex = 36;
            pbxCreditsBorder.TabStop = false;
            pbxCreditsBorder.Visible = false;
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox9.Dock = DockStyle.Left;
            pictureBox9.Location = new Point(181, 40);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(10, 390);
            pictureBox9.TabIndex = 37;
            pictureBox9.TabStop = false;
            // 
            // btnSaveBackup
            // 
            btnSaveBackup.Cursor = Cursors.Hand;
            btnSaveBackup.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnSaveBackup.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnSaveBackup.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnSaveBackup.FlatStyle = FlatStyle.Flat;
            btnSaveBackup.ForeColor = SystemColors.Control;
            btnSaveBackup.Location = new Point(33, 237);
            btnSaveBackup.Name = "btnSaveBackup";
            btnSaveBackup.Size = new Size(127, 25);
            btnSaveBackup.TabIndex = 4;
            btnSaveBackup.Text = "Save Backup";
            btnSaveBackup.UseCompatibleTextRendering = true;
            btnSaveBackup.UseVisualStyleBackColor = true;
            btnSaveBackup.Click += SaveBackup_Button_Click;
            // 
            // btnOpenBackupFolder
            // 
            btnOpenBackupFolder.Cursor = Cursors.Hand;
            btnOpenBackupFolder.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnOpenBackupFolder.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnOpenBackupFolder.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnOpenBackupFolder.FlatStyle = FlatStyle.Flat;
            btnOpenBackupFolder.ForeColor = SystemColors.Control;
            btnOpenBackupFolder.Location = new Point(33, 268);
            btnOpenBackupFolder.Name = "btnOpenBackupFolder";
            btnOpenBackupFolder.Size = new Size(127, 25);
            btnOpenBackupFolder.TabIndex = 5;
            btnOpenBackupFolder.Text = "Backup Folder";
            btnOpenBackupFolder.UseCompatibleTextRendering = true;
            btnOpenBackupFolder.UseVisualStyleBackColor = true;
            btnOpenBackupFolder.Click += OpenBackupFolder_Button_Click;
            // 
            // btnWindowsFirewall
            // 
            btnWindowsFirewall.Cursor = Cursors.Hand;
            btnWindowsFirewall.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnWindowsFirewall.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnWindowsFirewall.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnWindowsFirewall.FlatStyle = FlatStyle.Flat;
            btnWindowsFirewall.ForeColor = SystemColors.Control;
            btnWindowsFirewall.Location = new Point(33, 84);
            btnWindowsFirewall.Name = "btnWindowsFirewall";
            btnWindowsFirewall.Size = new Size(127, 24);
            btnWindowsFirewall.TabIndex = 40;
            btnWindowsFirewall.TabStop = false;
            btnWindowsFirewall.Text = "Windows Firewall";
            btnWindowsFirewall.UseVisualStyleBackColor = true;
            btnWindowsFirewall.Click += WindowsFirewall_Button_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(577, 168);
            label7.Name = "label7";
            label7.Size = new Size(0, 15);
            label7.TabIndex = 49;
            // 
            // lblServerProfileSpecific
            // 
            lblServerProfileSpecific.AutoSize = true;
            lblServerProfileSpecific.Location = new Point(32, 140);
            lblServerProfileSpecific.Name = "lblServerProfileSpecific";
            lblServerProfileSpecific.Size = new Size(129, 15);
            lblServerProfileSpecific.TabIndex = 42;
            lblServerProfileSpecific.Text = "\"Server Profile\" specific";
            // 
            // pictureBox10
            // 
            pictureBox10.BorderStyle = BorderStyle.FixedSingle;
            pictureBox10.Location = new Point(27, 148);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(140, 215);
            pictureBox10.TabIndex = 43;
            pictureBox10.TabStop = false;
            // 
            // btnOpenSavegameFolder
            // 
            btnOpenSavegameFolder.Cursor = Cursors.Hand;
            btnOpenSavegameFolder.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnOpenSavegameFolder.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnOpenSavegameFolder.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnOpenSavegameFolder.FlatStyle = FlatStyle.Flat;
            btnOpenSavegameFolder.ForeColor = SystemColors.Control;
            btnOpenSavegameFolder.Location = new Point(33, 299);
            btnOpenSavegameFolder.Name = "btnOpenSavegameFolder";
            btnOpenSavegameFolder.Size = new Size(127, 25);
            btnOpenSavegameFolder.TabIndex = 6;
            btnOpenSavegameFolder.Text = "Savegame Folder";
            btnOpenSavegameFolder.UseCompatibleTextRendering = true;
            btnOpenSavegameFolder.UseVisualStyleBackColor = true;
            btnOpenSavegameFolder.Click += OpenSavegameFolder_Button_Click;
            // 
            // btnOpenLogFolder
            // 
            btnOpenLogFolder.Cursor = Cursors.Hand;
            btnOpenLogFolder.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnOpenLogFolder.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnOpenLogFolder.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnOpenLogFolder.FlatStyle = FlatStyle.Flat;
            btnOpenLogFolder.ForeColor = SystemColors.Control;
            btnOpenLogFolder.Location = new Point(33, 330);
            btnOpenLogFolder.Name = "btnOpenLogFolder";
            btnOpenLogFolder.Size = new Size(127, 25);
            btnOpenLogFolder.TabIndex = 7;
            btnOpenLogFolder.Text = "Log Folder";
            btnOpenLogFolder.UseCompatibleTextRendering = true;
            btnOpenLogFolder.UseVisualStyleBackColor = true;
            btnOpenLogFolder.Click += OpenLogFolder_Button_Click;
            // 
            // btnUpdateServer
            // 
            btnUpdateServer.Cursor = Cursors.Hand;
            btnUpdateServer.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnUpdateServer.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnUpdateServer.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnUpdateServer.FlatStyle = FlatStyle.Flat;
            btnUpdateServer.ForeColor = SystemColors.Control;
            btnUpdateServer.Location = new Point(33, 196);
            btnUpdateServer.Name = "btnUpdateServer";
            btnUpdateServer.Size = new Size(127, 25);
            btnUpdateServer.TabIndex = 2;
            btnUpdateServer.Text = "Update Server";
            btnUpdateServer.UseCompatibleTextRendering = true;
            btnUpdateServer.UseVisualStyleBackColor = true;
            btnUpdateServer.Visible = false;
            btnUpdateServer.Click += UpdateServer_Button_Click;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Cursor = Cursors.Hand;
            lblLogo.Font = new Font("Malgun Gothic", 60F, FontStyle.Bold, GraphicsUnit.Point);
            lblLogo.ForeColor = Color.FromArgb(0, 204, 204);
            lblLogo.Location = new Point(574, 49);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(210, 106);
            lblLogo.TabIndex = 47;
            lblLogo.Text = "ESM";
            lblLogo.Click += GithubLabel_Click;
            // 
            // tabServerTabs
            // 
            tabServerTabs.Controls.Add(tabServerSettings);
            tabServerTabs.Controls.Add(tabProfileManager);
            tabServerTabs.Controls.Add(tabAutoBackup);
            tabServerTabs.Controls.Add(tabDiscord);
            tabServerTabs.Location = new Point(187, 84);
            tabServerTabs.Name = "tabServerTabs";
            tabServerTabs.SelectedIndex = 0;
            tabServerTabs.Size = new Size(367, 330);
            tabServerTabs.TabIndex = 48;
            tabServerTabs.SelectedIndexChanged += tabServerTabs_SelectedIndexChanged;
            // 
            // tabServerSettings
            // 
            tabServerSettings.BackColor = Color.FromArgb(0, 0, 18);
            tabServerSettings.Controls.Add(btnShowPassword);
            tabServerSettings.Controls.Add(txtIpAddress);
            tabServerSettings.Controls.Add(txtServerName);
            tabServerSettings.Controls.Add(txtServerPassword);
            tabServerSettings.Controls.Add(nudGamePort);
            tabServerSettings.Controls.Add(nudQueryPort);
            tabServerSettings.Controls.Add(nudSlotCount);
            tabServerSettings.Controls.Add(lblServername);
            tabServerSettings.Controls.Add(lblPassword);
            tabServerSettings.Controls.Add(lblIpAddress);
            tabServerSettings.Controls.Add(lblGamePort);
            tabServerSettings.Controls.Add(lblQueryPort);
            tabServerSettings.Controls.Add(lblMaxPlayers);
            tabServerSettings.Controls.Add(btnSaveSettings);
            tabServerSettings.Controls.Add(lblServerSettings);
            tabServerSettings.Location = new Point(4, 24);
            tabServerSettings.Name = "tabServerSettings";
            tabServerSettings.Padding = new Padding(3);
            tabServerSettings.Size = new Size(359, 302);
            tabServerSettings.TabIndex = 0;
            tabServerSettings.Text = "Server Settings";
            // 
            // btnShowPassword
            // 
            btnShowPassword.Cursor = Cursors.Hand;
            btnShowPassword.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnShowPassword.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnShowPassword.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnShowPassword.FlatStyle = FlatStyle.Flat;
            btnShowPassword.ForeColor = SystemColors.Control;
            btnShowPassword.Location = new Point(288, 70);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(48, 23);
            btnShowPassword.TabIndex = 26;
            btnShowPassword.Text = "Show";
            btnShowPassword.UseCompatibleTextRendering = true;
            btnShowPassword.UseVisualStyleBackColor = true;
            btnShowPassword.Click += btnShowPassword_Click;
            // 
            // tabProfileManager
            // 
            tabProfileManager.BackColor = Color.FromArgb(0, 0, 18);
            tabProfileManager.Controls.Add(lblAddNewProfile);
            tabProfileManager.Controls.Add(lblProfileManager);
            tabProfileManager.Controls.Add(pnlProfileNameUpdate);
            tabProfileManager.Controls.Add(btnDeleteProfile);
            tabProfileManager.Controls.Add(btnAddNewProfile);
            tabProfileManager.Controls.Add(lbxServerProfiles);
            tabProfileManager.Location = new Point(4, 24);
            tabProfileManager.Name = "tabProfileManager";
            tabProfileManager.Padding = new Padding(3);
            tabProfileManager.Size = new Size(359, 302);
            tabProfileManager.TabIndex = 1;
            tabProfileManager.Text = "Manage Profiles";
            // 
            // lblAddNewProfile
            // 
            lblAddNewProfile.AutoSize = true;
            lblAddNewProfile.Location = new Point(228, 20);
            lblAddNewProfile.Name = "lblAddNewProfile";
            lblAddNewProfile.Size = new Size(93, 15);
            lblAddNewProfile.TabIndex = 5;
            lblAddNewProfile.Text = "Add New Profile";
            // 
            // lblProfileManager
            // 
            lblProfileManager.AutoSize = true;
            lblProfileManager.BackColor = Color.Transparent;
            lblProfileManager.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblProfileManager.ForeColor = SystemColors.Control;
            lblProfileManager.Location = new Point(6, 305);
            lblProfileManager.Name = "lblProfileManager";
            lblProfileManager.Size = new Size(198, 32);
            lblProfileManager.TabIndex = 4;
            lblProfileManager.Text = "Profile Manager";
            // 
            // pnlProfileNameUpdate
            // 
            pnlProfileNameUpdate.BorderStyle = BorderStyle.FixedSingle;
            pnlProfileNameUpdate.Controls.Add(lblProfileNameInfo);
            pnlProfileNameUpdate.Controls.Add(btnSaveProfileName);
            pnlProfileNameUpdate.Controls.Add(txtEditProfileName);
            pnlProfileNameUpdate.Controls.Add(lblProfileNameInputHeading);
            pnlProfileNameUpdate.Location = new Point(187, 54);
            pnlProfileNameUpdate.Name = "pnlProfileNameUpdate";
            pnlProfileNameUpdate.Size = new Size(160, 160);
            pnlProfileNameUpdate.TabIndex = 3;
            // 
            // lblProfileNameInfo
            // 
            lblProfileNameInfo.AutoSize = true;
            lblProfileNameInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblProfileNameInfo.ForeColor = SystemColors.Info;
            lblProfileNameInfo.Location = new Point(9, 98);
            lblProfileNameInfo.Name = "lblProfileNameInfo";
            lblProfileNameInfo.Size = new Size(136, 51);
            lblProfileNameInfo.TabIndex = 5;
            lblProfileNameInfo.Text = "Only valid Windows\r\nFile System characters\r\nare allowed";
            // 
            // btnSaveProfileName
            // 
            btnSaveProfileName.Cursor = Cursors.Hand;
            btnSaveProfileName.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnSaveProfileName.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnSaveProfileName.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnSaveProfileName.FlatStyle = FlatStyle.Flat;
            btnSaveProfileName.ForeColor = Color.FromArgb(0, 255, 185);
            btnSaveProfileName.Location = new Point(16, 62);
            btnSaveProfileName.Name = "btnSaveProfileName";
            btnSaveProfileName.Size = new Size(128, 30);
            btnSaveProfileName.TabIndex = 3;
            btnSaveProfileName.Text = "Save Changes";
            btnSaveProfileName.UseCompatibleTextRendering = true;
            btnSaveProfileName.UseVisualStyleBackColor = true;
            btnSaveProfileName.EnabledChanged += SaveSettings_Button_EnabledChanged;
            btnSaveProfileName.Click += SaveProfileName_Button_Click;
            // 
            // txtEditProfileName
            // 
            txtEditProfileName.BackColor = Color.FromArgb(6, 6, 48);
            txtEditProfileName.BorderStyle = BorderStyle.FixedSingle;
            txtEditProfileName.ForeColor = SystemColors.Window;
            txtEditProfileName.Location = new Point(6, 28);
            txtEditProfileName.Name = "txtEditProfileName";
            txtEditProfileName.Size = new Size(146, 23);
            txtEditProfileName.TabIndex = 2;
            // 
            // lblProfileNameInputHeading
            // 
            lblProfileNameInputHeading.AutoSize = true;
            lblProfileNameInputHeading.Location = new Point(6, 10);
            lblProfileNameInputHeading.Name = "lblProfileNameInputHeading";
            lblProfileNameInputHeading.Size = new Size(76, 15);
            lblProfileNameInputHeading.TabIndex = 0;
            lblProfileNameInputHeading.Text = "Profile Name";
            // 
            // btnDeleteProfile
            // 
            btnDeleteProfile.BackColor = Color.Red;
            btnDeleteProfile.FlatAppearance.BorderColor = Color.Red;
            btnDeleteProfile.FlatStyle = FlatStyle.Popup;
            btnDeleteProfile.ForeColor = SystemColors.ControlLightLight;
            btnDeleteProfile.Location = new Point(204, 252);
            btnDeleteProfile.Name = "btnDeleteProfile";
            btnDeleteProfile.Size = new Size(127, 31);
            btnDeleteProfile.TabIndex = 4;
            btnDeleteProfile.Text = "Delete Selected";
            btnDeleteProfile.UseVisualStyleBackColor = false;
            btnDeleteProfile.Click += DeleteProfile_Button_Click;
            // 
            // btnAddNewProfile
            // 
            btnAddNewProfile.Anchor = AnchorStyles.None;
            btnAddNewProfile.BackgroundImageLayout = ImageLayout.None;
            btnAddNewProfile.Cursor = Cursors.Hand;
            btnAddNewProfile.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnAddNewProfile.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnAddNewProfile.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnAddNewProfile.FlatStyle = FlatStyle.Flat;
            btnAddNewProfile.Font = new Font("Consolas", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddNewProfile.ForeColor = Color.FromArgb(0, 255, 185);
            btnAddNewProfile.Location = new Point(187, 12);
            btnAddNewProfile.Margin = new Padding(0);
            btnAddNewProfile.Name = "btnAddNewProfile";
            btnAddNewProfile.Padding = new Padding(0, 2, 0, 0);
            btnAddNewProfile.Size = new Size(30, 30);
            btnAddNewProfile.TabIndex = 1;
            btnAddNewProfile.Text = "+";
            btnAddNewProfile.UseCompatibleTextRendering = true;
            btnAddNewProfile.UseVisualStyleBackColor = true;
            btnAddNewProfile.Click += AddNewProfile_Button_Click;
            // 
            // lbxServerProfiles
            // 
            lbxServerProfiles.BackColor = Color.FromArgb(0, 0, 28);
            lbxServerProfiles.BorderStyle = BorderStyle.FixedSingle;
            lbxServerProfiles.ForeColor = SystemColors.Window;
            lbxServerProfiles.FormattingEnabled = true;
            lbxServerProfiles.ItemHeight = 15;
            lbxServerProfiles.Location = new Point(10, 10);
            lbxServerProfiles.Name = "lbxServerProfiles";
            lbxServerProfiles.Size = new Size(166, 272);
            lbxServerProfiles.TabIndex = 0;
            lbxServerProfiles.SelectedIndexChanged += lbxServerProfiles_IndexChanged;
            // 
            // tabAutoBackup
            // 
            tabAutoBackup.BackColor = Color.FromArgb(0, 0, 18);
            tabAutoBackup.Controls.Add(lblAutoBackupChangesInfo);
            tabAutoBackup.Controls.Add(btnSaveAutoBackup);
            tabAutoBackup.Controls.Add(chkEnableBackups);
            tabAutoBackup.Controls.Add(lblProfileBackupsStats);
            tabAutoBackup.Controls.Add(lblProfileBackupsInstruction);
            tabAutoBackup.Controls.Add(nudBackupMaxCount);
            tabAutoBackup.Controls.Add(label2);
            tabAutoBackup.Controls.Add(lblBackupFrequency);
            tabAutoBackup.Controls.Add(nudBackupInterval);
            tabAutoBackup.Controls.Add(lblScheduleBackups);
            tabAutoBackup.Controls.Add(lbxProfileSelectorAutoBackup);
            tabAutoBackup.Location = new Point(4, 24);
            tabAutoBackup.Name = "tabAutoBackup";
            tabAutoBackup.Padding = new Padding(3);
            tabAutoBackup.Size = new Size(359, 302);
            tabAutoBackup.TabIndex = 2;
            tabAutoBackup.Text = "Auto Backup";
            // 
            // lblAutoBackupChangesInfo
            // 
            lblAutoBackupChangesInfo.AutoSize = true;
            lblAutoBackupChangesInfo.ForeColor = SystemColors.Info;
            lblAutoBackupChangesInfo.Location = new Point(202, 217);
            lblAutoBackupChangesInfo.Name = "lblAutoBackupChangesInfo";
            lblAutoBackupChangesInfo.Size = new Size(132, 30);
            lblAutoBackupChangesInfo.TabIndex = 16;
            lblAutoBackupChangesInfo.Text = "Changes will take effect\r\non the next server start";
            // 
            // btnSaveAutoBackup
            // 
            btnSaveAutoBackup.Cursor = Cursors.Hand;
            btnSaveAutoBackup.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnSaveAutoBackup.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnSaveAutoBackup.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnSaveAutoBackup.FlatStyle = FlatStyle.Flat;
            btnSaveAutoBackup.ForeColor = Color.FromArgb(0, 255, 185);
            btnSaveAutoBackup.Location = new Point(204, 252);
            btnSaveAutoBackup.Name = "btnSaveAutoBackup";
            btnSaveAutoBackup.Size = new Size(128, 30);
            btnSaveAutoBackup.TabIndex = 15;
            btnSaveAutoBackup.Text = "Save Changes";
            btnSaveAutoBackup.UseCompatibleTextRendering = true;
            btnSaveAutoBackup.UseVisualStyleBackColor = true;
            btnSaveAutoBackup.EnabledChanged += SaveSettings_Button_EnabledChanged;
            btnSaveAutoBackup.Click += btnSaveAutoBackup_Click;
            // 
            // chkEnableBackups
            // 
            chkEnableBackups.AutoSize = true;
            chkEnableBackups.Location = new Point(191, 74);
            chkEnableBackups.Name = "chkEnableBackups";
            chkEnableBackups.Size = new Size(108, 19);
            chkEnableBackups.TabIndex = 14;
            chkEnableBackups.Text = "Enable Backups";
            chkEnableBackups.UseVisualStyleBackColor = true;
            // 
            // lblProfileBackupsStats
            // 
            lblProfileBackupsStats.AutoSize = true;
            lblProfileBackupsStats.ForeColor = Color.FromArgb(0, 255, 185);
            lblProfileBackupsStats.Location = new Point(187, 31);
            lblProfileBackupsStats.Name = "lblProfileBackupsStats";
            lblProfileBackupsStats.Size = new Size(147, 30);
            lblProfileBackupsStats.TabIndex = 13;
            lblProfileBackupsStats.Text = "Total Backups: 12\r\nDisk Consumption: 200MB\r\n";
            lblProfileBackupsStats.Visible = false;
            // 
            // lblProfileBackupsInstruction
            // 
            lblProfileBackupsInstruction.AutoSize = true;
            lblProfileBackupsInstruction.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblProfileBackupsInstruction.ForeColor = SystemColors.ButtonHighlight;
            lblProfileBackupsInstruction.Location = new Point(187, 10);
            lblProfileBackupsInstruction.Name = "lblProfileBackupsInstruction";
            lblProfileBackupsInstruction.Size = new Size(169, 17);
            lblProfileBackupsInstruction.TabIndex = 11;
            lblProfileBackupsInstruction.Text = "Select a Profile to configure";
            // 
            // nudBackupMaxCount
            // 
            nudBackupMaxCount.BackColor = Color.FromArgb(6, 6, 48);
            nudBackupMaxCount.BorderStyle = BorderStyle.FixedSingle;
            nudBackupMaxCount.ForeColor = SystemColors.Window;
            nudBackupMaxCount.Location = new Point(191, 174);
            nudBackupMaxCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudBackupMaxCount.Name = "nudBackupMaxCount";
            nudBackupMaxCount.Size = new Size(63, 23);
            nudBackupMaxCount.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(187, 156);
            label2.Name = "label2";
            label2.Size = new Size(170, 15);
            label2.TabIndex = 9;
            label2.Text = "Maximum Number of Backups";
            // 
            // lblBackupFrequency
            // 
            lblBackupFrequency.AutoSize = true;
            lblBackupFrequency.Location = new Point(187, 105);
            lblBackupFrequency.Name = "lblBackupFrequency";
            lblBackupFrequency.Size = new Size(155, 15);
            lblBackupFrequency.TabIndex = 7;
            lblBackupFrequency.Text = "Backup Interval (in minutes)";
            // 
            // nudBackupInterval
            // 
            nudBackupInterval.BackColor = Color.FromArgb(6, 6, 48);
            nudBackupInterval.BorderStyle = BorderStyle.FixedSingle;
            nudBackupInterval.ForeColor = SystemColors.Window;
            nudBackupInterval.Location = new Point(191, 123);
            nudBackupInterval.Maximum = new decimal(new int[] { 1080, 0, 0, 0 });
            nudBackupInterval.Name = "nudBackupInterval";
            nudBackupInterval.Size = new Size(63, 23);
            nudBackupInterval.TabIndex = 6;
            // 
            // lblScheduleBackups
            // 
            lblScheduleBackups.AutoSize = true;
            lblScheduleBackups.BackColor = Color.Transparent;
            lblScheduleBackups.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblScheduleBackups.ForeColor = SystemColors.Control;
            lblScheduleBackups.Location = new Point(6, 305);
            lblScheduleBackups.Name = "lblScheduleBackups";
            lblScheduleBackups.Size = new Size(220, 32);
            lblScheduleBackups.TabIndex = 5;
            lblScheduleBackups.Text = "Schedule Backups";
            // 
            // lbxProfileSelectorAutoBackup
            // 
            lbxProfileSelectorAutoBackup.BackColor = Color.FromArgb(0, 0, 28);
            lbxProfileSelectorAutoBackup.BorderStyle = BorderStyle.FixedSingle;
            lbxProfileSelectorAutoBackup.ForeColor = SystemColors.Window;
            lbxProfileSelectorAutoBackup.FormattingEnabled = true;
            lbxProfileSelectorAutoBackup.ItemHeight = 15;
            lbxProfileSelectorAutoBackup.Location = new Point(10, 10);
            lbxProfileSelectorAutoBackup.Name = "lbxProfileSelectorAutoBackup";
            lbxProfileSelectorAutoBackup.Size = new Size(166, 272);
            lbxProfileSelectorAutoBackup.TabIndex = 1;
            lbxProfileSelectorAutoBackup.SelectedIndexChanged += lbxProfileSelectorAutoBackup_SelectedIndexChanged;
            // 
            // tabDiscord
            // 
            tabDiscord.BackColor = Color.FromArgb(0, 0, 18);
            tabDiscord.Controls.Add(lblDiscordChanges);
            tabDiscord.Controls.Add(gbxDiscordNotificationSettings);
            tabDiscord.Controls.Add(btnTestDiscord);
            tabDiscord.Controls.Add(lblDiscordWebhookUrl);
            tabDiscord.Controls.Add(btnSaveDiscordSettings);
            tabDiscord.Controls.Add(txtDiscordWebhookUrl);
            tabDiscord.Controls.Add(chkEnableDiscord);
            tabDiscord.Location = new Point(4, 24);
            tabDiscord.Name = "tabDiscord";
            tabDiscord.Size = new Size(359, 302);
            tabDiscord.TabIndex = 3;
            tabDiscord.Text = "Discord";
            // 
            // lblDiscordChanges
            // 
            lblDiscordChanges.AutoSize = true;
            lblDiscordChanges.ForeColor = SystemColors.Info;
            lblDiscordChanges.Location = new Point(51, 282);
            lblDiscordChanges.Name = "lblDiscordChanges";
            lblDiscordChanges.Size = new Size(258, 15);
            lblDiscordChanges.TabIndex = 69;
            lblDiscordChanges.Text = "Changes will take effect on the next server start ";
            // 
            // gbxDiscordNotificationSettings
            // 
            gbxDiscordNotificationSettings.Controls.Add(txtBackupMsg);
            gbxDiscordNotificationSettings.Controls.Add(txtServerUpdatingMsg);
            gbxDiscordNotificationSettings.Controls.Add(txtServerStoppedMsg);
            gbxDiscordNotificationSettings.Controls.Add(txtServerOnlineMsg);
            gbxDiscordNotificationSettings.Controls.Add(chkEmbed);
            gbxDiscordNotificationSettings.Controls.Add(chkNotifiBackup);
            gbxDiscordNotificationSettings.Controls.Add(chkNotifiServerUpdating);
            gbxDiscordNotificationSettings.Controls.Add(chkNotifiServerStopped);
            gbxDiscordNotificationSettings.Controls.Add(chkNotifiServerStarted);
            gbxDiscordNotificationSettings.ForeColor = SystemColors.ControlLight;
            gbxDiscordNotificationSettings.Location = new Point(19, 23);
            gbxDiscordNotificationSettings.Name = "gbxDiscordNotificationSettings";
            gbxDiscordNotificationSettings.Size = new Size(320, 170);
            gbxDiscordNotificationSettings.TabIndex = 68;
            gbxDiscordNotificationSettings.TabStop = false;
            gbxDiscordNotificationSettings.Text = "Notifications";
            // 
            // txtBackupMsg
            // 
            txtBackupMsg.BackColor = Color.FromArgb(6, 6, 48);
            txtBackupMsg.BorderStyle = BorderStyle.FixedSingle;
            txtBackupMsg.ForeColor = SystemColors.Window;
            txtBackupMsg.Location = new Point(127, 134);
            txtBackupMsg.Name = "txtBackupMsg";
            txtBackupMsg.Size = new Size(184, 23);
            txtBackupMsg.TabIndex = 71;
            txtBackupMsg.Text = "Backup created!";
            // 
            // txtServerUpdatingMsg
            // 
            txtServerUpdatingMsg.BackColor = Color.FromArgb(6, 6, 48);
            txtServerUpdatingMsg.BorderStyle = BorderStyle.FixedSingle;
            txtServerUpdatingMsg.ForeColor = SystemColors.Window;
            txtServerUpdatingMsg.Location = new Point(127, 105);
            txtServerUpdatingMsg.Name = "txtServerUpdatingMsg";
            txtServerUpdatingMsg.Size = new Size(184, 23);
            txtServerUpdatingMsg.TabIndex = 70;
            txtServerUpdatingMsg.Text = "Updating...";
            // 
            // txtServerStoppedMsg
            // 
            txtServerStoppedMsg.BackColor = Color.FromArgb(6, 6, 48);
            txtServerStoppedMsg.BorderStyle = BorderStyle.FixedSingle;
            txtServerStoppedMsg.ForeColor = SystemColors.Window;
            txtServerStoppedMsg.Location = new Point(127, 76);
            txtServerStoppedMsg.Name = "txtServerStoppedMsg";
            txtServerStoppedMsg.Size = new Size(184, 23);
            txtServerStoppedMsg.TabIndex = 69;
            txtServerStoppedMsg.Text = "Offline!";
            // 
            // txtServerOnlineMsg
            // 
            txtServerOnlineMsg.BackColor = Color.FromArgb(6, 6, 48);
            txtServerOnlineMsg.BorderStyle = BorderStyle.FixedSingle;
            txtServerOnlineMsg.ForeColor = SystemColors.Window;
            txtServerOnlineMsg.Location = new Point(127, 47);
            txtServerOnlineMsg.Name = "txtServerOnlineMsg";
            txtServerOnlineMsg.Size = new Size(184, 23);
            txtServerOnlineMsg.TabIndex = 68;
            txtServerOnlineMsg.Text = "Online!";
            // 
            // chkEmbed
            // 
            chkEmbed.AutoSize = true;
            chkEmbed.Location = new Point(12, 20);
            chkEmbed.Name = "chkEmbed";
            chkEmbed.Size = new Size(117, 19);
            chkEmbed.TabIndex = 67;
            chkEmbed.Text = "Embed Messages";
            chkEmbed.UseVisualStyleBackColor = true;
            // 
            // chkNotifiBackup
            // 
            chkNotifiBackup.AutoSize = true;
            chkNotifiBackup.Location = new Point(12, 137);
            chkNotifiBackup.Name = "chkNotifiBackup";
            chkNotifiBackup.Size = new Size(109, 19);
            chkNotifiBackup.TabIndex = 64;
            chkNotifiBackup.Text = "Backup Created";
            chkNotifiBackup.UseVisualStyleBackColor = true;
            // 
            // chkNotifiServerUpdating
            // 
            chkNotifiServerUpdating.AutoSize = true;
            chkNotifiServerUpdating.Location = new Point(12, 108);
            chkNotifiServerUpdating.Name = "chkNotifiServerUpdating";
            chkNotifiServerUpdating.Size = new Size(110, 19);
            chkNotifiServerUpdating.TabIndex = 63;
            chkNotifiServerUpdating.Text = "Server Updating";
            chkNotifiServerUpdating.UseVisualStyleBackColor = true;
            // 
            // chkNotifiServerStopped
            // 
            chkNotifiServerStopped.AutoSize = true;
            chkNotifiServerStopped.Location = new Point(12, 78);
            chkNotifiServerStopped.Name = "chkNotifiServerStopped";
            chkNotifiServerStopped.Size = new Size(105, 19);
            chkNotifiServerStopped.TabIndex = 62;
            chkNotifiServerStopped.Text = "Server Stopped";
            chkNotifiServerStopped.UseVisualStyleBackColor = true;
            // 
            // chkNotifiServerStarted
            // 
            chkNotifiServerStarted.AutoSize = true;
            chkNotifiServerStarted.Location = new Point(12, 49);
            chkNotifiServerStarted.Name = "chkNotifiServerStarted";
            chkNotifiServerStarted.Size = new Size(98, 19);
            chkNotifiServerStarted.TabIndex = 61;
            chkNotifiServerStarted.Text = "Server Started";
            chkNotifiServerStarted.UseVisualStyleBackColor = true;
            // 
            // btnTestDiscord
            // 
            btnTestDiscord.Cursor = Cursors.Hand;
            btnTestDiscord.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnTestDiscord.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnTestDiscord.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnTestDiscord.FlatStyle = FlatStyle.Flat;
            btnTestDiscord.ForeColor = SystemColors.Control;
            btnTestDiscord.Location = new Point(192, 248);
            btnTestDiscord.Name = "btnTestDiscord";
            btnTestDiscord.Size = new Size(127, 30);
            btnTestDiscord.TabIndex = 60;
            btnTestDiscord.Text = "Test Discord Msg";
            btnTestDiscord.UseCompatibleTextRendering = true;
            btnTestDiscord.UseVisualStyleBackColor = true;
            btnTestDiscord.Click += btnTestDiscord_Click;
            // 
            // lblDiscordWebhookUrl
            // 
            lblDiscordWebhookUrl.AutoSize = true;
            lblDiscordWebhookUrl.Location = new Point(114, 197);
            lblDiscordWebhookUrl.Name = "lblDiscordWebhookUrl";
            lblDiscordWebhookUrl.Size = new Size(128, 15);
            lblDiscordWebhookUrl.TabIndex = 18;
            lblDiscordWebhookUrl.Text = "Your Discord Webhook";
            // 
            // btnSaveDiscordSettings
            // 
            btnSaveDiscordSettings.Cursor = Cursors.Hand;
            btnSaveDiscordSettings.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnSaveDiscordSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnSaveDiscordSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnSaveDiscordSettings.FlatStyle = FlatStyle.Flat;
            btnSaveDiscordSettings.ForeColor = Color.FromArgb(0, 255, 185);
            btnSaveDiscordSettings.Location = new Point(43, 248);
            btnSaveDiscordSettings.Name = "btnSaveDiscordSettings";
            btnSaveDiscordSettings.Size = new Size(128, 30);
            btnSaveDiscordSettings.TabIndex = 17;
            btnSaveDiscordSettings.Text = "Save Changes";
            btnSaveDiscordSettings.UseCompatibleTextRendering = true;
            btnSaveDiscordSettings.UseVisualStyleBackColor = true;
            btnSaveDiscordSettings.EnabledChanged += SaveSettings_Button_EnabledChanged;
            btnSaveDiscordSettings.Click += btnSaveDiscordSettings_Click;
            // 
            // txtDiscordWebhookUrl
            // 
            txtDiscordWebhookUrl.BackColor = Color.FromArgb(6, 6, 48);
            txtDiscordWebhookUrl.BorderStyle = BorderStyle.FixedSingle;
            txtDiscordWebhookUrl.ForeColor = SystemColors.Window;
            txtDiscordWebhookUrl.Location = new Point(20, 217);
            txtDiscordWebhookUrl.Name = "txtDiscordWebhookUrl";
            txtDiscordWebhookUrl.Size = new Size(320, 23);
            txtDiscordWebhookUrl.TabIndex = 16;
            // 
            // chkEnableDiscord
            // 
            chkEnableDiscord.AutoSize = true;
            chkEnableDiscord.Location = new Point(99, 8);
            chkEnableDiscord.Name = "chkEnableDiscord";
            chkEnableDiscord.Size = new Size(175, 19);
            chkEnableDiscord.TabIndex = 15;
            chkEnableDiscord.Text = "Enable Discord Notifications";
            chkEnableDiscord.UseVisualStyleBackColor = true;
            // 
            // lblNewsText
            // 
            lblNewsText.AutoSize = true;
            lblNewsText.Location = new Point(567, 155);
            lblNewsText.Name = "lblNewsText";
            lblNewsText.Size = new Size(217, 195);
            lblNewsText.TabIndex = 53;
            lblNewsText.Text = resources.GetString("lblNewsText.Text");
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.BackColor = Color.FromArgb(64, 64, 64);
            lblVersion.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            lblVersion.ForeColor = Color.FromArgb(0, 204, 204);
            lblVersion.Location = new Point(8, 413);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(39, 13);
            lblVersion.TabIndex = 55;
            lblVersion.Text = "v.0.4.1";
            // 
            // GithubLabel
            // 
            GithubLabel.AutoSize = true;
            GithubLabel.Cursor = Cursors.Hand;
            GithubLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            GithubLabel.Location = new Point(741, 383);
            GithubLabel.Name = "GithubLabel";
            GithubLabel.Size = new Size(45, 15);
            GithubLabel.TabIndex = 56;
            GithubLabel.Text = "Github";
            GithubLabel.Click += GithubLabel_Click;
            // 
            // lblNewVersionAvailableNotification
            // 
            lblNewVersionAvailableNotification.AutoSize = true;
            lblNewVersionAvailableNotification.BackColor = Color.Transparent;
            lblNewVersionAvailableNotification.ForeColor = Color.FromArgb(0, 255, 185);
            lblNewVersionAvailableNotification.Location = new Point(660, 368);
            lblNewVersionAvailableNotification.Name = "lblNewVersionAvailableNotification";
            lblNewVersionAvailableNotification.Size = new Size(124, 15);
            lblNewVersionAvailableNotification.TabIndex = 57;
            lblNewVersionAvailableNotification.Text = "New version available!";
            lblNewVersionAvailableNotification.Visible = false;
            // 
            // pnlBackupExplanation
            // 
            pnlBackupExplanation.Controls.Add(btnOpenAutobackupFolder);
            pnlBackupExplanation.Controls.Add(label3);
            pnlBackupExplanation.Controls.Add(pictureBox4);
            pnlBackupExplanation.Controls.Add(label1);
            pnlBackupExplanation.Location = new Point(753, 413);
            pnlBackupExplanation.Name = "pnlBackupExplanation";
            pnlBackupExplanation.Size = new Size(241, 369);
            pnlBackupExplanation.TabIndex = 58;
            pnlBackupExplanation.Visible = false;
            // 
            // btnOpenAutobackupFolder
            // 
            btnOpenAutobackupFolder.Cursor = Cursors.Hand;
            btnOpenAutobackupFolder.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnOpenAutobackupFolder.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnOpenAutobackupFolder.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnOpenAutobackupFolder.FlatStyle = FlatStyle.Flat;
            btnOpenAutobackupFolder.ForeColor = SystemColors.Control;
            btnOpenAutobackupFolder.Location = new Point(55, 320);
            btnOpenAutobackupFolder.Name = "btnOpenAutobackupFolder";
            btnOpenAutobackupFolder.Size = new Size(128, 30);
            btnOpenAutobackupFolder.TabIndex = 16;
            btnOpenAutobackupFolder.Text = "Autobackup Folder";
            btnOpenAutobackupFolder.UseCompatibleTextRendering = true;
            btnOpenAutobackupFolder.UseVisualStyleBackColor = true;
            btnOpenAutobackupFolder.Click += btnOpenAutobackupFolder_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Malgun Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(34, 93);
            label3.Name = "label3";
            label3.Size = new Size(166, 21);
            label3.TabIndex = 26;
            label3.Text = "How Backups Work...";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.White;
            pictureBox4.Location = new Point(0, 66);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(239, 2);
            pictureBox4.TabIndex = 25;
            pictureBox4.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Info;
            label1.Location = new Point(34, 125);
            label1.Name = "label1";
            label1.Size = new Size(199, 180);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            // 
            // pnlCredits
            // 
            pnlCredits.Controls.Add(lblCreditsSponsorsList);
            pnlCredits.Controls.Add(lblCreditsSupportedBy);
            pnlCredits.Controls.Add(btnCreditsClose);
            pnlCredits.Controls.Add(lblCreditsLogo);
            pnlCredits.Controls.Add(lblHeadingSpecialThanks);
            pnlCredits.Controls.Add(lblHeadingMadeBy);
            pnlCredits.Controls.Add(lblCreditsContributors);
            pnlCredits.Controls.Add(lblCreditsMadeBy);
            pnlCredits.Location = new Point(753, 413);
            pnlCredits.Name = "pnlCredits";
            pnlCredits.Size = new Size(230, 369);
            pnlCredits.TabIndex = 61;
            pnlCredits.Visible = false;
            // 
            // lblCreditsSponsorsList
            // 
            lblCreditsSponsorsList.Font = new Font("Malgun Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblCreditsSponsorsList.Location = new Point(14, 295);
            lblCreditsSponsorsList.Name = "lblCreditsSponsorsList";
            lblCreditsSponsorsList.Size = new Size(155, 26);
            lblCreditsSponsorsList.TabIndex = 50;
            lblCreditsSponsorsList.Text = "FreeFun";
            // 
            // lblCreditsSupportedBy
            // 
            lblCreditsSupportedBy.Font = new Font("Malgun Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCreditsSupportedBy.Location = new Point(14, 268);
            lblCreditsSupportedBy.Name = "lblCreditsSupportedBy";
            lblCreditsSupportedBy.Size = new Size(155, 27);
            lblCreditsSupportedBy.TabIndex = 49;
            lblCreditsSupportedBy.Text = "Sponsored By:";
            // 
            // btnCreditsClose
            // 
            btnCreditsClose.AutoSize = true;
            btnCreditsClose.BackColor = Color.Transparent;
            btnCreditsClose.Cursor = Cursors.Hand;
            btnCreditsClose.Font = new Font("Malgun Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnCreditsClose.ForeColor = Color.FromArgb(0, 255, 185);
            btnCreditsClose.Location = new Point(206, 4);
            btnCreditsClose.Name = "btnCreditsClose";
            btnCreditsClose.Size = new Size(18, 19);
            btnCreditsClose.TabIndex = 28;
            btnCreditsClose.Text = "X";
            btnCreditsClose.Click += btnToggleCredits_Click;
            // 
            // lblCreditsLogo
            // 
            lblCreditsLogo.AutoSize = true;
            lblCreditsLogo.BackColor = Color.Transparent;
            lblCreditsLogo.Cursor = Cursors.Hand;
            lblCreditsLogo.Font = new Font("Malgun Gothic", 60F, FontStyle.Bold, GraphicsUnit.Point);
            lblCreditsLogo.ForeColor = Color.FromArgb(0, 204, 204);
            lblCreditsLogo.Location = new Point(14, 9);
            lblCreditsLogo.Name = "lblCreditsLogo";
            lblCreditsLogo.Size = new Size(210, 106);
            lblCreditsLogo.TabIndex = 48;
            lblCreditsLogo.Text = "ESM";
            // 
            // lblHeadingSpecialThanks
            // 
            lblHeadingSpecialThanks.Font = new Font("Malgun Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeadingSpecialThanks.Location = new Point(14, 202);
            lblHeadingSpecialThanks.Name = "lblHeadingSpecialThanks";
            lblHeadingSpecialThanks.Size = new Size(155, 27);
            lblHeadingSpecialThanks.TabIndex = 34;
            lblHeadingSpecialThanks.Text = "Special Thanks to:";
            // 
            // lblHeadingMadeBy
            // 
            lblHeadingMadeBy.Font = new Font("Malgun Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeadingMadeBy.Location = new Point(14, 114);
            lblHeadingMadeBy.Name = "lblHeadingMadeBy";
            lblHeadingMadeBy.Size = new Size(155, 27);
            lblHeadingMadeBy.TabIndex = 33;
            lblHeadingMadeBy.Text = "Made By:";
            // 
            // lblCreditsContributors
            // 
            lblCreditsContributors.Font = new Font("Malgun Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblCreditsContributors.Location = new Point(14, 229);
            lblCreditsContributors.Name = "lblCreditsContributors";
            lblCreditsContributors.Size = new Size(155, 26);
            lblCreditsContributors.TabIndex = 32;
            lblCreditsContributors.Text = "Strew/Evorin";
            // 
            // lblCreditsMadeBy
            // 
            lblCreditsMadeBy.Font = new Font("Malgun Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblCreditsMadeBy.Location = new Point(14, 141);
            lblCreditsMadeBy.Name = "lblCreditsMadeBy";
            lblCreditsMadeBy.Size = new Size(155, 46);
            lblCreditsMadeBy.TabIndex = 31;
            lblCreditsMadeBy.Text = "Spaik\r\nCrazyloon\r\n\r\n";
            // 
            // btnStopServer
            // 
            btnStopServer.Cursor = Cursors.Hand;
            btnStopServer.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
            btnStopServer.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
            btnStopServer.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
            btnStopServer.FlatStyle = FlatStyle.Flat;
            btnStopServer.ForeColor = SystemColors.Control;
            btnStopServer.Location = new Point(33, 165);
            btnStopServer.Name = "btnStopServer";
            btnStopServer.Size = new Size(127, 25);
            btnStopServer.TabIndex = 59;
            btnStopServer.Text = "Stop Server";
            btnStopServer.UseCompatibleTextRendering = true;
            btnStopServer.UseVisualStyleBackColor = true;
            btnStopServer.Visible = false;
            btnStopServer.Click += btnStopServer_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 18);
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Location = new Point(560, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(230, 390);
            pictureBox1.TabIndex = 35;
            pictureBox1.TabStop = false;
            // 
            // pbxFormHeader
            // 
            pbxFormHeader.BackColor = Color.FromArgb(64, 64, 64);
            pbxFormHeader.Dock = DockStyle.Top;
            pbxFormHeader.Location = new Point(0, 0);
            pbxFormHeader.Name = "pbxFormHeader";
            pbxFormHeader.Size = new Size(800, 40);
            pbxFormHeader.TabIndex = 22;
            pbxFormHeader.TabStop = false;
            pbxFormHeader.MouseDown += FormHeader_MouseDown;
            // 
            // btnOpenCredits
            // 
            btnOpenCredits.AutoSize = true;
            btnOpenCredits.BackColor = Color.FromArgb(64, 64, 64);
            btnOpenCredits.Cursor = Cursors.Hand;
            btnOpenCredits.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            btnOpenCredits.ForeColor = Color.FromArgb(0, 255, 185);
            btnOpenCredits.Location = new Point(750, 413);
            btnOpenCredits.Name = "btnOpenCredits";
            btnOpenCredits.Size = new Size(43, 13);
            btnOpenCredits.TabIndex = 60;
            btnOpenCredits.Text = "Credits";
            btnOpenCredits.TextAlign = ContentAlignment.BottomLeft;
            btnOpenCredits.Click += btnToggleCredits_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 18);
            ClientSize = new Size(800, 430);
            Controls.Add(btnOpenCredits);
            Controls.Add(lblServerProfileSpecific);
            Controls.Add(pnlCredits);
            Controls.Add(pnlBackupExplanation);
            Controls.Add(cbxProfileSelectionComboBox);
            Controls.Add(lblVersion);
            Controls.Add(lblProfileSelectionLabel);
            Controls.Add(pictureBox7);
            Controls.Add(lblNewVersionAvailableNotification);
            Controls.Add(btnStopServer);
            Controls.Add(GithubLabel);
            Controls.Add(pictureBox9);
            Controls.Add(pictureBox8);
            Controls.Add(btnOpenLogFolder);
            Controls.Add(btnOpenSavegameFolder);
            Controls.Add(btnOpenBackupFolder);
            Controls.Add(btnUpdateServer);
            Controls.Add(btnInstallServer);
            Controls.Add(btnSaveBackup);
            Controls.Add(btnStartServer);
            Controls.Add(pictureBox10);
            Controls.Add(lblAdminPanel);
            Controls.Add(btnWindowsFirewall);
            Controls.Add(btnInstallSteamCMD);
            Controls.Add(lblNewsText);
            Controls.Add(lblNews);
            Controls.Add(lblLogo);
            Controls.Add(tabServerTabs);
            Controls.Add(label7);
            Controls.Add(pictureBox1);
            Controls.Add(lblMinimizeTrayButton);
            Controls.Add(lblCloseButton);
            Controls.Add(lblTitle);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox6);
            Controls.Add(pbxFormHeader);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "ESM - Enshrouded Server Manager";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nudGamePort).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQueryPort).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSlotCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCreditsBorder).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            tabServerTabs.ResumeLayout(false);
            tabServerSettings.ResumeLayout(false);
            tabServerSettings.PerformLayout();
            tabProfileManager.ResumeLayout(false);
            tabProfileManager.PerformLayout();
            pnlProfileNameUpdate.ResumeLayout(false);
            pnlProfileNameUpdate.PerformLayout();
            tabAutoBackup.ResumeLayout(false);
            tabAutoBackup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudBackupMaxCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudBackupInterval).EndInit();
            tabDiscord.ResumeLayout(false);
            tabDiscord.PerformLayout();
            gbxDiscordNotificationSettings.ResumeLayout(false);
            gbxDiscordNotificationSettings.PerformLayout();
            pnlBackupExplanation.ResumeLayout(false);
            pnlBackupExplanation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            pnlCredits.ResumeLayout(false);
            pnlCredits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxFormHeader).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbxProfileSelectionComboBox;
        private Label lblProfileSelectionLabel;
        private Button btnInstallSteamCMD;
        private Button btnInstallServer;
        private TextBox txtServerName;
        private TextBox txtServerPassword;
        private TextBox txtIpAddress;
        private NumericUpDown nudGamePort;
        private NumericUpDown nudQueryPort;
        private NumericUpDown nudSlotCount;
        private Label lblServername;
        private Label lblPassword;
        private Label lblIpAddress;
        private Label lblGamePort;
        private Label lblQueryPort;
        private Label lblMaxPlayers;
        private Button btnSaveSettings;
        private Button btnStartServer;
        private PictureBox pictureBox2;
        private Label lblAdminPanel;
        private Label lblTitle;
        private Label lblServerSettings;
        private Label lblCloseButton;
        private Label lblMinimizeTrayButton;
        private PictureBox pictureBox5;
        private Label lblNews;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox pbxCreditsBorder;
        private Button btnSaveBackup;
        private Button btnOpenBackupFolder;
        private Button btnWindowsFirewall;
        private Label label7;
        private Label lblServerProfileSpecific;
        private PictureBox pictureBox10;
        private Button btnOpenSavegameFolder;
        private Button btnOpenLogFolder;
        private Button btnUpdateServer;
        private TabControl tabServerTabs;
        private TabPage tabServerSettings;
        private TabPage tabProfileManager;
        private Button btnAddNewProfile;
        private ListBox lbxServerProfiles;
        private Button btnDeleteProfile;
        private Label lblProfileManager;
        private Panel pnlProfileNameUpdate;
        private Button btnSaveProfileName;
        private TextBox txtEditProfileName;
        private Label lblProfileNameInputHeading;
        private Label lblProfileNameInfo;
        private Label lblLogo;
        private Label lblNewsText;
        private Label lblAddNewProfile;
        private Button btnShowPassword;
        private Label lblVersion;
        private Label GithubLabel;
        private Label lblNewVersionAvailableNotification;
        private TabPage tabAutoBackup;
        private Label lblScheduleBackups;
        private ListBox lbxProfileSelectorAutoBackup;
        private Label lblBackupFrequency;
        private NumericUpDown nudBackupInterval;
        private NumericUpDown nudBackupMaxCount;
        private Label label2;
        private Label lblProfileBackupsInstruction;
        private Label lblProfileBackupsStats;
        private CheckBox chkEnableBackups;
        private Panel pnlBackupExplanation;
        private Label lblBackupInfo;
        private Label label1;
        private PictureBox pictureBox4;
        private Label label3;
        private Button btnStopServer;
        private Button btnSaveAutoBackup;
        private Button btnOpenAutobackupFolder;
        private Label lblAutoBackupChangesInfo;
        private PictureBox pictureBox1;
        private PictureBox pbxFormHeader;
        private TabPage tabDiscord;
        private Label lblDiscordWebhookUrl;
        private Button btnSaveDiscordSettings;
        private TextBox txtDiscordWebhookUrl;
        private CheckBox chkEnableDiscord;
        private Button btnTestDiscord;
        private CheckBox chkNotifiBackup;
        private CheckBox chkNotifiServerUpdating;
        private CheckBox chkNotifiServerStopped;
        private CheckBox chkNotifiServerStarted;
        private CheckBox chkEmbed;
        private Label btnOpenCredits;
        private Panel pnlCredits;
        private Label btnCreditsClose;
        private Label lblCreditsMadeBy;
        private Label lblCreditsContributors;
        private Label lblHeadingSpecialThanks;
        private Label lblHeadingMadeBy;
        private Label lblCreditsLogo;
        private Label lblCreditsSupportedBy;
        private Label lblCreditsSponsorsList;
        private Label lblDiscordChanges;
        private GroupBox gbxDiscordNotificationSettings;
        private TextBox txtBackupMsg;
        private TextBox txtServerUpdatingMsg;
        private TextBox txtServerStoppedMsg;
        private TextBox txtServerOnlineMsg;
    }
}
