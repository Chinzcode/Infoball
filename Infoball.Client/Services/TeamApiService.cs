using Infoball.Shared.Models.DTOs;
using System.Net.Http.Json;

namespace Infoball.Client.Services;

public class TeamApiService
{
    private readonly HttpClient _httpClient;

    public TeamApiService(HttpClient HttpClient)
    {
        _httpClient = HttpClient;
    }

    public async Task<TeamDto?> GetTeamAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<TeamDto>($"api/team/{id}");
    }
}
