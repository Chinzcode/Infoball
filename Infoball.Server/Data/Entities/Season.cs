using System.ComponentModel.DataAnnotations;

namespace Infoball.Server.Data.Entities;

public class Season
{
    [Key]
    public int Id { get; set; }

    public int LeagueId { get; set; }

    public int Year { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public bool IsCurrent { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public League League { get; set; } = null!;
    public ICollection<Standing> Standings { get; set; } = new List<Standing>();
}
