<Query Kind="Program">
  <Connection>
    <ID>34e49857-742e-4d0e-985f-27a711b93174</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	var result=from x in Employees
		orderby x.LastName, x.FirstName
		select new employee{
			Name= x.LastName+ ", "+ x.FirstName,
			Phone= x.Phone,
			ClientCount= x.SupportRepIdCustomers.Count(),
			Clients=(from y in x.SupportRepIdCustomers
						orderby y.LastName, y.FirstName
						select new client{
							Client=y.LastName+", "+y.FirstName,
							City=y.City,
							Phone=y.Phone
						}
					).ToList()
		};
		result.Dump();
}

// Define other methods and classes here

//POCO
public class client{
 public string Client{get;set;}
 public string City{set;get;}
 public string Phone{get;set;}
 
}

//DTO
//linq returns data collections as Iqueryable or IEnumerable by default
//if you want to have the data collection treated as a list<t> you need to add the .ToList() method  to the collection
public class employee{
	public string Name{get;set;}
	public string Phone{get;set;}
	public int ClientCount{get;set;}
	//public IEnumerable<client> Clients{get;set;}
	public List<client> Clients{get;set;}

}