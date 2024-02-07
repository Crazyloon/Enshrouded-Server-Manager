namespace Enshrouded_Server_Manager.Services.Interfaces;
public interface IHttpClient
{
    void Send(string url, string fileName);
}
