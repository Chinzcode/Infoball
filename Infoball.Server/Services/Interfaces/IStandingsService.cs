using Infoball.Shared.Models.Domain;

namespace Infoball.Server.Services.Interfaces;

public interface IStandingsService
{
    Task<List<Standing>?> GetStandingsAsync(int leagueId, int season);
}
