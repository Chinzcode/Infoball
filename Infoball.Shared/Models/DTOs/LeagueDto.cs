namespace Infoball.Shared.Models.DTOs;

public class LeagueDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string? Logo { get; set; }
    public string? Flag { get; set; }
}
