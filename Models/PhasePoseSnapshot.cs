namespace DiamondMechanics.Models;

public class PhasePoseSnapshot
{
    public string PhaseId { get; set; } = string.Empty;
    public Dictionary<string, PosePoint> ProPoints { get; set; } = [];
    public Dictionary<string, PosePoint> UserPoints { get; set; } = [];
}