using System.Diagnostics;

namespace Enshrouded_Server_Manager.Services;
public interface ISystemProcessService
{
    Process Start(string fileName, string arguments);
}
