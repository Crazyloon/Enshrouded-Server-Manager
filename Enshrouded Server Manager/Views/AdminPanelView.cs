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
            var button = new Button();
            button.Enabled = command.IsEnabled;
            button.Visible = command.IsVisible;

            var c = command; // create a closure around the command
            command.PropertyChanged += (o, s) =>
            {
                button.Enabled = c.IsEnabled;
                button.Visible = c.IsVisible;
            };
            btnInstallSteamCMD.Click += (o, s) =>
            {
                c.Execute();
            };
        }
    }

    private void gbxServerSpecificControls_Paint(object sender, PaintEventArgs e)
    {
        GroupBox box = (GroupBox)sender;
        e.Graphics.Clear(Color.FromArgb(0, 0, 18));
        var pen = new Pen(Color.FromArgb(0, 0, 18), 0.5f);
        var borderPen = new Pen(SystemBrushes.ControlDarkDark, 0.5f);
        var brush = new SolidBrush(Color.FromArgb(0, 0, 18));
        var fontHeight = (int)Math.Round(e.Graphics.MeasureString(box.Text, box.Font).Height);
        var textWidth = e.Graphics.MeasureString(box.Text, box.Font).Width;
        var textPaddingVertical = 2;
        var textPaddingHorizontal = 3;

        //e.Graphics.FillRectangle(brush, 0, 0, box.Width - 1, box.Height - 1); // fill the background
        e.Graphics.DrawRectangle(borderPen, 0, 8, box.Width - 1, box.Height - 10); // draw the border

        e.Graphics.FillRectangle(brush, 3, 0, textWidth + textPaddingHorizontal, box.Font.Height); // draw the text background
        e.Graphics.DrawString(box.Text, box.Font, SystemBrushes.ControlLight, fontHeight / 2 - textPaddingVertical, 0); // draw the text
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