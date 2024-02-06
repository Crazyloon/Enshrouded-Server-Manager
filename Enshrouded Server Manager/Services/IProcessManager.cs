using System.Diagnostics;

namespace Enshrouded_Server_Manager.Services;
public interface IProcessManager
{
    Process Start(string fileName, string arguments);
}
