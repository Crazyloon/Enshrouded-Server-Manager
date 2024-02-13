namespace Enshrouded_Server_Manager.Views;

partial class NavBarView
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
        btnDiscord = new Button();
        btnAutoBackup = new Button();
        lblVersion = new Label();
        lblLogo = new Label();
        btnServerSettings = new Button();
        btnProfileSettings = new Button();
        btnHome = new Button();
        SuspendLayout();
        // 
        // btnDiscord
        // 
        btnDiscord.Dock = DockStyle.Top;
        btnDiscord.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 18);
        btnDiscord.FlatAppearance.BorderSize = 0;
        btnDiscord.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 58);
        btnDiscord.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 58);
        btnDiscord.FlatStyle = FlatStyle.Flat;
        btnDiscord.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        btnDiscord.ForeColor = Color.White;
        btnDiscord.Location = new Point(0, 245);
        btnDiscord.Name = "btnDiscord";
        btnDiscord.Padding = new Padding(30, 0, 0, 0);
        btnDiscord.Size = new Size(200, 39);
        btnDiscord.TabIndex = 70;
        btnDiscord.Text = "Discord";
        btnDiscord.TextAlign = ContentAlignment.MiddleLeft;
        btnDiscord.UseVisualStyleBackColor = true;
        // 
        // btnAutoBackup
        // 
        btnAutoBackup.Dock = DockStyle.Top;
        btnAutoBackup.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 18);
        btnAutoBackup.FlatAppearance.BorderSize = 0;
        btnAutoBackup.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 58);
        btnAutoBackup.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 58);
        btnAutoBackup.FlatStyle = FlatStyle.Flat;
        btnAutoBackup.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        btnAutoBackup.ForeColor = Color.White;
        btnAutoBackup.Location = new Point(0, 206);
        btnAutoBackup.Name = "btnAutoBackup";
        btnAutoBackup.Padding = new Padding(30, 0, 0, 0);
        btnAutoBackup.Size = new Size(200, 39);
        btnAutoBackup.TabIndex = 69;
        btnAutoBackup.Text = "Auto Backup";
        btnAutoBackup.TextAlign = ContentAlignment.MiddleLeft;
        btnAutoBackup.UseVisualStyleBackColor = true;
        // 
        // lblVersion
        // 
        lblVersion.AutoSize = true;
        lblVersion.BackColor = Color.FromArgb(0, 0, 18);
        lblVersion.Dock = DockStyle.Bottom;
        lblVersion.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
        lblVersion.ForeColor = Color.FromArgb(0, 204, 204);
        lblVersion.Location = new Point(0, 430);
        lblVersion.Name = "lblVersion";
        lblVersion.Padding = new Padding(5, 0, 0, 5);
        lblVersion.Size = new Size(44, 18);
        lblVersion.TabIndex = 68;
        lblVersion.Text = "v.0.4.1";
        // 
        // lblLogo
        // 
        lblLogo.BackColor = Color.Transparent;
        lblLogo.Cursor = Cursors.Hand;
        lblLogo.Dock = DockStyle.Top;
        lblLogo.Font = new Font("Malgun Gothic", 50F, FontStyle.Bold, GraphicsUnit.Point);
        lblLogo.ForeColor = Color.FromArgb(0, 204, 204);
        lblLogo.Location = new Point(0, 0);
        lblLogo.Name = "lblLogo";
        lblLogo.Size = new Size(200, 89);
        lblLogo.TabIndex = 67;
        lblLogo.Text = "ESM";
        lblLogo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnServerSettings
        // 
        btnServerSettings.Dock = DockStyle.Top;
        btnServerSettings.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 18);
        btnServerSettings.FlatAppearance.BorderSize = 0;
        btnServerSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 58);
        btnServerSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 58);
        btnServerSettings.FlatStyle = FlatStyle.Flat;
        btnServerSettings.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        btnServerSettings.ForeColor = Color.White;
        btnServerSettings.Location = new Point(0, 167);
        btnServerSettings.Name = "btnServerSettings";
        btnServerSettings.Padding = new Padding(30, 0, 0, 0);
        btnServerSettings.Size = new Size(200, 39);
        btnServerSettings.TabIndex = 66;
        btnServerSettings.Text = "Server Settings";
        btnServerSettings.TextAlign = ContentAlignment.MiddleLeft;
        btnServerSettings.UseVisualStyleBackColor = true;
        // 
        // btnProfileSettings
        // 
        btnProfileSettings.Dock = DockStyle.Top;
        btnProfileSettings.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 18);
        btnProfileSettings.FlatAppearance.BorderSize = 0;
        btnProfileSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 18);
        btnProfileSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 18);
        btnProfileSettings.FlatStyle = FlatStyle.Flat;
        btnProfileSettings.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
        btnProfileSettings.ForeColor = Color.White;
        btnProfileSettings.Location = new Point(0, 128);
        btnProfileSettings.Name = "btnProfileSettings";
        btnProfileSettings.Padding = new Padding(20, 0, 0, 0);
        btnProfileSettings.Size = new Size(200, 39);
        btnProfileSettings.TabIndex = 65;
        btnProfileSettings.Text = "Profile Settings";
        btnProfileSettings.TextAlign = ContentAlignment.MiddleLeft;
        btnProfileSettings.UseVisualStyleBackColor = true;
        // 
        // btnHome
        // 
        btnHome.Dock = DockStyle.Top;
        btnHome.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 18);
        btnHome.FlatAppearance.BorderSize = 0;
        btnHome.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 58);
        btnHome.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 58);
        btnHome.FlatStyle = FlatStyle.Flat;
        btnHome.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
        btnHome.ForeColor = Color.White;
        btnHome.Location = new Point(0, 89);
        btnHome.Name = "btnHome";
        btnHome.Padding = new Padding(20, 0, 0, 0);
        btnHome.Size = new Size(200, 39);
        btnHome.TabIndex = 64;
        btnHome.Text = "Home";
        btnHome.TextAlign = ContentAlignment.MiddleLeft;
        btnHome.UseVisualStyleBackColor = true;
        // 
        // NavBarView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(btnDiscord);
        Controls.Add(btnAutoBackup);
        Controls.Add(lblVersion);
        Controls.Add(btnServerSettings);
        Controls.Add(btnProfileSettings);
        Controls.Add(btnHome);
        Controls.Add(lblLogo);
        ForeColor = SystemColors.Control;
        Name = "NavBarView";
        Size = new Size(200, 448);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnDiscord;
    private Button btnAutoBackup;
    private Label lblVersion;
    private Label lblLogo;
    private Button btnServerSettings;
    private Button btnProfileSettings;
    private Button btnHome;
}
