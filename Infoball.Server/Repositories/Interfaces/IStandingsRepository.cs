using Infoball.Shared.Models.Domain;

namespace Infoball.Server.Repositories.Interfaces;

public interface IStandingsRepository
{
    Task<List<Standing>?> GetStandingsAsync(int season, int league);
    Task SaveStandingsAsync(List<Standing> standings, int leagueId, int season);
}
