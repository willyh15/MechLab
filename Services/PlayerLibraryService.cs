using System.Text.Json;
using DiamondMechanics.Models;

namespace DiamondMechanics.Services;

public class PlayerLibraryService
{
    private readonly IWebHostEnvironment _env;
    private List<PlayerProfile>? _cache;

    public PlayerLibraryService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<List<PlayerProfile>> GetPlayersAsync()
    {
        if (_cache is not null)
            return _cache;

        var filePath = Path.Combine(_env.ContentRootPath, "Data", "players.json");

        if (!File.Exists(filePath))
            return [];

        var json = await File.ReadAllTextAsync(filePath);

        _cache = JsonSerializer.Deserialize<List<PlayerProfile>>(json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? [];

        return _cache;
    }

    public async Task<PlayerProfile?> GetPlayerBySlugAsync(string slug)
    {
        var players = await GetPlayersAsync();
        return players.FirstOrDefault(p => p.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
    }
}