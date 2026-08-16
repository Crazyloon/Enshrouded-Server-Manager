using System.Text.Json;

namespace Enshrouded_Server_Manager.Helpers;
public static class JsonSettings
{
    /// <summary>
    /// JSON options with camel case naming and indented formatting.
    /// Used for the files whose properties are camelCase on disk (server settings, profiles,
    /// discord settings).
    /// </summary>
    public static JsonSerializerOptions Default { get; } = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        // Newtonsoft matched property names case-insensitively; keep that behaviour so
        // files written by older versions of the manager still load.
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
    };

    /// <summary>
    /// JSON options without a naming policy, so property names stay PascalCase.
    /// Used for the files that were written without any serializer settings before the
    /// System.Text.Json migration (config.json, githubversion.json, the running server
    /// process file) - changing their casing would orphan existing files.
    /// </summary>
    public static JsonSerializerOptions Plain { get; } = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
    };
}
