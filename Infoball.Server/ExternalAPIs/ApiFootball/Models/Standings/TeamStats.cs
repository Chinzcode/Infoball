using System.Text.Json.Serialization;

namespace Infoball.Server.ExternalAPIs.ApiFootball.Models.Standings;

public class TeamStats
{
    [JsonPropertyName("played")]
    public int Played { get; set; }

    [JsonPropertyName("win")]
    public int Win { get; set; }

    [JsonPropertyName("draw")]
    public int Draw { get; set; }

    [JsonPropertyName("lose")]
    public int Lose { get; set; }

    [JsonPropertyName("goals")]
    public Goals? Goals { get; set; }
}
