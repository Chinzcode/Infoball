using Infoball.Server.ExternalAPIs.ApiFootball.Models.Standings;

namespace Infoball.Server.ExternalAPIs.ApiFootball.Interfaces;

public interface IStandingsApiClient
{
    Task<List<Response>?> GetStandingsAsync(int league, int season);
}
