namespace DiamondMechanics.Models;

public class AnalysisSession
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string SessionName { get; set; } = string.Empty;
    public string PlayerSlug { get; set; } = string.Empty;
    public string PlayerName { get; set; } = string.Empty;
    public string SelectedPhaseId { get; set; } = string.Empty;
    public double UserOffsetSeconds { get; set; }
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedUtc { get; set; } = DateTime.UtcNow;
    public Dictionary<string, PhasePoseSnapshot> PoseSnapshots { get; set; } = [];
}