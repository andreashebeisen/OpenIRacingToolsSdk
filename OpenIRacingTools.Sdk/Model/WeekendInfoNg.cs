using OpenIRacingTools.Sdk.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk.Model
{
    public class WeekendInfoNg
    {
        public string TrackName { get; private set; }
        public int TrackId { get; private set; }
        public Measure TrackLength { get; private set; }
        public string TrackDisplayName { get; private set; }
        public string TrackDisplayShortName { get; private set; }
        public string TrackConfigName { get; private set; }
        public string TrackCity { get; private set; }
        public string TrackCountry { get; private set; }
        public Measure TrackAltitude { get; private set; }
        public double TrackLatitude { get; private set; }
        public double TrackLongitude { get; private set; }
        public double TrackNorthOffset { get; private set; }
        public int TrackNumTurns { get; private set; }
        public Speed TrackPitSpeedLimit { get; private set; }
        // TODO: Use enum!
        public string TrackType { get; private set; }
        public string TrackDirection { get; private set; }
        public string TrackWeatherType { get; private set; }
        public string TrackSkies { get; private set; }
        public Temperature TrackSurfaceTemp { get; private set; }
        public Temperature TrackAirTemp { get; private set; }
        public double TrackAirPressure { get; private set; }
        public Speed TrackWindVel { get; private set; }
        public double TrackWindDir { get; private set; }
        public double TrackRelativeHumidity { get; private set; }
        public double TrackFogLevel { get; private set; }
        public bool TrackCleanup { get; private set; }
        public bool TrackDynamicTrack { get; private set; }
        public string TrackVersion { get; private set; }
        public int SeriesID { get; private set; }
        public int SeasonID { get; private set; }
        public int SessionID { get; private set; }
        public int SubSessionID { get; private set; }
        public int LeagueID { get; private set; }
        public bool Official { get; private set; }
        public int RaceWeek { get; private set; }
        public string EventType { get; private set; }
        public string Category { get; private set; }
        public string SimMode { get; private set; }
        public bool TeamRacing { get; private set; }
        public int MinDrivers { get; private set; }
        public int MaxDrivers { get; private set; }
        public string DCRuleSet { get; private set; }
        public bool QualifierMustStartRace { get; private set; }
        public int NumCarClasses { get; private set; }
        public int NumCarTypes { get; private set; }
        public bool HeatRacing { get; private set; }
        public string BuildType { get; private set; }
        public string BuildTarget { get; private set; }
        public string BuildVersion { get; private set; }
        public WeekendOptionsNg WeekendOptions { get; private set; }
        public TelemetryOptionsNg TelemetryOptions { get; private set; }
    }
}
