Client Side: Blazor Components -> Client Service
Server Side: Controller -> Service -> Cache(miss) -> Repository -> DB(miss) -> API


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
