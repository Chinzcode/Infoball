using Infoball.Shared.Models;
using System.Net.Http.Json;

namespace Infoball.Client.Services;

public class TeamApiService
{
    private readonly HttpClient _httpClient;

    public TeamApiService(HttpClient HttpClient)
    {
        _httpClient = HttpClient;
    }

    public async Task<List<Team>> GetAllTeamsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Team>>("api/teams") ?? new List<Team>();
    }

    public async Task<Team?> GetTeamAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Team>($"api/teams/{id}");
    }
}
