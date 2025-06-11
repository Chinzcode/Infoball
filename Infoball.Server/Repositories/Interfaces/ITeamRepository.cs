using Infoball.Shared.Models.Domain;

namespace Infoball.Server.Repositories.Interfaces;

public interface ITeamRepository
{
    Task<Team?> GetTeamByIdAsync(int id);
    Task SaveTeamAsync(Team team);
}
