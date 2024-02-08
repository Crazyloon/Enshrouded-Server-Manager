using System.Diagnostics;

namespace Enshrouded_Server_Manager.Services.Interfaces;
public interface ISystemProcessService
{
    Process Start(string fileName, string arguments);
}
