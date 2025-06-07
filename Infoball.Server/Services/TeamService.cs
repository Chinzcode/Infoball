using Infoball.Server.Services.Interfaces;
using Infoball.Shared.Models.Domain;
using Infoball.Server.Repositories.Interfaces;

namespace Infoball.Server.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<Team?> GetTeamAsync(int id)
    {
        //TODO: Check if cached. If not cached then use repository to get data from DB

        var team = await _teamRepository.GetTeamByIdAsync(id);
        return team;
    }
}
