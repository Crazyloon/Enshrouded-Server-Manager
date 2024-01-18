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
            ServerSelectionComboBox = new ComboBox();
            ServerSelectionLabel = new Label();
            InstallSteamCMD_Button = new Button();
            InstallUpdateServer_Button = new Button();
            ServerName_TextBox = new TextBox();
            ServerPassword_TextBox = new TextBox();
            IP_TextBox = new TextBox();
            GamePort_input = new NumericUpDown();
            QueryPort_input = new NumericUpDown();
            SlotCount_input = new NumericUpDown();
            Servername_Label = new Label();
            Password_Label = new Label();
            IpAddress_Label = new Label();
            GamePort_label = new Label();
            QueryPort_Label = new Label();
            MaxPlayers_Label = new Label();
            SaveSettings_Button = new Button();
            StartServer_Button = new Button();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            AdminPanelLabel = new Label();
            TitleLabel = new Label();
            ServerSettingsLabel = new Label();
            pictureBox4 = new PictureBox();
            CloseLabel = new Label();
            MinimizeTrayLabel = new Label();
            pictureBox5 = new PictureBox();
            NewsLabel = new Label();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox8 = new PictureBox();
            pictureBox9 = new PictureBox();
            SaveBackup_Button = new Button();
            OpenBackupFolder_Button = new Button();
            WindowsFirewall_Button = new Button();
            label7 = new Label();
            ServerProfileSpecific = new Label();
            pictureBox10 = new PictureBox();
            OpenSavegameFolder_Button = new Button();
            OpenLogFolder_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)GamePort_input).BeginInit();
            ((System.ComponentModel.ISupportInitialize)QueryPort_input).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SlotCount_input).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            SuspendLayout();
            // 
            // ServerSelectionComboBox
            // 
            ServerSelectionComboBox.FormattingEnabled = true;
            ServerSelectionComboBox.Items.AddRange(new object[] { "1", "2", "3", "4" });
            ServerSelectionComboBox.Location = new Point(415, 77);
            ServerSelectionComboBox.Name = "ServerSelectionComboBox";
            ServerSelectionComboBox.Size = new Size(31, 23);
            ServerSelectionComboBox.TabIndex = 0;
            ServerSelectionComboBox.Text = "1";
            ServerSelectionComboBox.SelectedIndexChanged += Form1_Load;
            // 
            // ServerSelectionLabel
            // 
            ServerSelectionLabel.AutoSize = true;
            ServerSelectionLabel.ForeColor = SystemColors.ButtonHighlight;
            ServerSelectionLabel.Location = new Point(334, 80);
            ServerSelectionLabel.Name = "ServerSelectionLabel";
            ServerSelectionLabel.Size = new Size(76, 15);
            ServerSelectionLabel.TabIndex = 1;
            ServerSelectionLabel.Text = "Server Profile";
            // 
            // InstallSteamCMD_Button
            // 
            InstallSteamCMD_Button.ForeColor = SystemColors.ActiveCaptionText;
            InstallSteamCMD_Button.Location = new Point(33, 57);
            InstallSteamCMD_Button.Name = "InstallSteamCMD_Button";
            InstallSteamCMD_Button.Size = new Size(127, 23);
            InstallSteamCMD_Button.TabIndex = 2;
            InstallSteamCMD_Button.Text = "Install SteamCMD";
            InstallSteamCMD_Button.UseVisualStyleBackColor = true;
            InstallSteamCMD_Button.Click += InstallSteamCMD_Button_Click;
            // 
            // InstallUpdateServer_Button
            // 
            InstallUpdateServer_Button.ForeColor = SystemColors.ActiveCaptionText;
            InstallUpdateServer_Button.Location = new Point(33, 165);
            InstallUpdateServer_Button.Name = "InstallUpdateServer_Button";
            InstallUpdateServer_Button.Size = new Size(127, 23);
            InstallUpdateServer_Button.TabIndex = 3;
            InstallUpdateServer_Button.Text = "Install/Update Server";
            InstallUpdateServer_Button.UseVisualStyleBackColor = true;
            InstallUpdateServer_Button.Visible = false;
            InstallUpdateServer_Button.Click += InstallUpdateServer_Button_Click;
            // 
            // ServerName_TextBox
            // 
            ServerName_TextBox.Location = new Point(314, 121);
            ServerName_TextBox.Name = "ServerName_TextBox";
            ServerName_TextBox.Size = new Size(170, 23);
            ServerName_TextBox.TabIndex = 4;
            // 
            // ServerPassword_TextBox
            // 
            ServerPassword_TextBox.Location = new Point(314, 150);
            ServerPassword_TextBox.Name = "ServerPassword_TextBox";
            ServerPassword_TextBox.Size = new Size(170, 23);
            ServerPassword_TextBox.TabIndex = 5;
            // 
            // IP_TextBox
            // 
            IP_TextBox.Location = new Point(314, 179);
            IP_TextBox.Name = "IP_TextBox";
            IP_TextBox.Size = new Size(134, 23);
            IP_TextBox.TabIndex = 6;
            // 
            // GamePort_input
            // 
            GamePort_input.Location = new Point(314, 209);
            GamePort_input.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            GamePort_input.Name = "GamePort_input";
            GamePort_input.Size = new Size(62, 23);
            GamePort_input.TabIndex = 7;
            // 
            // QueryPort_input
            // 
            QueryPort_input.Location = new Point(314, 238);
            QueryPort_input.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            QueryPort_input.Name = "QueryPort_input";
            QueryPort_input.Size = new Size(62, 23);
            QueryPort_input.TabIndex = 8;
            // 
            // SlotCount_input
            // 
            SlotCount_input.Location = new Point(314, 267);
            SlotCount_input.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            SlotCount_input.Name = "SlotCount_input";
            SlotCount_input.Size = new Size(35, 23);
            SlotCount_input.TabIndex = 9;
            // 
            // Servername_Label
            // 
            Servername_Label.AutoSize = true;
            Servername_Label.ForeColor = SystemColors.ButtonHighlight;
            Servername_Label.Location = new Point(243, 124);
            Servername_Label.Name = "Servername_Label";
            Servername_Label.Size = new Size(69, 15);
            Servername_Label.TabIndex = 10;
            Servername_Label.Text = "Servername";
            // 
            // Password_Label
            // 
            Password_Label.AutoSize = true;
            Password_Label.ForeColor = SystemColors.ButtonHighlight;
            Password_Label.Location = new Point(255, 153);
            Password_Label.Name = "Password_Label";
            Password_Label.Size = new Size(57, 15);
            Password_Label.TabIndex = 11;
            Password_Label.Text = "Password";
            // 
            // IpAddress_Label
            // 
            IpAddress_Label.AutoSize = true;
            IpAddress_Label.ForeColor = SystemColors.ButtonHighlight;
            IpAddress_Label.Location = new Point(250, 182);
            IpAddress_Label.Name = "IpAddress_Label";
            IpAddress_Label.Size = new Size(62, 15);
            IpAddress_Label.TabIndex = 12;
            IpAddress_Label.Text = "Ip Address";
            // 
            // GamePort_label
            // 
            GamePort_label.AutoSize = true;
            GamePort_label.ForeColor = SystemColors.ButtonHighlight;
            GamePort_label.Location = new Point(252, 211);
            GamePort_label.Name = "GamePort_label";
            GamePort_label.Size = new Size(60, 15);
            GamePort_label.TabIndex = 13;
            GamePort_label.Text = "GamePort";
            // 
            // QueryPort_Label
            // 
            QueryPort_Label.AutoSize = true;
            QueryPort_Label.ForeColor = SystemColors.ButtonHighlight;
            QueryPort_Label.Location = new Point(251, 240);
            QueryPort_Label.Name = "QueryPort_Label";
            QueryPort_Label.Size = new Size(61, 15);
            QueryPort_Label.TabIndex = 14;
            QueryPort_Label.Text = "QueryPort";
            // 
            // MaxPlayers_Label
            // 
            MaxPlayers_Label.AutoSize = true;
            MaxPlayers_Label.Location = new Point(245, 269);
            MaxPlayers_Label.Name = "MaxPlayers_Label";
            MaxPlayers_Label.Size = new Size(67, 15);
            MaxPlayers_Label.TabIndex = 15;
            MaxPlayers_Label.Text = "MaxPlayers";
            // 
            // SaveSettings_Button
            // 
            SaveSettings_Button.ForeColor = SystemColors.ActiveCaptionText;
            SaveSettings_Button.Location = new Point(318, 315);
            SaveSettings_Button.Name = "SaveSettings_Button";
            SaveSettings_Button.Size = new Size(124, 23);
            SaveSettings_Button.TabIndex = 17;
            SaveSettings_Button.Text = "Save Settings";
            SaveSettings_Button.UseVisualStyleBackColor = true;
            SaveSettings_Button.Click += SaveSettings_Button_Click;
            // 
            // StartServer_Button
            // 
            StartServer_Button.ForeColor = SystemColors.ActiveCaptionText;
            StartServer_Button.Location = new Point(33, 194);
            StartServer_Button.Name = "StartServer_Button";
            StartServer_Button.Size = new Size(127, 23);
            StartServer_Button.TabIndex = 18;
            StartServer_Button.Text = "Start Server";
            StartServer_Button.UseVisualStyleBackColor = true;
            StartServer_Button.Visible = false;
            StartServer_Button.Click += StartServer_Button_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ControlDarkDark;
            pictureBox2.Dock = DockStyle.Left;
            pictureBox2.Location = new Point(10, 40);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(171, 369);
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.ControlDark;
            pictureBox3.Dock = DockStyle.Top;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(800, 40);
            pictureBox3.TabIndex = 22;
            pictureBox3.TabStop = false;
            pictureBox3.MouseDown += pictureBox3_MouseDown;
            // 
            // AdminPanelLabel
            // 
            AdminPanelLabel.BackColor = SystemColors.ControlDarkDark;
            AdminPanelLabel.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            AdminPanelLabel.ForeColor = SystemColors.ControlDark;
            AdminPanelLabel.Location = new Point(11, 375);
            AdminPanelLabel.Name = "AdminPanelLabel";
            AdminPanelLabel.Size = new Size(153, 32);
            AdminPanelLabel.TabIndex = 23;
            AdminPanelLabel.Text = "AdminPanel";
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.BackColor = SystemColors.ControlDark;
            TitleLabel.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            TitleLabel.ForeColor = SystemColors.ControlDarkDark;
            TitleLabel.Location = new Point(6, 5);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(414, 32);
            TitleLabel.TabIndex = 24;
            TitleLabel.Text = "ESM - Enshrouded Server Manager";
            TitleLabel.MouseDown += pictureBox3_MouseDown;
            // 
            // ServerSettingsLabel
            // 
            ServerSettingsLabel.AutoSize = true;
            ServerSettingsLabel.BackColor = SystemColors.ControlDarkDark;
            ServerSettingsLabel.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            ServerSettingsLabel.ForeColor = SystemColors.ControlDark;
            ServerSettingsLabel.Location = new Point(193, 374);
            ServerSettingsLabel.Name = "ServerSettingsLabel";
            ServerSettingsLabel.Size = new Size(186, 32);
            ServerSettingsLabel.TabIndex = 25;
            ServerSettingsLabel.Text = "Server Settings";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(568, 51);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(213, 99);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 26;
            pictureBox4.TabStop = false;
            // 
            // CloseLabel
            // 
            CloseLabel.AutoSize = true;
            CloseLabel.BackColor = SystemColors.ControlDark;
            CloseLabel.Font = new Font("Malgun Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point);
            CloseLabel.ForeColor = SystemColors.ActiveCaptionText;
            CloseLabel.Location = new Point(771, 9);
            CloseLabel.Name = "CloseLabel";
            CloseLabel.Size = new Size(18, 19);
            CloseLabel.TabIndex = 27;
            CloseLabel.Text = "X";
            CloseLabel.Click += label4_Click;
            // 
            // MinimizeTrayLabel
            // 
            MinimizeTrayLabel.AutoSize = true;
            MinimizeTrayLabel.BackColor = SystemColors.ControlDark;
            MinimizeTrayLabel.Font = new Font("Malgun Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            MinimizeTrayLabel.ForeColor = SystemColors.ActiveCaptionText;
            MinimizeTrayLabel.Location = new Point(741, 6);
            MinimizeTrayLabel.Name = "MinimizeTrayLabel";
            MinimizeTrayLabel.Size = new Size(17, 21);
            MinimizeTrayLabel.TabIndex = 28;
            MinimizeTrayLabel.Text = "_";
            MinimizeTrayLabel.Click += label5_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = SystemColors.ControlDark;
            pictureBox5.Dock = DockStyle.Left;
            pictureBox5.Location = new Point(0, 40);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(10, 369);
            pictureBox5.TabIndex = 29;
            pictureBox5.TabStop = false;
            // 
            // NewsLabel
            // 
            NewsLabel.AutoSize = true;
            NewsLabel.BackColor = SystemColors.ControlDarkDark;
            NewsLabel.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            NewsLabel.ForeColor = SystemColors.ControlDark;
            NewsLabel.Location = new Point(562, 374);
            NewsLabel.Name = "NewsLabel";
            NewsLabel.Size = new Size(76, 32);
            NewsLabel.TabIndex = 30;
            NewsLabel.Text = "News";
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = SystemColors.ControlDark;
            pictureBox7.Dock = DockStyle.Bottom;
            pictureBox7.Location = new Point(0, 409);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(790, 21);
            pictureBox7.TabIndex = 33;
            pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = SystemColors.ControlDark;
            pictureBox6.Dock = DockStyle.Right;
            pictureBox6.Location = new Point(790, 40);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(10, 390);
            pictureBox6.TabIndex = 34;
            pictureBox6.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlDarkDark;
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Location = new Point(560, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(230, 369);
            pictureBox1.TabIndex = 35;
            pictureBox1.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = SystemColors.ControlDark;
            pictureBox8.Dock = DockStyle.Right;
            pictureBox8.Location = new Point(550, 40);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(10, 369);
            pictureBox8.TabIndex = 36;
            pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = SystemColors.ControlDark;
            pictureBox9.Dock = DockStyle.Left;
            pictureBox9.Location = new Point(181, 40);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(10, 369);
            pictureBox9.TabIndex = 37;
            pictureBox9.TabStop = false;
            // 
            // SaveBackup_Button
            // 
            SaveBackup_Button.ForeColor = SystemColors.ActiveCaptionText;
            SaveBackup_Button.Location = new Point(33, 242);
            SaveBackup_Button.Name = "SaveBackup_Button";
            SaveBackup_Button.Size = new Size(127, 23);
            SaveBackup_Button.TabIndex = 38;
            SaveBackup_Button.Text = "Save Backup";
            SaveBackup_Button.UseVisualStyleBackColor = true;
            SaveBackup_Button.Click += SaveBackup_Button_Click;
            // 
            // OpenBackupFolder_Button
            // 
            OpenBackupFolder_Button.ForeColor = SystemColors.ActiveCaptionText;
            OpenBackupFolder_Button.Location = new Point(33, 271);
            OpenBackupFolder_Button.Name = "OpenBackupFolder_Button";
            OpenBackupFolder_Button.Size = new Size(127, 23);
            OpenBackupFolder_Button.TabIndex = 39;
            OpenBackupFolder_Button.Text = "Backup Folder";
            OpenBackupFolder_Button.UseVisualStyleBackColor = true;
            OpenBackupFolder_Button.Click += OpenBackupFolder_Button_Click;
            // 
            // WindowsFirewall_Button
            // 
            WindowsFirewall_Button.ForeColor = SystemColors.ActiveCaptionText;
            WindowsFirewall_Button.Location = new Point(33, 84);
            WindowsFirewall_Button.Name = "WindowsFirewall_Button";
            WindowsFirewall_Button.Size = new Size(127, 23);
            WindowsFirewall_Button.TabIndex = 40;
            WindowsFirewall_Button.Text = "Windows Firewall";
            WindowsFirewall_Button.UseVisualStyleBackColor = true;
            WindowsFirewall_Button.Click += WindowsFirewall_Button_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(577, 168);
            label7.Name = "label7";
            label7.Size = new Size(164, 45);
            label7.TabIndex = 41;
            label7.Text = "Version 0.0.1:\r\n\r\n- first version of this Launcher\r\n";
            // 
            // ServerProfileSpecific
            // 
            ServerProfileSpecific.AutoSize = true;
            ServerProfileSpecific.Location = new Point(30, 138);
            ServerProfileSpecific.Name = "ServerProfileSpecific";
            ServerProfileSpecific.Size = new Size(129, 15);
            ServerProfileSpecific.TabIndex = 42;
            ServerProfileSpecific.Text = "\"Server Profile\" specific";
            // 
            // pictureBox10
            // 
            pictureBox10.BorderStyle = BorderStyle.Fixed3D;
            pictureBox10.Location = new Point(26, 159);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(140, 203);
            pictureBox10.TabIndex = 43;
            pictureBox10.TabStop = false;
            // 
            // OpenSavegameFolder_Button
            // 
            OpenSavegameFolder_Button.ForeColor = SystemColors.ActiveCaptionText;
            OpenSavegameFolder_Button.Location = new Point(33, 300);
            OpenSavegameFolder_Button.Name = "OpenSavegameFolder_Button";
            OpenSavegameFolder_Button.Size = new Size(126, 23);
            OpenSavegameFolder_Button.TabIndex = 44;
            OpenSavegameFolder_Button.Text = "Savegame Folder";
            OpenSavegameFolder_Button.UseVisualStyleBackColor = true;
            OpenSavegameFolder_Button.Click += OpenSavegameFolder_Button_Click;
            // 
            // OpenLogFolder_Button
            // 
            OpenLogFolder_Button.ForeColor = SystemColors.ActiveCaptionText;
            OpenLogFolder_Button.Location = new Point(33, 329);
            OpenLogFolder_Button.Name = "OpenLogFolder_Button";
            OpenLogFolder_Button.Size = new Size(127, 23);
            OpenLogFolder_Button.TabIndex = 45;
            OpenLogFolder_Button.Text = "Log Folder";
            OpenLogFolder_Button.UseVisualStyleBackColor = true;
            OpenLogFolder_Button.Click += OpenLogFolder_Button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 430);
            Controls.Add(OpenLogFolder_Button);
            Controls.Add(OpenSavegameFolder_Button);
            Controls.Add(OpenBackupFolder_Button);
            Controls.Add(SaveBackup_Button);
            Controls.Add(StartServer_Button);
            Controls.Add(InstallUpdateServer_Button);
            Controls.Add(ServerProfileSpecific);
            Controls.Add(pictureBox10);
            Controls.Add(label7);
            Controls.Add(WindowsFirewall_Button);
            Controls.Add(InstallSteamCMD_Button);
            Controls.Add(AdminPanelLabel);
            Controls.Add(pictureBox9);
            Controls.Add(NewsLabel);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox8);
            Controls.Add(pictureBox1);
            Controls.Add(MinimizeTrayLabel);
            Controls.Add(CloseLabel);
            Controls.Add(ServerSettingsLabel);
            Controls.Add(TitleLabel);
            Controls.Add(pictureBox2);
            Controls.Add(SaveSettings_Button);
            Controls.Add(MaxPlayers_Label);
            Controls.Add(QueryPort_Label);
            Controls.Add(GamePort_label);
            Controls.Add(IpAddress_Label);
            Controls.Add(Password_Label);
            Controls.Add(Servername_Label);
            Controls.Add(SlotCount_input);
            Controls.Add(QueryPort_input);
            Controls.Add(GamePort_input);
            Controls.Add(IP_TextBox);
            Controls.Add(ServerPassword_TextBox);
            Controls.Add(ServerName_TextBox);
            Controls.Add(ServerSelectionLabel);
            Controls.Add(ServerSelectionComboBox);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox3);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)GamePort_input).EndInit();
            ((System.ComponentModel.ISupportInitialize)QueryPort_input).EndInit();
            ((System.ComponentModel.ISupportInitialize)SlotCount_input).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ServerSelectionComboBox;
        private Label ServerSelectionLabel;
        private Button InstallSteamCMD_Button;
        private Button InstallUpdateServer_Button;
        private TextBox ServerName_TextBox;
        private TextBox ServerPassword_TextBox;
        private TextBox IP_TextBox;
        private NumericUpDown GamePort_input;
        private NumericUpDown QueryPort_input;
        private NumericUpDown SlotCount_input;
        private Label Servername_Label;
        private Label Password_Label;
        private Label IpAddress_Label;
        private Label GamePort_label;
        private Label QueryPort_Label;
        private Label MaxPlayers_Label;
        private Button SaveSettings_Button;
        private Button StartServer_Button;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label AdminPanelLabel;
        private Label TitleLabel;
        private Label ServerSettingsLabel;
        private PictureBox pictureBox4;
        private Label CloseLabel;
        private Label MinimizeTrayLabel;
        private PictureBox pictureBox5;
        private Label NewsLabel;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox1;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private Button SaveBackup_Button;
        private Button OpenBackupFolder_Button;
        private Button WindowsFirewall_Button;
        private Label label7;
        private Label ServerProfileSpecific;
        private PictureBox pictureBox10;
        private Button OpenSavegameFolder_Button;
        private Button OpenLogFolder_Button;
    }
}
