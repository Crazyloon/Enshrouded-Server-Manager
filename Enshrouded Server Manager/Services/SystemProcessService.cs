using System.Diagnostics;

namespace Enshrouded_Server_Manager.Services;
public class SystemProcessService : ISystemProcessService
{
    public Process Start(string fileName, string arguments)
    {
        return Process.Start(fileName, arguments);
    }
}
