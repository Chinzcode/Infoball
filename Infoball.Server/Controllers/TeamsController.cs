using Microsoft.AspNetCore.Mvc;
using Infoball.Server.Services.Interfaces;
using Infoball.Server.Models;

namespace Infoball.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamsController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    // GET: api/teams
    [HttpGet]
    public async Task<IActionResult> GetAllTeams()
    {
        var teams = await _teamService.GetTeamsAsync();
        return Ok(teams);
    }

    // GET: api/teams/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeam(int id)
    {
        var team = await _teamService.GetTeamByIdAsync(id);
        if (team == null)
        {
            return NotFound();
        }

        return Ok(team);
    }
}
