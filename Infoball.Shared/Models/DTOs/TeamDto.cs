namespace Infoball.Shared.Models.DTOs;

/// <summary>
/// Team Model
/// </summary>
public class TeamDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? League { get; set; }
    public string? Logo { get; set; }
    public string? Code { get; set; }
    public string? Country { get; set; }
    public int? Founded { get; set; }
}
