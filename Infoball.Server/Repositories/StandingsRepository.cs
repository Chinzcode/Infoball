using Microsoft.EntityFrameworkCore;
using Infoball.Server.Repositories.Interfaces;
using Infoball.Shared.Models.Domain;
using Infoball.Server.Data;

namespace Infoball.Server.Repositories;

public class StandingsRepository : IStandingsRepository
{
    private readonly ApplicationDbContext _context;

    public StandingsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Standing>?> GetLeagueStandingsAsync(int leagueId, int season)
    {
        var standingEntities = await _context.Standings
          .Where(s => s.LeagueId == leagueId && s.Season == season)
          .Include(s = s.Team)
          .OrderBy(s = s.Rank)
          .ToListAsync();

        return new Team
        {
            Id = teamEntity.Id,
            Name = teamEntity.Name,
            League = teamEntity.League
        };
    }
}
