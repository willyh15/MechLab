namespace DiamondMechanics.Models;

public class SavedReportRecord
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ReportTitle { get; set; } = string.Empty;
    public string PlayerSlug { get; set; } = string.Empty;
    public string PlayerName { get; set; } = string.Empty;
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;

    public string JsonFileName { get; set; } = string.Empty;
    public string HtmlFileName { get; set; } = string.Empty;

    public AnalysisReport Report { get; set; } = new();
}
