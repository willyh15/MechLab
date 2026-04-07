namespace DiamondMechanics.Models;

public static class PosePreset
{
    public static readonly List<PoseMarker> DefaultMarkers =
    [
        new() { Key = "head", Label = "Head" },
        new() { Key = "lead_shoulder", Label = "Lead Shoulder" },
        new() { Key = "rear_shoulder", Label = "Rear Shoulder" },
        new() { Key = "hands", Label = "Hands" },
        new() { Key = "lead_hip", Label = "Lead Hip" },
        new() { Key = "rear_hip", Label = "Rear Hip" },
        new() { Key = "lead_knee", Label = "Lead Knee" },
        new() { Key = "rear_knee", Label = "Rear Knee" }
    ];
}