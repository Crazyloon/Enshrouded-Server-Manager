namespace Enshrouded_Server_Manager.Views;

partial class AdminPanelView
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        btnStopServer = new Button();
        btnOpenLogFolder = new Button();
        btnOpenSavegameFolder = new Button();
        btnOpenBackupFolder = new Button();
        btnUpdateServer = new Button();
        btnSaveBackup = new Button();
        lblAdminPanel = new Label();
        btnWindowsFirewall = new Button();
        btnInstallSteamCMD = new Button();
        gbxServerSpecificControls = new GroupBox();
        btnStartServer = new Button();
        btnInstallServer = new Button();
        gbxServerSpecificControls.SuspendLayout();
        SuspendLayout();
        // 
        // btnStopServer
        // 
        btnStopServer.Cursor = Cursors.Hand;
        btnStopServer.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnStopServer.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnStopServer.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnStopServer.FlatStyle = FlatStyle.Flat;
        btnStopServer.ForeColor = SystemColors.Control;
        btnStopServer.Location = new Point(11, 22);
        btnStopServer.Name = "btnStopServer";
        btnStopServer.Size = new Size(127, 25);
        btnStopServer.TabIndex = 70;
        btnStopServer.Text = "Stop Server";
        btnStopServer.UseCompatibleTextRendering = true;
        btnStopServer.UseVisualStyleBackColor = true;
        btnStopServer.Visible = false;
        // 
        // btnOpenLogFolder
        // 
        btnOpenLogFolder.Cursor = Cursors.Hand;
        btnOpenLogFolder.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnOpenLogFolder.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnOpenLogFolder.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnOpenLogFolder.FlatStyle = FlatStyle.Flat;
        btnOpenLogFolder.ForeColor = SystemColors.Control;
        btnOpenLogFolder.Location = new Point(11, 186);
        btnOpenLogFolder.Name = "btnOpenLogFolder";
        btnOpenLogFolder.Size = new Size(127, 25);
        btnOpenLogFolder.TabIndex = 65;
        btnOpenLogFolder.Text = "Log Folder";
        btnOpenLogFolder.UseCompatibleTextRendering = true;
        btnOpenLogFolder.UseVisualStyleBackColor = true;
        // 
        // btnOpenSavegameFolder
        // 
        btnOpenSavegameFolder.Cursor = Cursors.Hand;
        btnOpenSavegameFolder.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnOpenSavegameFolder.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnOpenSavegameFolder.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnOpenSavegameFolder.FlatStyle = FlatStyle.Flat;
        btnOpenSavegameFolder.ForeColor = SystemColors.Control;
        btnOpenSavegameFolder.Location = new Point(11, 155);
        btnOpenSavegameFolder.Name = "btnOpenSavegameFolder";
        btnOpenSavegameFolder.Size = new Size(127, 25);
        btnOpenSavegameFolder.TabIndex = 64;
        btnOpenSavegameFolder.Text = "Savegame Folder";
        btnOpenSavegameFolder.UseCompatibleTextRendering = true;
        btnOpenSavegameFolder.UseVisualStyleBackColor = true;
        // 
        // btnOpenBackupFolder
        // 
        btnOpenBackupFolder.Cursor = Cursors.Hand;
        btnOpenBackupFolder.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnOpenBackupFolder.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnOpenBackupFolder.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnOpenBackupFolder.FlatStyle = FlatStyle.Flat;
        btnOpenBackupFolder.ForeColor = SystemColors.Control;
        btnOpenBackupFolder.Location = new Point(11, 124);
        btnOpenBackupFolder.Name = "btnOpenBackupFolder";
        btnOpenBackupFolder.Size = new Size(127, 25);
        btnOpenBackupFolder.TabIndex = 63;
        btnOpenBackupFolder.Text = "Backup Folder";
        btnOpenBackupFolder.UseCompatibleTextRendering = true;
        btnOpenBackupFolder.UseVisualStyleBackColor = true;
        // 
        // btnUpdateServer
        // 
        btnUpdateServer.Cursor = Cursors.Hand;
        btnUpdateServer.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnUpdateServer.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnUpdateServer.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnUpdateServer.FlatStyle = FlatStyle.Flat;
        btnUpdateServer.ForeColor = SystemColors.Control;
        btnUpdateServer.Location = new Point(11, 53);
        btnUpdateServer.Name = "btnUpdateServer";
        btnUpdateServer.Size = new Size(127, 25);
        btnUpdateServer.TabIndex = 60;
        btnUpdateServer.Text = "Update Server";
        btnUpdateServer.UseCompatibleTextRendering = true;
        btnUpdateServer.UseVisualStyleBackColor = true;
        btnUpdateServer.Visible = false;
        // 
        // btnSaveBackup
        // 
        btnSaveBackup.Cursor = Cursors.Hand;
        btnSaveBackup.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnSaveBackup.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnSaveBackup.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnSaveBackup.FlatStyle = FlatStyle.Flat;
        btnSaveBackup.ForeColor = SystemColors.Control;
        btnSaveBackup.Location = new Point(11, 93);
        btnSaveBackup.Name = "btnSaveBackup";
        btnSaveBackup.Size = new Size(127, 25);
        btnSaveBackup.TabIndex = 62;
        btnSaveBackup.Text = "Save Backup";
        btnSaveBackup.UseCompatibleTextRendering = true;
        btnSaveBackup.UseVisualStyleBackColor = true;
        // 
        // lblAdminPanel
        // 
        lblAdminPanel.AutoSize = true;
        lblAdminPanel.BackColor = Color.Transparent;
        lblAdminPanel.Dock = DockStyle.Bottom;
        lblAdminPanel.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
        lblAdminPanel.ForeColor = SystemColors.Control;
        lblAdminPanel.Location = new Point(0, 330);
        lblAdminPanel.Name = "lblAdminPanel";
        lblAdminPanel.Padding = new Padding(4);
        lblAdminPanel.Size = new Size(161, 40);
        lblAdminPanel.TabIndex = 66;
        lblAdminPanel.Text = "AdminPanel";
        // 
        // btnWindowsFirewall
        // 
        btnWindowsFirewall.Cursor = Cursors.Hand;
        btnWindowsFirewall.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnWindowsFirewall.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnWindowsFirewall.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnWindowsFirewall.FlatStyle = FlatStyle.Flat;
        btnWindowsFirewall.ForeColor = SystemColors.Control;
        btnWindowsFirewall.Location = new Point(22, 45);
        btnWindowsFirewall.Name = "btnWindowsFirewall";
        btnWindowsFirewall.Size = new Size(127, 24);
        btnWindowsFirewall.TabIndex = 67;
        btnWindowsFirewall.TabStop = false;
        btnWindowsFirewall.Text = "Windows Firewall";
        btnWindowsFirewall.UseVisualStyleBackColor = true;
        // 
        // btnInstallSteamCMD
        // 
        btnInstallSteamCMD.Cursor = Cursors.Hand;
        btnInstallSteamCMD.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnInstallSteamCMD.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnInstallSteamCMD.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnInstallSteamCMD.FlatStyle = FlatStyle.Flat;
        btnInstallSteamCMD.ForeColor = SystemColors.Control;
        btnInstallSteamCMD.Location = new Point(22, 18);
        btnInstallSteamCMD.Name = "btnInstallSteamCMD";
        btnInstallSteamCMD.Size = new Size(127, 23);
        btnInstallSteamCMD.TabIndex = 61;
        btnInstallSteamCMD.TabStop = false;
        btnInstallSteamCMD.Text = "Install Steam";
        btnInstallSteamCMD.UseVisualStyleBackColor = true;
        // 
        // gbxServerSpecificControls
        // 
        gbxServerSpecificControls.BackColor = Color.FromArgb(0, 0, 18);
        gbxServerSpecificControls.Controls.Add(btnStopServer);
        gbxServerSpecificControls.Controls.Add(btnStartServer);
        gbxServerSpecificControls.Controls.Add(btnOpenLogFolder);
        gbxServerSpecificControls.Controls.Add(btnOpenSavegameFolder);
        gbxServerSpecificControls.Controls.Add(btnOpenBackupFolder);
        gbxServerSpecificControls.Controls.Add(btnUpdateServer);
        gbxServerSpecificControls.Controls.Add(btnInstallServer);
        gbxServerSpecificControls.Controls.Add(btnSaveBackup);
        gbxServerSpecificControls.FlatStyle = FlatStyle.Flat;
        gbxServerSpecificControls.ForeColor = SystemColors.ControlLight;
        gbxServerSpecificControls.Location = new Point(10, 98);
        gbxServerSpecificControls.Name = "gbxServerSpecificControls";
        gbxServerSpecificControls.Size = new Size(150, 220);
        gbxServerSpecificControls.TabIndex = 71;
        gbxServerSpecificControls.TabStop = false;
        gbxServerSpecificControls.Text = "\"Server Profile\" specific";
        gbxServerSpecificControls.Paint += gbxServerSpecificControls_Paint;
        // 
        // btnStartServer
        // 
        btnStartServer.Cursor = Cursors.Hand;
        btnStartServer.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnStartServer.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnStartServer.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnStartServer.FlatStyle = FlatStyle.Flat;
        btnStartServer.ForeColor = SystemColors.Control;
        btnStartServer.Location = new Point(11, 22);
        btnStartServer.Name = "btnStartServer";
        btnStartServer.Size = new Size(127, 25);
        btnStartServer.TabIndex = 71;
        btnStartServer.Text = "Start Server";
        btnStartServer.UseCompatibleTextRendering = true;
        btnStartServer.UseVisualStyleBackColor = true;
        btnStartServer.Visible = false;
        // 
        // btnInstallServer
        // 
        btnInstallServer.Cursor = Cursors.Hand;
        btnInstallServer.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnInstallServer.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnInstallServer.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnInstallServer.FlatStyle = FlatStyle.Flat;
        btnInstallServer.ForeColor = SystemColors.Control;
        btnInstallServer.Location = new Point(11, 53);
        btnInstallServer.Name = "btnInstallServer";
        btnInstallServer.Size = new Size(127, 25);
        btnInstallServer.TabIndex = 72;
        btnInstallServer.Text = "Install Server";
        btnInstallServer.UseVisualStyleBackColor = true;
        btnInstallServer.Visible = false;
        // 
        // AdminPanelView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(gbxServerSpecificControls);
        Controls.Add(lblAdminPanel);
        Controls.Add(btnWindowsFirewall);
        Controls.Add(btnInstallSteamCMD);
        Name = "AdminPanelView";
        Size = new Size(170, 370);
        gbxServerSpecificControls.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Button btnStopServer;
    private Button btnOpenLogFolder;
    private Button btnOpenSavegameFolder;
    private Button btnOpenBackupFolder;
    private Button btnUpdateServer;
    private Button btnSaveBackup;
    private Label lblAdminPanel;
    private Button btnWindowsFirewall;
    private Button btnInstallSteamCMD;
    private GroupBox gbxServerSpecificControls;
    private Button btnStartServer;
    private Button btnInstallServer;
}
