<Query Kind="Expression">
  <Connection>
    <ID>34e49857-742e-4d0e-985f-27a711b93174</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//simnple grouping
from genre in Genres
	group genre by genre.Name
	
//grouping by multiple attributes
from tra in Tracks
	group tra by new {tra.Genre.Name, tra.Album.Title}
		
//saving your grouping to a temporary collection
from genre in Genres
	group genre by genre.Name into gresult
	//select gresult
	select new{
		genreName=gresult.Key,
		songs= from x in gresult.ToList() 
		select new {
			Songs=from y in x.Tracks select y.Name
		} 
	}
	
	//reverse of the above (child to parent, not parent to child)
	//uses parent attribute
	from t in Tracks
	 group t by t.Genre.Name into tresult
	 	select new{
			genreID=tresult.Key,
			songs= tresult.Select(s=>s.Name)
	}
	
	
	//group by entire parent record
	from  t in Tracks
	group t by t.Genre into gresult
		select new{
			keyvalue=gresult.Key.Name,
			songs=from x in gresult select new{
				song=x.Name, album=x.Album.Title
			}
		}
		
	//grouping by multiple attributes with temp
from tra in Tracks
	group tra by new {tra.Genre.Name, tra.Album.Title} into gresult
	select new{
		id=gresult.Key.Name,
		song=gresult.Select(a=>a.Name)
	}
	
	
//
from x in Albums
	select new{
		title=x.Title,
		year=x.ReleaseYear,
		Decade=x.ReleaseYear >1969 && x.ReleaseYear<1980?"70s":
				x.ReleaseYear >1979 && x.ReleaseYear<1990?"80s":
				x.ReleaseYear >1989 && x.ReleaseYear<2000?"90s":
				"Modern"
	}
	
//