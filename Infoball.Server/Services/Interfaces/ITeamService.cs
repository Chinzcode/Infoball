using Infoball.Shared.Models.Domain;

namespace Infoball.Server.Services.Interfaces;

public interface ITeamService
{
    Task<Team?> GetTeamAsync(int id);
}
