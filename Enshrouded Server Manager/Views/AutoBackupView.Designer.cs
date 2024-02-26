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
        components = new System.ComponentModel.Container();
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
        lblBackupSummaryTitle = new Label();
        lblBackupSummary = new Label();
        ttpToolTip = new ToolTip(components);
        ((System.ComponentModel.ISupportInitialize)nudBackupMaxCount).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudBackupInterval).BeginInit();
        SuspendLayout();
        // 
        // lblAutoBackupChangesInfo
        // 
        lblAutoBackupChangesInfo.AutoSize = true;
        lblAutoBackupChangesInfo.ForeColor = SystemColors.Info;
        lblAutoBackupChangesInfo.Location = new Point(258, 385);
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
        btnSaveAutoBackup.Location = new Point(410, 342);
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
        chkEnableBackups.Location = new Point(400, 124);
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
        lblProfileBackupsStats.Location = new Point(396, 62);
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
        nudBackupMaxCount.Location = new Point(400, 229);
        nudBackupMaxCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudBackupMaxCount.Name = "nudBackupMaxCount";
        nudBackupMaxCount.Size = new Size(63, 23);
        nudBackupMaxCount.TabIndex = 31;
        // 
        // lblBackupMaxCount
        // 
        lblBackupMaxCount.AutoSize = true;
        lblBackupMaxCount.Location = new Point(396, 211);
        lblBackupMaxCount.Name = "lblBackupMaxCount";
        lblBackupMaxCount.Size = new Size(170, 15);
        lblBackupMaxCount.TabIndex = 30;
        lblBackupMaxCount.Text = "Maximum Number of Backups";
        // 
        // lblBackupFrequency
        // 
        lblBackupFrequency.AutoSize = true;
        lblBackupFrequency.Location = new Point(396, 155);
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
        nudBackupInterval.Location = new Point(400, 173);
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
        btnOpenAutobackupFolder.Location = new Point(207, 342);
        btnOpenAutobackupFolder.Name = "btnOpenAutobackupFolder";
        btnOpenAutobackupFolder.Size = new Size(128, 30);
        btnOpenAutobackupFolder.TabIndex = 38;
        btnOpenAutobackupFolder.Text = "Autobackup Folder";
        ttpToolTip.SetToolTip(btnOpenAutobackupFolder, "Opens the Autobackup folder for this profile");
        btnOpenAutobackupFolder.UseCompatibleTextRendering = true;
        btnOpenAutobackupFolder.UseVisualStyleBackColor = true;
        // 
        // lblBackupSummaryTitle
        // 
        lblBackupSummaryTitle.AutoSize = true;
        lblBackupSummaryTitle.Font = new Font("Malgun Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
        lblBackupSummaryTitle.Location = new Point(179, 31);
        lblBackupSummaryTitle.Name = "lblBackupSummaryTitle";
        lblBackupSummaryTitle.Size = new Size(166, 21);
        lblBackupSummaryTitle.TabIndex = 39;
        lblBackupSummaryTitle.Text = "How Backups Work...";
        // 
        // lblBackupSummary
        // 
        lblBackupSummary.AutoSize = true;
        lblBackupSummary.ForeColor = SystemColors.Info;
        lblBackupSummary.Location = new Point(179, 62);
        lblBackupSummary.Name = "lblBackupSummary";
        lblBackupSummary.Size = new Size(199, 225);
        lblBackupSummary.TabIndex = 37;
        lblBackupSummary.Text = resources.GetString("lblBackupSummary.Text");
        // 
        // AutoBackupView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(btnOpenAutobackupFolder);
        Controls.Add(lblBackupSummaryTitle);
        Controls.Add(lblBackupSummary);
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
        Size = new Size(744, 411);
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
    private Label lblBackupSummaryTitle;
    private Label lblBackupSummary;
    private ToolTip ttpToolTip;
}
