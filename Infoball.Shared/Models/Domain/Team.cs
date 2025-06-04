using Infoball.Shared.Models.DTOs;

namespace Infoball.Shared.Models.Domain;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string League { get; set; }

    public TeamDto ToDto()
    {
        return new TeamDto
        {
            Id = Id,
            Name = Name,
            League = League
        };
    }
}
