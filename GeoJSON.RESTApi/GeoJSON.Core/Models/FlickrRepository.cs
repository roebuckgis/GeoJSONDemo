using System;
using jGIS.GeoJsonApi.Core.Helpers;

namespace jGIS.GeoJsonApi.Core.Models
{
	public class FlickrRepository : IGeoJsonRepository
	{
		
		FeatureCollection IGeoJsonRepository.GetAll()
		{            
      return MapEntities.GeoRss(url);
		}
		FeatureCollection IGeoJsonRepository.GetAll(string identifier)
		{
			return MapEntities.GeoRss(identifier);
		}
		FeatureCollection IGeoJsonRepository.GetIntersecting(Geometry geometry)
		{
			throw new NotImplementedException();
		}

		Feature IGeoJsonRepository.Get(int id)
		{
			throw new NotImplementedException();
		}

		FeatureCollection IGeoJsonRepository.Query(string id)
		{
			throw new NotImplementedException();
		}

		Feature IGeoJsonRepository.Add(FeatureCollection item)
		{
			throw new NotImplementedException();
		}

		void IGeoJsonRepository.Remove(int id)
		{
			throw new NotImplementedException();
		}

		bool IGeoJsonRepository.Update(FeatureCollection item)
		{
			throw new NotImplementedException();
		}
	}
}