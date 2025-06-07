using System.Text.Json.Serialization;

namespace Infoball.Server.ExternalAPIs.ApiFootball.Models.Standings;

public class Goals
{
    [JsonPropertyName("for")]
    public int For { get; set; }

    [JsonPropertyName("against")]
    public int Against { get; set; }
}
