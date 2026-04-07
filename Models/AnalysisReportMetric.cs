namespace DiamondMechanics.Models;

public class AnalysisReportMetric
{
    public string Title { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string Detail { get; set; } = string.Empty;
    public string Severity { get; set; } = "good";
}