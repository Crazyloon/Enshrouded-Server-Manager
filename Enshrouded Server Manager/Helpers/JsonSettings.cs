using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Enshrouded_Server_Manager.Helpers;
public static class JsonSettings
{
    /// <summary>
    /// Returns JSON settings with camel case naming strategy and indented formatting.
    /// </summary>
    public static JsonSerializerSettings Default => new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        },
        Formatting = Formatting.Indented
    };
}