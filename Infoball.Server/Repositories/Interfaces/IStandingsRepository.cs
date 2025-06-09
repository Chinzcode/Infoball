using Infoball.Shared.Models.Domain;

namespace Infoball.Server.Repositories.Interfaces;

public interface IStandingsRepository
{
    Task<List<Standing>?> GetLeagueStandingsAsync(int season, int league);
}
