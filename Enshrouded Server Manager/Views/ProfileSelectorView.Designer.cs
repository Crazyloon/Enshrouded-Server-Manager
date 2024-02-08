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
        SuspendLayout();
        // 
        // cbxProfileSelectionComboBox
        // 
        cbxProfileSelectionComboBox.Anchor = AnchorStyles.Top;
        cbxProfileSelectionComboBox.BackColor = SystemColors.Window;
        cbxProfileSelectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxProfileSelectionComboBox.FlatStyle = FlatStyle.System;
        cbxProfileSelectionComboBox.FormattingEnabled = true;
        cbxProfileSelectionComboBox.Location = new Point(178, 9);
        cbxProfileSelectionComboBox.Name = "cbxProfileSelectionComboBox";
        cbxProfileSelectionComboBox.Size = new Size(175, 23);
        cbxProfileSelectionComboBox.TabIndex = 2;
        // 
        // lblProfileSelectionLabel
        // 
        lblProfileSelectionLabel.Anchor = AnchorStyles.Top;
        lblProfileSelectionLabel.AutoSize = true;
        lblProfileSelectionLabel.ForeColor = SystemColors.ButtonHighlight;
        lblProfileSelectionLabel.Location = new Point(98, 12);
        lblProfileSelectionLabel.Name = "lblProfileSelectionLabel";
        lblProfileSelectionLabel.Size = new Size(76, 15);
        lblProfileSelectionLabel.TabIndex = 3;
        lblProfileSelectionLabel.Text = "Server Profile";
        // 
        // ProfileSelectorView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(cbxProfileSelectionComboBox);
        Controls.Add(lblProfileSelectionLabel);
        Name = "ProfileSelectorView";
        Size = new Size(450, 40);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ComboBox cbxProfileSelectionComboBox;
    private Label lblProfileSelectionLabel;
}
