using Infoball.Shared.Models.DTOs;

namespace Infoball.Shared.Models.Domain;

public class Standing
{
    public int Id { get; set; }
    public int LeagueId { get; set; }
    public int Season { get; set; }
    public int TeamId { get; set; }
    public int Rank { get; set; }
    public int Points { get; set; }
    public int MatchesPlayed { get; set; }
    public int Wins { get; set; }
    public int Draws { get; set; }
    public int Losses { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalDifference { get; set; }
    public string? Form { get; set; }

    public Team? Team { get; set; }

    public DateTime LastUpdated { get; set; }

    public StandingDTO ToDto()
    {
        return new StandingDTO
        {
            Rank = Rank,
            TeamId = TeamId,
            Points = Points,
            MatchesPlayed = MatchesPlayed,
            Wins = Wins,
            Draws = Draws,
            Losses = Losses,
            GoalsFor = GoalsFor,
            GoalsAgainst = GoalsAgainst,
            GoalDifference = GoalDifference,
            Form = Form
        };
    }
}
