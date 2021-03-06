<Query Kind="Expression">
  <Connection>
    <ID>34e49857-742e-4d0e-985f-27a711b93174</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//simple where
//artists with ch in name
from artist in Artists
	where artist.Name.Contains("ch")
		select artist
		
//artists with multiple albums
//need an aggregarte test in the where. aggregate test are done against a collection
from artist in Artists
	where artist.Albums.Count()>1
		select artist
		
//combo where
from artist in Artists
	where artist.Albums.Count()>1 && artist.Name.Contains("ch")
		select artist

//test nulls
from alb in Albums
	where alb.ReleaseLabel != null || alb.ReleaseLabel != ""
	select alb
	
	//no works
	from alb in Albums
	where string.IsNullOrEmpty(alb.ReleaseLabel)
	select alb