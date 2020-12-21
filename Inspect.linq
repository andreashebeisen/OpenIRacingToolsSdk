<Query Kind="Statements">
  <Reference Relative="OpenIRacingTools.Sdk\bin\Debug\net5.0\OpenIRacingTools.Sdk.dll">C:\Users\matth\source\repos\mburtscher\OpenIRacingTools.Sdk\OpenIRacingTools.Sdk\bin\Debug\net5.0\OpenIRacingTools.Sdk.dll</Reference>
  <Namespace>OpenIRacingTools.Sdk</Namespace>
  <Namespace>OpenIRacingTools.Sdk.Model.Types</Namespace>
  <Namespace>System.Drawing</Namespace>
</Query>

using (var sdk = new Sdk())
{
	sdk.Start().WaitForFirstData();
	
	//sdk.TelemetryData.Dump();
	//sdk.SessionData.Dump();
	
	var relativesContainer = new DumpContainer();
	relativesContainer.Dump();
	
	var estimatedTimeContainer = new DumpContainer();
	estimatedTimeContainer.Dump();

	int wantedBehind = 3;
	int wantedAhead = 3;

	while (true)
	{

		var myCarIdx = sdk.TelemetryData.CamCarIdx.Value;
		var myPos2 = sdk.TelemetryData.CarIdxLapDistPct.Value[myCarIdx];
		var foo = (from x in sdk.SessionData.DriverInfo.Drivers
				   let trackPos = sdk.TelemetryData.CarIdxLapDistPct.Value[x.CarIdx]
				   let lap = sdk.TelemetryData.CarIdxLap.Value[x.CarIdx]
				   let order = trackPos + (trackPos < myPos2 - 0.5 ? 1 : 0) - (trackPos > myPos2 + 0.5 ? 1 : 0)
				   where trackPos > 0 && !x.IsSpectator && !x.CarIsPaceCar
				   orderby order descending
				   select x.CarIdx).ToList();

		var myIndex = foo.IndexOf(myCarIdx);
		
		List<(int, TimeSpan?)> result2 = new List<(int, TimeSpan?)>();
		
		// Add cars ahead
		var skip = myIndex - wantedAhead;
		result2.AddRange(foo.Skip(skip).Take(Math.Min(wantedAhead, wantedAhead + skip)).Select(x => (x, sdk.CalculateDeltaBetweenCars(x, myCarIdx))));
		while(result2.Count < wantedAhead)
		{
			result2.Insert(0, (-1, null));
		}
		
		// Add myself
		result2.Add((myCarIdx, default(TimeSpan)));
		
		// Add cars after
		result2.AddRange(foo.Skip(myIndex + 1).Take(wantedBehind).Select(x => (x, sdk.CalculateDeltaBetweenCars(myCarIdx, x))));
		while (result2.Count < wantedAhead + wantedBehind + 1)
		{
			result2.Add((-1, null));
		}
		
		/*
		
		var myEstTime = sdk.TelemetryData.CarIdxEstTime.Value[myCarIdx];
		var myPct = sdk.TelemetryData.CarIdxLapDistPct.Value[myCarIdx];
		
		// Calculate from estimated time and percentage
		// var estimatedTime = myEstTime / myPct;
		
		// Calculate from estimation and remaining of last time
		double estimatedTime;
		var fastestTime = sdk.SessionData.SessionInfo.CurrentSession.ResultsPositions.SingleOrDefault(x => x.CarIdx == myCarIdx)?.FastestTime.TotalSeconds;
		if (fastestTime > 0)
		{
			var remaining = fastestTime.Value * (1 - myPct);
			estimatedTime = myEstTime + remaining;
		}
		else
		{
			estimatedTime = myEstTime / myPct;
		}
		
		// var estimatedTime = sdk.TelemetryData;
		
		estimatedTimeContainer.Content = estimatedTime;

		float CalculatePercentageDiff(float myPercentage, float DriverPercentage)
		{
			if (myPercentage > 0.7 && DriverPercentage < 0.3)
			{
				// Driver is already in next lap
				return DriverPercentage + 1 - myPercentage;
			}
			else if (myPercentage < 0.3 && DriverPercentage > 0.7)
			{
				// Driver is in previous lap
				return DriverPercentage - (myPercentage + 1);
			}
			else
			{
				return DriverPercentage - myPercentage;
			}
		}
*/
		var items = (from x in result2
		 let driver = x.Item1 == -1 ? null : sdk.SessionData.DriverInfo.Drivers.Single(y => y.CarIdx == x.Item1)
		 //let time = x == -1 ? 0 : sdk.TelemetryData.CarIdxEstTime.Value[x]
		 select x.Item1 == -1 ? null : new
		 {
		 	CarIdx = x.Item1,
		 	Name = driver?.AbbrevName,
			Delta = Math.Round(x.Item2.Value.TotalSeconds, 1),
			/*
			EstimatedTime = sdk.TelemetryData.CarIdxEstTime.Value[x.Item1],
			Percentage = sdk.TelemetryData.CarIdxLapDistPct.Value[x.Item1],
			TimeFromFinishLine = sdk.CalculateTimeFromFinishLine(x.Item1),
			TimeToFinishLine = sdk.CalculateEstimatedTimeToFinishLine(x.Item1),
			CurrentLapTime = sdk.SessionData.SessionInfo.CurrentSession.ResultsPositions.Single(y => y.CarIdx == x.Item1).Time,
			*/
		 });
		 /*
		 double CalcTimeDiff(float pct, float myPct, float pctDiff, double estimatedTime, int carIdx, int myCarIdx)
		 {
		 	float estTime = sdk.TelemetryData.CarIdxEstTime.Value[carIdx];
			float myTime = sdk.TelemetryData.CarIdxEstTime.Value[myCarIdx];
			
		 	if (pct > myPct && pct < myPct + 0.3)
			{
				return estTime - myTime;
			}
			else if (pct < myPct && pct > myPct - 0.3)
			{
				return myTime - estTime;
			}
		 	return Math.Round(pctDiff * estimatedTime, 1);
		 }
		 */
		 relativesContainer.Content= items;
		 
		 estimatedTimeContainer.Content = sdk.SessionData;
		 
		 Thread.Sleep(1000);
	}


	//sdk.TelemetryData.CarIdxLapDistPct.Dump();
	//sdk.TelemetryData.Dump();
	var res = from x in sdk.SessionData.DriverInfo.Drivers
			  let trackPos = sdk.TelemetryData.CarIdxLapDistPct.Value[x.CarIdx]
			  let lap = sdk.TelemetryData.CarIdxLap.Value[x.CarIdx]
			  where trackPos != 0 && !x.IsSpectator && !x.CarIsPaceCar
			  orderby trackPos descending
			  select (CarIdx: x.CarIdx, Position: trackPos);
	
	// Start with my own pos
	var relatives = res.Where(x => x.CarIdx == sdk.TelemetryData.CamCarIdx.Value).ToList();
	var myPos = relatives.Single().Position;

	// Add behind
	relatives.AddRange(res.Where(x => x.Position > myPos - 0.5 && x.Position < myPos).Take(wantedBehind));
	relatives.AddRange(res.Where(x => x.Position > 1 + myPos - 0.5).Take(wantedBehind - relatives.Count));
	while (relatives.Count < wantedBehind + 1)
	{
		relatives.Add((-1, 0));
	}

	// Add in front
	relatives.InsertRange(0, res.Where(x => x.Position < myPos + 0.5 && x.Position > myPos).TakeLast(wantedAhead));
	relatives.InsertRange(0, res.Where(x => x.Position < myPos - 0.5).TakeLast(wantedAhead + wantedBehind + 1 - relatives.Count));
	while (relatives.Count < wantedBehind + wantedAhead + 1)
	{
		relatives.Insert(0, (-1, 0));
	}
	
	var result = from x in relatives
				 let d = sdk.SessionData.DriverInfo.Drivers.SingleOrDefault(y => y.CarIdx == x.CarIdx)
	             select x.CarIdx > -1 ? new {
				 	CarIdx = x.CarIdx,
					Name = d?.TeamName,
					Position = x.Position,
				 } : null;

	result.Dump();
	/*
	var ahead = res.Where(x => x.Position > myPos).OrderByDescending(x => x.Position).TakeLast(3);
	
	
	
	var behind = res.Where(x => x.Position > myPos - 0.5 && x.Position < myPos).OrderByDescending(x => x.Position).Take(3);
	
	ahead.Dump("Drivers ahead");
	myPos.Dump("My position");
	behind.Dump("Drivers behind");
	*/		  	
	//sdk.TelemetryData.CamCarIdx.Value.Dump();
	//sdk.TelemetryData.CarIdxEstTime.Dump();
	//sdk.SessionData.SessionInfo.CurrentSession.ResultsPositions.Dump();
	/*
	var myCarIdx = sdk.TelemetryData.CamCarIdx.Value;
	var myName = sdk.SessionData.DriverInfo.Drivers.Single(x => x.CarIdx == myCarIdx).TeamName;
	
	var pairs = new Dictionary<string, float>();
	
	for (int i = 0; i < sdk.TelemetryData.CarIdxEstTime.Value.Length; i++)
	{
		var driver = sdk.SessionData.DriverInfo.Drivers.SingleOrDefault(x => x.CarIdx == i);
		
		if (driver == null || driver.CarIsPaceCar) {
			continue;
		}
		
		pairs[driver.TeamName] = sdk.TelemetryData.CarIdxEstTime.Value[i];
	}

	var ordered = pairs.OrderByDescending(x => x.Value).ToList();
	var myIndex = ordered.IndexOf(ordered.Single(x => x.Key == myName));
	var myTime = ordered[myIndex].Value;
	
	var first = Math.Max(myIndex - 3, 0);
	
	var set = ordered.Skip(first).Take(3 + 1 + 3);

	(from x in set
	 select new { Name = x.Key, Time = x.Value - myTime }).Dump();
	
	
	var result = from p in sdk.SessionData.SessionInfo.CurrentSession.ResultsPositions
				 let d = sdk.SessionData.DriverInfo.Drivers.Single(x => x.CarIdx == p.CarIdx)
				 select new {
				  Position = p.ClassPosition,
				  PositionTotal = p.Position,
				  Name = d.AbbrevName,
				  Team = d.TeamName,
				  Gap = sdk.TelemetryData.CarIdxF2Time.Value[p.CarIdx]
				 };
	
	result.Dump();
	
	*/
	//sdk.SessionData.Dump();
	
	//sdk.TelemetryData.Dump();
}

// sdk.SessionInfo?.SessionInfo?.Dump("SessionInfo.WeekendInfo", null, 1);

// sdk.SessionInfo.DriverInfo.Dump("SessionInfo.DriverInfo", null, 2);

// sdk.SessionInfo.DriverInfo.Drivers.Dump("SessionInfo.DriverInfo.Drivers", null, 1);

// sdk.TelemetryInfo.Dump();