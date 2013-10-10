SELECT     Tbl.Col.value('(georss:point)[1]', 'varchar(500)') AS Shape
FROM         GetXmlFromService('http://www.adaweb.net/mapping/Vandal.xml') xmlData CROSS APPLY xmlData.[ListItems].nodes('/rss/channel/item') Tbl(Col);

WITH XMLNAMESPACES('http://www.georss.org/georss' as georss
	)
	,rss as (
		select
			Tbl.Col.value('(georss:point)[1]', 'varchar(500)') AS Shape,
			Tbl.Col.value('(description)[1]', 'varchar(2000)') AS description
		from 
			GetXmlFromService('http://www.flickr.com/services/feeds/geo/United+States/Idaho/Boise?format=rss_200') xmlData
			CROSS APPLY xmlData.[ListItems].nodes('/rss/channel/item') Tbl(Col)
	)
	,rss_lat_long as (
		select 
			SUBSTRING(Shape,0,CHARINDEX(' ',Shape,1)) lat,
			SUBSTRING(Shape,CHARINDEX(' ',Shape,1),LEN(Shape)) long,
			description
		from rss
	)
	select geography::STGeomFromText('POINT (' + long + ' ' + lat + ')', 4326) Shape, description INTO StaticFlickr from rss_lat_long 