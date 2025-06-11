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

    public async Task SaveTeamAsync(Team team)
    {
        var existingEntity = await _context.Team.FirstOrDefaultAsync(t => t.Id == team.Id);

        if (existingEntity == null)
        {
            var teamEntity = new Infoball.Server.Data.Entities.Team
            {
                Id = team.Id,
                Name = team.Name,
                League = team.League,
                Logo = team.Logo,
                Code = team.Code,
                Country = team.Country,
                Founded = team.Founded,
                IsNational = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _context.Team.AddAsync(teamEntity);
        }
        else
        {
            existingEntity.Name = team.Name;
            existingEntity.League = team.League;
            existingEntity.Logo = team.Logo;
            existingEntity.Code = team.Code;
            existingEntity.Country = team.Country;
            existingEntity.Founded = team.Founded;
            existingEntity.UpdatedAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
    }
}
