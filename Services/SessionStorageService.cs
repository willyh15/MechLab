using System.Text.Json;
using DiamondMechanics.Models;

namespace DiamondMechanics.Services;

public class SessionStorageService
{
    private readonly IWebHostEnvironment _env;
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    public SessionStorageService(IWebHostEnvironment env)
    {
        _env = env;
    }

    private string SessionsDirectory =>
        Path.Combine(_env.ContentRootPath, "App_Data", "sessions");

    private void EnsureDirectory()
    {
        Directory.CreateDirectory(SessionsDirectory);
    }

    private string GetSessionPath(Guid id) =>
        Path.Combine(SessionsDirectory, $"{id}.json");

    public async Task<List<AnalysisSession>> GetSessionsForPlayerAsync(string playerSlug)
    {
        EnsureDirectory();

        var sessions = new List<AnalysisSession>();

        foreach (var file in Directory.GetFiles(SessionsDirectory, "*.json"))
        {
            try
            {
                var json = await File.ReadAllTextAsync(file);
                var session = JsonSerializer.Deserialize<AnalysisSession>(json, _jsonOptions);

                if (session is not null &&
                    session.PlayerSlug.Equals(playerSlug, StringComparison.OrdinalIgnoreCase))
                {
                    sessions.Add(session);
                }
            }
            catch
            {
                // ignore malformed session file for now
            }
        }

        return sessions
            .OrderByDescending(s => s.UpdatedUtc)
            .ToList();
    }

    public async Task<AnalysisSession?> GetSessionAsync(Guid id)
    {
        EnsureDirectory();

        var path = GetSessionPath(id);

        if (!File.Exists(path))
            return null;

        var json = await File.ReadAllTextAsync(path);
        return JsonSerializer.Deserialize<AnalysisSession>(json, _jsonOptions);
    }

    public async Task SaveSessionAsync(AnalysisSession session)
    {
        EnsureDirectory();

        session.UpdatedUtc = DateTime.UtcNow;

        var json = JsonSerializer.Serialize(session, _jsonOptions);
        await File.WriteAllTextAsync(GetSessionPath(session.Id), json);
    }

    public Task DeleteSessionAsync(Guid id)
    {
        EnsureDirectory();

        var path = GetSessionPath(id);

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        return Task.CompletedTask;
    }
}