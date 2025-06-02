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

        var apiKey = ""; //TODO Get Api key
        _baseUrl = ""; //TODO Get base url

        //TODO Set headers
    }

    public async Task<string> FetchRawDataAsync(Dictionary<string, string> queryParams)
    {
        try
        {
            var queryString = BuildQueryString(queryParams);
            var url = $"{_baseUrl}?{queryString}";

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

    public async Task<T?> FetchDataAsync<T>(Dictionary<string, string> queryParams) where T : class
    {
        try
        {
            var json = await FetchRawDataAsync(queryParams);

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
