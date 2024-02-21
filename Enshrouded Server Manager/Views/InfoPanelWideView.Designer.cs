namespace Enshrouded_Server_Manager;

partial class InfoPanelWideView
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoPanelWideView));
        lblNewsText = new Label();
        lblGitHubLink = new Label();
        lblChanges = new Label();
        lblTitle = new Label();
        lblSupportLink = new Label();
        SuspendLayout();
        // 
        // lblNewsText
        // 
        lblNewsText.AutoSize = true;
        lblNewsText.Location = new Point(81, 123);
        lblNewsText.Name = "lblNewsText";
        lblNewsText.Padding = new Padding(5);
        lblNewsText.Size = new Size(620, 220);
        lblNewsText.TabIndex = 54;
        lblNewsText.Text = resources.GetString("lblNewsText.Text");
        // 
        // lblGitHubLink
        // 
        lblGitHubLink.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblGitHubLink.AutoSize = true;
        lblGitHubLink.Cursor = Cursors.Hand;
        lblGitHubLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        lblGitHubLink.ForeColor = Color.FromArgb(0, 255, 185);
        lblGitHubLink.Location = new Point(3, 391);
        lblGitHubLink.Name = "lblGitHubLink";
        lblGitHubLink.Size = new Size(95, 15);
        lblGitHubLink.TabIndex = 59;
        lblGitHubLink.Text = "View on GitHub";
        // 
        // lblChanges
        // 
        lblChanges.AutoSize = true;
        lblChanges.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
        lblChanges.Location = new Point(81, 87);
        lblChanges.Name = "lblChanges";
        lblChanges.Size = new Size(118, 25);
        lblChanges.TabIndex = 60;
        lblChanges.Text = "Change Log";
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
        lblTitle.ForeColor = Color.FromArgb(0, 204, 204);
        lblTitle.Location = new Point(203, 33);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(339, 32);
        lblTitle.TabIndex = 61;
        lblTitle.Text = "Enshrouded Server Manager";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSupportLink
        // 
        lblSupportLink.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        lblSupportLink.AutoSize = true;
        lblSupportLink.Cursor = Cursors.Hand;
        lblSupportLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        lblSupportLink.ForeColor = Color.FromArgb(0, 255, 185);
        lblSupportLink.Location = new Point(612, 391);
        lblSupportLink.Name = "lblSupportLink";
        lblSupportLink.Size = new Size(132, 15);
        lblSupportLink.TabIndex = 62;
        lblSupportLink.Text = "Support Development";
        // 
        // InfoPanelWideView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(lblSupportLink);
        Controls.Add(lblTitle);
        Controls.Add(lblChanges);
        Controls.Add(lblGitHubLink);
        Controls.Add(lblNewsText);
        ForeColor = SystemColors.HighlightText;
        Name = "InfoPanelWideView";
        Size = new Size(744, 411);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Label lblNewsText;
    private Label lblGitHubLink;
    private Label lblChanges;
    private Label lblTitle;
    private Label lblSupportLink;
}
