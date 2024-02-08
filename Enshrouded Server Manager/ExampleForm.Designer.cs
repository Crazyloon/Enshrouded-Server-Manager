using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager;

partial class ExampleForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExampleForm));
        pbxFormHeader = new PictureBox();
        lblTitle = new Label();
        lblMinimizeTrayButton = new Label();
        lblCloseButton = new Label();
        pbxLeftBorder = new PictureBox();
        pbxInnerLeftBorder = new PictureBox();
        pbxRightBorder = new PictureBox();
        pbxInnerRightBorder = new PictureBox();
        pbxBottomBorder = new PictureBox();
        pnlLeftPanel = new Panel();
        adminPanelView = new AdminPanelView();
        pnlRightPanel = new Panel();
        profileSelectorView = new ProfileSelectorView();
        pnlInfoPanel = new Panel();
        infoPanelView = new InfoPanelView();
        tabsServerTabs = new TabControl();
        tabServerSettings = new TabPage();
        serverSettingsView = new ServerSettingsView();
        tabManageProfiles = new TabPage();
        manageProfilesView = new ManageProfilesView();
        tabAutoBackup = new TabPage();
        autoBackupView = new AutoBackupView();
        tabDiscord = new TabPage();
        discordNotificationsView = new DiscordNotificationsView();
        pnlBottomBorder = new Panel();
        pnlFormHeader = new Panel();
        ((System.ComponentModel.ISupportInitialize)pbxFormHeader).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbxLeftBorder).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbxInnerLeftBorder).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbxRightBorder).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbxInnerRightBorder).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbxBottomBorder).BeginInit();
        pnlLeftPanel.SuspendLayout();
        pnlRightPanel.SuspendLayout();
        pnlInfoPanel.SuspendLayout();
        tabsServerTabs.SuspendLayout();
        tabServerSettings.SuspendLayout();
        tabManageProfiles.SuspendLayout();
        tabAutoBackup.SuspendLayout();
        tabDiscord.SuspendLayout();
        pnlBottomBorder.SuspendLayout();
        pnlFormHeader.SuspendLayout();
        SuspendLayout();
        // 
        // pbxFormHeader
        // 
        pbxFormHeader.BackColor = Color.FromArgb(64, 64, 64);
        pbxFormHeader.Dock = DockStyle.Top;
        pbxFormHeader.Location = new Point(0, 0);
        pbxFormHeader.Margin = new Padding(0);
        pbxFormHeader.Name = "pbxFormHeader";
        pbxFormHeader.Size = new Size(896, 40);
        pbxFormHeader.TabIndex = 23;
        pbxFormHeader.TabStop = false;
        pbxFormHeader.MouseDown += pbxFormHeader_MouseDown;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.BackColor = Color.FromArgb(64, 64, 64);
        lblTitle.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
        lblTitle.ForeColor = SystemColors.Control;
        lblTitle.Location = new Point(6, 5);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(414, 32);
        lblTitle.TabIndex = 25;
        lblTitle.Text = "ESM - Enshrouded Server Manager";
        lblTitle.MouseDown += pbxFormHeader_MouseDown;
        // 
        // lblMinimizeTrayButton
        // 
        lblMinimizeTrayButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblMinimizeTrayButton.AutoSize = true;
        lblMinimizeTrayButton.BackColor = Color.FromArgb(64, 64, 64);
        lblMinimizeTrayButton.Cursor = Cursors.Hand;
        lblMinimizeTrayButton.Font = new Font("Malgun Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblMinimizeTrayButton.ForeColor = Color.FromArgb(0, 255, 185);
        lblMinimizeTrayButton.Location = new Point(840, 6);
        lblMinimizeTrayButton.Name = "lblMinimizeTrayButton";
        lblMinimizeTrayButton.Size = new Size(17, 21);
        lblMinimizeTrayButton.TabIndex = 30;
        lblMinimizeTrayButton.Text = "_";
        lblMinimizeTrayButton.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblCloseButton
        // 
        lblCloseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblCloseButton.AutoSize = true;
        lblCloseButton.BackColor = Color.FromArgb(64, 64, 64);
        lblCloseButton.Cursor = Cursors.Hand;
        lblCloseButton.Font = new Font("Malgun Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblCloseButton.ForeColor = Color.FromArgb(0, 255, 185);
        lblCloseButton.Location = new Point(868, 9);
        lblCloseButton.Name = "lblCloseButton";
        lblCloseButton.Size = new Size(18, 19);
        lblCloseButton.TabIndex = 29;
        lblCloseButton.Text = "X";
        lblCloseButton.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pbxLeftBorder
        // 
        pbxLeftBorder.BackColor = Color.FromArgb(64, 64, 64);
        pbxLeftBorder.Dock = DockStyle.Left;
        pbxLeftBorder.Location = new Point(0, 0);
        pbxLeftBorder.Name = "pbxLeftBorder";
        pbxLeftBorder.Size = new Size(10, 446);
        pbxLeftBorder.TabIndex = 31;
        pbxLeftBorder.TabStop = false;
        // 
        // pbxInnerLeftBorder
        // 
        pbxInnerLeftBorder.BackColor = Color.FromArgb(64, 64, 64);
        pbxInnerLeftBorder.Dock = DockStyle.Right;
        pbxInnerLeftBorder.Location = new Point(180, 0);
        pbxInnerLeftBorder.Name = "pbxInnerLeftBorder";
        pbxInnerLeftBorder.Size = new Size(10, 446);
        pbxInnerLeftBorder.TabIndex = 38;
        pbxInnerLeftBorder.TabStop = false;
        // 
        // pbxRightBorder
        // 
        pbxRightBorder.BackColor = Color.FromArgb(64, 64, 64);
        pbxRightBorder.Dock = DockStyle.Right;
        pbxRightBorder.Location = new Point(237, 0);
        pbxRightBorder.Name = "pbxRightBorder";
        pbxRightBorder.Size = new Size(10, 446);
        pbxRightBorder.TabIndex = 39;
        pbxRightBorder.TabStop = false;
        // 
        // pbxInnerRightBorder
        // 
        pbxInnerRightBorder.BackColor = Color.FromArgb(64, 64, 64);
        pbxInnerRightBorder.Dock = DockStyle.Left;
        pbxInnerRightBorder.Location = new Point(0, 0);
        pbxInnerRightBorder.Name = "pbxInnerRightBorder";
        pbxInnerRightBorder.Size = new Size(10, 446);
        pbxInnerRightBorder.TabIndex = 41;
        pbxInnerRightBorder.TabStop = false;
        // 
        // pbxBottomBorder
        // 
        pbxBottomBorder.BackColor = Color.FromArgb(64, 64, 64);
        pbxBottomBorder.Dock = DockStyle.Bottom;
        pbxBottomBorder.Location = new Point(0, 0);
        pbxBottomBorder.Name = "pbxBottomBorder";
        pbxBottomBorder.Size = new Size(896, 21);
        pbxBottomBorder.TabIndex = 42;
        pbxBottomBorder.TabStop = false;
        // 
        // pnlLeftPanel
        // 
        pnlLeftPanel.Controls.Add(adminPanelView);
        pnlLeftPanel.Controls.Add(pbxInnerLeftBorder);
        pnlLeftPanel.Controls.Add(pbxLeftBorder);
        pnlLeftPanel.Dock = DockStyle.Left;
        pnlLeftPanel.Location = new Point(0, 37);
        pnlLeftPanel.Name = "pnlLeftPanel";
        pnlLeftPanel.Size = new Size(190, 446);
        pnlLeftPanel.TabIndex = 49;
        // 
        // adminPanelView
        // 
        adminPanelView.BackColor = Color.FromArgb(0, 0, 18);
        adminPanelView.Dock = DockStyle.Fill;
        adminPanelView.Location = new Point(10, 0);
        adminPanelView.Name = "adminPanelView";
        adminPanelView.Size = new Size(170, 446);
        adminPanelView.TabIndex = 39;
        // 
        // pnlRightPanel
        // 
        pnlRightPanel.Controls.Add(profileSelectorView);
        pnlRightPanel.Controls.Add(pnlInfoPanel);
        pnlRightPanel.Controls.Add(tabsServerTabs);
        pnlRightPanel.Dock = DockStyle.Fill;
        pnlRightPanel.Location = new Point(190, 37);
        pnlRightPanel.Name = "pnlRightPanel";
        pnlRightPanel.Size = new Size(706, 446);
        pnlRightPanel.TabIndex = 50;
        // 
        // profileSelectorView
        // 
        profileSelectorView.BackColor = Color.FromArgb(0, 0, 18);
        profileSelectorView.Dock = DockStyle.Top;
        profileSelectorView.Location = new Point(0, 0);
        profileSelectorView.Name = "profileSelectorView";
        profileSelectorView.Size = new Size(459, 45);
        profileSelectorView.TabIndex = 1;
        // 
        // pnlInfoPanel
        // 
        pnlInfoPanel.Controls.Add(infoPanelView);
        pnlInfoPanel.Controls.Add(pbxRightBorder);
        pnlInfoPanel.Controls.Add(pbxInnerRightBorder);
        pnlInfoPanel.Dock = DockStyle.Right;
        pnlInfoPanel.Location = new Point(459, 0);
        pnlInfoPanel.Name = "pnlInfoPanel";
        pnlInfoPanel.Size = new Size(247, 446);
        pnlInfoPanel.TabIndex = 0;
        // 
        // infoPanelView
        // 
        infoPanelView.BackColor = Color.FromArgb(0, 0, 18);
        infoPanelView.Dock = DockStyle.Fill;
        infoPanelView.ForeColor = SystemColors.HighlightText;
        infoPanelView.Location = new Point(10, 0);
        infoPanelView.Name = "infoPanelView";
        infoPanelView.Size = new Size(227, 446);
        infoPanelView.TabIndex = 42;
        // 
        // tabsServerTabs
        // 
        tabsServerTabs.Controls.Add(tabServerSettings);
        tabsServerTabs.Controls.Add(tabManageProfiles);
        tabsServerTabs.Controls.Add(tabAutoBackup);
        tabsServerTabs.Controls.Add(tabDiscord);
        tabsServerTabs.Location = new Point(-4, 43);
        tabsServerTabs.Name = "tabsServerTabs";
        tabsServerTabs.SelectedIndex = 0;
        tabsServerTabs.Size = new Size(467, 412);
        tabsServerTabs.TabIndex = 2;
        // 
        // tabServerSettings
        // 
        tabServerSettings.BackColor = Color.FromArgb(0, 0, 18);
        tabServerSettings.Controls.Add(serverSettingsView);
        tabServerSettings.ForeColor = SystemColors.ControlLight;
        tabServerSettings.Location = new Point(4, 24);
        tabServerSettings.Name = "tabServerSettings";
        tabServerSettings.Padding = new Padding(3);
        tabServerSettings.Size = new Size(459, 384);
        tabServerSettings.TabIndex = 0;
        tabServerSettings.Text = "Server Settings";
        // 
        // serverSettingsView
        // 
        serverSettingsView.BackColor = Color.FromArgb(0, 0, 18);
        serverSettingsView.Dock = DockStyle.Fill;
        serverSettingsView.ForeColor = SystemColors.ButtonHighlight;
        serverSettingsView.GamePort = 0;
        serverSettingsView.IpAddress = "";
        serverSettingsView.IsPasswordShown = false;
        serverSettingsView.Location = new Point(3, 3);
        serverSettingsView.MaxPlayers = 0;
        serverSettingsView.Name = "serverSettingsView";
        serverSettingsView.Password = "";
        serverSettingsView.QueryPort = 0;
        serverSettingsView.ServerName = "";
        serverSettingsView.ShowPasswordButtonText = "Show";
        serverSettingsView.Size = new Size(453, 378);
        serverSettingsView.TabIndex = 0;
        // 
        // tabManageProfiles
        // 
        tabManageProfiles.BackColor = Color.FromArgb(0, 0, 18);
        tabManageProfiles.Controls.Add(manageProfilesView);
        tabManageProfiles.ForeColor = SystemColors.ControlLight;
        tabManageProfiles.Location = new Point(4, 24);
        tabManageProfiles.Name = "tabManageProfiles";
        tabManageProfiles.Padding = new Padding(3);
        tabManageProfiles.Size = new Size(459, 384);
        tabManageProfiles.TabIndex = 1;
        tabManageProfiles.Text = "Manage Profiles";
        // 
        // manageProfilesView
        // 
        manageProfilesView.BackColor = Color.FromArgb(0, 0, 18);
        manageProfilesView.Dock = DockStyle.Fill;
        manageProfilesView.ForeColor = SystemColors.ButtonHighlight;
        manageProfilesView.Location = new Point(3, 3);
        manageProfilesView.Name = "manageProfilesView";
        manageProfilesView.Size = new Size(453, 378);
        manageProfilesView.TabIndex = 0;
        // 
        // tabAutoBackup
        // 
        tabAutoBackup.BackColor = Color.FromArgb(0, 0, 18);
        tabAutoBackup.Controls.Add(autoBackupView);
        tabAutoBackup.ForeColor = SystemColors.ControlLight;
        tabAutoBackup.Location = new Point(4, 24);
        tabAutoBackup.Name = "tabAutoBackup";
        tabAutoBackup.Padding = new Padding(3);
        tabAutoBackup.Size = new Size(459, 384);
        tabAutoBackup.TabIndex = 2;
        tabAutoBackup.Text = "Auto Backup";
        // 
        // autoBackupView
        // 
        autoBackupView.BackColor = Color.FromArgb(0, 0, 18);
        autoBackupView.Dock = DockStyle.Fill;
        autoBackupView.ForeColor = SystemColors.ButtonHighlight;
        autoBackupView.Location = new Point(3, 3);
        autoBackupView.Name = "autoBackupView";
        autoBackupView.Size = new Size(453, 378);
        autoBackupView.TabIndex = 0;
        // 
        // tabDiscord
        // 
        tabDiscord.BackColor = Color.FromArgb(0, 0, 18);
        tabDiscord.Controls.Add(discordNotificationsView);
        tabDiscord.ForeColor = SystemColors.ControlLight;
        tabDiscord.Location = new Point(4, 24);
        tabDiscord.Name = "tabDiscord";
        tabDiscord.Padding = new Padding(3);
        tabDiscord.Size = new Size(459, 384);
        tabDiscord.TabIndex = 3;
        tabDiscord.Text = "Discord";
        // 
        // discordNotificationsView
        // 
        discordNotificationsView.BackColor = Color.FromArgb(0, 0, 18);
        discordNotificationsView.Dock = DockStyle.Fill;
        discordNotificationsView.ForeColor = SystemColors.ButtonHighlight;
        discordNotificationsView.Location = new Point(3, 3);
        discordNotificationsView.Name = "discordNotificationsView";
        discordNotificationsView.Size = new Size(453, 378);
        discordNotificationsView.TabIndex = 0;
        // 
        // pnlBottomBorder
        // 
        pnlBottomBorder.Controls.Add(pbxBottomBorder);
        pnlBottomBorder.Dock = DockStyle.Bottom;
        pnlBottomBorder.Location = new Point(0, 483);
        pnlBottomBorder.Name = "pnlBottomBorder";
        pnlBottomBorder.Size = new Size(896, 21);
        pnlBottomBorder.TabIndex = 1;
        // 
        // pnlFormHeader
        // 
        pnlFormHeader.Controls.Add(lblMinimizeTrayButton);
        pnlFormHeader.Controls.Add(lblCloseButton);
        pnlFormHeader.Controls.Add(lblTitle);
        pnlFormHeader.Controls.Add(pbxFormHeader);
        pnlFormHeader.Dock = DockStyle.Top;
        pnlFormHeader.Location = new Point(0, 0);
        pnlFormHeader.Name = "pnlFormHeader";
        pnlFormHeader.Size = new Size(896, 37);
        pnlFormHeader.TabIndex = 51;
        // 
        // ExampleForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        ClientSize = new Size(896, 504);
        ControlBox = false;
        Controls.Add(pnlRightPanel);
        Controls.Add(pnlLeftPanel);
        Controls.Add(pnlFormHeader);
        Controls.Add(pnlBottomBorder);
        ForeColor = SystemColors.ButtonHighlight;
        FormBorderStyle = FormBorderStyle.None;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "ExampleForm";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pbxFormHeader).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbxLeftBorder).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbxInnerLeftBorder).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbxRightBorder).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbxInnerRightBorder).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbxBottomBorder).EndInit();
        pnlLeftPanel.ResumeLayout(false);
        pnlRightPanel.ResumeLayout(false);
        pnlInfoPanel.ResumeLayout(false);
        tabsServerTabs.ResumeLayout(false);
        tabServerSettings.ResumeLayout(false);
        tabManageProfiles.ResumeLayout(false);
        tabAutoBackup.ResumeLayout(false);
        tabDiscord.ResumeLayout(false);
        pnlBottomBorder.ResumeLayout(false);
        pnlFormHeader.ResumeLayout(false);
        pnlFormHeader.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private Label lblTitle;
    private Label lblMinimizeTrayButton;
    private Label lblCloseButton;
    private PictureBox pbxFormHeader;
    private PictureBox pbxLeftBorder;
    private PictureBox pbxInnerLeftBorder;
    private PictureBox pbxRightBorder;
    private PictureBox pbxRightPanel;
    private PictureBox pbxInnerRightBorder;
    private PictureBox pbxBottomBorder;
    private Panel pnlLeftPanel;
    private Panel pnlRightPanel;
    private Panel pnlInfoPanel;
    private Panel pnlBottomBorder;
    private Panel pnlFormHeader;
    private TabControl tabsServerTabs;
    private TabPage tabServerSettings;
    private TabPage tabManageProfiles;
    private TabPage tabAutoBackup;
    private TabPage tabDiscord;
    private AdminPanelView adminPanelView;
    private ProfileSelectorView profileSelectorView;
    private InfoPanelView infoPanelView;
    private ServerSettingsView serverSettingsView;
    private ManageProfilesView manageProfilesView;
    private AutoBackupView autoBackupView;
    private DiscordNotificationsView discordNotificationsView;
}