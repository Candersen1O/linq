<Query Kind="Statements">
  <Connection>
    <ID>34e49857-742e-4d0e-985f-27a711b93174</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

var results=from x in Albums
	select new{
		title=x.Title,
		year=x.ReleaseYear,
		Decade=x.ReleaseYear >1969 && x.ReleaseYear<1980?"70s":
				x.ReleaseYear >1979 && x.ReleaseYear<1990?"80s":
				x.ReleaseYear >1989 && x.ReleaseYear<2000?"90s":
				"Modern"
	}
	
var resultsavg=(from x in Tracks
				select x.Milliseconds).Average();
				
resultsavg.Dump();
var trackbalance = from x in Tracks
	select new{
		song=x.Name,
		length=x.Milliseconds>resultsavg?"long":
				x.Milliseconds<resultsavg?"short":
				"average"
	};trackbalance.Dump();