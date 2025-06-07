namespace Infoball.Server.ExternalAPIs.ApiFootball.Interfaces;

public interface IApiClient
{
    Task<T?> GetDataAsync<T>(string endpoint, Dictionary<string, string> queryParams) where T : class;
}
