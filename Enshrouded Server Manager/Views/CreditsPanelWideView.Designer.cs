namespace Enshrouded_Server_Manager.Views;

partial class CreditsPanelWideView
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
        lblCreditsSponsorsList = new Label();
        lblHeadingSponsoredBy = new Label();
        lblHeadingContributors = new Label();
        lblHeadingMadeBy = new Label();
        lblCreditsContributors = new Label();
        lblCreditsMadeBy = new Label();
        lnkGitHubSponsor = new Label();
        SuspendLayout();
        // 
        // lblCreditsSponsorsList
        // 
        lblCreditsSponsorsList.Dock = DockStyle.Top;
        lblCreditsSponsorsList.Font = new Font("Malgun Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        lblCreditsSponsorsList.ForeColor = Color.FromArgb(0, 204, 204);
        lblCreditsSponsorsList.Location = new Point(5, 262);
        lblCreditsSponsorsList.Name = "lblCreditsSponsorsList";
        lblCreditsSponsorsList.Size = new Size(734, 26);
        lblCreditsSponsorsList.TabIndex = 50;
        lblCreditsSponsorsList.Text = "FreeFun";
        lblCreditsSponsorsList.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblHeadingSponsoredBy
        // 
        lblHeadingSponsoredBy.Dock = DockStyle.Top;
        lblHeadingSponsoredBy.Font = new Font("Malgun Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
        lblHeadingSponsoredBy.Location = new Point(5, 232);
        lblHeadingSponsoredBy.Name = "lblHeadingSponsoredBy";
        lblHeadingSponsoredBy.Padding = new Padding(0, 0, 0, 4);
        lblHeadingSponsoredBy.Size = new Size(734, 30);
        lblHeadingSponsoredBy.TabIndex = 49;
        lblHeadingSponsoredBy.Text = "Sponsored By:";
        lblHeadingSponsoredBy.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblHeadingContributors
        // 
        lblHeadingContributors.Dock = DockStyle.Top;
        lblHeadingContributors.Font = new Font("Malgun Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
        lblHeadingContributors.Location = new Point(5, 176);
        lblHeadingContributors.Name = "lblHeadingContributors";
        lblHeadingContributors.Padding = new Padding(0, 0, 0, 4);
        lblHeadingContributors.Size = new Size(734, 30);
        lblHeadingContributors.TabIndex = 34;
        lblHeadingContributors.Text = "Special Thanks to:";
        lblHeadingContributors.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblHeadingMadeBy
        // 
        lblHeadingMadeBy.Dock = DockStyle.Top;
        lblHeadingMadeBy.Font = new Font("Malgun Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
        lblHeadingMadeBy.Location = new Point(5, 100);
        lblHeadingMadeBy.Name = "lblHeadingMadeBy";
        lblHeadingMadeBy.Padding = new Padding(0, 0, 0, 4);
        lblHeadingMadeBy.Size = new Size(734, 30);
        lblHeadingMadeBy.TabIndex = 33;
        lblHeadingMadeBy.Text = "Made By:";
        lblHeadingMadeBy.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblCreditsContributors
        // 
        lblCreditsContributors.Dock = DockStyle.Top;
        lblCreditsContributors.Font = new Font("Malgun Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        lblCreditsContributors.ForeColor = Color.FromArgb(0, 204, 204);
        lblCreditsContributors.Location = new Point(5, 206);
        lblCreditsContributors.Name = "lblCreditsContributors";
        lblCreditsContributors.Size = new Size(734, 26);
        lblCreditsContributors.TabIndex = 32;
        lblCreditsContributors.Text = "Strew/Evorin";
        lblCreditsContributors.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblCreditsMadeBy
        // 
        lblCreditsMadeBy.Dock = DockStyle.Top;
        lblCreditsMadeBy.Font = new Font("Malgun Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        lblCreditsMadeBy.ForeColor = Color.FromArgb(0, 204, 204);
        lblCreditsMadeBy.Location = new Point(5, 130);
        lblCreditsMadeBy.Name = "lblCreditsMadeBy";
        lblCreditsMadeBy.Size = new Size(734, 46);
        lblCreditsMadeBy.TabIndex = 31;
        lblCreditsMadeBy.Text = "Spaik\r\nCrazyloon\r\n\r\n";
        lblCreditsMadeBy.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lnkGitHubSponsor
        // 
        lnkGitHubSponsor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        lnkGitHubSponsor.AutoSize = true;
        lnkGitHubSponsor.Cursor = Cursors.Hand;
        lnkGitHubSponsor.ForeColor = Color.FromArgb(0, 255, 185);
        lnkGitHubSponsor.Location = new Point(631, 385);
        lnkGitHubSponsor.Name = "lnkGitHubSponsor";
        lnkGitHubSponsor.Size = new Size(105, 15);
        lnkGitHubSponsor.TabIndex = 60;
        lnkGitHubSponsor.Text = "Become a Sponsor";
        // 
        // CreditsPanelWideView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(lnkGitHubSponsor);
        Controls.Add(lblCreditsSponsorsList);
        Controls.Add(lblHeadingSponsoredBy);
        Controls.Add(lblCreditsContributors);
        Controls.Add(lblHeadingContributors);
        Controls.Add(lblCreditsMadeBy);
        Controls.Add(lblHeadingMadeBy);
        ForeColor = SystemColors.Control;
        Name = "CreditsPanelWideView";
        Padding = new Padding(5, 100, 5, 5);
        Size = new Size(744, 411);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel pnlCredits;
    private Label lblCreditsSponsorsList;
    private Label lblCreditsSupportedBy;
    private Label lblHeadingSponsoredBy;
    private Label lblHeadingContributors;
    private Label lblHeadingMadeBy;
    private Label lblCreditsContributors;
    private Label lblCreditsMadeBy;
    private Label lnkGitHubSponsor;
}
