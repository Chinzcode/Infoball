using System.Text.Json.Serialization;

namespace Infoball.Server.ExternalAPIs.ApiFootball.Models.Standings;

public class Response
{
    [JsonPropertyName("league")]
    public League? League { get; set; }
}
