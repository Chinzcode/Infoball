using System.Text.Json.Serialization;

namespace Infoball.Shared.Models;

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
    public Dictionary<int, int>? Paging { get; set; }

    [JsonPropertyName("response")]
    public T? Response { get; set; }
}
