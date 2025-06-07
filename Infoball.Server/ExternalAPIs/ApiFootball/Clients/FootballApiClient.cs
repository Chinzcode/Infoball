using Infoball.Server.ExternalAPIs.ApiFootball.Interfaces;
using Infoball.Server.ExternalAPIs.ApiFootball.Models.Common;
using System.Text.Json;

namespace Infoball.Server.ExternalAPIs.ApiFootball.Clients;

public class FootballApiClient : IApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<FootballApiClient> _logger;
    private readonly string _baseUrl;

    public FootballApiClient(HttpClient httpClient, ILogger<FootballApiClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _baseUrl = "https://v3.football.api-sports.io";

        var apiKey = Environment.GetEnvironmentVariable("FOOTBALL_API_KEY")
            ?? throw new InvalidOperationException("FOOTBALL_API_KEY environment variable is required");

        _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);
        _httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");
    }

    public async Task<T?> GetDataAsync<T>(string endpoint, Dictionary<string, string> queryParams) where T : class
    {
        try
        {
            var queryString = BuildQueryString(queryParams);
            var url = $"{_baseUrl}/{endpoint}?{queryString}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(json))
            {
                return default(T);
            }

            var apiResponse = JsonSerializer.Deserialize<ApiResponse<T>>(json);
            return apiResponse?.Response ?? default;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching data from API");
            return default(T);
        }
    }

    private static string BuildQueryString(Dictionary<string, string> queryParams)
    {
        return string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}"));
    }
}
