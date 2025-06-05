using System.Text.Json.Serialization;

namespace Infoball.Server.ExternalAPIs.ApiFootball.Models.Standings;

public class Team
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("logo")]
    public string? Logo { get; set; }
}
