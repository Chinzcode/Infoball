namespace Infoball.Server.Services.Interfaces;

public interface IStandingsApiClient
{
    Task<string> GetStandingsRawAsync(int league, int season);
    Task<T?> GetStandingsAsync<T>(int league, int season) where T : class;
}
