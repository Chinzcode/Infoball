using Infoball.Server.Services.Interfaces;

namespace Infoball.Server.Services.ExternalApi;

public class StandingsApiClient : IStandingsApiClient
{
    private const string Endpoint = "standings";
    private readonly IApiClient _apiClient;

    public StandingsApiClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<string> GetStandingsRawAsync(int league, int season)
    {
        var queryParams = new Dictionary<string, string>
        {
            ["league"] = league.ToString(),
            ["season"] = season.ToString()
        };

        return await _apiClient.FetchRawDataAsync(Endpoint, queryParams);
    }

    public async Task<T?> GetStandingsAsync<T>(int league, int season) where T : class
    {
        var queryParams = new Dictionary<string, string>
        {
            ["league"] = league.ToString(),
            ["season"] = season.ToString()
        };

        return await _apiClient.FetchDataAsync<T>(Endpoint, queryParams);
    }
}
