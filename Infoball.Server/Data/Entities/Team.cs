using System.ComponentModel.DataAnnotations;

namespace Infoball.Server.Data.Entities;

public class Team
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(10)]
    public string? Code { get; set; }

    [MaxLength(50)]
    public string? Country { get; set; }

    public int? Founded { get; set; }

    [MaxLength(500)]
    public string? Logo { get; set; }

    public bool IsNational { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<Standing> Standings { get; set; } = new List<Standing>();
}
