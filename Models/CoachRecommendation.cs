namespace DiamondMechanics.Models;

public class CoachRecommendation
{
    public string MainFlaw { get; set; } = string.Empty;
    public string CoachNotes { get; set; } = string.Empty;
    public List<string> TopDrills { get; set; } = [];
}
