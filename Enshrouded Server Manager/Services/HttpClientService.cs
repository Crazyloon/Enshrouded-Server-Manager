namespace Enshrouded_Server_Manager.Services;
public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _httpClient;
    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void Send(string url, string fileName)
    {
        // Callers are synchronous UI paths. Run the download on the thread pool and
        // block, so waiting on the task can't deadlock against the UI message loop.
        Task.Run(() => DownloadFileAsync(url, fileName)).GetAwaiter().GetResult();
    }

    private async Task DownloadFileAsync(string url, string fileName)
    {
        using var response = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        using var source = await response.Content.ReadAsStreamAsync();
        using var destination = File.Create(fileName);
        await source.CopyToAsync(destination);
    }
}
