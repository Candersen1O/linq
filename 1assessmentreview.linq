<Query Kind="Expression">
  <Connection>
    <ID>edc3e093-06c9-401c-8661-f10802c7ee5a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from x in EmployeeSkills
 where x.Skill.Description.Contains("plu")
 select new{
 name=x.Employee.FirstName,
 schedule=from y in Schedules where y.EmployeeID==x.EmployeeID select y.HourlyWage
}

from x in Employees 
where (EmployeeSkills.Any(c=>c.Skill.Description.Contains("plu")&&c.EmployeeID==x.EmployeeID)) 
select new{
	name= x.FirstName,
	wage=from i in x.Schedules select i.Day
}