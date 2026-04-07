namespace DiamondMechanics.Models;

public class AnalysisReport
{
    public string ReportTitle { get; set; } = string.Empty;
    public string PlayerSlug { get; set; } = string.Empty;
    public string PlayerName { get; set; } = string.Empty;
    public string? SelectedPhaseId { get; set; }
    public string? SelectedPhaseName { get; set; }
    public double UserOffsetSeconds { get; set; }
    public DateTime GeneratedUtc { get; set; } = DateTime.UtcNow;
    public List<AnalysisReportMetric> Metrics { get; set; } = [];
    public List<string> SavedPosePhaseIds { get; set; } = [];
    public string CoachSummary { get; set; } = string.Empty;
}