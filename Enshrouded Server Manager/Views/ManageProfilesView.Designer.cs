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
        pnlProfileNameUpdate = new Panel();
        lblProfileNameInfo = new Label();
        btnSaveProfileName = new Button();
        txtEditProfileName = new TextBox();
        lblProfileNameInputHeading = new Label();
        pnlProfileNameUpdate.SuspendLayout();
        SuspendLayout();
        // 
        // pnlProfileNameUpdate
        // 
        pnlProfileNameUpdate.BorderStyle = BorderStyle.FixedSingle;
        pnlProfileNameUpdate.Controls.Add(lblProfileNameInfo);
        pnlProfileNameUpdate.Controls.Add(btnSaveProfileName);
        pnlProfileNameUpdate.Controls.Add(txtEditProfileName);
        pnlProfileNameUpdate.Controls.Add(lblProfileNameInputHeading);
        pnlProfileNameUpdate.Dock = DockStyle.Fill;
        pnlProfileNameUpdate.Location = new Point(0, 0);
        pnlProfileNameUpdate.Name = "pnlProfileNameUpdate";
        pnlProfileNameUpdate.Size = new Size(249, 156);
        pnlProfileNameUpdate.TabIndex = 26;
        // 
        // lblProfileNameInfo
        // 
        lblProfileNameInfo.AutoSize = true;
        lblProfileNameInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        lblProfileNameInfo.ForeColor = SystemColors.Info;
        lblProfileNameInfo.Location = new Point(40, 107);
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
        btnSaveProfileName.Location = new Point(59, 57);
        btnSaveProfileName.Name = "btnSaveProfileName";
        btnSaveProfileName.Size = new Size(128, 30);
        btnSaveProfileName.TabIndex = 3;
        btnSaveProfileName.Text = "Save Changes";
        btnSaveProfileName.UseCompatibleTextRendering = true;
        btnSaveProfileName.UseVisualStyleBackColor = true;
        btnSaveProfileName.EnabledChanged += btnSaveProfileName_EnabledChanged;
        // 
        // txtEditProfileName
        // 
        txtEditProfileName.BackColor = Color.FromArgb(6, 6, 48);
        txtEditProfileName.BorderStyle = BorderStyle.FixedSingle;
        txtEditProfileName.ForeColor = SystemColors.Window;
        txtEditProfileName.Location = new Point(40, 28);
        txtEditProfileName.Name = "txtEditProfileName";
        txtEditProfileName.Size = new Size(166, 23);
        txtEditProfileName.TabIndex = 2;
        // 
        // lblProfileNameInputHeading
        // 
        lblProfileNameInputHeading.AutoSize = true;
        lblProfileNameInputHeading.Location = new Point(40, 10);
        lblProfileNameInputHeading.Name = "lblProfileNameInputHeading";
        lblProfileNameInputHeading.Size = new Size(99, 15);
        lblProfileNameInputHeading.TabIndex = 0;
        lblProfileNameInputHeading.Text = "Edit Profile Name";
        // 
        // ManageProfilesView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(pnlProfileNameUpdate);
        ForeColor = SystemColors.ButtonHighlight;
        Name = "ManageProfilesView";
        Size = new Size(249, 156);
        pnlProfileNameUpdate.ResumeLayout(false);
        pnlProfileNameUpdate.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private Panel pnlProfileNameUpdate;
    private Label lblProfileNameInfo;
    private Button btnSaveProfileName;
    private TextBox txtEditProfileName;
    private Label lblProfileNameInputHeading;
}
