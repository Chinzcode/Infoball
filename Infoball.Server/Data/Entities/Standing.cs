using System.ComponentModel.DataAnnotations;

namespace Infoball.Server.Data.Entities;

public class Standing
{
    [Key]
    public int Id { get; set; }

    public int LeagueId { get; set; }
    public int Season { get; set; }
    public int TeamId { get; set; }

    // Standing data
    public int Rank { get; set; }
    public int Points { get; set; }
    public int MatchesPlayed { get; set; }
    public int Wins { get; set; }
    public int Draws { get; set; }
    public int Losses { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalDifference { get; set; }

    [MaxLength(20)]
    public string? Form { get; set; }

    [MaxLength(50)]
    public string? Status { get; set; }

    [MaxLength(200)]
    public string? Description { get; set; }

    [MaxLength(50)]
    public string? Group { get; set; }

    // Home stats
    public int HomeMatchesPlayed { get; set; }
    public int HomeWins { get; set; }
    public int HomeDraws { get; set; }
    public int HomeLosses { get; set; }
    public int HomeGoalsFor { get; set; }
    public int HomeGoalsAgainst { get; set; }

    // Away stats
    public int AwayMatchesPlayed { get; set; }
    public int AwayWins { get; set; }
    public int AwayDraws { get; set; }
    public int AwayLosses { get; set; }
    public int AwayGoalsFor { get; set; }
    public int AwayGoalsAgainst { get; set; }

    public DateTime LastUpdated { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public League League { get; set; } = null!;
    public Team Team { get; set; } = null!;
}
