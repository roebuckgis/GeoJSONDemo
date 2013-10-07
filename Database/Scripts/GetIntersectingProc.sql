USE [CLR_Demo]
GO

/****** Object:  StoredProcedure [dbo].[GetRssNearAddress]    Script Date: 09/29/2013 16:18:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetIntersecting]
	@focuslayer varchar(1000),
	@overlaylayer varchar(1000)
as 
begin

	IF CHARINDEX('http', @focuslayer) > 0
	BEGIN
		DECLARE @georssTable TABLE (point geography, description varchar(2000));
		INSERT INTO @georssTable exec GetGeoRSS @focuslayer;
		SELECT * INTO #focustable FROM @georssTable
	END 
	ELSE
		SELECT * INTO #focustable FROM EXEC GetGeoDataset @focuslayer
--	DECLARE @rssTable TABLE (point geography, description varchar(2000));
--	DECLARE @addressTable TABLE (address varchar(500),point geography);
--	insert into @rssTable exec GetGeoRSS @rssUrl;
--	insert into @addressTable exec GetBingAddressPoint  @address;


--select r.point, r.description from @rssTable r, @addressTable a
--where (r.point.STIntersects(a.point.STBuffer(@Distance)) = 1);

end
GO


