namespace Enshrouded_Server_Manager;

partial class InfoPanelView
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoPanelView));
        lblLogo = new Label();
        lblNewsText = new Label();
        lblNewVersionAvailableNotification = new Label();
        GithubLabel = new Label();
        lblNews = new Label();
        SuspendLayout();
        // 
        // lblLogo
        // 
        lblLogo.BackColor = Color.Transparent;
        lblLogo.Cursor = Cursors.Hand;
        lblLogo.Dock = DockStyle.Top;
        lblLogo.Font = new Font("Malgun Gothic", 60F, FontStyle.Bold, GraphicsUnit.Point);
        lblLogo.ForeColor = Color.FromArgb(0, 204, 204);
        lblLogo.Location = new Point(0, 0);
        lblLogo.Name = "lblLogo";
        lblLogo.Size = new Size(240, 106);
        lblLogo.TabIndex = 49;
        lblLogo.Text = "ESM";
        lblLogo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblNewsText
        // 
        lblNewsText.AutoSize = true;
        lblNewsText.Dock = DockStyle.Top;
        lblNewsText.Location = new Point(0, 106);
        lblNewsText.Name = "lblNewsText";
        lblNewsText.Padding = new Padding(4);
        lblNewsText.Size = new Size(225, 203);
        lblNewsText.TabIndex = 54;
        lblNewsText.Text = resources.GetString("lblNewsText.Text");
        // 
        // lblNewVersionAvailableNotification
        // 
        lblNewVersionAvailableNotification.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        lblNewVersionAvailableNotification.AutoSize = true;
        lblNewVersionAvailableNotification.BackColor = Color.Transparent;
        lblNewVersionAvailableNotification.ForeColor = Color.FromArgb(0, 255, 185);
        lblNewVersionAvailableNotification.Location = new Point(113, 406);
        lblNewVersionAvailableNotification.Name = "lblNewVersionAvailableNotification";
        lblNewVersionAvailableNotification.Size = new Size(124, 15);
        lblNewVersionAvailableNotification.TabIndex = 60;
        lblNewVersionAvailableNotification.Text = "New version available!";
        // 
        // GithubLabel
        // 
        GithubLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        GithubLabel.AutoSize = true;
        GithubLabel.Cursor = Cursors.Hand;
        GithubLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        GithubLabel.Location = new Point(192, 425);
        GithubLabel.Name = "GithubLabel";
        GithubLabel.Size = new Size(45, 15);
        GithubLabel.TabIndex = 59;
        GithubLabel.Text = "Github";
        // 
        // lblNews
        // 
        lblNews.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblNews.AutoSize = true;
        lblNews.BackColor = Color.Transparent;
        lblNews.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
        lblNews.ForeColor = SystemColors.Control;
        lblNews.Location = new Point(3, 406);
        lblNews.Name = "lblNews";
        lblNews.Padding = new Padding(4);
        lblNews.Size = new Size(84, 40);
        lblNews.TabIndex = 58;
        lblNews.Text = "News";
        // 
        // InfoPanelView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(lblNewVersionAvailableNotification);
        Controls.Add(GithubLabel);
        Controls.Add(lblNews);
        Controls.Add(lblNewsText);
        Controls.Add(lblLogo);
        ForeColor = SystemColors.HighlightText;
        Name = "InfoPanelView";
        Size = new Size(240, 446);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblLogo;
    private Label lblNewsText;
    private Label lblNewVersionAvailableNotification;
    private Label GithubLabel;
    private Label lblNews;
}
