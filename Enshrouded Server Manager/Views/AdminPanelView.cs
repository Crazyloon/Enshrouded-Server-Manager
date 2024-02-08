using Enshrouded_Server_Manager.Commands;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Views.Interfaces;

namespace Enshrouded_Server_Manager.Views;
public partial class AdminPanelView : UserControl, IAdminPanelView
{

    public AdminPanelView()
    {
        InitializeComponent();

        EventAggregator.Instance.Subscribe<SteamCmdInstalledMessage>(b => OnSteamCmdInstallVerified(b.IsInstalled));
    }

    public void SetCommands(IAdminPanelCommand[] commands)
    {
        foreach (var command in commands)
        {
            var button = GetButtonByCommand(command);
            button.Enabled = command.IsEnabled;
            button.Visible = command.IsVisible;

            var c = command; // create a closure around the command
            command.PropertyChanged += (o, s) =>
            {
                button.Enabled = c.IsEnabled;
                button.Visible = c.IsVisible;
            };
            button.Click += (o, s) =>
            {
                c.Execute();
            };
        }
    }

    private Button GetButtonByCommand(IAdminPanelCommand command)
    {
        switch (command)
        {
            case InstallSteamCmdCommand:
                return btnInstallSteamCMD;

            default:
                return null;
        }
    }

    private void OnSteamCmdInstallVerified(bool isInstalled)
    {
        btnInstallServer.Visible = true;
        btnStartServer.Visible = true;
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
