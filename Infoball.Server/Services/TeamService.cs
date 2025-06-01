using Microsoft.EntityFrameworkCore;
using Infoball.Server.Services.Interfaces;
using Infoball.Shared.Models;
using Infoball.Server.Data;

namespace Infoball.Server.Services;

public class TeamService : ITeamService
{
    private readonly ApplicationDbContext _context;

    public TeamService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Team>> GetTeamsAsync()
    {
        return await _context.Teams.ToListAsync();
    }

    public async Task<Team?> GetTeamByIdAsync(int id)
    {
        return await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Team> CreateTeamAsync(Team team)
    {
        _context.Teams.Add(team);
        await _context.SaveChangesAsync();
        return team;
    }

    public async Task<Team?> UpdateTeamAsync(Team team)
    {
        var existingTeam = await _context.Teams.FindAsync(team.Id);
        if (existingTeam == null)
            return null;

        _context.Entry(existingTeam).CurrentValues.SetValues(team);
        await _context.SaveChangesAsync();
        return existingTeam;
    }

    public async Task<bool> DeleteTeamAsync(int id)
    {
        var team = await _context.Teams.FindAsync(id);
        if (team == null)
        {
            return false;
        }

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
        return true;
    }
}
