namespace Enshrouded_Server_Manager;

partial class UserGroupSettingsView
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
        btnSaveSettings = new Button();
        lblServerMustBeStoppedMessage = new Label();
        lblAdminPassword = new Label();
        txtAdminPassword = new TextBox();
        lblAdminSettings = new Label();
        chkCanAdminKickBan = new CheckBox();
        chkCanAdminAccessInventories = new CheckBox();
        chkCanAdminEditBase = new CheckBox();
        chkCanAdminExtendBase = new CheckBox();
        nudAdminReservedSlots = new NumericUpDown();
        lblSlots = new Label();
        label1 = new Label();
        nudGuestReservedSlots = new NumericUpDown();
        chkCanGuestExtendBase = new CheckBox();
        chkCanGuestEditBase = new CheckBox();
        chkCanGuestAccessInventories = new CheckBox();
        chkCanGuestKickBan = new CheckBox();
        lblGuestSettings = new Label();
        txtGuestPassword = new TextBox();
        lblGuestPassword = new Label();
        label4 = new Label();
        nudFriendReservedSlots = new NumericUpDown();
        chkCanFriendExtendBase = new CheckBox();
        chkCanFriendEditBase = new CheckBox();
        chkCanFriendAccessInventories = new CheckBox();
        chkCanFriendKickBan = new CheckBox();
        lblFriendSettings = new Label();
        txtFriendPassword = new TextBox();
        lblFriendPassword = new Label();
        ((System.ComponentModel.ISupportInitialize)nudAdminReservedSlots).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudGuestReservedSlots).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudFriendReservedSlots).BeginInit();
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
        btnSaveSettings.TabIndex = 53;
        btnSaveSettings.Text = "Save Settings";
        btnSaveSettings.UseCompatibleTextRendering = true;
        btnSaveSettings.UseVisualStyleBackColor = true;
        btnSaveSettings.EnabledChanged += btnSaveSettings_EnabledChanged;
        // 
        // lblServerMustBeStoppedMessage
        // 
        lblServerMustBeStoppedMessage.AutoSize = true;
        lblServerMustBeStoppedMessage.ForeColor = SystemColors.Info;
        lblServerMustBeStoppedMessage.Location = new Point(258, 385);
        lblServerMustBeStoppedMessage.Name = "lblServerMustBeStoppedMessage";
        lblServerMustBeStoppedMessage.Size = new Size(229, 15);
        lblServerMustBeStoppedMessage.TabIndex = 60;
        lblServerMustBeStoppedMessage.Text = "Server must be stopped to update settings\r\n";
        lblServerMustBeStoppedMessage.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblAdminPassword
        // 
        lblAdminPassword.AutoSize = true;
        lblAdminPassword.Location = new Point(57, 90);
        lblAdminPassword.Name = "lblAdminPassword";
        lblAdminPassword.Size = new Size(57, 15);
        lblAdminPassword.TabIndex = 61;
        lblAdminPassword.Text = "Password";
        // 
        // txtAdminPassword
        // 
        txtAdminPassword.BackColor = Color.FromArgb(6, 6, 48);
        txtAdminPassword.BorderStyle = BorderStyle.FixedSingle;
        txtAdminPassword.ForeColor = SystemColors.Window;
        txtAdminPassword.Location = new Point(57, 108);
        txtAdminPassword.Name = "txtAdminPassword";
        txtAdminPassword.Size = new Size(147, 23);
        txtAdminPassword.TabIndex = 62;
        // 
        // lblAdminSettings
        // 
        lblAdminSettings.AutoSize = true;
        lblAdminSettings.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        lblAdminSettings.Location = new Point(57, 57);
        lblAdminSettings.Name = "lblAdminSettings";
        lblAdminSettings.Size = new Size(155, 20);
        lblAdminSettings.TabIndex = 63;
        lblAdminSettings.Text = "Admin Group Settings";
        // 
        // chkCanAdminKickBan
        // 
        chkCanAdminKickBan.AutoSize = true;
        chkCanAdminKickBan.Location = new Point(57, 192);
        chkCanAdminKickBan.Name = "chkCanAdminKickBan";
        chkCanAdminKickBan.Size = new Size(97, 19);
        chkCanAdminKickBan.TabIndex = 64;
        chkCanAdminKickBan.Text = "Can Kick/Ban";
        chkCanAdminKickBan.UseVisualStyleBackColor = true;
        // 
        // chkCanAdminAccessInventories
        // 
        chkCanAdminAccessInventories.AutoSize = true;
        chkCanAdminAccessInventories.Location = new Point(57, 217);
        chkCanAdminAccessInventories.Name = "chkCanAdminAccessInventories";
        chkCanAdminAccessInventories.Size = new Size(147, 19);
        chkCanAdminAccessInventories.TabIndex = 65;
        chkCanAdminAccessInventories.Text = "Can Access Inventories";
        chkCanAdminAccessInventories.UseVisualStyleBackColor = true;
        // 
        // chkCanAdminEditBase
        // 
        chkCanAdminEditBase.AutoSize = true;
        chkCanAdminEditBase.Location = new Point(57, 242);
        chkCanAdminEditBase.Name = "chkCanAdminEditBase";
        chkCanAdminEditBase.Size = new Size(97, 19);
        chkCanAdminEditBase.TabIndex = 66;
        chkCanAdminEditBase.Text = "Can Edit Base";
        chkCanAdminEditBase.UseVisualStyleBackColor = true;
        // 
        // chkCanAdminExtendBase
        // 
        chkCanAdminExtendBase.AutoSize = true;
        chkCanAdminExtendBase.Location = new Point(57, 267);
        chkCanAdminExtendBase.Name = "chkCanAdminExtendBase";
        chkCanAdminExtendBase.Size = new Size(112, 19);
        chkCanAdminExtendBase.TabIndex = 67;
        chkCanAdminExtendBase.Text = "Can Extend Base";
        chkCanAdminExtendBase.UseVisualStyleBackColor = true;
        // 
        // nudAdminReservedSlots
        // 
        nudAdminReservedSlots.BackColor = Color.FromArgb(6, 6, 48);
        nudAdminReservedSlots.BorderStyle = BorderStyle.FixedSingle;
        nudAdminReservedSlots.ForeColor = SystemColors.Window;
        nudAdminReservedSlots.Location = new Point(57, 163);
        nudAdminReservedSlots.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
        nudAdminReservedSlots.Name = "nudAdminReservedSlots";
        nudAdminReservedSlots.Size = new Size(35, 23);
        nudAdminReservedSlots.TabIndex = 68;
        // 
        // lblSlots
        // 
        lblSlots.AutoSize = true;
        lblSlots.Location = new Point(57, 145);
        lblSlots.Name = "lblSlots";
        lblSlots.Size = new Size(82, 15);
        lblSlots.TabIndex = 69;
        lblSlots.Text = "Reserved Slots";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(459, 145);
        label1.Name = "label1";
        label1.Size = new Size(82, 15);
        label1.TabIndex = 96;
        label1.Text = "Reserved Slots";
        // 
        // nudGuestReservedSlots
        // 
        nudGuestReservedSlots.BackColor = Color.FromArgb(6, 6, 48);
        nudGuestReservedSlots.BorderStyle = BorderStyle.FixedSingle;
        nudGuestReservedSlots.ForeColor = SystemColors.Window;
        nudGuestReservedSlots.Location = new Point(459, 163);
        nudGuestReservedSlots.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
        nudGuestReservedSlots.Name = "nudGuestReservedSlots";
        nudGuestReservedSlots.Size = new Size(35, 23);
        nudGuestReservedSlots.TabIndex = 95;
        // 
        // chkCanGuestExtendBase
        // 
        chkCanGuestExtendBase.AutoSize = true;
        chkCanGuestExtendBase.Location = new Point(459, 267);
        chkCanGuestExtendBase.Name = "chkCanGuestExtendBase";
        chkCanGuestExtendBase.Size = new Size(112, 19);
        chkCanGuestExtendBase.TabIndex = 94;
        chkCanGuestExtendBase.Text = "Can Extend Base";
        chkCanGuestExtendBase.UseVisualStyleBackColor = true;
        // 
        // chkCanGuestEditBase
        // 
        chkCanGuestEditBase.AutoSize = true;
        chkCanGuestEditBase.Location = new Point(459, 242);
        chkCanGuestEditBase.Name = "chkCanGuestEditBase";
        chkCanGuestEditBase.Size = new Size(97, 19);
        chkCanGuestEditBase.TabIndex = 93;
        chkCanGuestEditBase.Text = "Can Edit Base";
        chkCanGuestEditBase.UseVisualStyleBackColor = true;
        // 
        // chkCanGuestAccessInventories
        // 
        chkCanGuestAccessInventories.AutoSize = true;
        chkCanGuestAccessInventories.Location = new Point(459, 217);
        chkCanGuestAccessInventories.Name = "chkCanGuestAccessInventories";
        chkCanGuestAccessInventories.Size = new Size(147, 19);
        chkCanGuestAccessInventories.TabIndex = 92;
        chkCanGuestAccessInventories.Text = "Can Access Inventories";
        chkCanGuestAccessInventories.UseVisualStyleBackColor = true;
        // 
        // chkCanGuestKickBan
        // 
        chkCanGuestKickBan.AutoSize = true;
        chkCanGuestKickBan.Location = new Point(459, 192);
        chkCanGuestKickBan.Name = "chkCanGuestKickBan";
        chkCanGuestKickBan.Size = new Size(97, 19);
        chkCanGuestKickBan.TabIndex = 91;
        chkCanGuestKickBan.Text = "Can Kick/Ban";
        chkCanGuestKickBan.UseVisualStyleBackColor = true;
        // 
        // lblGuestSettings
        // 
        lblGuestSettings.AutoSize = true;
        lblGuestSettings.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        lblGuestSettings.Location = new Point(459, 57);
        lblGuestSettings.Name = "lblGuestSettings";
        lblGuestSettings.Size = new Size(148, 20);
        lblGuestSettings.TabIndex = 90;
        lblGuestSettings.Text = "Guest Group Settings";
        // 
        // txtGuestPassword
        // 
        txtGuestPassword.BackColor = Color.FromArgb(6, 6, 48);
        txtGuestPassword.BorderStyle = BorderStyle.FixedSingle;
        txtGuestPassword.ForeColor = SystemColors.Window;
        txtGuestPassword.Location = new Point(459, 108);
        txtGuestPassword.Name = "txtGuestPassword";
        txtGuestPassword.Size = new Size(147, 23);
        txtGuestPassword.TabIndex = 89;
        // 
        // lblGuestPassword
        // 
        lblGuestPassword.AutoSize = true;
        lblGuestPassword.Location = new Point(459, 90);
        lblGuestPassword.Name = "lblGuestPassword";
        lblGuestPassword.Size = new Size(57, 15);
        lblGuestPassword.TabIndex = 88;
        lblGuestPassword.Text = "Password";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(258, 145);
        label4.Name = "label4";
        label4.Size = new Size(82, 15);
        label4.TabIndex = 106;
        label4.Text = "Reserved Slots";
        // 
        // nudFriendReservedSlots
        // 
        nudFriendReservedSlots.BackColor = Color.FromArgb(6, 6, 48);
        nudFriendReservedSlots.BorderStyle = BorderStyle.FixedSingle;
        nudFriendReservedSlots.ForeColor = SystemColors.Window;
        nudFriendReservedSlots.Location = new Point(258, 163);
        nudFriendReservedSlots.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
        nudFriendReservedSlots.Name = "nudFriendReservedSlots";
        nudFriendReservedSlots.Size = new Size(35, 23);
        nudFriendReservedSlots.TabIndex = 105;
        // 
        // chkCanFriendExtendBase
        // 
        chkCanFriendExtendBase.AutoSize = true;
        chkCanFriendExtendBase.Location = new Point(258, 267);
        chkCanFriendExtendBase.Name = "chkCanFriendExtendBase";
        chkCanFriendExtendBase.Size = new Size(112, 19);
        chkCanFriendExtendBase.TabIndex = 104;
        chkCanFriendExtendBase.Text = "Can Extend Base";
        chkCanFriendExtendBase.UseVisualStyleBackColor = true;
        // 
        // chkCanFriendEditBase
        // 
        chkCanFriendEditBase.AutoSize = true;
        chkCanFriendEditBase.Location = new Point(258, 242);
        chkCanFriendEditBase.Name = "chkCanFriendEditBase";
        chkCanFriendEditBase.Size = new Size(97, 19);
        chkCanFriendEditBase.TabIndex = 103;
        chkCanFriendEditBase.Text = "Can Edit Base";
        chkCanFriendEditBase.UseVisualStyleBackColor = true;
        // 
        // chkCanFriendAccessInventories
        // 
        chkCanFriendAccessInventories.AutoSize = true;
        chkCanFriendAccessInventories.Location = new Point(258, 217);
        chkCanFriendAccessInventories.Name = "chkCanFriendAccessInventories";
        chkCanFriendAccessInventories.Size = new Size(147, 19);
        chkCanFriendAccessInventories.TabIndex = 102;
        chkCanFriendAccessInventories.Text = "Can Access Inventories";
        chkCanFriendAccessInventories.UseVisualStyleBackColor = true;
        // 
        // chkCanFriendKickBan
        // 
        chkCanFriendKickBan.AutoSize = true;
        chkCanFriendKickBan.Location = new Point(258, 192);
        chkCanFriendKickBan.Name = "chkCanFriendKickBan";
        chkCanFriendKickBan.Size = new Size(97, 19);
        chkCanFriendKickBan.TabIndex = 101;
        chkCanFriendKickBan.Text = "Can Kick/Ban";
        chkCanFriendKickBan.UseVisualStyleBackColor = true;
        // 
        // lblFriendSettings
        // 
        lblFriendSettings.AutoSize = true;
        lblFriendSettings.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        lblFriendSettings.Location = new Point(258, 57);
        lblFriendSettings.Name = "lblFriendSettings";
        lblFriendSettings.Size = new Size(152, 20);
        lblFriendSettings.TabIndex = 100;
        lblFriendSettings.Text = "Friend Group Settings";
        // 
        // txtFriendPassword
        // 
        txtFriendPassword.BackColor = Color.FromArgb(6, 6, 48);
        txtFriendPassword.BorderStyle = BorderStyle.FixedSingle;
        txtFriendPassword.ForeColor = SystemColors.Window;
        txtFriendPassword.Location = new Point(258, 108);
        txtFriendPassword.Name = "txtFriendPassword";
        txtFriendPassword.Size = new Size(147, 23);
        txtFriendPassword.TabIndex = 99;
        // 
        // lblFriendPassword
        // 
        lblFriendPassword.AutoSize = true;
        lblFriendPassword.Location = new Point(258, 90);
        lblFriendPassword.Name = "lblFriendPassword";
        lblFriendPassword.Size = new Size(57, 15);
        lblFriendPassword.TabIndex = 98;
        lblFriendPassword.Text = "Password";
        // 
        // UserGroupSettingsView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(label4);
        Controls.Add(nudFriendReservedSlots);
        Controls.Add(chkCanFriendExtendBase);
        Controls.Add(chkCanFriendEditBase);
        Controls.Add(chkCanFriendAccessInventories);
        Controls.Add(chkCanFriendKickBan);
        Controls.Add(lblFriendSettings);
        Controls.Add(txtFriendPassword);
        Controls.Add(lblFriendPassword);
        Controls.Add(label1);
        Controls.Add(nudGuestReservedSlots);
        Controls.Add(chkCanGuestExtendBase);
        Controls.Add(chkCanGuestEditBase);
        Controls.Add(chkCanGuestAccessInventories);
        Controls.Add(chkCanGuestKickBan);
        Controls.Add(lblGuestSettings);
        Controls.Add(txtGuestPassword);
        Controls.Add(lblGuestPassword);
        Controls.Add(lblSlots);
        Controls.Add(nudAdminReservedSlots);
        Controls.Add(chkCanAdminExtendBase);
        Controls.Add(chkCanAdminEditBase);
        Controls.Add(chkCanAdminAccessInventories);
        Controls.Add(chkCanAdminKickBan);
        Controls.Add(lblAdminSettings);
        Controls.Add(txtAdminPassword);
        Controls.Add(lblAdminPassword);
        Controls.Add(lblServerMustBeStoppedMessage);
        Controls.Add(btnSaveSettings);
        ForeColor = SystemColors.ButtonHighlight;
        Name = "UserGroupSettingsView";
        Size = new Size(744, 411);
        ((System.ComponentModel.ISupportInitialize)nudAdminReservedSlots).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudGuestReservedSlots).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudFriendReservedSlots).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Button btnSaveSettings;
    private Label lblServerMustBeStoppedMessage;
    private Label lblAdminPassword;
    private TextBox txtAdminPassword;
    private Label lblAdminSettings;
    private CheckBox chkCanAdminKickBan;
    private CheckBox chkCanAdminAccessInventories;
    private CheckBox chkCanAdminEditBase;
    private CheckBox chkCanAdminExtendBase;
    private NumericUpDown nudAdminReservedSlots;
    private Label lblSlots;
    private Label label1;
    private NumericUpDown nudGuestReservedSlots;
    private CheckBox chkCanGuestExtendBase;
    private CheckBox chkCanGuestEditBase;
    private CheckBox chkCanGuestAccessInventories;
    private CheckBox chkCanGuestKickBan;
    private Label lblGuestSettings;
    private TextBox txtGuestPassword;
    private Label lblGuestPassword;
    private Label label4;
    private NumericUpDown nudFriendReservedSlots;
    private CheckBox chkCanFriendExtendBase;
    private CheckBox chkCanFriendEditBase;
    private CheckBox chkCanFriendAccessInventories;
    private CheckBox chkCanFriendKickBan;
    private Label lblFriendSettings;
    private TextBox txtFriendPassword;
    private Label lblFriendPassword;
}
