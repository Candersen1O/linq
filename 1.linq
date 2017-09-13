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
	// from instance variable name in entity
	//select for each instance of entity the count of children
	var stuff = from x in Artists  //x.Albums.Count() by x.Name
		select new
		{
		artistname =x.Name,
		albumcount = x.Albums.Count()
		};
		stuff.Dump();
	
}
		public class MyData{
			public string artistname{get;set;}
			public int albumcount{get;set;}
		}


// Define other methods and classes here
