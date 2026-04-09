using System.Text.Json;
using DiamondMechanics.Models;

namespace DiamondMechanics.Services;

public class ReportStorageService
{
    private readonly IWebHostEnvironment _env;
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    public ReportStorageService(IWebHostEnvironment env)
    {
        _env = env;
    }

    private string ReportsDirectory =>
        Path.Combine(_env.ContentRootPath, "App_Data", "reports");

    private void EnsureDirectory()
    {
        Directory.CreateDirectory(ReportsDirectory);
    }

    private string GetRecordPath(Guid id) =>
        Path.Combine(ReportsDirectory, $"{id}.json");

    public async Task SaveReportAsync(SavedReportRecord record)
    {
        EnsureDirectory();

        var json = JsonSerializer.Serialize(record, _jsonOptions);
        await File.WriteAllTextAsync(GetRecordPath(record.Id), json);
    }

    public async Task<List<SavedReportRecord>> GetReportsForPlayerAsync(string playerSlug)
    {
        EnsureDirectory();

        var results = new List<SavedReportRecord>();

        foreach (var file in Directory.GetFiles(ReportsDirectory, "*.json"))
        {
            try
            {
                var json = await File.ReadAllTextAsync(file);
                var record = JsonSerializer.Deserialize<SavedReportRecord>(json, _jsonOptions);

                if (record is not null &&
                    record.PlayerSlug.Equals(playerSlug, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(record);
                }
            }
            catch
            {
                // ignore malformed files for now
            }
        }

        return results
            .OrderByDescending(x => x.CreatedUtc)
            .ToList();
    }

    public async Task<SavedReportRecord?> GetReportAsync(Guid id)
    {
        EnsureDirectory();

        var path = GetRecordPath(id);

        if (!File.Exists(path))
            return null;

        var json = await File.ReadAllTextAsync(path);
        return JsonSerializer.Deserialize<SavedReportRecord>(json, _jsonOptions);
    }

    public Task DeleteReportAsync(Guid id)
    {
        EnsureDirectory();

        var path = GetRecordPath(id);

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        return Task.CompletedTask;
    }
}
