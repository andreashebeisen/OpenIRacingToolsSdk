using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk.Model
{
    public class DriverNg
    {
        public int CarIdx { get; private set; }
        public string AbbrevName { get; private set; }
        public string Initials { get; private set; }
        public int UserID { get; private set; }
        public int TeamID { get; private set; }
        public string TeamName { get; private set; }
        public string CarNumber { get; private set; }
        public int CarNumberRaw { get; private set; }
        public string CarPath { get; private set; }
        public int CarClassID { get; private set; }
        public int CarID { get; private set; }
        public bool CarIsPaceCar { get; private set; }
        public bool CarIsAI { get; private set; }
        public string CarScreenName { get; private set; }
        public string CarScreenNameShort { get; private set; }
        public string CarClassShortName { get; private set; }
        public int CarClassRelSpeed { get; private set; }
        public int CarClassLicenseLevel { get; private set; }
        public double CarClassMaxFuelPct { get; private set; }
        public double CarClassWeightPenalty { get; private set; }
        public double CarClassPowerAdjust { get; private set; }
        public double CarClassDryTireSetLimit { get; private set; }
        public Color CarClassColor { get; private set; }
        public int IRating { get; private set; }
        public int LicLevel { get; private set; }
        public int LicSubLevel { get; private set; }
        public string LicString { get; private set; }
        public Color LicColor { get; private set; }
        public bool IsSpectator { get; private set; }
        public string CarDesignStr { get; private set; }
        public string HelmetDesignStr { get; private set; }
        public string SuitDesignStr { get; private set; }
        public string CarNumberDesignStr { get; private set; }
        public int CarSponsor_1 { get; private set; }
        public int CarSponsor_2 { get; private set; }
        public string ClubName { get; private set; }
        public string DivisionName { get; private set; }
        public int CurDriverIncidentCount { get; private set; }
        public int TeamIncidentCount { get; private set; }
    }
}
