using System.Text.Json.Serialization;

namespace Enshrouded_Server_Manager.Services
{
    public class Json
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("saveDirectory")]
        public string SaveDirectory { get; set; }

        [JsonPropertyName("logDirectory")]
        public string LogDirectory { get; set; }

        [JsonPropertyName("ip")]
        public string IpAddress { get; set; }

        [JsonPropertyName("gamePort")]
        public int GamePort { get; set; }

        [JsonPropertyName("queryPort")]
        public int QueryPort { get; set; }

        [JsonPropertyName("slotCount")]
        public int SlotCount { get; set; }
    }

}