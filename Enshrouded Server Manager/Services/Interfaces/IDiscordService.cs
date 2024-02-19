using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Services;

public interface IDiscordService
{
    void SendMessage(ServerProfile profile, DiscordMessageType messageType, string? timeLeft = null);
    Task TestMsg(string Url, bool embedEnabled);

}