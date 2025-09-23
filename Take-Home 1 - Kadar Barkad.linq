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

Programs
.Select(x => new 
{
	School = x.SchoolCode == "SAMIT" ? "School of Advance Media and IT" :
			 x.SchoolCode == "SEET" ? "School of Electrical Engineering Technology" : "Unknown",
	Program = x.ProgramName,
	RequiredCourseCount = x.ProgramCourses.Count(x => x.Required),
	OptionalCourseCount = x.ProgramCourses.Count(x => x.Required == false)
})
.Where(x => x.RequiredCourseCount >= 22)
.OrderBy(x => x.Program)
.Dump();

//Question 3

Students.Where(x => x.StudentPayments.Count == 0 && x.Countries.CountryName != "Canada")
.OrderBy(x => x.LastName)
.Select(x => new 
{
	StudentNumber = x.StudentNumber,
	CountryName = x.Countries.CountryName,
	FullName = x.FirstName + " " + x.LastName,
	ClubMembershipCount = x.ClubMembers.Count == 0 ? "None" : x.ClubMembers.Count.ToString()
})
.Dump();

//Question 4
Employees.Where(x => x.Position.Description == "Instructor" && x.ReleaseDate == null && x.ClassOfferings.Count >= 1)
.OrderByDescending(x => x.ClassOfferings.Count)
.ThenBy(x => x.LastName)
.Select(x => new 
{
	ProgramName = x.Program.ProgramName,
	FullName = x.FirstName + " " + x.LastName,
	WorkLoad = x.ClassOfferings.Count > 24 ? "High" :
			   x.ClassOfferings.Count > 8 ? "Med" : "Low"	
})
.Dump();
Employees.Dump();

//Question 5

Clubs
	.Select(x => new 
	{ 
		Supervisor = x.Employee != null ? x.Employee.FirstName + " " + x.Employee.LastName : "Unknown",
		Club = x.ClubName,
		MemberCount = x.ClubMembers.Count,
		Activities = x.ClubActivities.Count == 0 ? "None Schedule" : x.ClubActivities.Count.ToString()
	})
	.OrderByDescending(x => x.MemberCount)
	.Dump();























