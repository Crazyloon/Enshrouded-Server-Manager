namespace Enshrouded_Server_Manager.UI;
public static class Interactions
{
    public static void AnimateSaveChangesButton(Button btn, string buttonText, string savedText, int duration = 2000)
    {
        btn.Text = savedText;
        btn.Enabled = false;

        Task.Factory.StartNew(() =>
        {
            Thread.Sleep(duration);
            btn.Invoke(new Action(() =>
            {
                btn.Text = buttonText;
                btn.Enabled = true;
            }));
        });
    }

    public static void UpdateBackupInfo(Label infoLabel, int totalBackups, long diskConsumption)
    {
        string metric = "KB";
        // convert bytes to KB
        diskConsumption = diskConsumption / 1024;

        if (diskConsumption > 1024)
        {
            // convert KB to MB
            diskConsumption = diskConsumption / 1024;
            metric = "MB";
        }

        infoLabel.Visible = true;
        infoLabel.Text = $"Total Backups: {totalBackups}\nDisk Consumption: {diskConsumption}{metric}";
    }
}
