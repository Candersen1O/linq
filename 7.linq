<Query Kind="Expression">
  <Connection>
    <ID>34e49857-742e-4d0e-985f-27a711b93174</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//all acdc song costs
(from x in Tracks
 where x.Composer =="AC/DC"
 select x.UnitPrice).Sum()
 
 //album track info
from x in Albums
 where x.AlbumId == 1
 select new{
 	Title=x.Title,
	ArtistsId=x.ArtistId,
	TrackCount=x.Tracks.Count(),
	AlbumTracks = from y in x.Tracks
					select y
 }
 
 
  //album length info
from x in Albums
 where x.AlbumId == 1
 select new{
 	Title=x.Title,
	ArtistsId=x.ArtistId,
	TrackCount=x.Tracks.Count(),
	//AlbumTracks = (x.Tracks =>).Sum() <--doesn't work
	AlubmLength= (from y in x.Tracks
					select y.Milliseconds).Sum()
	//AlubmLength = x.Tracks.Select (y => y.Milliseconds).Sum ()
 }
 
 from x in Albums
 where x.AlbumId == 1
 select new{
 	Title=x.Title,
	ArtistsId=x.ArtistId,
	TrackCount=x.Tracks.Count(),
	
	AlubmLength= (from y in x.Tracks
					select y.Milliseconds).Sum(),
	MaxTrackLength= (from y in x.Tracks
					select y.Milliseconds).Max(),
	MinTrackLength= (from y in x.Tracks
					select y.Milliseconds).Min(),
					
					averageAlubmLength= (from y in x.Tracks
					select y.Milliseconds).Average()
 }
 
Albums.First()
Albums.First(t=>t.Title.StartsWith("m"))
Albums.ToList()
Albums