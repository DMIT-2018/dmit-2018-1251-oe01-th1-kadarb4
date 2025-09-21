<Query Kind="Statements">
  <Connection>
    <ID>c16ba2b2-047b-4b52-a352-f890f1016924</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>Kadar</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>StartTed-2025-Sept</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

//Question 1
ClubActivities.Where(x => x.StartDate >= new DateTime(2025, 1, 1) && x.CampusVenue.Location != "Scheduled Room" && x.Name != "BTech Club Meeting")
.Select(x => new 
{ 
	StartDate = x.StartDate,
	Location = x.CampusVenue.Location,
	Club = x.Club.ClubName,
	Activity = x.Name
})
.OrderBy(x => x.StartDate)
.Dump();

//Question 2
ProgramCourses.OrderBy(x => x.Program.ProgramName)
.Select(x => new 
{ 
	School = x.Program.SchoolCode == "SAMIT" ? "School of Advance Media and IT" :
			 x.Program.SchoolCode == "SEET" ? "School of Electrical Engineering Technology" : "Unknown",
	Program = x.Program.ProgramName,
	RequiredCourseCount = x.Required == true ? 1 : 0,
	
	
})
.Dump();

//Question 3
