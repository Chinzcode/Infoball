using Microsoft.AspNetCore.Mvc;
using Infoball.Server.Services.Interfaces;

namespace Infoball.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StandingsController : ControllerBase
{
    private readonly IStandingsService _standingsService;
    private readonly ILogger<StandingsController> _logger;

    public StandingsController(IStandingsService standingsService, ILogger<StandingsController> logger)
    {
        _standingsService = standingsService;
        _logger = logger;
    }

    [HttpGet("{league}/{season}")]
    public async Task<IActionResult> GetStandings(int league, int season)
    {
        try
        {
            if (league <= 0 || season <= 0)
            {
                return BadRequest("League and season numbers not valid");
            }

            var standings = await _standingsService.GetStandingsAsync(league, season);

            if (standings == null || !standings.Any())
            {
                return NotFound("No standings data found for the specified league and season");
            }

            var standingsDtos = standings.Select(s => s.ToDto()).ToList();
            return Ok(standingsDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting standings for league {League}, season {Season}", league, season);
            return StatusCode(500, "An error occurred while processing your request");
        }
    }
}
