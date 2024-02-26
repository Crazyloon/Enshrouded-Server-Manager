namespace Enshrouded_Server_Manager;

partial class RestoreBackupView
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
        components = new System.ComponentModel.Container();
        btnSaveSettings = new Button();
        lblSelectRestoreFile = new Label();
        lblAutoBackupChangesInfo = new Label();
        btnSelectRestoreFile = new Button();
        txtRestoreFilePath = new TextBox();
        ofdBackupFileSelector = new OpenFileDialog();
        chkRestoreBackupOnRestart = new CheckBox();
        btnRestoreSaveFile = new Button();
        lblAutoRestoreInfo = new Label();
        ttpToolTip = new ToolTip(components);
        SuspendLayout();
        // 
        // btnSaveSettings
        // 
        btnSaveSettings.Cursor = Cursors.Hand;
        btnSaveSettings.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnSaveSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnSaveSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnSaveSettings.FlatStyle = FlatStyle.Flat;
        btnSaveSettings.ForeColor = Color.FromArgb(0, 255, 185);
        btnSaveSettings.Location = new Point(410, 342);
        btnSaveSettings.Name = "btnSaveSettings";
        btnSaveSettings.Size = new Size(128, 30);
        btnSaveSettings.TabIndex = 45;
        btnSaveSettings.Text = "Save Settings";
        btnSaveSettings.UseCompatibleTextRendering = true;
        btnSaveSettings.UseVisualStyleBackColor = true;
        btnSaveSettings.EnabledChanged += btnSaveAutoBackup_EnabledChanged;
        // 
        // lblSelectRestoreFile
        // 
        lblSelectRestoreFile.AutoSize = true;
        lblSelectRestoreFile.Location = new Point(211, 61);
        lblSelectRestoreFile.Name = "lblSelectRestoreFile";
        lblSelectRestoreFile.Size = new Size(101, 15);
        lblSelectRestoreFile.TabIndex = 30;
        lblSelectRestoreFile.Text = "Select Restore File";
        // 
        // lblAutoBackupChangesInfo
        // 
        lblAutoBackupChangesInfo.AutoSize = true;
        lblAutoBackupChangesInfo.ForeColor = SystemColors.Info;
        lblAutoBackupChangesInfo.Location = new Point(258, 385);
        lblAutoBackupChangesInfo.Name = "lblAutoBackupChangesInfo";
        lblAutoBackupChangesInfo.Size = new Size(235, 15);
        lblAutoBackupChangesInfo.TabIndex = 36;
        lblAutoBackupChangesInfo.Text = "Server must be stopped to restore a backup";
        // 
        // btnSelectRestoreFile
        // 
        btnSelectRestoreFile.Anchor = AnchorStyles.None;
        btnSelectRestoreFile.BackgroundImageLayout = ImageLayout.None;
        btnSelectRestoreFile.Cursor = Cursors.Hand;
        btnSelectRestoreFile.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnSelectRestoreFile.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnSelectRestoreFile.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnSelectRestoreFile.FlatStyle = FlatStyle.Flat;
        btnSelectRestoreFile.Font = new Font("Malgun Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        btnSelectRestoreFile.ForeColor = SystemColors.ControlLightLight;
        btnSelectRestoreFile.Location = new Point(381, 110);
        btnSelectRestoreFile.Margin = new Padding(0);
        btnSelectRestoreFile.Name = "btnSelectRestoreFile";
        btnSelectRestoreFile.Padding = new Padding(0, 2, 0, 0);
        btnSelectRestoreFile.Size = new Size(157, 30);
        btnSelectRestoreFile.TabIndex = 43;
        btnSelectRestoreFile.Text = "Select Restore File";
        btnSelectRestoreFile.UseCompatibleTextRendering = true;
        btnSelectRestoreFile.UseVisualStyleBackColor = true;
        // 
        // txtRestoreFilePath
        // 
        txtRestoreFilePath.BackColor = Color.FromArgb(6, 6, 48);
        txtRestoreFilePath.BorderStyle = BorderStyle.FixedSingle;
        txtRestoreFilePath.ForeColor = SystemColors.Window;
        txtRestoreFilePath.Location = new Point(207, 79);
        txtRestoreFilePath.Name = "txtRestoreFilePath";
        txtRestoreFilePath.Size = new Size(331, 23);
        txtRestoreFilePath.TabIndex = 42;
        ttpToolTip.SetToolTip(txtRestoreFilePath, "Enter a directory to restore from the newest zip file in that directory");
        // 
        // ofdBackupFileSelector
        // 
        ofdBackupFileSelector.FileName = "3ad85aea";
        // 
        // chkRestoreBackupOnRestart
        // 
        chkRestoreBackupOnRestart.AutoSize = true;
        chkRestoreBackupOnRestart.Location = new Point(207, 157);
        chkRestoreBackupOnRestart.Name = "chkRestoreBackupOnRestart";
        chkRestoreBackupOnRestart.Size = new Size(281, 19);
        chkRestoreBackupOnRestart.TabIndex = 44;
        chkRestoreBackupOnRestart.Text = "Auto Restore From Backup on Scheduled Restart";
        chkRestoreBackupOnRestart.UseVisualStyleBackColor = true;
        // 
        // btnRestoreSaveFile
        // 
        btnRestoreSaveFile.BackgroundImageLayout = ImageLayout.None;
        btnRestoreSaveFile.Cursor = Cursors.Hand;
        btnRestoreSaveFile.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnRestoreSaveFile.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnRestoreSaveFile.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnRestoreSaveFile.FlatStyle = FlatStyle.Flat;
        btnRestoreSaveFile.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        btnRestoreSaveFile.ForeColor = SystemColors.ControlLightLight;
        btnRestoreSaveFile.Location = new Point(207, 342);
        btnRestoreSaveFile.Margin = new Padding(0);
        btnRestoreSaveFile.Name = "btnRestoreSaveFile";
        btnRestoreSaveFile.Padding = new Padding(0, 2, 0, 0);
        btnRestoreSaveFile.Size = new Size(128, 30);
        btnRestoreSaveFile.TabIndex = 46;
        btnRestoreSaveFile.Text = "Restore Selected File";
        ttpToolTip.SetToolTip(btnRestoreSaveFile, "Copies the selected file to your savegame directory");
        btnRestoreSaveFile.UseCompatibleTextRendering = true;
        btnRestoreSaveFile.UseVisualStyleBackColor = true;
        btnRestoreSaveFile.EnabledChanged += btnSaveAutoBackup_EnabledChanged;
        // 
        // lblAutoRestoreInfo
        // 
        lblAutoRestoreInfo.ForeColor = SystemColors.Info;
        lblAutoRestoreInfo.Location = new Point(223, 179);
        lblAutoRestoreInfo.Name = "lblAutoRestoreInfo";
        lblAutoRestoreInfo.Size = new Size(236, 50);
        lblAutoRestoreInfo.TabIndex = 47;
        lblAutoRestoreInfo.Text = "If this profile restarts on a schedule, checking this box will ensure that it restores from a backup when it shuts down";
        // 
        // RestoreBackupView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(lblAutoRestoreInfo);
        Controls.Add(btnRestoreSaveFile);
        Controls.Add(chkRestoreBackupOnRestart);
        Controls.Add(txtRestoreFilePath);
        Controls.Add(btnSelectRestoreFile);
        Controls.Add(lblAutoBackupChangesInfo);
        Controls.Add(btnSaveSettings);
        Controls.Add(lblSelectRestoreFile);
        ForeColor = SystemColors.ButtonHighlight;
        Name = "RestoreBackupView";
        Size = new Size(744, 411);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Button btnSaveSettings;
    private Label lblSelectRestoreFile;
    private Label lblAutoBackupChangesInfo;
    private Button btnSelectRestoreFile;
    private TextBox txtRestoreFilePath;
    private OpenFileDialog ofdBackupFileSelector;
    private CheckBox chkRestoreBackupOnRestart;
    private Button btnRestoreSaveFile;
    private Label lblAutoRestoreInfo;
    private ToolTip ttpToolTip;
}
