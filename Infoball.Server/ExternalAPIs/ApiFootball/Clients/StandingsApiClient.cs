using Infoball.Server.ExternalAPIs.ApiFootball.Interfaces;
using Infoball.Server.ExternalAPIs.ApiFootball.Models.Standings;

namespace Infoball.Server.ExternalAPIs.ApiFootball.Clients;

public class StandingsApiClient : IStandingsApiClient
{
    private const string Endpoint = "standings";
    private readonly IApiClient _apiClient;

    public StandingsApiClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<Response>?> GetStandingsAsync(int league, int season)
    {
        var queryParams = new Dictionary<string, string>
        {
            ["league"] = league.ToString(),
            ["season"] = season.ToString()
        };

        return await _apiClient.GetDataAsync<List<Response>>(Endpoint, queryParams);
    }
}
