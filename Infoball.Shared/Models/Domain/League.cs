using Infoball.Shared.Models.DTOs;

namespace Infoball.Shared.Models.Domain;

public class League
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string? Logo { get; set; }
    public string? Flag { get; set; }

    public LeagueDto ToDto()
    {
        return new LeagueDto
        {
            Id = Id,
            Name = Name,
            Country = Country,
            Logo = Logo,
            Flag = Flag
        };
    }
}

