using OpenIRacingTools.Sdk.Model.Enums;
using OpenIRacingTools.Sdk.Model.Types;
using System;

namespace OpenIRacingTools.Sdk.Model
{
    public class WeekendOptions
    {
        public int NumStarters { get; private set; }
        public StartingGrid StartingGrid { get; private set; }
        public QualifyingScore QualifyingScoring { get; private set; }
        public CourseCaution CourseCautions { get; private set; }
        public bool StandingStart { get; private set; }
        public bool ShortParadeLap { get; private set; }
        public Restart Restarts { get; private set; }
        public WeatherType WeatherType { get; private set; }
        public TrackSky Skies { get; private set; }
        public string WindDirection { get; private set; }
        public Speed WindSpeed { get; private set; }
        public Temperature WeatherTemp { get; private set; }
        public double RelativeHumidity { get; private set; }
        public double FogLevel { get; private set; }
        public DateTime TimeOfDay { get; private set; }
        public DateTime Date { get; private set; }
        public int EarthRotationSpeedupFactor { get; private set; }
        public bool Unofficial { get; private set; }
        public CommercialMode CommercialMode { get; private set; }
        public NightMode NightMode { get; private set; }
        public bool IsFixedSetup { get; private set; }
        public StrictLapsChecking StrictLapsChecking { get; private set; }
        public bool HasOpenRegistration { get; private set; }
        public int HardcoreLevel { get; private set; }
        public int NumJokerLaps { get; private set; }
        public string IncidentLimit { get; private set; }
        public int FastRepairsLimit { get; private set; }
        public int GreenWhiteCheckeredLimit { get; private set; }
    }
}
