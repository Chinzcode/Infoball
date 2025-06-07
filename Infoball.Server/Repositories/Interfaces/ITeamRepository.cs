using Infoball.Shared.Models.Domain;

namespace Infoball.Server.Repositories.Interfaces;

public interface ITeamRepository
{
    Task<Team?> GetTeamByIdAsync(int id);
    // Task<List<Team>> GetTeamsAsync();
    // Task<Team> CreateTeamAsync(Team team);
    // Task<Team> UpdateTeamAsync(Team team);
    // Task<bool> DeleteTeamAsync(int id);
}
