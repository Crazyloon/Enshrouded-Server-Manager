namespace Enshrouded_Server_Manager;

partial class AutoBackupView
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
        lblAutoBackupChangesInfo = new Label();
        btnSaveAutoBackup = new Button();
        chkEnableBackups = new CheckBox();
        lblProfileBackupsStats = new Label();
        lblProfileBackupsInstruction = new Label();
        nudBackupMaxCount = new NumericUpDown();
        lblBackupMaxCount = new Label();
        lblBackupFrequency = new Label();
        nudBackupInterval = new NumericUpDown();
        lbxProfileSelectorAutoBackup = new ListBox();
        ((System.ComponentModel.ISupportInitialize)nudBackupMaxCount).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudBackupInterval).BeginInit();
        SuspendLayout();
        // 
        // lblAutoBackupChangesInfo
        // 
        lblAutoBackupChangesInfo.AutoSize = true;
        lblAutoBackupChangesInfo.ForeColor = SystemColors.Info;
        lblAutoBackupChangesInfo.Location = new Point(100, 350);
        lblAutoBackupChangesInfo.Name = "lblAutoBackupChangesInfo";
        lblAutoBackupChangesInfo.Size = new Size(255, 15);
        lblAutoBackupChangesInfo.TabIndex = 36;
        lblAutoBackupChangesInfo.Text = "Changes will take effect on the next server start";
        // 
        // btnSaveAutoBackup
        // 
        btnSaveAutoBackup.Cursor = Cursors.Hand;
        btnSaveAutoBackup.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnSaveAutoBackup.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnSaveAutoBackup.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnSaveAutoBackup.FlatStyle = FlatStyle.Flat;
        btnSaveAutoBackup.ForeColor = Color.FromArgb(0, 255, 185);
        btnSaveAutoBackup.Location = new Point(262, 301);
        btnSaveAutoBackup.Name = "btnSaveAutoBackup";
        btnSaveAutoBackup.Size = new Size(128, 30);
        btnSaveAutoBackup.TabIndex = 35;
        btnSaveAutoBackup.Text = "Save Changes";
        btnSaveAutoBackup.UseCompatibleTextRendering = true;
        btnSaveAutoBackup.UseVisualStyleBackColor = true;
        // 
        // chkEnableBackups
        // 
        chkEnableBackups.AutoSize = true;
        chkEnableBackups.Location = new Point(245, 107);
        chkEnableBackups.Name = "chkEnableBackups";
        chkEnableBackups.Size = new Size(108, 19);
        chkEnableBackups.TabIndex = 34;
        chkEnableBackups.Text = "Enable Backups";
        chkEnableBackups.UseVisualStyleBackColor = true;
        // 
        // lblProfileBackupsStats
        // 
        lblProfileBackupsStats.AutoSize = true;
        lblProfileBackupsStats.ForeColor = Color.FromArgb(0, 255, 185);
        lblProfileBackupsStats.Location = new Point(241, 45);
        lblProfileBackupsStats.Name = "lblProfileBackupsStats";
        lblProfileBackupsStats.Size = new Size(147, 30);
        lblProfileBackupsStats.TabIndex = 33;
        lblProfileBackupsStats.Text = "Total Backups: 12\r\nDisk Consumption: 200MB\r\n";
        lblProfileBackupsStats.Visible = false;
        // 
        // lblProfileBackupsInstruction
        // 
        lblProfileBackupsInstruction.AutoSize = true;
        lblProfileBackupsInstruction.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        lblProfileBackupsInstruction.ForeColor = SystemColors.ButtonHighlight;
        lblProfileBackupsInstruction.Location = new Point(45, 22);
        lblProfileBackupsInstruction.Name = "lblProfileBackupsInstruction";
        lblProfileBackupsInstruction.Size = new Size(169, 17);
        lblProfileBackupsInstruction.TabIndex = 32;
        lblProfileBackupsInstruction.Text = "Select a Profile to configure";
        // 
        // nudBackupMaxCount
        // 
        nudBackupMaxCount.BackColor = Color.FromArgb(6, 6, 48);
        nudBackupMaxCount.BorderStyle = BorderStyle.FixedSingle;
        nudBackupMaxCount.ForeColor = SystemColors.Window;
        nudBackupMaxCount.Location = new Point(245, 212);
        nudBackupMaxCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudBackupMaxCount.Name = "nudBackupMaxCount";
        nudBackupMaxCount.Size = new Size(63, 23);
        nudBackupMaxCount.TabIndex = 31;
        // 
        // lblBackupMaxCount
        // 
        lblBackupMaxCount.AutoSize = true;
        lblBackupMaxCount.Location = new Point(241, 194);
        lblBackupMaxCount.Name = "lblBackupMaxCount";
        lblBackupMaxCount.Size = new Size(170, 15);
        lblBackupMaxCount.TabIndex = 30;
        lblBackupMaxCount.Text = "Maximum Number of Backups";
        // 
        // lblBackupFrequency
        // 
        lblBackupFrequency.AutoSize = true;
        lblBackupFrequency.Location = new Point(241, 138);
        lblBackupFrequency.Name = "lblBackupFrequency";
        lblBackupFrequency.Size = new Size(155, 15);
        lblBackupFrequency.TabIndex = 29;
        lblBackupFrequency.Text = "Backup Interval (in minutes)";
        // 
        // nudBackupInterval
        // 
        nudBackupInterval.BackColor = Color.FromArgb(6, 6, 48);
        nudBackupInterval.BorderStyle = BorderStyle.FixedSingle;
        nudBackupInterval.ForeColor = SystemColors.Window;
        nudBackupInterval.Location = new Point(245, 156);
        nudBackupInterval.Maximum = new decimal(new int[] { 1080, 0, 0, 0 });
        nudBackupInterval.Name = "nudBackupInterval";
        nudBackupInterval.Size = new Size(63, 23);
        nudBackupInterval.TabIndex = 28;
        // 
        // lbxProfileSelectorAutoBackup
        // 
        lbxProfileSelectorAutoBackup.BackColor = Color.FromArgb(0, 0, 28);
        lbxProfileSelectorAutoBackup.BorderStyle = BorderStyle.FixedSingle;
        lbxProfileSelectorAutoBackup.ForeColor = SystemColors.Window;
        lbxProfileSelectorAutoBackup.FormattingEnabled = true;
        lbxProfileSelectorAutoBackup.ItemHeight = 15;
        lbxProfileSelectorAutoBackup.Location = new Point(45, 45);
        lbxProfileSelectorAutoBackup.Name = "lbxProfileSelectorAutoBackup";
        lbxProfileSelectorAutoBackup.Size = new Size(160, 287);
        lbxProfileSelectorAutoBackup.TabIndex = 27;
        // 
        // AutoBackupView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(lblAutoBackupChangesInfo);
        Controls.Add(btnSaveAutoBackup);
        Controls.Add(chkEnableBackups);
        Controls.Add(lblProfileBackupsStats);
        Controls.Add(lblProfileBackupsInstruction);
        Controls.Add(nudBackupMaxCount);
        Controls.Add(lblBackupMaxCount);
        Controls.Add(lblBackupFrequency);
        Controls.Add(nudBackupInterval);
        Controls.Add(lbxProfileSelectorAutoBackup);
        ForeColor = SystemColors.ButtonHighlight;
        Name = "AutoBackupView";
        Size = new Size(459, 384);
        ((System.ComponentModel.ISupportInitialize)nudBackupMaxCount).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudBackupInterval).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblAutoBackupChangesInfo;
    private Button btnSaveAutoBackup;
    private CheckBox chkEnableBackups;
    private Label lblProfileBackupsStats;
    private Label lblProfileBackupsInstruction;
    private NumericUpDown nudBackupMaxCount;
    private Label lblBackupMaxCount;
    private Label lblBackupFrequency;
    private NumericUpDown nudBackupInterval;
    private ListBox lbxProfileSelectorAutoBackup;
}
