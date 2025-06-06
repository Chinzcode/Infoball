using Microsoft.EntityFrameworkCore;
using Infoball.Server.Data.Entities;

namespace Infoball.Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Team> Team { get; set; }
    public DbSet<Standing> Standing { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Season> Seasons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.HasIndex(e => e.Name);
        });

        modelBuilder.Entity<Standing>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.League)
                  .WithMany(l => l.Standings)
                  .HasForeignKey(e => e.LeagueId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Team)
                  .WithMany(t => t.Standings)
                  .HasForeignKey(e => e.TeamId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => new { e.LeagueId, e.Season, e.TeamId }).IsUnique();

            entity.HasIndex(e => new { e.LeagueId, e.Season });
            entity.HasIndex(e => e.Rank);
        });

        modelBuilder.Entity<League>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Country).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.Name);
        });

        // Season configuration
        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.League)
                  .WithMany(l => l.Seasons)
                  .HasForeignKey(e => e.LeagueId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint: One season per league per year
            entity.HasIndex(e => new { e.LeagueId, e.Year }).IsUnique();
        });

    }
}
