using System.Diagnostics;

namespace Enshrouded_Server_Manager.Services.Interfaces;
public interface IProcessManager
{
    Process Start(string fileName, string arguments);
}
