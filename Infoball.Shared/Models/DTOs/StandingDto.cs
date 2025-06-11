namespace Infoball.Shared.Models.DTOs;

public class StandingDTO
{
    public int Rank { get; set; }
    public int TeamId { get; set; }
    public int Points { get; set; }
    public int MatchesPlayed { get; set; }
    public int Wins { get; set; }
    public int Draws { get; set; }
    public int Losses { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalDifference { get; set; }
    public string? Form { get; set; }
}
