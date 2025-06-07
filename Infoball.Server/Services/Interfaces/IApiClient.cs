namespace Infoball.Server.Services.Interfaces;

public interface IApiClient
{
    Task<string> FetchRawDataAsync(string endpoint, Dictionary<string, string> queryParams);
    Task<T?> FetchDataAsync<T>(string endpoint, Dictionary<string, string> queryParams) where T : class;
}
