using System.Diagnostics;

namespace Enshrouded_Server_Manager.Services;
public class ProcessManager : IProcessManager
{
    public Process Start(string fileName, string arguments)
    {
        return Process.Start(fileName, arguments);
    }
}
