using Microsoft.AspNetCore.Mvc;
using Infoball.Server.Services.Interfaces;
using Infoball.Shared.Models.ApiModels;

namespace Infoball.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StandingsController : ControllerBase
{
    private readonly IStandingsApiClient _standingsClient;

    public StandingsController(IStandingsApiClient standingsClient)
    {
        _standingsClient = standingsClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetStandings([FromQuery] int league, [FromQuery] int season)
    {
        try
        {
            if (league <= 0 || season <= 0)
            {
                return BadRequest("League and season numbers not valid");
            }

            var standings = await _standingsClient.GetStandingsAsync<StandingsResponse[]>(league, season);

            if (standings == null)
            {
                return NotFound("No standings data found for the specified league and season");
            }

            return Ok(standings);
        }
        catch (Exception ex)
        {

            return StatusCode(500, $"Error: {ex.Message}");
        }
    }

    [HttpGet("{league}/{season}")]
    public async Task<IActionResult> GetStandinsByRoute(int league, int season)
    {
        return await GetStandings(league, season);
    }
}
