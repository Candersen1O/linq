<Query Kind="Statements">
  <Connection>
    <ID>34e49857-742e-4d0e-985f-27a711b93174</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

var results = from x in Albums
 orderby x.ReleaseYear descending, x.Artist.Name ascending, x.Title ascending
 			
 select new{
 	Title=x.Title,
	Artist=x.Artist.Name,
	Year=x.ReleaseYear
};
results.Dump();

var tresults = from x in Tracks
 orderby x.Name ascending
 select new{
 	Track=x.Name,
	Album=x.Album.Title,
	Artist=x.Album.Artist.Name
};
tresults.Dump();

var uresults = from x in Tracks
	where x.Album.Artist.Name.Equals("U2")
//	orderby x.Name ascending
	select new{
		track=x.Name,
		alb=x.Album.Title,
		length=x.Milliseconds/60000.00,
		year=x.Album.ReleaseYear,
		art=x.Album.Artist.Name
		
	};uresults.Dump();
	

