using System.ComponentModel.DataAnnotations;

namespace Infoball.Server.Data.Entities;

public class League
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
    public ICollection<Season> Seasons { get; set; } = new List<Season>();
    public ICollection<Standing> Standings { get; set; } = new List<Standing>();
}
