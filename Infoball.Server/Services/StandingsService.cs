using Infoball.Server.ExternalAPIs.ApiFootball.Interfaces;
using Infoball.Server.Repositories.Interfaces;
using Infoball.Server.Services.Interfaces;
using Infoball.Shared.Models.Domain;
using Infoball.Server.ExternalAPIs.ApiFootball.Mappers;

namespace Infoball.Server.Services;

public class StandingsService : IStandingsService
{
    private readonly IStandingsRepository _standingsRepository;
    private readonly ILeagueRepository _leagueRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IStandingsApiClient _standingsApiClient;
    private readonly ILogger<StandingsService> _logger;

    public StandingsService(
        IStandingsRepository standingsRepository,
        ILeagueRepository leagueRepository,
        ITeamRepository teamRepository,
        IStandingsApiClient standingsApiClient,
        ILogger<StandingsService> logger)
    {
        _standingsRepository = standingsRepository;
        _leagueRepository = leagueRepository;
        _teamRepository = teamRepository;
        _standingsApiClient = standingsApiClient;
        _logger = logger;
    }

    public async Task<List<Standing>?> GetStandingsAsync(int leagueId, int season)
    {
        try
        {
            //1. Check cache (TODO: Implement later)

            //2. Check database
            var dbStandings = await _standingsRepository.GetStandingsAsync(leagueId, season);
            if (dbStandings != null && dbStandings.Any())
            {
                _logger.LogInformation("Standings found in db");
                return dbStandings;
            }

            //3. Get from external API
            var apiResponse = await _standingsApiClient.GetStandingsAsync(leagueId, season);
            if (apiResponse == null || !apiResponse.Any())
            {
                _logger.LogWarning("No Standings data received from API");
                return null;
            }

            //4. Extract league and standings data
            var league = apiResponse.FirstOrDefault()?.League;
            if (league?.Standings == null || !league.Standings.Any())
            {
                _logger.LogWarning("API response contains no standings data for league {LeagueId}, season {Season}", leagueId, season);
                return null;
            }

            var teamStandings = league.Standings.FirstOrDefault();
            if (teamStandings == null || !teamStandings.Any())
            {
                _logger.LogWarning("No team standings found in API response for league {LeagueId}, season {Season}", leagueId, season);
                return null;
            }

            var standings = teamStandings.Select(ts => ts.ToDomain(leagueId, season)).ToList();

            //5. Save League data
            var existingLeague = await _leagueRepository.GetLeagueByIdAsync(leagueId);
            if (existingLeague == null)
            {
                var leagueDomain = new League
                {
                    Id = league.Id,
                    Name = league.Name ?? string.Empty,
                    Country = league.Country ?? string.Empty,
                    Logo = league.Logo,
                    Flag = league.Flag
                };

                await _leagueRepository.SaveLeagueAsync(leagueDomain);
                _logger.LogInformation("Saved new league: {LeagueName} (ID: {LeagueId})", league.Name, league.Id);
            }

            //6. Save teams data
            foreach (var teamStanding in teamStandings)
            {
                if (teamStanding.Team != null)
                {
                    var existingTeam = await _teamRepository.GetTeamByIdAsync(teamStanding.Team.Id);
                    if (existingTeam == null)
                    {
                        var team = teamStanding.Team.ToDomain(league.Name ?? "");
                        await _teamRepository.SaveTeamAsync(team);
                        _logger.LogInformation("Saved new team: {TeamName} (ID: {TeamId})", teamStanding.Team.Name, teamStanding.Team.Id);
                    }
                }
            }

            //7. Save standings to database
            await _standingsRepository.SaveStandingsAsync(standings, leagueId, season);

            //8. Cache the result (TODO: Implement later)

            _logger.LogInformation("Successfully saved {Count} standings for league {LeagueId}, season {Season}", standings.Count, leagueId, season);
            return standings;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting standings for league {LeagueId}, season {Season}", leagueId, season);
            throw;
        }
    }
}
