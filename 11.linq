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
	
	//reverse of the above
	from t in Tracks
	 group t by t.Genre.Name into tresult
	 	select new{
			genreID=tresult.Key,
			songs= tresult.Select(s=>s.Name)
	}
	
	
	//