using ApiTeam = Infoball.Server.ExternalAPIs.ApiFootball.Models.Standings.Team;
using ApiTeamStanding = Infoball.Server.ExternalAPIs.ApiFootball.Models.Standings.TeamStanding;
using DomainTeam = Infoball.Shared.Models.Domain.Team;
using DomainStanding = Infoball.Shared.Models.Domain.Standing;
using EntityStanding = Infoball.Server.Data.Entities.Standing;

namespace Infoball.Server.ExternalAPIs.ApiFootball.Mappers;

public static class StandingsMapper
{
    public static DomainStanding ToDomain(this ApiTeamStanding apiStanding, int leagueId, int season)
    {
        return new DomainStanding
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

    public static DomainTeam ToDomain(this ApiTeam apiTeam, string leagueName)
    {
        return new DomainTeam
        {
            Id = apiTeam.Id,
            Name = apiTeam.Name ?? string.Empty,
            League = leagueName,
            Logo = apiTeam.Logo
        };
    }

    public static EntityStanding ToEntity(this DomainStanding domain)
    {
        return new EntityStanding
        {
            LeagueId = domain.LeagueId,
            Season = domain.Season,
            TeamId = domain.TeamId,
            Rank = domain.Rank,
            Points = domain.Points,
            MatchesPlayed = domain.MatchesPlayed,
            Wins = domain.Wins,
            Draws = domain.Draws,
            Losses = domain.Losses,
            GoalsFor = domain.GoalsFor,
            GoalsAgainst = domain.GoalsAgainst,
            GoalDifference = domain.GoalDifference,
            Form = domain.Form,
            LastUpdated = domain.LastUpdated,
            CreatedAt = DateTime.Now,
        };
    }
}
