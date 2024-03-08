using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Services;
public interface IScheduledRestartService
{
    Task<CountDownTimer?> StartScheduledRestarts(ServerProfile serverProfile);
}
