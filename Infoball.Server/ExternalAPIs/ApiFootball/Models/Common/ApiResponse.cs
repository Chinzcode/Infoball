using System.Text.Json.Serialization;

namespace Infoball.Server.ExternalAPIs.ApiFootball.Models.Common;

public class ApiResponse<T>
{
    [JsonPropertyName("get")]
    public string? Get { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, string>? Parameters { get; set; }

    [JsonPropertyName("errors")]
    public string[]? Errors { get; set; }

    [JsonPropertyName("results")]
    public int Results { get; set; }

    [JsonPropertyName("paging")]
    public Dictionary<string, int>? Paging { get; set; }

    [JsonPropertyName("response")]
    public T? Response { get; set; }
}
