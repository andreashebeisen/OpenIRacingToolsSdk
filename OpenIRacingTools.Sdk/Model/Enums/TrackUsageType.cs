using System.ComponentModel.DataAnnotations;

namespace OpenIRacingTools.Sdk.Model.Enums
{
    public enum TrackUsageType
    {
        Unknown = -1,
        Clean,
        SlightUsage,
        LowUsage,
        ModeratelyLowUsage,
        ModerateUsage,
        ModeratelyHighUsage,
        HighUsage,
        ExtensiveUsage,
        MaximumUsage,
        CarryOver
    }
}
