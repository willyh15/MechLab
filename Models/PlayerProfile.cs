namespace DiamondMechanics.Models;

public class PlayerProfile
{
    public string Slug { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Sport { get; set; } = string.Empty;     // Baseball / Softball
    public string Category { get; set; } = string.Empty;  // Hitting / Pitching
    public string Level { get; set; } = string.Empty;     // Pro / College
    public string TeamOrSchool { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string ThrowsOrBats { get; set; } = string.Empty;
    public string HeroImageUrl { get; set; } = string.Empty;
    public string VideoUrl { get; set; } = string.Empty;
    public string Overview { get; set; } = string.Empty;
    public List<MechanicsPhase> Phases { get; set; } = [];
}