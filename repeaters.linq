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
	//web display control repeater
	//example Artist: ____ Albums: ___ ___ ___ ___ __ __ __ __
	//(repeat)
	//DTOs
	
	var results = from x in Genres 
					select new GenreDTO{//Genre DTO
						genre=x.Name,
						albums= from y in x.Tracks
								group y by y.Album into gresults
								select new AlbumDTO//Album DTO
								{
									title=gresults.Key.Title,
									year=gresults.Key.ReleaseYear,
									//numotracks=gresults.Key.Tracks.Count(),
									numotracks=gresults.Count(),
									tracks=from z in gresults select new TrackPOCO{//track POCO
																song=z.Name,
																length=z.Milliseconds
															}
								}
					};
	results.Dump();
}

public class TrackPOCO{
	public string song{get;set;}
	public int length{get;set;}
	public string LENGTH{
	get{
		int minutes=length/60000;
		int seconds=(length % 60000)/1000;
		return string.Format("{0}:{1:00}",minutes, seconds);
	}
	}
}

public class AlbumDTO{
	public string title{get;set;}
	public int year{get;set;}
	public int numotracks{get;set;}
	public IEnumerable<TrackPOCO> tracks{get;set;}
}

public class GenreDTO{
     public string genre{get;set;}
	 public IEnumerable<AlbumDTO> albums{get;set;}
}