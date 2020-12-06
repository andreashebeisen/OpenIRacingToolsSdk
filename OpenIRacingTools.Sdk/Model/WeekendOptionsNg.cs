using OpenIRacingTools.Sdk.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk.Model
{
    public class WeekendOptionsNg
    {
        public int NumStarters { get; private set; }
        public string StartingGrid { get; private set; }
        public string QualifyingScoring { get; private set; }
        public bool CourseCautions { get; private set; }
        public bool StandingStart { get; private set; }
        public bool ShortParadeLap { get; private set; }
        public string Restarts { get; private set; }
        public string WeatherType { get; private set; }
        public string Skies { get; private set; }
        public string WindDirection { get; private set; }
        public Speed WindSpeed { get; private set; }
        public Temperature WeatherTemp { get; private set; }
        public double RelativeHumidity { get; private set; }
        public double FogLevel { get; private set; }
        public DateTime TimeOfDay { get; private set; }
        public DateTime Date { get; private set; }
        public int EarthRotationSpeedupFactor { get; private set; }
        public bool Unofficial { get; private set; }
        public string CommercialMode { get; private set; }
        public string NightMode { get; private set; }
        public bool IsFixedSetup { get; private set; }
        public string StrictLapsChecking { get; private set; }
        public bool HasOpenRegistration { get; private set; }
        public int HardcoreLevel { get; private set; }
        public int NumJokerLaps { get; private set; }
        public string IncidentLimit { get; private set; }
        public int FastRepairsLimit { get; private set; }
        public int GreenWhiteCheckeredLimit { get; private set; }
    }
}
