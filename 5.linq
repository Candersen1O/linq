<Query Kind="Expression">
  <Connection>
    <ID>34e49857-742e-4d0e-985f-27a711b93174</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

from x in Employees
	orderby x.LastName, x.FirstName
	select new {
		Name= x.LastName+ ", "+ x.FirstName,
		Phone= x.Phone,
		ClientCount= x.SupportRepIdCustomers.Count(),
		Clients=from y in x.SupportRepIdCustomers
					orderby y.LastName, y.FirstName
					select new{
						Client=y.LastName+", "+y.FirstName,
						City=y.City,
						Phone=y.Phone
					}
	}
	//DTO- Data TRansfer Object
	//POCO - Plain Ordinary COmmon Object
	//used to represent a sebset of a table entity OR combination of fields from multiple table entities
	//POCO is a flat dataset -simple collection has int, date string, etc
	//DTO is a structure dataset- has single fields as well as whole other sets of data
	//CBo- custom business object
	//when select new is used without a type/name its return type is IOrderedQueryable
	//add a name if you want a specific type