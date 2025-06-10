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
        var standingEntities = await _context.Standing
          .Where(s => s.LeagueId == leagueId && s.Season == season)
          .Include(s => s.Team)
          .OrderBy(s => s.Rank)
          .ToListAsync();

        if (!standingEntities.Any())
        {
            return null;
        }

        return standingEntities.Select(entity => new Standing
        {
            Rank = entity.Rank,
            TeamId = entity.TeamId,
            Points = entity.Points,
            MatchesPlayed = entity.MatchesPlayed,
            Wins = entity.Wins,
            Draws = entity.Draws,
            Losses = entity.Losses,
            GoalsFor = entity.GoalsFor,
            GoalsAgainst = entity.GoalsAgainst,
            GoalDifference = entity.GoalDifference
        }).ToList();
    }
}
