using Infoball.Shared.Models.Domain;

namespace Infoball.Server.Repositories.Interfaces;

public interface ILeagueRepository
{
    Task<League?> GetLeagueByIdAsync(int id);
    Task SaveLeagueAsync(League league);
}

