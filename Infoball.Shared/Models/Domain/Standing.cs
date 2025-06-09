using Infoball.Shared.Models.DTOs;

namespace Infoball.Shared.Models.Domain;

public class Standing
{
    public int Id { get; set; }
    public string League { get; set; }

    public StandingDTO ToDto()
    {
        return new StandingDTO
        {
            Id = Id,
            League = League
        };
    }
}
