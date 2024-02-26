using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;

namespace Enshrouded_Server_Manager;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // parse the UI version from the config.json file
        var configText = File.ReadAllText("./config.json");
        var config = JsonConvert.DeserializeObject<AppConfig>(configText);
        string? uiVersion = config?.UI;

        if (uiVersion is null || (uiVersion is not null && uiVersion != "OLD"))
        {
            Application.Run(new EnshroudedServerManager());
        }
        else
        {
            Application.Run(new MainForm());
        }
    }
}