using Infoball.Shared.Models.DTOs;

namespace Infoball.Shared.Models.Domain;

public class Team
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? League { get; set; }
    public string? Logo { get; set; }
    public string? Code { get; set; }
    public string? Country { get; set; }
    public int? Founded { get; set; }

    public TeamDto ToDto()
    {
        return new TeamDto
        {
            Id = Id,
            Name = Name,
            League = League,
            Logo = Logo,
            Code = Code,
            Country = Country,
            Founded = Founded
        };
    }
}
