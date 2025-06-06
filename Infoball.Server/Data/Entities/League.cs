using System.ComponentModel.DataAnnotations;

namespace Infoball.Server.Data.Entities;

public class LeagueEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Country { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Logo { get; set; }

    [MaxLength(500)]
    public string? Flag { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<SeasonEntity> Seasons { get; set; } = new List<SeasonEntity>();
    public ICollection<StandingEntity> Standings { get; set; } = new List<StandingEntity>();
}
