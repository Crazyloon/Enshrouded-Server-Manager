using Enshrouded_Server_Manager.Services.Interfaces;
using System.Net;

namespace Enshrouded_Server_Manager.Services;
public class HttpClientService : IHttpClient
{
    private readonly WebClient _httpClient;
    public HttpClientService(WebClient webClient)
    {
        _httpClient = webClient;
    }

    public void Send(string Url, string fileName)
    {
        _httpClient.DownloadFile(Url, fileName);
    }
}
