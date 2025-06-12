using Infoball.Server.Data;
using Microsoft.EntityFrameworkCore;
using Infoball.Shared.Models.Domain;
using Infoball.Server.Repositories.Interfaces;
using Infoball.Server.Data.Entities;

namespace Infoball.Server.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly ApplicationDbContext _context;

        public LeagueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<League?> GetLeagueByIdAsync(int id)
        {
            var leagueEntity = await _context.Leagues.FirstOrDefaultAsync(l => l.Id == id);
            if (leagueEntity == null) return null;

            return new League
            {
                Id = leagueEntity.Id,
                Name = leagueEntity.Name,
                Country = leagueEntity.Country,
                Logo = leagueEntity.Logo,
                Flag = leagueEntity.Flag
            };
        }

        public async Task SaveLeagueAsync(League league)
        {
            var existingEntity = await _context.Leagues.FirstOrDefaultAsync(l => l.Id == league.Id);

            if (existingEntity == null)
            {
                var leagueEntity = new LeagueEntity
                {
                    Id = league.Id,
                    Name = league.Name,
                    Country = league.Country,
                    Logo = league.Logo,
                    Flag = league.Flag,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                await _context.Leagues.AddAsync(leagueEntity);
            }
            else
            {
                existingEntity.Name = league.Name;
                existingEntity.Country = league.Country;
                existingEntity.Logo = league.Logo;
                existingEntity.Flag = league.Flag;
                existingEntity.UpdatedAt = DateTime.Now;
            }

            await _context.SaveChangesAsync();
        }
    }
}
