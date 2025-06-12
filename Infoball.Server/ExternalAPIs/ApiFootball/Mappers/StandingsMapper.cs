using ApiTeam = Infoball.Server.ExternalAPIs.ApiFootball.Models.Standings.Team;
using ApiTeamStanding = Infoball.Server.ExternalAPIs.ApiFootball.Models.Standings.TeamStanding;
using Infoball.Server.Data.Entities;
using Infoball.Shared.Models.Domain;

namespace Infoball.Server.ExternalAPIs.ApiFootball.Mappers;

public static class StandingsMapper
{
    public static Standing ToDomain(this ApiTeamStanding apiStanding, int leagueId, int season)
    {
        return new Standing
        {
            Rank = apiStanding.Rank,
            TeamId = apiStanding.Team?.Id ?? 0,
            LeagueId = leagueId,
            Season = season,
            Points = apiStanding.Points,
            MatchesPlayed = apiStanding.All?.Played ?? 0,
            Wins = apiStanding.All?.Win ?? 0,
            Draws = apiStanding.All?.Draw ?? 0,
            Losses = apiStanding.All?.Lose ?? 0,
            GoalsFor = apiStanding.All?.Goals?.For ?? 0,
            GoalsAgainst = apiStanding.All?.Goals?.Against ?? 0,
            GoalDifference = apiStanding.GoalsDiff,
            Form = apiStanding.Form,
            LastUpdated = DateTime.Now
        };
    }

    public static Team ToDomain(this ApiTeam apiTeam, string leagueName)
    {
        return new Team
        {
            Id = apiTeam.Id,
            Name = apiTeam.Name ?? string.Empty,
            League = leagueName,
            Logo = apiTeam.Logo
        };
    }

    public static StandingEntity ToEntity(this Standing standing)
    {
        return new StandingEntity
        {
            LeagueId = standing.LeagueId,
            Season = standing.Season,
            TeamId = standing.TeamId,
            Rank = standing.Rank,
            Points = standing.Points,
            MatchesPlayed = standing.MatchesPlayed,
            Wins = standing.Wins,
            Draws = standing.Draws,
            Losses = standing.Losses,
            GoalsFor = standing.GoalsFor,
            GoalsAgainst = standing.GoalsAgainst,
            GoalDifference = standing.GoalDifference,
            Form = standing.Form,
            LastUpdated = standing.LastUpdated,
            CreatedAt = DateTime.Now,
        };
    }
}
