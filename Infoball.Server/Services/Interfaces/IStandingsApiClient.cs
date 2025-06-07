namespace Infoball.Server.Services.Interfaces;

public interface IStandingsApiClient
{
    Task<string> GetStandingsRawAsync(int league, int season);
}
