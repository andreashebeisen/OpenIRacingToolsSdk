using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk.Model
{
    public class SessionInfoNg
    {
        public SessionInfoNg()
        {
            UpdateDate = DateTime.Now;
        }

        public DateTime UpdateDate { get; }
        public WeekendInfoNg WeekendInfo { get; private set; }
        public CameraInfo CameraInfo { get; private set; }
        public RadioInfo RadioInfo { get; private set; }
        public DriverInfo DriverInfo { get; private set; }
        public SplitTimeInfoNg SplitTimeInfo { get; private set; }
    }
}
