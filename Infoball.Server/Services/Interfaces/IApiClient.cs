namespace Infoball.Server.Services.Interfaces;

public interface IApiClient
{
    Task<string> FetchRawDataAsync(Dictionary<string, string> queryParams);
    Task<T?> FetchDataAsync<T>(Dictionary<string, string> queryParams);
}
