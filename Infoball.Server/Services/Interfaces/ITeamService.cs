using Infoball.Shared.Models;

namespace Infoball.Server.Services.Interfaces;

public interface ITeamService
{
    Task<List<Team>> GetTeamsAsync();
    Task<Team> GetTeamByIdAsync(int id);
    Task<Team> CreateTeamAsync(Team team);
    Task<Team> UpdateTeamAsync(Team team);
    Task<bool> DeleteTeamAsync(int id);
}
