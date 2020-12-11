<Query Kind="Statements">
  <Reference Relative="OpenIRacingTools.Sdk\bin\Debug\net5.0\OpenIRacingTools.Sdk.dll">C:\Users\matth\source\repos\mburtscher\OpenIRacingTools.Sdk\OpenIRacingTools.Sdk\bin\Debug\net5.0\OpenIRacingTools.Sdk.dll</Reference>
  <Namespace>OpenIRacingTools.Sdk</Namespace>
  <Namespace>OpenIRacingTools.Sdk.Model.Types</Namespace>
  <Namespace>System.Drawing</Namespace>
</Query>

using (var sdk = new Sdk()) {
	sdk.Start().WaitForFirstData();
	
	var result = from p in sdk.SessionData.SessionInfo.Sessions.Last().ResultsPositions
				 let d = sdk.SessionData.DriverInfo.Drivers.Single(x => x.CarIdx == p.CarIdx)
				 select new {
				  Position = p.ClassPosition,
				  PositionTotal = p.Position,
				  Name = d.AbbrevName,
				  Team = d.TeamName
				 };
	
	result.Dump();
	
	sdk.SessionData.Dump();
	
	sdk.TelemetryData.Dump();
}

// sdk.SessionInfo?.SessionInfo?.Dump("SessionInfo.WeekendInfo", null, 1);

// sdk.SessionInfo.DriverInfo.Dump("SessionInfo.DriverInfo", null, 2);

// sdk.SessionInfo.DriverInfo.Drivers.Dump("SessionInfo.DriverInfo.Drivers", null, 1);

// sdk.TelemetryInfo.Dump();