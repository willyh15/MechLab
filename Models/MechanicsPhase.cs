using System.Text.Json.Serialization;

namespace DiamondMechanics.Models;

public class MechanicsPhase
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public double StartSeconds { get; set; }
    public double EndSeconds { get; set; }
    public string Summary { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public List<CoachingPoint> CoachingPoints { get; set; } = [];

    [JsonIgnore]
    public double DurationSeconds => Math.Max(0, EndSeconds - StartSeconds);
}