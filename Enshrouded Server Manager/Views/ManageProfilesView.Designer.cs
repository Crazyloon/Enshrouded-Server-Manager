namespace Enshrouded_Server_Manager;

partial class ManageProfilesView
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
        lblManageProfileHeading = new Label();
        lblAddNewProfile = new Label();
        pnlProfileNameUpdate = new Panel();
        lblProfileNameInfo = new Label();
        btnSaveProfileName = new Button();
        txtEditProfileName = new TextBox();
        lblProfileNameInputHeading = new Label();
        btnAddNewProfile = new Button();
        lbxServerProfiles = new ListBox();
        btnDeleteProfile = new Button();
        pnlProfileNameUpdate.SuspendLayout();
        SuspendLayout();
        // 
        // lblManageProfileHeading
        // 
        lblManageProfileHeading.AutoSize = true;
        lblManageProfileHeading.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        lblManageProfileHeading.ForeColor = SystemColors.ButtonHighlight;
        lblManageProfileHeading.Location = new Point(45, 22);
        lblManageProfileHeading.Name = "lblManageProfileHeading";
        lblManageProfileHeading.Size = new Size(161, 17);
        lblManageProfileHeading.TabIndex = 29;
        lblManageProfileHeading.Text = "Select a Profile to manage";
        // 
        // lblAddNewProfile
        // 
        lblAddNewProfile.AutoSize = true;
        lblAddNewProfile.Location = new Point(297, 74);
        lblAddNewProfile.Name = "lblAddNewProfile";
        lblAddNewProfile.Size = new Size(93, 15);
        lblAddNewProfile.TabIndex = 28;
        lblAddNewProfile.Text = "Add New Profile";
        // 
        // pnlProfileNameUpdate
        // 
        pnlProfileNameUpdate.BorderStyle = BorderStyle.FixedSingle;
        pnlProfileNameUpdate.Controls.Add(lblProfileNameInfo);
        pnlProfileNameUpdate.Controls.Add(btnSaveProfileName);
        pnlProfileNameUpdate.Controls.Add(txtEditProfileName);
        pnlProfileNameUpdate.Controls.Add(lblProfileNameInputHeading);
        pnlProfileNameUpdate.Location = new Point(231, 121);
        pnlProfileNameUpdate.Name = "pnlProfileNameUpdate";
        pnlProfileNameUpdate.Size = new Size(186, 149);
        pnlProfileNameUpdate.TabIndex = 26;
        // 
        // lblProfileNameInfo
        // 
        lblProfileNameInfo.AutoSize = true;
        lblProfileNameInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        lblProfileNameInfo.ForeColor = SystemColors.Info;
        lblProfileNameInfo.Location = new Point(10, 107);
        lblProfileNameInfo.Name = "lblProfileNameInfo";
        lblProfileNameInfo.Size = new Size(166, 30);
        lblProfileNameInfo.TabIndex = 5;
        lblProfileNameInfo.Text = "Only characters allowed in the\r\nWindows File System are valid";
        // 
        // btnSaveProfileName
        // 
        btnSaveProfileName.Cursor = Cursors.Hand;
        btnSaveProfileName.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnSaveProfileName.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnSaveProfileName.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnSaveProfileName.FlatStyle = FlatStyle.Flat;
        btnSaveProfileName.ForeColor = Color.FromArgb(0, 255, 185);
        btnSaveProfileName.Location = new Point(30, 57);
        btnSaveProfileName.Name = "btnSaveProfileName";
        btnSaveProfileName.Size = new Size(128, 30);
        btnSaveProfileName.TabIndex = 3;
        btnSaveProfileName.Text = "Save Changes";
        btnSaveProfileName.UseCompatibleTextRendering = true;
        btnSaveProfileName.UseVisualStyleBackColor = true;
        // 
        // txtEditProfileName
        // 
        txtEditProfileName.BackColor = Color.FromArgb(6, 6, 48);
        txtEditProfileName.BorderStyle = BorderStyle.FixedSingle;
        txtEditProfileName.ForeColor = SystemColors.Window;
        txtEditProfileName.Location = new Point(10, 28);
        txtEditProfileName.Name = "txtEditProfileName";
        txtEditProfileName.Size = new Size(166, 23);
        txtEditProfileName.TabIndex = 2;
        // 
        // lblProfileNameInputHeading
        // 
        lblProfileNameInputHeading.AutoSize = true;
        lblProfileNameInputHeading.Location = new Point(10, 10);
        lblProfileNameInputHeading.Name = "lblProfileNameInputHeading";
        lblProfileNameInputHeading.Size = new Size(99, 15);
        lblProfileNameInputHeading.TabIndex = 0;
        lblProfileNameInputHeading.Text = "Edit Profile Name";
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
        btnAddNewProfile.Location = new Point(262, 66);
        btnAddNewProfile.Margin = new Padding(0);
        btnAddNewProfile.Name = "btnAddNewProfile";
        btnAddNewProfile.Padding = new Padding(0, 2, 0, 0);
        btnAddNewProfile.Size = new Size(30, 30);
        btnAddNewProfile.TabIndex = 25;
        btnAddNewProfile.Text = "+";
        btnAddNewProfile.UseCompatibleTextRendering = true;
        btnAddNewProfile.UseVisualStyleBackColor = true;
        // 
        // lbxServerProfiles
        // 
        lbxServerProfiles.BackColor = Color.FromArgb(0, 0, 28);
        lbxServerProfiles.BorderStyle = BorderStyle.FixedSingle;
        lbxServerProfiles.ForeColor = SystemColors.Window;
        lbxServerProfiles.FormattingEnabled = true;
        lbxServerProfiles.ItemHeight = 15;
        lbxServerProfiles.Location = new Point(45, 45);
        lbxServerProfiles.Name = "lbxServerProfiles";
        lbxServerProfiles.Size = new Size(160, 287);
        lbxServerProfiles.TabIndex = 24;
        // 
        // btnDeleteProfile
        // 
        btnDeleteProfile.BackColor = Color.Red;
        btnDeleteProfile.FlatAppearance.BorderColor = Color.Red;
        btnDeleteProfile.FlatStyle = FlatStyle.Popup;
        btnDeleteProfile.ForeColor = SystemColors.ControlLightLight;
        btnDeleteProfile.Location = new Point(262, 301);
        btnDeleteProfile.Name = "btnDeleteProfile";
        btnDeleteProfile.Size = new Size(128, 31);
        btnDeleteProfile.TabIndex = 27;
        btnDeleteProfile.Text = "Delete Selected";
        btnDeleteProfile.UseVisualStyleBackColor = false;
        // 
        // ManageProfilesView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(lblManageProfileHeading);
        Controls.Add(lblAddNewProfile);
        Controls.Add(pnlProfileNameUpdate);
        Controls.Add(btnAddNewProfile);
        Controls.Add(lbxServerProfiles);
        Controls.Add(btnDeleteProfile);
        ForeColor = SystemColors.ButtonHighlight;
        Name = "ManageProfilesView";
        Size = new Size(459, 384);
        pnlProfileNameUpdate.ResumeLayout(false);
        pnlProfileNameUpdate.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblManageProfileHeading;
    private Label lblAddNewProfile;
    private Panel pnlProfileNameUpdate;
    private Label lblProfileNameInfo;
    private Button btnSaveProfileName;
    private TextBox txtEditProfileName;
    private Label lblProfileNameInputHeading;
    private Button btnAddNewProfile;
    private ListBox lbxServerProfiles;
    private Button btnDeleteProfile;
}
