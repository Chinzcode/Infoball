using System.Text.Json.Serialization;

namespace Infoball.Server.ExternalAPIs.ApiFootball.Models.Standings;

public class TeamStanding
{
    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    [JsonPropertyName("team")]
    public Team? Team { get; set; }

    [JsonPropertyName("points")]
    public int Points { get; set; }

    [JsonPropertyName("goalsDiff")]
    public int GoalsDiff { get; set; }

    [JsonPropertyName("group")]
    public string? Group { get; set; }

    [JsonPropertyName("form")]
    public string? Form { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("all")]
    public TeamStats? All { get; set; }

    [JsonPropertyName("home")]
    public TeamStats? Home { get; set; }

    [JsonPropertyName("away")]
    public TeamStats? Away { get; set; }

    [JsonPropertyName("update")]
    public string? Update { get; set; }
}
