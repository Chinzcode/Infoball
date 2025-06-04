using Microsoft.AspNetCore.Mvc;
using Infoball.Shared.Models.DTOs;
using Infoball.Server.Services.Interfaces;

namespace Infoball.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    // GET: api/team/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TeamDto>> GetTeam(int id)
    {
        var team = await _teamService.GetTeamAsync(id);

        if (team == null)
        {
            return NotFound();
        }

        return Ok(team.ToDto());
    }
}
