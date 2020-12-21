using System;
using System.Linq;

namespace OpenIRacingTools.Sdk
{
    public static class Calculations
    {
        public static TimeSpan? CalculateDeltaBetweenCars(this Sdk sdk, int carIdxAhead, int carIdxBehind)
        {
            if (sdk.TelemetryData == null)
            {
                return null;
            }

            // First try to calculate with the estimated time to current location which is most precise but not always reliably available.
            var estTimeAhead = sdk.TelemetryData.CarIdxEstTime.Value[carIdxAhead];
            var estTimeBehind = sdk.TelemetryData.CarIdxEstTime.Value[carIdxBehind];
            if (estTimeAhead > 0 && estTimeBehind > 0 && estTimeAhead > estTimeBehind)
            {
                return TimeSpan.FromSeconds(estTimeAhead - estTimeBehind);
            }

            // Get the percentage and estimated time completed of this lap
            var percentageAhead = sdk.TelemetryData.CarIdxLapDistPct.Value[carIdxAhead];
            var percentageBehind = sdk.TelemetryData.CarIdxLapDistPct.Value[carIdxBehind];
            
            float percentageDiff;
            if (percentageAhead > percentageBehind)
            {
                // This is the usual case. Car ahead has a higher lap completion percentage than car behind. We can just use
                // the estimated time to current location on track.
                percentageDiff = percentageAhead - percentageBehind;
            }
            else
            {

                // Now that car behind seems to be further than car ahead means that car ahead already crossed the finish line
                // but car behind didn't. So let's use the car ahead's estimated time to location on track and the car behind's
                // estimated time left on this lap.
                percentageDiff = percentageAhead + 1 - percentageBehind;
            }

            // Calculate diff using the last lap time of the car behind
            var lastLapTime = sdk.TelemetryData.CarIdxLastLapTime.Value[carIdxBehind];

            return lastLapTime > -1 ? TimeSpan.FromSeconds(lastLapTime * percentageDiff) : null;
        }

        public static TimeSpan? CalculateEstimatedTimeToFinishLine(this Sdk sdk, int carIdx)
        {
            if (sdk.TelemetryData == null)
            {
                return null;
            }

            // Get the percentage and estimated time completed of this lap
            var percentage = sdk.TelemetryData.CarIdxLapDistPct.Value[carIdx];
            var estimate = sdk.TelemetryData.CarIdxEstTime.Value[carIdx];

            // Try to get fastest lap time as a reference
            var fastestTime = sdk.SessionData?.SessionInfo?.CurrentSession?.ResultsPositions?.SingleOrDefault(x => x.CarIdx == carIdx)?.FastestTime;

            if (fastestTime.HasValue)
            {
                // Calculate a more accurate estimation using the fastest lap time if available.
                return fastestTime.Value * (1 - percentage);
            }

            // Use the current estimated time on this lap
            return TimeSpan.FromSeconds(estimate / percentage * (1 - percentage));
        }

        public static TimeSpan? CalculateTimeFromFinishLine(this Sdk sdk, int carIdx)
        {
            // Get the percentage and estimated time completed of this lap
            var estimate = sdk.TelemetryData?.CarIdxEstTime.Value[carIdx];

            return estimate.HasValue ? TimeSpan.FromSeconds(estimate.Value) : null;
        }
    }
}
