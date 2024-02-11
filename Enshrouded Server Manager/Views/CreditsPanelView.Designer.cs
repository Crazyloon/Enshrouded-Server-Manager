namespace Enshrouded_Server_Manager.Views;

partial class CreditsPanelView
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
        btnCreditsClose = new Label();
        lblCreditsLogo = new Label();
        lblHeadingContributors = new Label();
        lblHeadingMadeBy = new Label();
        lblCreditsContributors = new Label();
        lblCreditsMadeBy = new Label();
        SuspendLayout();
        // 
        // lblCreditsSponsorsList
        // 
        lblCreditsSponsorsList.Dock = DockStyle.Top;
        lblCreditsSponsorsList.Font = new Font("Malgun Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        lblCreditsSponsorsList.Location = new Point(5, 292);
        lblCreditsSponsorsList.Name = "lblCreditsSponsorsList";
        lblCreditsSponsorsList.Size = new Size(230, 26);
        lblCreditsSponsorsList.TabIndex = 50;
        lblCreditsSponsorsList.Text = "FreeFun";
        // 
        // lblHeadingSponsoredBy
        // 
        lblHeadingSponsoredBy.Dock = DockStyle.Top;
        lblHeadingSponsoredBy.Font = new Font("Malgun Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblHeadingSponsoredBy.Location = new Point(5, 262);
        lblHeadingSponsoredBy.Name = "lblHeadingSponsoredBy";
        lblHeadingSponsoredBy.Padding = new Padding(0, 0, 0, 4);
        lblHeadingSponsoredBy.Size = new Size(230, 30);
        lblHeadingSponsoredBy.TabIndex = 49;
        lblHeadingSponsoredBy.Text = "Sponsored By:";
        lblHeadingSponsoredBy.TextAlign = ContentAlignment.BottomLeft;
        // 
        // btnCreditsClose
        // 
        btnCreditsClose.BackColor = Color.Transparent;
        btnCreditsClose.Cursor = Cursors.Hand;
        btnCreditsClose.Dock = DockStyle.Top;
        btnCreditsClose.Font = new Font("Malgun Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point);
        btnCreditsClose.ForeColor = Color.FromArgb(0, 255, 185);
        btnCreditsClose.Location = new Point(5, 5);
        btnCreditsClose.Name = "btnCreditsClose";
        btnCreditsClose.Size = new Size(230, 19);
        btnCreditsClose.TabIndex = 28;
        btnCreditsClose.Text = "X";
        btnCreditsClose.TextAlign = ContentAlignment.TopRight;
        // 
        // lblCreditsLogo
        // 
        lblCreditsLogo.BackColor = Color.Transparent;
        lblCreditsLogo.Cursor = Cursors.Hand;
        lblCreditsLogo.Dock = DockStyle.Top;
        lblCreditsLogo.Font = new Font("Malgun Gothic", 60F, FontStyle.Bold, GraphicsUnit.Point);
        lblCreditsLogo.ForeColor = Color.FromArgb(0, 204, 204);
        lblCreditsLogo.Location = new Point(5, 24);
        lblCreditsLogo.Name = "lblCreditsLogo";
        lblCreditsLogo.Size = new Size(230, 106);
        lblCreditsLogo.TabIndex = 48;
        lblCreditsLogo.Text = "ESM";
        lblCreditsLogo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblHeadingContributors
        // 
        lblHeadingContributors.Dock = DockStyle.Top;
        lblHeadingContributors.Font = new Font("Malgun Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblHeadingContributors.Location = new Point(5, 206);
        lblHeadingContributors.Name = "lblHeadingContributors";
        lblHeadingContributors.Padding = new Padding(0, 0, 0, 4);
        lblHeadingContributors.Size = new Size(230, 30);
        lblHeadingContributors.TabIndex = 34;
        lblHeadingContributors.Text = "Special Thanks to:";
        lblHeadingContributors.TextAlign = ContentAlignment.BottomLeft;
        // 
        // lblHeadingMadeBy
        // 
        lblHeadingMadeBy.Dock = DockStyle.Top;
        lblHeadingMadeBy.Font = new Font("Malgun Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblHeadingMadeBy.Location = new Point(5, 130);
        lblHeadingMadeBy.Name = "lblHeadingMadeBy";
        lblHeadingMadeBy.Padding = new Padding(0, 0, 0, 4);
        lblHeadingMadeBy.Size = new Size(230, 30);
        lblHeadingMadeBy.TabIndex = 33;
        lblHeadingMadeBy.Text = "Made By:";
        lblHeadingMadeBy.TextAlign = ContentAlignment.BottomLeft;
        // 
        // lblCreditsContributors
        // 
        lblCreditsContributors.Dock = DockStyle.Top;
        lblCreditsContributors.Font = new Font("Malgun Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        lblCreditsContributors.Location = new Point(5, 236);
        lblCreditsContributors.Name = "lblCreditsContributors";
        lblCreditsContributors.Size = new Size(230, 26);
        lblCreditsContributors.TabIndex = 32;
        lblCreditsContributors.Text = "Strew/Evorin";
        // 
        // lblCreditsMadeBy
        // 
        lblCreditsMadeBy.Dock = DockStyle.Top;
        lblCreditsMadeBy.Font = new Font("Malgun Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        lblCreditsMadeBy.Location = new Point(5, 160);
        lblCreditsMadeBy.Name = "lblCreditsMadeBy";
        lblCreditsMadeBy.Size = new Size(230, 46);
        lblCreditsMadeBy.TabIndex = 31;
        lblCreditsMadeBy.Text = "Spaik\r\nCrazyloon\r\n\r\n";
        // 
        // CreditsPanelView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(lblCreditsSponsorsList);
        Controls.Add(lblHeadingSponsoredBy);
        Controls.Add(lblCreditsContributors);
        Controls.Add(lblHeadingContributors);
        Controls.Add(lblCreditsMadeBy);
        Controls.Add(lblHeadingMadeBy);
        Controls.Add(lblCreditsLogo);
        Controls.Add(btnCreditsClose);
        ForeColor = SystemColors.Control;
        Name = "CreditsPanelView";
        Padding = new Padding(5);
        Size = new Size(240, 446);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlCredits;
    private Label lblCreditsSponsorsList;
    private Label lblCreditsSupportedBy;
    private Label btnCreditsClose;
    private Label lblCreditsLogo;
    private Label lblHeadingSponsoredBy;
    private Label lblHeadingContributors;
    private Label lblHeadingMadeBy;
    private Label lblCreditsContributors;
    private Label lblCreditsMadeBy;
}
