namespace DiamondMechanics.Models;

public class MechanicsPhase
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public double StartSeconds { get; set; }
    public double EndSeconds { get; set; }
    public string Summary { get; set; } = string.Empty;
    public List<CoachingPoint> CoachingPoints { get; set; } = [];
}