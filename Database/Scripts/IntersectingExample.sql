DECLARE @focuslayer AS VARCHAR(255)
DECLARE @overlayer AS VARCHAR(255)

SET @focuslayer = 'Vandalism'
SET @overlayer = 'FloodZone'

DECLARE @sql VARCHAR(MAX) = '
select f.* from '+@focuslayer+' f, '+@overlayer+' o
where f.Shape.STIntersects(o.Shape )= 1'

EXEC(@sql)