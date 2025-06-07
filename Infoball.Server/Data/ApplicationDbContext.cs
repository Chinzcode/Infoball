using Microsoft.EntityFrameworkCore;
using Infoball.Shared.Models;

namespace Infoball.Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<League> Leagues { get; set; }
}
