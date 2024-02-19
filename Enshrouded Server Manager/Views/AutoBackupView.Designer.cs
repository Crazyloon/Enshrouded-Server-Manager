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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoBackupView));
        lblAutoBackupChangesInfo = new Label();
        btnSaveAutoBackup = new Button();
        chkEnableBackups = new CheckBox();
        lblProfileBackupsStats = new Label();
        nudBackupMaxCount = new NumericUpDown();
        lblBackupMaxCount = new Label();
        lblBackupFrequency = new Label();
        nudBackupInterval = new NumericUpDown();
        btnOpenAutobackupFolder = new Button();
        label3 = new Label();
        label1 = new Label();
        ((System.ComponentModel.ISupportInitialize)nudBackupMaxCount).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudBackupInterval).BeginInit();
        SuspendLayout();
        // 
        // lblAutoBackupChangesInfo
        // 
        lblAutoBackupChangesInfo.AutoSize = true;
        lblAutoBackupChangesInfo.ForeColor = SystemColors.Info;
        lblAutoBackupChangesInfo.Location = new Point(100, 360);
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
        btnSaveAutoBackup.Location = new Point(263, 315);
        btnSaveAutoBackup.Name = "btnSaveAutoBackup";
        btnSaveAutoBackup.Size = new Size(128, 30);
        btnSaveAutoBackup.TabIndex = 35;
        btnSaveAutoBackup.Text = "Save Changes";
        btnSaveAutoBackup.UseCompatibleTextRendering = true;
        btnSaveAutoBackup.UseVisualStyleBackColor = true;
        btnSaveAutoBackup.EnabledChanged += btnSaveAutoBackup_EnabledChanged;
        // 
        // chkEnableBackups
        // 
        chkEnableBackups.AutoSize = true;
        chkEnableBackups.Location = new Point(253, 107);
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
        lblProfileBackupsStats.Location = new Point(249, 45);
        lblProfileBackupsStats.Name = "lblProfileBackupsStats";
        lblProfileBackupsStats.Size = new Size(147, 30);
        lblProfileBackupsStats.TabIndex = 33;
        lblProfileBackupsStats.Text = "Total Backups: 12\r\nDisk Consumption: 200MB\r\n";
        lblProfileBackupsStats.Visible = false;
        // 
        // nudBackupMaxCount
        // 
        nudBackupMaxCount.BackColor = Color.FromArgb(6, 6, 48);
        nudBackupMaxCount.BorderStyle = BorderStyle.FixedSingle;
        nudBackupMaxCount.ForeColor = SystemColors.Window;
        nudBackupMaxCount.Location = new Point(253, 212);
        nudBackupMaxCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudBackupMaxCount.Name = "nudBackupMaxCount";
        nudBackupMaxCount.Size = new Size(63, 23);
        nudBackupMaxCount.TabIndex = 31;
        // 
        // lblBackupMaxCount
        // 
        lblBackupMaxCount.AutoSize = true;
        lblBackupMaxCount.Location = new Point(249, 194);
        lblBackupMaxCount.Name = "lblBackupMaxCount";
        lblBackupMaxCount.Size = new Size(170, 15);
        lblBackupMaxCount.TabIndex = 30;
        lblBackupMaxCount.Text = "Maximum Number of Backups";
        // 
        // lblBackupFrequency
        // 
        lblBackupFrequency.AutoSize = true;
        lblBackupFrequency.Location = new Point(249, 138);
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
        nudBackupInterval.Location = new Point(253, 156);
        nudBackupInterval.Maximum = new decimal(new int[] { 1080, 0, 0, 0 });
        nudBackupInterval.Name = "nudBackupInterval";
        nudBackupInterval.Size = new Size(63, 23);
        nudBackupInterval.TabIndex = 28;
        // 
        // btnOpenAutobackupFolder
        // 
        btnOpenAutobackupFolder.Cursor = Cursors.Hand;
        btnOpenAutobackupFolder.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnOpenAutobackupFolder.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnOpenAutobackupFolder.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnOpenAutobackupFolder.FlatStyle = FlatStyle.Flat;
        btnOpenAutobackupFolder.ForeColor = SystemColors.Control;
        btnOpenAutobackupFolder.Location = new Point(68, 315);
        btnOpenAutobackupFolder.Name = "btnOpenAutobackupFolder";
        btnOpenAutobackupFolder.Size = new Size(128, 30);
        btnOpenAutobackupFolder.TabIndex = 38;
        btnOpenAutobackupFolder.Text = "Autobackup Folder";
        btnOpenAutobackupFolder.UseCompatibleTextRendering = true;
        btnOpenAutobackupFolder.UseVisualStyleBackColor = true;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Malgun Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
        label3.Location = new Point(32, 14);
        label3.Name = "label3";
        label3.Size = new Size(166, 21);
        label3.TabIndex = 39;
        label3.Text = "How Backups Work...";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.ForeColor = SystemColors.Info;
        label1.Location = new Point(32, 45);
        label1.Name = "label1";
        label1.Size = new Size(199, 225);
        label1.TabIndex = 37;
        label1.Text = resources.GetString("label1.Text");
        // 
        // AutoBackupView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(btnOpenAutobackupFolder);
        Controls.Add(label3);
        Controls.Add(label1);
        Controls.Add(lblAutoBackupChangesInfo);
        Controls.Add(btnSaveAutoBackup);
        Controls.Add(chkEnableBackups);
        Controls.Add(lblProfileBackupsStats);
        Controls.Add(nudBackupMaxCount);
        Controls.Add(lblBackupMaxCount);
        Controls.Add(lblBackupFrequency);
        Controls.Add(nudBackupInterval);
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
    private NumericUpDown nudBackupMaxCount;
    private Label lblBackupMaxCount;
    private Label lblBackupFrequency;
    private NumericUpDown nudBackupInterval;
    private Button btnOpenAutobackupFolder;
    private Label label3;
    private Label label1;
}
