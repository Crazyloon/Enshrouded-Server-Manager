using Enshrouded_Server_Manager.Commands;

namespace Enshrouded_Server_Manager.Views;
public partial class AdminPanelView : UserControl, IAdminPanelView
{
    public AdminPanelView()
    {
        InitializeComponent();
    }

    //public event EventHandler InstallSteamCmd_ButtonClicked
    //{
    //    add { btnInstallSteamCMD.Click += value; }
    //    remove { btnInstallSteamCMD.Click -= value; }
    //}

    //public event EventHandler OpenWindowsFirewall_ButtonClicked
    //{
    //    add { btnWindowsFirewall.Click += value; }
    //    remove { btnWindowsFirewall.Click -= value; }
    //}

    //public event EventHandler StartServer_ButtonClicked
    //{
    //    add { btnStartServer.Click += value; }
    //    remove { btnStartServer.Click -= value; }
    //}

    //public event EventHandler StopServer_ButtonClicked
    //{
    //    add { btnStopServer.Click += value; }
    //    remove { btnStopServer.Click -= value; }
    //}

    //public event EventHandler InstallServer_ButtonClicked
    //{
    //    add { btnInstallServer.Click += value; }
    //    remove { btnInstallServer.Click -= value; }
    //}

    //public event EventHandler UpdateServer_ButtonClicked
    //{
    //    add { btnUpdateServer.Click += value; }
    //    remove { btnUpdateServer.Click -= value; }
    //}

    //public event EventHandler SaveBackup_ButtonClicked
    //{
    //    add { btnSaveBackup.Click += value; }
    //    remove { btnSaveBackup.Click -= value; }
    //}

    //public event EventHandler OpenBackupFolder_ButtonClicked
    //{
    //    add { btnOpenBackupFolder.Click += value; }
    //    remove { btnOpenBackupFolder.Click -= value; }
    //}

    //public event EventHandler OpenSavegameFolder_ButtonClicked
    //{
    //    add { btnOpenSavegameFolder.Click += value; }
    //    remove { btnOpenSavegameFolder.Click -= value; }
    //}

    //public event EventHandler OpenLogFolder_ButtonClicked
    //{
    //    add { btnOpenLogFolder.Click += value; }
    //    remove { btnOpenLogFolder.Click -= value; }
    //}

    public void SetCommands(IAdminPanelCommand[] commands)
    {
        foreach (var command in commands)
        {
            var button = new ToolStripButton();
            button.Enabled = command.IsEnabled;
            button.Visible = command.IsVisible;

            var c = command; // create a closure around the command
            command.PropertyChanged += (o, s) =>
            {
                button.Enabled = c.IsEnabled;
                button.Visible = c.IsVisible;
            };
            button.Click += (o, s) => c.Execute();
        }
    }

    private void gbxServerSpecificControls_Paint(object sender, PaintEventArgs e)
    {
        GroupBox box = (GroupBox)sender;
        e.Graphics.Clear(SystemColors.Control);
        e.Graphics.DrawString(box.Text, box.Font, Brushes.Black, 0, 0);
    }
}

public interface IAdminPanelView
{
    //event EventHandler InstallSteamCmd_ButtonClicked;
    //event EventHandler OpenWindowsFirewall_ButtonClicked;
    //event EventHandler StartServer_ButtonClicked;
    //event EventHandler StopServer_ButtonClicked;
    //event EventHandler InstallServer_ButtonClicked;
    //event EventHandler UpdateServer_ButtonClicked;
    //event EventHandler SaveBackup_ButtonClicked;
    //event EventHandler OpenBackupFolder_ButtonClicked;
    //event EventHandler OpenSavegameFolder_ButtonClicked;
    //event EventHandler OpenLogFolder_ButtonClicked;

    void SetCommands(IAdminPanelCommand[] commands);
}