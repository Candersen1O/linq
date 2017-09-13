<Query Kind="Expression">
  <Connection>
    <ID>34e49857-742e-4d0e-985f-27a711b93174</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

from x in Artists  //x.Albums.Count() by x.Name
		select new
		{
		artistname =x.Name,
		albumcount = x.Albums.Count()
		};
		stuff.Dump();