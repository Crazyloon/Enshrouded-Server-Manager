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
        txtPassword = new TextBox();
        lblAdminSettings = new Label();
        chkCanKickBan = new CheckBox();
        chkCanAccessInventories = new CheckBox();
        chkCanEditBase = new CheckBox();
        chkCanExtendBase = new CheckBox();
        nudReservedSlots = new NumericUpDown();
        lblSlots = new Label();
        cbxUserGroup = new ComboBox();
        ((System.ComponentModel.ISupportInitialize)nudReservedSlots).BeginInit();
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
        lblAdminPassword.Location = new Point(258, 115);
        lblAdminPassword.Name = "lblAdminPassword";
        lblAdminPassword.Size = new Size(57, 15);
        lblAdminPassword.TabIndex = 61;
        lblAdminPassword.Text = "Password";
        // 
        // txtPassword
        // 
        txtPassword.BackColor = Color.FromArgb(6, 6, 48);
        txtPassword.BorderStyle = BorderStyle.FixedSingle;
        txtPassword.ForeColor = SystemColors.Window;
        txtPassword.Location = new Point(258, 133);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(147, 23);
        txtPassword.TabIndex = 62;
        // 
        // lblAdminSettings
        // 
        lblAdminSettings.AutoSize = true;
        lblAdminSettings.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        lblAdminSettings.Location = new Point(258, 57);
        lblAdminSettings.Name = "lblAdminSettings";
        lblAdminSettings.Size = new Size(140, 20);
        lblAdminSettings.TabIndex = 63;
        lblAdminSettings.Text = "User Group Settings";
        // 
        // chkCanKickBan
        // 
        chkCanKickBan.AutoSize = true;
        chkCanKickBan.Location = new Point(258, 217);
        chkCanKickBan.Name = "chkCanKickBan";
        chkCanKickBan.Size = new Size(97, 19);
        chkCanKickBan.TabIndex = 64;
        chkCanKickBan.Text = "Can Kick/Ban";
        chkCanKickBan.UseVisualStyleBackColor = true;
        // 
        // chkCanAccessInventories
        // 
        chkCanAccessInventories.AutoSize = true;
        chkCanAccessInventories.Location = new Point(258, 242);
        chkCanAccessInventories.Name = "chkCanAccessInventories";
        chkCanAccessInventories.Size = new Size(147, 19);
        chkCanAccessInventories.TabIndex = 65;
        chkCanAccessInventories.Text = "Can Access Inventories";
        chkCanAccessInventories.UseVisualStyleBackColor = true;
        // 
        // chkCanEditBase
        // 
        chkCanEditBase.AutoSize = true;
        chkCanEditBase.Location = new Point(258, 267);
        chkCanEditBase.Name = "chkCanEditBase";
        chkCanEditBase.Size = new Size(97, 19);
        chkCanEditBase.TabIndex = 66;
        chkCanEditBase.Text = "Can Edit Base";
        chkCanEditBase.UseVisualStyleBackColor = true;
        // 
        // chkCanExtendBase
        // 
        chkCanExtendBase.AutoSize = true;
        chkCanExtendBase.Location = new Point(258, 292);
        chkCanExtendBase.Name = "chkCanExtendBase";
        chkCanExtendBase.Size = new Size(113, 19);
        chkCanExtendBase.TabIndex = 67;
        chkCanExtendBase.Text = "Can Extend Base";
        chkCanExtendBase.UseVisualStyleBackColor = true;
        // 
        // nudReservedSlots
        // 
        nudReservedSlots.BackColor = Color.FromArgb(6, 6, 48);
        nudReservedSlots.BorderStyle = BorderStyle.FixedSingle;
        nudReservedSlots.ForeColor = SystemColors.Window;
        nudReservedSlots.Location = new Point(258, 188);
        nudReservedSlots.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
        nudReservedSlots.Name = "nudReservedSlots";
        nudReservedSlots.Size = new Size(35, 23);
        nudReservedSlots.TabIndex = 68;
        // 
        // lblSlots
        // 
        lblSlots.AutoSize = true;
        lblSlots.Location = new Point(258, 170);
        lblSlots.Name = "lblSlots";
        lblSlots.Size = new Size(82, 15);
        lblSlots.TabIndex = 69;
        lblSlots.Text = "Reserved Slots";
        // 
        // cbxUserGroup
        // 
        cbxUserGroup.Anchor = AnchorStyles.Top;
        cbxUserGroup.BackColor = Color.FromArgb(6, 6, 48);
        cbxUserGroup.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxUserGroup.FlatStyle = FlatStyle.Flat;
        cbxUserGroup.ForeColor = SystemColors.Window;
        cbxUserGroup.FormattingEnabled = true;
        cbxUserGroup.Location = new Point(258, 80);
        cbxUserGroup.Name = "cbxUserGroup";
        cbxUserGroup.Size = new Size(175, 23);
        cbxUserGroup.TabIndex = 87;
        // 
        // UserGroupSettingsView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(cbxUserGroup);
        Controls.Add(lblSlots);
        Controls.Add(nudReservedSlots);
        Controls.Add(chkCanExtendBase);
        Controls.Add(chkCanEditBase);
        Controls.Add(chkCanAccessInventories);
        Controls.Add(chkCanKickBan);
        Controls.Add(lblAdminSettings);
        Controls.Add(txtPassword);
        Controls.Add(lblAdminPassword);
        Controls.Add(lblServerMustBeStoppedMessage);
        Controls.Add(btnSaveSettings);
        ForeColor = SystemColors.ButtonHighlight;
        Name = "UserGroupSettingsView";
        Size = new Size(744, 411);
        ((System.ComponentModel.ISupportInitialize)nudReservedSlots).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Button btnSaveSettings;
    private Label lblServerMustBeStoppedMessage;
    private Label lblAdminPassword;
    private TextBox txtPassword;
    private Label lblAdminSettings;
    private CheckBox chkCanKickBan;
    private CheckBox chkCanAccessInventories;
    private CheckBox chkCanEditBase;
    private CheckBox chkCanExtendBase;
    private NumericUpDown nudReservedSlots;
    private Label lblSlots;
    private ComboBox cbxUserGroup;
}
