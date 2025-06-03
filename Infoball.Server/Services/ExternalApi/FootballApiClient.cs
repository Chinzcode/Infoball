using Infoball.Server.Services.Interfaces;
using Infoball.Shared.Models;
using System.Text.Json;

namespace Infoball.Server.Services.ExternalApi;

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

    public async Task<string> FetchRawDataAsync(string endpoint, Dictionary<string, string> queryParams)
    {
        try
        {
            var queryString = BuildQueryString(queryParams);
            var url = $"{_baseUrl}/{endpoint}?{queryString}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching raw data from API");
            return string.Empty;
        }
    }

    public async Task<T?> FetchDataAsync<T>(string endpoint, Dictionary<string, string> queryParams) where T : class
    {
        try
        {
            var json = await FetchRawDataAsync(endpoint, queryParams);

            if (string.IsNullOrEmpty(json))
            {
                return default(T);
            }

            var apiResponse = JsonSerializer.Deserialize<ApiResponse<T>>(json);
            return apiResponse?.Response ?? default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deserializing API respone");
            return default(T);
        }
    }

    private static string BuildQueryString(Dictionary<string, string> queryParams)
    {
        return string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}"));
    }
}
