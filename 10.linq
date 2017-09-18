<Query Kind="Statements">
  <Connection>
    <ID>34e49857-742e-4d0e-985f-27a711b93174</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//multistatements

var results= (from x in MediaTypes
				select x.Tracks.Count()).Max();
results.Dump();				
//we want the tracks of the most popular mediatype
var popmedtyp=from x in MediaTypes
				where x.Tracks.Count() >= results
				select new{
					type=x.Name,
					TCount=x.Tracks.Count()
				};
				popmedtyp.Dump();
			
				
//combination of the two above statements
var combopopmedtyp=from x in MediaTypes
				where x.Tracks.Count() >= (from z in MediaTypes
				select z.Tracks.Count()).Max()
				select new{
					type=x.Name,
					TCount=x.Tracks.Count()
				};
				combopopmedtyp.Dump();
				
				
				//least tracks
var combopopmedtyp=from x in MediaTypes
				where x.Tracks.Count() <= (from z in MediaTypes
				select z.Tracks.Count()).Min()
				select new{
					type=x.Name,
					TCount=x.Tracks.Count()
				};
				combopopmedtyp.Dump();
				
				//which artist has published the most albums
				var bigartist=from x in Artists
				where x.Albums.Count() >= (from z in Artists
				select z.Albums.Count()).Max()
				select new{
					Artist=x.Name,
					NumberOfAlbums=x.Albums.Count()
				};
				bigartist.Dump();
				
				//classvariant
				var mostalbums=(from x in Artists
					select x.Albums.Count()).Max();
				mostalbums.Dump();
				
				var busyartist=from x in Artists
					where x.Albums.Count()>=mostalbums
					select new{Artist=x.Name, total=x.Albums.Count(), albums=x.Albums.Title};
					busyartist.Dump();
				