## Flow

Client Side: Blazor Components -> Client Service
Server Side: Controller -> Service -> Cache(miss) -> Repository -> DB(miss) -> API

Controller → Service → Cache → Repository → Database
                  ↓ (if cache/db miss)
                API Client → External API


1. Blazor Component (Client)
Infoball.Client/Components/Pages/PlayerStats.razor
playerStats = await ApiService.GetPlayerStatsAsync(playerId);

2. Client Service (Client)
Infoball.Client/Services/ApiService.cs
return await _httpClient.GetFromJsonAsync<PlayerStatsDto>($"api/players/{playerId}/stats");

3. Controller (Server)
Infoball.Server/Controllers/PlayersController.cs
var player = await _playerService.GetPlayerStatsAsync(id);

4. Service (Server)
Infoball.Server/Services/PlayerService.cs
var cached = await _cacheService.GetAsync($"player-{id}");
if (cached == null) player = await _playerRepository.GetByIdAsync(id);

5. Repository (Server)
Infoball.Server/Repositories/PlayerRepository.cs
var dbPlayer = await _context.Players.FindAsync(id);
if (dbPlayer == null) player = await _footballApiClient.GetPlayerAsync(id);

Example:
Service calls Repository->GetTournaments() (this returns Tournament domain object)
Service makes this Tournament domain object to DTO

## Branches

1. feature/project-setup
2. feature/shared-models
3. feature/database-setup
4. feature/repositories
5. feature/external-api-client
6. feature/caching
7. feature/server-services
8. feature/web-api-contollers
9. feature/client-services
10. feature/blazor-components
11. feature/integration-testing
