using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk.Model
{
    public class DriverInfo
    {
        public int DriverCarIdx { get; private set; }
        public int DriverUserID { get; private set; }
        public int PaceCarIdx { get; private set; }
        public double DriverHeadPosX { get; private set; }
        public double DriverHeadPosY { get; private set; }
        public double DriverHeadPosZ { get; private set; }
        public double DriverCarIdleRPM { get; private set; }
        public double DriverCarRedLine { get; private set; }
        public int DriverCarEngCylinderCount { get; private set; }
        public double DriverCarFuelKgPerLtr { get; private set; }
        public double DriverCarFuelMaxLtr { get; private set; }
        public double DriverCarMaxFuelPct { get; private set; }
        public double DriverCarSLFirstRPM { get; private set; }
        public double DriverCarSLShiftRPM { get; private set; }
        public double DriverCarSLLastRPM { get; private set; }
        public double DriverCarSLBlinkRPM { get; private set; }
        public string DriverCarVersion { get; private set; }
        public double DriverPitTrkPct { get; private set; }
        public double DriverCarEstLapTime { get; private set; }
        public string DriverSetupName { get; private set; }
        public bool DriverSetupIsModified { get; private set; }
        public string DriverSetupLoadTypeName { get; private set; }
        public bool DriverSetupPassedTech { get; private set; }
        public int DriverIncidentCount { get; private set; }
        public List<DriverNg> Drivers { get; private set; }
    }
}
