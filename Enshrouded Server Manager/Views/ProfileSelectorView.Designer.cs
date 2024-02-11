namespace Enshrouded_Server_Manager.Views;

partial class ProfileSelectorView
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
        cbxProfileSelectionComboBox = new ComboBox();
        lblProfileSelectionLabel = new Label();
        btnAddNewProfile = new Button();
        btnDeleteProfile = new Button();
        btnRenameProfile = new Button();
        SuspendLayout();
        // 
        // cbxProfileSelectionComboBox
        // 
        cbxProfileSelectionComboBox.Anchor = AnchorStyles.Top;
        cbxProfileSelectionComboBox.BackColor = SystemColors.Window;
        cbxProfileSelectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxProfileSelectionComboBox.FlatStyle = FlatStyle.System;
        cbxProfileSelectionComboBox.FormattingEnabled = true;
        cbxProfileSelectionComboBox.Location = new Point(109, 11);
        cbxProfileSelectionComboBox.Name = "cbxProfileSelectionComboBox";
        cbxProfileSelectionComboBox.Size = new Size(175, 23);
        cbxProfileSelectionComboBox.TabIndex = 2;
        // 
        // lblProfileSelectionLabel
        // 
        lblProfileSelectionLabel.Anchor = AnchorStyles.Top;
        lblProfileSelectionLabel.AutoSize = true;
        lblProfileSelectionLabel.ForeColor = SystemColors.ButtonHighlight;
        lblProfileSelectionLabel.Location = new Point(29, 15);
        lblProfileSelectionLabel.Name = "lblProfileSelectionLabel";
        lblProfileSelectionLabel.Size = new Size(76, 15);
        lblProfileSelectionLabel.TabIndex = 3;
        lblProfileSelectionLabel.Text = "Server Profile";
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
        btnAddNewProfile.Location = new Point(300, 5);
        btnAddNewProfile.Margin = new Padding(0);
        btnAddNewProfile.Name = "btnAddNewProfile";
        btnAddNewProfile.Padding = new Padding(0, 2, 0, 0);
        btnAddNewProfile.Size = new Size(30, 30);
        btnAddNewProfile.TabIndex = 4;
        btnAddNewProfile.Text = "+";
        btnAddNewProfile.UseCompatibleTextRendering = true;
        btnAddNewProfile.UseVisualStyleBackColor = true;
        // 
        // btnDeleteProfile
        // 
        btnDeleteProfile.Anchor = AnchorStyles.None;
        btnDeleteProfile.BackColor = Color.Red;
        btnDeleteProfile.BackgroundImageLayout = ImageLayout.None;
        btnDeleteProfile.Cursor = Cursors.Hand;
        btnDeleteProfile.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnDeleteProfile.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnDeleteProfile.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnDeleteProfile.FlatStyle = FlatStyle.Flat;
        btnDeleteProfile.Font = new Font("Consolas", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
        btnDeleteProfile.ForeColor = SystemColors.ButtonHighlight;
        btnDeleteProfile.Location = new Point(340, 5);
        btnDeleteProfile.Margin = new Padding(0);
        btnDeleteProfile.Name = "btnDeleteProfile";
        btnDeleteProfile.Padding = new Padding(0, 2, 0, 0);
        btnDeleteProfile.Size = new Size(30, 30);
        btnDeleteProfile.TabIndex = 5;
        btnDeleteProfile.Text = "-";
        btnDeleteProfile.UseCompatibleTextRendering = true;
        btnDeleteProfile.UseVisualStyleBackColor = false;
        // 
        // btnRenameProfile
        // 
        btnRenameProfile.Anchor = AnchorStyles.None;
        btnRenameProfile.BackgroundImageLayout = ImageLayout.None;
        btnRenameProfile.Cursor = Cursors.Hand;
        btnRenameProfile.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnRenameProfile.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnRenameProfile.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnRenameProfile.FlatStyle = FlatStyle.Flat;
        btnRenameProfile.Font = new Font("Malgun Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        btnRenameProfile.ForeColor = SystemColors.ControlLightLight;
        btnRenameProfile.Location = new Point(384, 5);
        btnRenameProfile.Margin = new Padding(0);
        btnRenameProfile.Name = "btnRenameProfile";
        btnRenameProfile.Padding = new Padding(0, 2, 0, 0);
        btnRenameProfile.Size = new Size(88, 30);
        btnRenameProfile.TabIndex = 6;
        btnRenameProfile.Text = "Rename";
        btnRenameProfile.UseCompatibleTextRendering = true;
        btnRenameProfile.UseVisualStyleBackColor = true;
        // 
        // ProfileSelectorView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(btnRenameProfile);
        Controls.Add(btnDeleteProfile);
        Controls.Add(btnAddNewProfile);
        Controls.Add(cbxProfileSelectionComboBox);
        Controls.Add(lblProfileSelectionLabel);
        Name = "ProfileSelectorView";
        Size = new Size(505, 40);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ComboBox cbxProfileSelectionComboBox;
    private Label lblProfileSelectionLabel;
    private Button btnAddNewProfile;
    private Button btnDeleteProfile;
    private Button btnRenameProfile;
}
