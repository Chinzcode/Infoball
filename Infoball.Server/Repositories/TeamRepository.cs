using Microsoft.EntityFrameworkCore;
using Infoball.Server.Repositories.Interfaces;
using Infoball.Shared.Models.Domain;
using Infoball.Server.Data;

namespace Infoball.Server.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly ApplicationDbContext _context;

    public TeamRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Team?> GetTeamByIdAsync(int id)
    {

        var teamEntity = await _context.Team.FirstOrDefaultAsync(t => t.Id == id);

        if (teamEntity == null)
        {
            return null;
        }

        return new Team
        {
            Id = teamEntity.Id,
            Name = teamEntity.Name,
            League = teamEntity.League ?? string.Empty,
            Logo = teamEntity.Logo,
            Code = teamEntity.Code,
            Country = teamEntity.Country,
            Founded = teamEntity.Founded
        };
    }

    // public async Task<List<Team>> GetTeamsAsync()
    // {
    //     return await _context.Teams.ToListAsync();
    // }

    // public async Task<Team> CreateTeamAsync(Team team)
    // {
    //     _context.Teams.Add(team);
    //     await _context.SaveChangesAsync();
    //     return team;
    // }

    // public async Task<Team?> UpdateTeamAsync(Team team)
    // {
    //     var existingTeam = await _context.Teams.FindAsync(team.Id);
    //     if (existingTeam == null)
    //         return null;
    //
    //     _context.Entry(existingTeam).CurrentValues.SetValues(team);
    //     await _context.SaveChangesAsync();
    //     return existingTeam;
    // }

    // public async Task<bool> DeleteTeamAsync(int id)
    // {
    //     var team = await _context.Teams.FindAsync(id);
    //     if (team == null)
    //     {
    //         return false;
    //     }
    //
    //     _context.Teams.Remove(team);
    //     await _context.SaveChangesAsync();
    //     return true;
    // }
}
