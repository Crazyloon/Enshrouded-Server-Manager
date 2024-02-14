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
        btnRestoreSaveFile = new Button();
        lblSelectRestoreFile = new Label();
        lblAutoBackupChangesInfo = new Label();
        btnSelectRestoreFile = new Button();
        txtRestoreFilePath = new TextBox();
        ofdBackupFileSelector = new OpenFileDialog();
        SuspendLayout();
        // 
        // btnRestoreSaveFile
        // 
        btnRestoreSaveFile.Cursor = Cursors.Hand;
        btnRestoreSaveFile.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnRestoreSaveFile.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnRestoreSaveFile.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnRestoreSaveFile.FlatStyle = FlatStyle.Flat;
        btnRestoreSaveFile.ForeColor = Color.FromArgb(0, 255, 185);
        btnRestoreSaveFile.Location = new Point(262, 301);
        btnRestoreSaveFile.Name = "btnRestoreSaveFile";
        btnRestoreSaveFile.Size = new Size(128, 30);
        btnRestoreSaveFile.TabIndex = 35;
        btnRestoreSaveFile.Text = "Restore Selected File";
        btnRestoreSaveFile.UseCompatibleTextRendering = true;
        btnRestoreSaveFile.UseVisualStyleBackColor = true;
        btnRestoreSaveFile.EnabledChanged += btnSaveAutoBackup_EnabledChanged;
        // 
        // lblSelectRestoreFile
        // 
        lblSelectRestoreFile.AutoSize = true;
        lblSelectRestoreFile.Location = new Point(66, 61);
        lblSelectRestoreFile.Name = "lblSelectRestoreFile";
        lblSelectRestoreFile.Size = new Size(101, 15);
        lblSelectRestoreFile.TabIndex = 30;
        lblSelectRestoreFile.Text = "Select Restore File";
        // 
        // lblAutoBackupChangesInfo
        // 
        lblAutoBackupChangesInfo.AutoSize = true;
        lblAutoBackupChangesInfo.ForeColor = SystemColors.Info;
        lblAutoBackupChangesInfo.Location = new Point(112, 350);
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
        btnSelectRestoreFile.Location = new Point(68, 114);
        btnSelectRestoreFile.Margin = new Padding(0);
        btnSelectRestoreFile.Name = "btnSelectRestoreFile";
        btnSelectRestoreFile.Padding = new Padding(0, 2, 0, 0);
        btnSelectRestoreFile.Size = new Size(157, 30);
        btnSelectRestoreFile.TabIndex = 37;
        btnSelectRestoreFile.Text = "Select Restore File";
        btnSelectRestoreFile.UseCompatibleTextRendering = true;
        btnSelectRestoreFile.UseVisualStyleBackColor = true;
        // 
        // txtRestoreFilePath
        // 
        txtRestoreFilePath.BackColor = Color.FromArgb(6, 6, 48);
        txtRestoreFilePath.BorderStyle = BorderStyle.FixedSingle;
        txtRestoreFilePath.ForeColor = SystemColors.Window;
        txtRestoreFilePath.Location = new Point(65, 79);
        txtRestoreFilePath.Name = "txtRestoreFilePath";
        txtRestoreFilePath.Size = new Size(325, 23);
        txtRestoreFilePath.TabIndex = 42;
        // 
        // ofdBackupFileSelector
        // 
        ofdBackupFileSelector.FileName = "3ad85aea";
        // 
        // RestoreBackupView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(txtRestoreFilePath);
        Controls.Add(btnSelectRestoreFile);
        Controls.Add(lblAutoBackupChangesInfo);
        Controls.Add(btnRestoreSaveFile);
        Controls.Add(lblSelectRestoreFile);
        ForeColor = SystemColors.ButtonHighlight;
        Name = "RestoreBackupView";
        Size = new Size(459, 384);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Button btnRestoreSaveFile;
    private Label lblSelectRestoreFile;
    private Label lblAutoBackupChangesInfo;
    private Button btnSelectRestoreFile;
    private TextBox txtRestoreFilePath;
    private OpenFileDialog ofdBackupFileSelector;
}
