using Microsoft.EntityFrameworkCore;
using Infoball.Server.Data.Entities;

namespace Infoball.Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<TeamEntity> Teams { get; set; }
    public DbSet<StandingEntity> Standings { get; set; }
    public DbSet<LeagueEntity> Leagues { get; set; }
    public DbSet<SeasonEntity> Seasons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TeamEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.HasIndex(e => e.Name);
        });

        modelBuilder.Entity<StandingEntity>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Leagues)
                  .WithMany(l => l.Standings)
                  .HasForeignKey(e => e.LeagueId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Teams)
                  .WithMany(t => t.Standings)
                  .HasForeignKey(e => e.TeamId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => new { e.LeagueId, e.Season, e.TeamId }).IsUnique();

            entity.HasIndex(e => new { e.LeagueId, e.Season });
            entity.HasIndex(e => e.Rank);
        });

        modelBuilder.Entity<LeagueEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Country).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.Name);
        });

        modelBuilder.Entity<SeasonEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Leagues)
                  .WithMany(l => l.Seasons)
                  .HasForeignKey(e => e.LeagueId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => new { e.LeagueId, e.Year }).IsUnique();
        });

    }
}
