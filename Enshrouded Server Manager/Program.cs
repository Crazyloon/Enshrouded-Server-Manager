namespace Enshrouded_Server_Manager;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var uiVersion = File.ReadAllLines("./config.txt").Where(x => x.StartsWith("UI")).ToList().FirstOrDefault();

        if (uiVersion is null)
        {
            Application.Run(new EnshroudedServerManager());
        }
        else
        {
            var split = uiVersion.Split('=');
            if (split.Length == 2)
            {
                if (split[0] == "UI")
                {
                    if (split[1] == "NEW")
                    {
                        Application.Run(new EnshroudedServerManager());
                    }
                    else
                    {
                        Application.Run(new MainForm());
                    }
                }
            }
        }
    }
}