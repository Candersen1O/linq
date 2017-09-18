<Query Kind="Expression">
  <Connection>
    <ID>34e49857-742e-4d0e-985f-27a711b93174</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

from x in Albums where x.Tracks.Count() == 0 select x

//to get both albums with and without tracks you can use a .Union()
//in a union you need o ensure cast typing is correct
// collumns cast type match identically 
// (query1).Union(query2).Union(quer3).Orderby(first sort).THenBy(nthsort)
(from x in Albums where x.Tracks.Count() == 0 select new {
	TItle=x.Title,
	NumOfTracks=0,
	Artist=x.Artist.Name,
	AlbumCost=0.00m
}).Union(from x in Albums where x.Tracks.Count() > 0 select new {
	TItle=x.Title,
	NumOfTracks=x.Tracks.Count(),
	Artist=x.Artist.Name,
	AlbumCost=x.Tracks.Sum(y=>y.UnitPrice)
}).OrderBy(y=>y.Artist).ThenByDescending(y=>y.AlbumCost).ThenBy(y=>y.TItle)


