using OpenIRacingTools.Sdk.Model.Enums;
using OpenIRacingTools.Sdk.Native;
using System.Collections.Generic;

namespace OpenIRacingTools.Sdk.Model
{
    /// <summary>
    /// Represents an object from which you can get Telemetry var headers by name
    /// </summary>
    public sealed class TelemetryData
    {
        private readonly iRacingSDK sdk;

        public TelemetryData(iRacingSDK sdk)
        {
            this.sdk = sdk;
        }

        public TelemetryValue<float> MGUKDeployAdapt => new TelemetryValue<float>(sdk, "dcMGUKDeployAdapt");

        public TelemetryValue<float> MGUKDeployFixed => new TelemetryValue<float>(sdk, "dcMGUKDeployFixed");

        public TelemetryValue<float> MGUKRegenGain => new TelemetryValue<float>(sdk, "dcMGUKRegenGain");

        public TelemetryValue<float> EnergyBatteryToMGU => new TelemetryValue<float>(sdk, "EnergyBatteryToMGU_KLap");

        public TelemetryValue<float> EnergyBudgetBattToMGU => new TelemetryValue<float>(sdk, "EnergyBudgetBattToMGU_KLap");

        public TelemetryValue<float> EnergyERSBattery => new TelemetryValue<float>(sdk, "EnergyERSBattery");

        public TelemetryValue<float> PowerMGUH => new TelemetryValue<float>(sdk, "PowerMGU_H");

        public TelemetryValue<float> PowerMGUK => new TelemetryValue<float>(sdk, "PowerMGU_K");

        public TelemetryValue<float> TorqueMGUK => new TelemetryValue<float>(sdk, "TorqueMGU_K");

        /// <summary>
        /// Current DRS status. 0 = inactive, 1 = can be activated in next DRS zone, 2 = can be activated now, 3 = active.
        /// </summary>
        public TelemetryValue<int> DrsStatus => new TelemetryValue<int>(sdk, "DRS_Status");

        /// <summary>
        /// The number of laps you have completed. Note: on Nordschleife Tourist layout, you can complete a lap without starting a new one!
        /// </summary>
        public TelemetryValue<int> LapCompleted => new TelemetryValue<int>(sdk, "LapCompleted");


        /// <summary>
        /// Seconds since session start. Unit: s
        /// </summary>
        public TelemetryValue<double> SessionTime => new TelemetryValue<double>(sdk, "SessionTime");


        /// <summary>
        /// Session number. 
        /// </summary>
        public TelemetryValue<int> SessionNum => new TelemetryValue<int>(sdk, "SessionNum");


        /// <summary>
        /// Session state. Unit: irsdk_SessionState
        /// </summary>
        public TelemetryValue<SessionState> SessionState => new TelemetryValue<SessionState>(sdk, "SessionState");


        /// <summary>
        /// Session ID. 
        /// </summary>
        public TelemetryValue<int> SessionUniqueID => new TelemetryValue<int>(sdk, "SessionUniqueID");


        /// <summary>
        /// Session flags. Unit: irsdk_Flags
        /// </summary>
        public TelemetryValue<SessionFlags> SessionFlags => new TelemetryValue<SessionFlags>(sdk, "SessionFlags");


        /// <summary>
        /// Driver activated flag. 
        /// </summary>
        public TelemetryValue<bool> DriverMarker => new TelemetryValue<bool>(sdk, "DriverMarker");


        /// <summary>
        /// 0=replay not playing  1=replay playing. 
        /// </summary>
        public TelemetryValue<bool> IsReplayPlaying => new TelemetryValue<bool>(sdk, "IsReplayPlaying");


        /// <summary>
        /// Integer replay frame number (60 per second). 
        /// </summary>
        public TelemetryValue<int> ReplayFrameNum => new TelemetryValue<int>(sdk, "ReplayFrameNum");


        /// <summary>
        /// Current lap number by car index
        /// </summary>
        public TelemetryValue<int[]> CarIdxLap => new TelemetryValue<int[]>(sdk, "CarIdxLap");

        /// <summary>
        /// Current number of completed laps by car index. Note: On Nordschleife Tourist layout, cars can complete a lap without starting a new lap!
        /// </summary>
        public TelemetryValue<int[]> CarIdxLapCompleted => new TelemetryValue<int[]>(sdk, "CarIdxLapCompleted");

        /// <summary>
        /// Percentage distance around lap by car index. Unit: %
        /// </summary>
        public TelemetryValue<float[]> CarIdxLapDistPct => new TelemetryValue<float[]>(sdk, "CarIdxLapDistPct");


        /// <summary>
        /// Track surface type by car index. Unit: irsdk_TrkLoc
        /// </summary>
        public TelemetryValue<TrackSurface[]> CarIdxTrackSurface => new TelemetryValue<TrackSurface[]>(sdk, "CarIdxTrackSurface");


        /// <summary>
        /// Steering wheel angle by car index. Unit: rad
        /// </summary>
        public TelemetryValue<float[]> CarIdxSteer => new TelemetryValue<float[]>(sdk, "CarIdxSteer");


        /// <summary>
        /// Engine rpm by car index. Unit: revs/min
        /// </summary>
        public TelemetryValue<float[]> CarIdxRPM => new TelemetryValue<float[]>(sdk, "CarIdxRPM");


        /// <summary>
        /// -1=reverse  0=neutral  1..n=current gear by car index. 
        /// </summary>
        public TelemetryValue<int[]> CarIdxGear => new TelemetryValue<int[]>(sdk, "CarIdxGear");

        public TelemetryValue<float[]> CarIdxF2Time => new TelemetryValue<float[]>(sdk, "CarIdxF2Time");

        public TelemetryValue<float[]> CarIdxEstTime => new TelemetryValue<float[]>(sdk, "CarIdxEstTime");

        public TelemetryValue<float[]> CarIdxLastLapTime => new TelemetryValue<float[]>(sdk, nameof(CarIdxLastLapTime));

        public TelemetryValue<bool[]> CarIdxOnPitRoad => new TelemetryValue<bool[]>(sdk, "CarIdxOnPitRoad");

        public TelemetryValue<int[]> CarIdxPosition => new TelemetryValue<int[]>(sdk, "CarIdxPosition");

        public TelemetryValue<int[]> CarIdxClassPosition => new TelemetryValue<int[]>(sdk, "CarIdxClassPosition");


        /// <summary>
        /// Steering wheel angle. Unit: rad
        /// </summary>
        public TelemetryValue<float> SteeringWheelAngle => new TelemetryValue<float>(sdk, "SteeringWheelAngle");


        /// <summary>
        /// 0=off throttle to 1=full throttle. Unit: %
        /// </summary>
        public TelemetryValue<float> Throttle => new TelemetryValue<float>(sdk, "Throttle");


        /// <summary>
        /// 0=brake released to 1=max pedal force. Unit: %
        /// </summary>
        public TelemetryValue<float> Brake => new TelemetryValue<float>(sdk, "Brake");


        /// <summary>
        /// 0=disengaged to 1=fully engaged. Unit: %
        /// </summary>
        public TelemetryValue<float> Clutch => new TelemetryValue<float>(sdk, "Clutch");


        /// <summary>
        /// -1=reverse  0=neutral  1..n=current gear. 
        /// </summary>
        public TelemetryValue<int> Gear => new TelemetryValue<int>(sdk, "Gear");


        /// <summary>
        /// Engine rpm. Unit: revs/min
        /// </summary>
        public TelemetryValue<float> RPM => new TelemetryValue<float>(sdk, "RPM");


        /// <summary>
        /// Lap count. 
        /// </summary>
        public TelemetryValue<int> Lap => new TelemetryValue<int>(sdk, "Lap");


        /// <summary>
        /// Meters traveled from S/F this lap. Unit: m
        /// </summary>
        public TelemetryValue<float> LapDist => new TelemetryValue<float>(sdk, "LapDist");


        /// <summary>
        /// Percentage distance around lap. Unit: %
        /// </summary>
        public TelemetryValue<float> LapDistPct => new TelemetryValue<float>(sdk, "LapDistPct");


        /// <summary>
        /// Laps completed in race. 
        /// </summary>
        public TelemetryValue<int> RaceLaps => new TelemetryValue<int>(sdk, "RaceLaps");


        /// <summary>
        /// Longitudinal acceleration (including gravity). Unit: m/s^2
        /// </summary>
        public TelemetryValue<float> LongAccel => new TelemetryValue<float>(sdk, "LongAccel");


        /// <summary>
        /// Lateral acceleration (including gravity). Unit: m/s^2
        /// </summary>
        public TelemetryValue<float> LatAccel => new TelemetryValue<float>(sdk, "LatAccel");


        /// <summary>
        /// Vertical acceleration (including gravity). Unit: m/s^2
        /// </summary>
        public TelemetryValue<float> VertAccel => new TelemetryValue<float>(sdk, "VertAccel");


        /// <summary>
        /// Roll rate. Unit: rad/s
        /// </summary>
        public TelemetryValue<float> RollRate => new TelemetryValue<float>(sdk, "RollRate");


        /// <summary>
        /// Pitch rate. Unit: rad/s
        /// </summary>
        public TelemetryValue<float> PitchRate => new TelemetryValue<float>(sdk, "PitchRate");


        /// <summary>
        /// Yaw rate. Unit: rad/s
        /// </summary>
        public TelemetryValue<float> YawRate => new TelemetryValue<float>(sdk, "YawRate");


        /// <summary>
        /// GPS vehicle speed. Unit: m/s
        /// </summary>
        public TelemetryValue<float> Speed => new TelemetryValue<float>(sdk, "Speed");


        /// <summary>
        /// X velocity. Unit: m/s
        /// </summary>
        public TelemetryValue<float> VelocityX => new TelemetryValue<float>(sdk, "VelocityX");


        /// <summary>
        /// Y velocity. Unit: m/s
        /// </summary>
        public TelemetryValue<float> VelocityY => new TelemetryValue<float>(sdk, "VelocityY");


        /// <summary>
        /// Z velocity. Unit: m/s
        /// </summary>
        public TelemetryValue<float> VelocityZ => new TelemetryValue<float>(sdk, "VelocityZ");


        /// <summary>
        /// Yaw orientation. Unit: rad
        /// </summary>
        public TelemetryValue<float> Yaw => new TelemetryValue<float>(sdk, "Yaw");


        /// <summary>
        /// Pitch orientation. Unit: rad
        /// </summary>
        public TelemetryValue<float> Pitch => new TelemetryValue<float>(sdk, "Pitch");


        /// <summary>
        /// Roll orientation. Unit: rad
        /// </summary>
        public TelemetryValue<float> Roll => new TelemetryValue<float>(sdk, "Roll");


        /// <summary>
        /// Active camera's focus car index. 
        /// </summary>
        public TelemetryValue<int> CamCarIdx => new TelemetryValue<int>(sdk, "CamCarIdx");


        /// <summary>
        /// Active camera number. 
        /// </summary>
        public TelemetryValue<int> CamCameraNumber => new TelemetryValue<int>(sdk, "CamCameraNumber");


        /// <summary>
        /// Active camera group number. 
        /// </summary>
        public TelemetryValue<int> CamGroupNumber => new TelemetryValue<int>(sdk, "CamGroupNumber");


        /// <summary>
        /// State of camera system. Unit: irsdk_CameraState
        /// </summary>
        public TelemetryValue<CameraStates> CamCameraState => new TelemetryValue<CameraStates>(sdk, "CamCameraState");


        /// <summary>
        /// 1=Car on track physics running. 
        /// </summary>
        public TelemetryValue<bool> IsOnTrack => new TelemetryValue<bool>(sdk, "IsOnTrack");


        /// <summary>
        /// 1=Car in garage physics running. 
        /// </summary>
        public TelemetryValue<bool> IsInGarage => new TelemetryValue<bool>(sdk, "IsInGarage");


        /// <summary>
        /// Output torque on steering shaft. Unit: N*m
        /// </summary>
        public TelemetryValue<float> SteeringWheelTorque => new TelemetryValue<float>(sdk, "SteeringWheelTorque");


        /// <summary>
        /// Force feedback % max torque on steering shaft. Unit: %
        /// </summary>
        public TelemetryValue<float> SteeringWheelPctTorque => new TelemetryValue<float>(sdk, "SteeringWheelPctTorque");


        /// <summary>
        /// Percent of shift indicator to light up. Unit: %
        /// </summary>
        public TelemetryValue<float> ShiftIndicatorPct => new TelemetryValue<float>(sdk, "ShiftIndicatorPct");


        /// <summary>
        /// Bitfield for warning lights. Unit: irsdk_EngineWarnings
        /// </summary>
        public TelemetryValue<EngineWarnings> EngineWarnings => new TelemetryValue<EngineWarnings>(sdk, "EngineWarnings");


        /// <summary>
        /// Liters of fuel remaining. Unit: l
        /// </summary>
        public TelemetryValue<float> FuelLevel => new TelemetryValue<float>(sdk, "FuelLevel");


        /// <summary>
        /// Percent fuel remaining. Unit: %
        /// </summary>
        public TelemetryValue<float> FuelLevelPct => new TelemetryValue<float>(sdk, "FuelLevelPct");


        /// <summary>
        /// Replay playback speed. 
        /// </summary>
        public TelemetryValue<int> ReplayPlaySpeed => new TelemetryValue<int>(sdk, "ReplayPlaySpeed");


        /// <summary>
        /// 0=not slow motion  1=replay is in slow motion. 
        /// </summary>
        public TelemetryValue<bool> ReplayPlaySlowMotion => new TelemetryValue<bool>(sdk, "ReplayPlaySlowMotion");


        /// <summary>
        /// Seconds since replay session start. Unit: s
        /// </summary>
        public TelemetryValue<double> ReplaySessionTime => new TelemetryValue<double>(sdk, "ReplaySessionTime");


        /// <summary>
        /// Replay session number. 
        /// </summary>
        public TelemetryValue<int> ReplaySessionNum => new TelemetryValue<int>(sdk, "ReplaySessionNum");


        /// <summary>
        /// Engine coolant temp. Unit: C
        /// </summary>
        public TelemetryValue<float> WaterTemp => new TelemetryValue<float>(sdk, "WaterTemp");


        /// <summary>
        /// Engine coolant level. Unit: l
        /// </summary>
        public TelemetryValue<float> WaterLevel => new TelemetryValue<float>(sdk, "WaterLevel");


        /// <summary>
        /// Engine fuel pressure. Unit: bar
        /// </summary>
        public TelemetryValue<float> FuelPress => new TelemetryValue<float>(sdk, "FuelPress");


        /// <summary>
        /// Engine oil temperature. Unit: C
        /// </summary>
        public TelemetryValue<float> OilTemp => new TelemetryValue<float>(sdk, "OilTemp");


        /// <summary>
        /// Engine oil pressure. Unit: bar
        /// </summary>
        public TelemetryValue<float> OilPress => new TelemetryValue<float>(sdk, "OilPress");


        /// <summary>
        /// Engine oil level. Unit: l
        /// </summary>
        public TelemetryValue<float> OilLevel => new TelemetryValue<float>(sdk, "OilLevel");


        /// <summary>
        /// Engine voltage. Unit: V
        /// </summary>
        public TelemetryValue<float> Voltage => new TelemetryValue<float>(sdk, "Voltage");

        public TelemetryValue<double> SessionTimeRemain => new TelemetryValue<double>(sdk, "SessionTimeRemain");

        public TelemetryValue<int> ReplayFrameNumEnd => new TelemetryValue<int>(sdk, "ReplayFrameNumEnd");

        /// <summary>
        /// Density of air at start/finish line. Unit: kg/m³
        /// </summary>
        public TelemetryValue<float> AirDensity => new TelemetryValue<float>(sdk, "AirDensity");

        /// <summary>
        /// Pressure of air at start/finish line. Unit: Hg
        /// </summary>
        public TelemetryValue<float> AirPressure => new TelemetryValue<float>(sdk, "AirPressure");

        /// <summary>
        /// Temperature of air at start/finish line. Unit: C
        /// </summary>
        public TelemetryValue<float> AirTemp => new TelemetryValue<float>(sdk, "AirTemp");

        /// <summary>
        /// Fog level. Unit: %
        /// </summary>
        public TelemetryValue<float> FogLevel => new TelemetryValue<float>(sdk, "FogLevel");

        /// <summary>
        /// Skies (0=clear/1=p cloudy/2=m cloudy/3=overcast).
        /// </summary>
        public TelemetryValue<int> Skies => new TelemetryValue<int>(sdk, "Skies");

        /// <summary>
        /// Temperature of track at start/finish line. Unit: C
        /// </summary>
        public TelemetryValue<float> TrackTemp => new TelemetryValue<float>(sdk, "TrackTemp");

        /// <summary>
        /// Temperature of track measured by crew around track. Unit: C
        /// </summary>
        public TelemetryValue<float> TrackTempCrew => new TelemetryValue<float>(sdk, "TrackTempCrew");

        /// <summary>
        /// Relative Humidity. Unit: %
        /// </summary>
        public TelemetryValue<float> RelativeHumidity => new TelemetryValue<float>(sdk, "RelativeHumidity");

        /// <summary>
        /// Weather type (0=constant  1=dynamic).
        /// </summary>
        public TelemetryValue<int> WeatherType => new TelemetryValue<int>(sdk, "WeatherType");

        /// <summary>
        /// Wind direction at start/finish line. Unit: rad
        /// </summary>
        public TelemetryValue<float> WindDir => new TelemetryValue<float>(sdk, "WindDir");

        /// <summary>
        /// Wind velocity at start/finish line. Unit: m/s
        /// </summary>
        public TelemetryValue<float> WindVel => new TelemetryValue<float>(sdk, "WindVel");

        public TelemetryValue<int> PlayerCarTeamIncidentCount => new TelemetryValue<int>(sdk, "PlayerCarTeamIncidentCount");

        public TelemetryValue<int> PlayerCarMyIncidentCount => new TelemetryValue<int>(sdk, "PlayerCarMyIncidentCount");

        public TelemetryValue<int> PlayerCarDriverIncidentCount => new TelemetryValue<int>(sdk, "PlayerCarDriverIncidentCount");

        public TelemetryValue<TrackSurface> PlayerTrackSurface => new TelemetryValue<TrackSurface>(sdk, "PlayerTrackSurface");

        public TelemetryValue<int> PlayerCarIdx => new TelemetryValue<int>(sdk, "PlayerCarIdx");
    }
}
