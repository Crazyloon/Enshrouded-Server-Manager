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
            pictureBox3 = new PictureBox();
            lblAdminPanel = new Label();
            lblTitle = new Label();
            lblServerSettings = new Label();
            lblCloseButton = new Label();
            lblMinimizeTrayButton = new Label();
            pictureBox5 = new PictureBox();
            lblNews = new Label();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox8 = new PictureBox();
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
            lblNewsText = new Label();
            lblCredits = new Label();
            VersionLabel = new Label();
            GithubLabel = new Label();
            NewVersionLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)nudGamePort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQueryPort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSlotCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            tabServerTabs.SuspendLayout();
            tabServerSettings.SuspendLayout();
            tabProfileManager.SuspendLayout();
            pnlProfileNameUpdate.SuspendLayout();
            SuspendLayout();
            // 
            // cbxProfileSelectionComboBox
            // 
            cbxProfileSelectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxProfileSelectionComboBox.FlatStyle = FlatStyle.System;
            cbxProfileSelectionComboBox.FormattingEnabled = true;
            cbxProfileSelectionComboBox.Location = new Point(112, 34);
            cbxProfileSelectionComboBox.Name = "cbxProfileSelectionComboBox";
            cbxProfileSelectionComboBox.Size = new Size(170, 23);
            cbxProfileSelectionComboBox.TabIndex = 0;
            cbxProfileSelectionComboBox.SelectedIndexChanged += ServerProfileComboBox_IndexChanged;
            // 
            // lblProfileSelectionLabel
            // 
            lblProfileSelectionLabel.AutoSize = true;
            lblProfileSelectionLabel.Location = new Point(34, 37);
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
            btnInstallServer.Location = new Point(34, 196);
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
            txtServerName.Location = new Point(112, 78);
            txtServerName.Name = "txtServerName";
            txtServerName.Size = new Size(170, 23);
            txtServerName.TabIndex = 4;
            // 
            // txtServerPassword
            // 
            txtServerPassword.BackColor = Color.FromArgb(6, 6, 48);
            txtServerPassword.BorderStyle = BorderStyle.FixedSingle;
            txtServerPassword.ForeColor = SystemColors.Window;
            txtServerPassword.Location = new Point(112, 107);
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
            txtIpAddress.Location = new Point(112, 136);
            txtIpAddress.Name = "txtIpAddress";
            txtIpAddress.Size = new Size(134, 23);
            txtIpAddress.TabIndex = 6;
            // 
            // nudGamePort
            // 
            nudGamePort.BackColor = Color.FromArgb(6, 6, 48);
            nudGamePort.BorderStyle = BorderStyle.FixedSingle;
            nudGamePort.ForeColor = SystemColors.Window;
            nudGamePort.Location = new Point(112, 166);
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
            nudQueryPort.Location = new Point(112, 195);
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
            nudSlotCount.Location = new Point(112, 224);
            nudSlotCount.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            nudSlotCount.Name = "nudSlotCount";
            nudSlotCount.Size = new Size(35, 23);
            nudSlotCount.TabIndex = 9;
            // 
            // lblServername
            // 
            lblServername.AutoSize = true;
            lblServername.ForeColor = SystemColors.ButtonHighlight;
            lblServername.Location = new Point(41, 81);
            lblServername.Name = "lblServername";
            lblServername.Size = new Size(69, 15);
            lblServername.TabIndex = 10;
            lblServername.Text = "Servername";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = SystemColors.ButtonHighlight;
            lblPassword.Location = new Point(53, 110);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 11;
            lblPassword.Text = "Password";
            // 
            // lblIpAddress
            // 
            lblIpAddress.AutoSize = true;
            lblIpAddress.ForeColor = SystemColors.ButtonHighlight;
            lblIpAddress.Location = new Point(48, 139);
            lblIpAddress.Name = "lblIpAddress";
            lblIpAddress.Size = new Size(62, 15);
            lblIpAddress.TabIndex = 12;
            lblIpAddress.Text = "Ip Address";
            // 
            // lblGamePort
            // 
            lblGamePort.AutoSize = true;
            lblGamePort.ForeColor = SystemColors.ButtonHighlight;
            lblGamePort.Location = new Point(50, 168);
            lblGamePort.Name = "lblGamePort";
            lblGamePort.Size = new Size(60, 15);
            lblGamePort.TabIndex = 13;
            lblGamePort.Text = "GamePort";
            // 
            // lblQueryPort
            // 
            lblQueryPort.AutoSize = true;
            lblQueryPort.ForeColor = SystemColors.ButtonHighlight;
            lblQueryPort.Location = new Point(49, 197);
            lblQueryPort.Name = "lblQueryPort";
            lblQueryPort.Size = new Size(61, 15);
            lblQueryPort.TabIndex = 14;
            lblQueryPort.Text = "QueryPort";
            // 
            // lblMaxPlayers
            // 
            lblMaxPlayers.AutoSize = true;
            lblMaxPlayers.Location = new Point(43, 226);
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
            btnSaveSettings.Location = new Point(127, 266);
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
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(64, 64, 64);
            pictureBox3.Dock = DockStyle.Top;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(800, 40);
            pictureBox3.TabIndex = 22;
            pictureBox3.TabStop = false;
            pictureBox3.MouseDown += pictureBox3_MouseDown;
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
            lblTitle.MouseDown += pictureBox3_MouseDown;
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
            lblCloseButton.Font = new Font("Malgun Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblCloseButton.ForeColor = Color.FromArgb(0, 255, 185);
            lblCloseButton.Location = new Point(771, 9);
            lblCloseButton.Name = "lblCloseButton";
            lblCloseButton.Size = new Size(18, 19);
            lblCloseButton.TabIndex = 27;
            lblCloseButton.Text = "X";
            lblCloseButton.Click += label4_Click;
            // 
            // lblMinimizeTrayButton
            // 
            lblMinimizeTrayButton.AutoSize = true;
            lblMinimizeTrayButton.BackColor = Color.FromArgb(64, 64, 64);
            lblMinimizeTrayButton.Font = new Font("Malgun Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMinimizeTrayButton.ForeColor = Color.FromArgb(0, 255, 185);
            lblMinimizeTrayButton.Location = new Point(741, 6);
            lblMinimizeTrayButton.Name = "lblMinimizeTrayButton";
            lblMinimizeTrayButton.Size = new Size(17, 21);
            lblMinimizeTrayButton.TabIndex = 28;
            lblMinimizeTrayButton.Text = "_";
            lblMinimizeTrayButton.Click += label5_Click;
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
            lblServerProfileSpecific.Location = new Point(30, 133);
            lblServerProfileSpecific.Name = "lblServerProfileSpecific";
            lblServerProfileSpecific.Size = new Size(129, 15);
            lblServerProfileSpecific.TabIndex = 42;
            lblServerProfileSpecific.Text = "\"Server Profile\" specific";
            // 
            // pictureBox10
            // 
            pictureBox10.BorderStyle = BorderStyle.FixedSingle;
            pictureBox10.Location = new Point(27, 158);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(140, 205);
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
            btnUpdateServer.Location = new Point(34, 196);
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
            lblLogo.Font = new Font("Malgun Gothic", 60F, FontStyle.Bold, GraphicsUnit.Point);
            lblLogo.ForeColor = Color.FromArgb(0, 204, 204);
            lblLogo.Location = new Point(574, 49);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(210, 106);
            lblLogo.TabIndex = 47;
            lblLogo.Text = "ESM";
            // 
            // tabServerTabs
            // 
            tabServerTabs.Controls.Add(tabServerSettings);
            tabServerTabs.Controls.Add(tabProfileManager);
            tabServerTabs.Location = new Point(187, 40);
            tabServerTabs.Name = "tabServerTabs";
            tabServerTabs.SelectedIndex = 0;
            tabServerTabs.Size = new Size(367, 374);
            tabServerTabs.TabIndex = 48;
            // 
            // tabServerSettings
            // 
            tabServerSettings.BackColor = Color.FromArgb(0, 0, 18);
            tabServerSettings.Controls.Add(btnShowPassword);
            tabServerSettings.Controls.Add(txtIpAddress);
            tabServerSettings.Controls.Add(cbxProfileSelectionComboBox);
            tabServerSettings.Controls.Add(lblProfileSelectionLabel);
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
            tabServerSettings.Size = new Size(359, 346);
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
            btnShowPassword.Location = new Point(288, 107);
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
            tabProfileManager.Size = new Size(359, 346);
            tabProfileManager.TabIndex = 1;
            tabProfileManager.Text = "Manage Profiles";
            // 
            // lblAddNewProfile
            // 
            lblAddNewProfile.AutoSize = true;
            lblAddNewProfile.Location = new Point(225, 19);
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
            pnlProfileNameUpdate.Location = new Point(187, 74);
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
            lblProfileNameInfo.Size = new Size(140, 51);
            lblProfileNameInfo.TabIndex = 5;
            lblProfileNameInfo.Text = "Only alphanumeric\r\nunderscore and dash\r\ncharacters are allowed";
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
            btnAddNewProfile.Location = new Point(187, 10);
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
            lbxServerProfiles.SelectedIndexChanged += ServerProfilesListBox_IndexChanged;
            // 
            // lblNewsText
            // 
            lblNewsText.AutoSize = true;
            lblNewsText.Location = new Point(584, 181);
            lblNewsText.Name = "lblNewsText";
            lblNewsText.Size = new Size(177, 105);
            lblNewsText.TabIndex = 53;
            lblNewsText.Text = "Changes:\r\n- Version Check of the Manager\r\n- Github-Link\r\n- SteamCMD.zip will be deleted \r\n   now after install\r\n- Update interval added\r\n- at SteamCMD install it updates";
            // 
            // lblCredits
            // 
            lblCredits.AutoSize = true;
            lblCredits.BackColor = Color.FromArgb(64, 64, 64);
            lblCredits.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            lblCredits.ForeColor = Color.FromArgb(0, 204, 204);
            lblCredits.Location = new Point(10, 413);
            lblCredits.Name = "lblCredits";
            lblCredits.Size = new Size(211, 13);
            lblCredits.TabIndex = 54;
            lblCredits.Text = "Credits to Strew / Evorin and Crazyloon";
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.BackColor = Color.FromArgb(64, 64, 64);
            VersionLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            VersionLabel.ForeColor = Color.FromArgb(0, 204, 204);
            VersionLabel.Location = new Point(751, 413);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(39, 13);
            VersionLabel.TabIndex = 55;
            VersionLabel.Text = "v.0.1.1";
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
            // NewVersionLabel
            // 
            NewVersionLabel.AutoSize = true;
            NewVersionLabel.ForeColor = Color.FromArgb(0, 255, 185);
            NewVersionLabel.Location = new Point(662, 368);
            NewVersionLabel.Name = "NewVersionLabel";
            NewVersionLabel.Size = new Size(124, 15);
            NewVersionLabel.TabIndex = 57;
            NewVersionLabel.Text = "New version available!";
            NewVersionLabel.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 18);
            ClientSize = new Size(800, 430);
            Controls.Add(NewVersionLabel);
            Controls.Add(GithubLabel);
            Controls.Add(VersionLabel);
            Controls.Add(lblCredits);
            Controls.Add(pictureBox7);
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
            Controls.Add(lblServerProfileSpecific);
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
            Controls.Add(pictureBox3);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nudGamePort).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQueryPort).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSlotCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            tabServerTabs.ResumeLayout(false);
            tabServerSettings.ResumeLayout(false);
            tabServerSettings.PerformLayout();
            tabProfileManager.ResumeLayout(false);
            tabProfileManager.PerformLayout();
            pnlProfileNameUpdate.ResumeLayout(false);
            pnlProfileNameUpdate.PerformLayout();
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
        private PictureBox pictureBox3;
        private Label lblAdminPanel;
        private Label lblTitle;
        private Label lblServerSettings;
        private Label lblCloseButton;
        private Label lblMinimizeTrayButton;
        private PictureBox pictureBox5;
        private Label lblNews;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox1;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
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
        private Label lblCredits;
        private Label lblAddNewProfile;
        private Button btnShowPassword;
        private Label VersionLabel;
        private Label GithubLabel;
        private Label NewVersionLabel;
    }
}
