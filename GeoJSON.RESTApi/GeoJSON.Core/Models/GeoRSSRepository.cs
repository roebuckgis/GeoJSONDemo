using System;
using jGIS.GeoJsonApi.Core.DataAccess;
using jGIS.GeoJsonApi.Core.Helpers;

namespace jGIS.GeoJsonApi.Core.Models
{
	public class GeoRSSRepository : IGeoJsonRepository
	{
		
		FeatureCollection IGeoJsonRepository.GetAll()
		{
			throw new NotImplementedException();
		}
		FeatureCollection IGeoJsonRepository.GetAll(string identifier)
		{
            var result = GeoDataAccess.GeoRss(identifier);
            return Helpers.GeoJson.GetFeatureCollection(result);
		}
		FeatureCollection IGeoJsonRepository.GetIntersecting(string focuslayer, string overlaylayer)
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

        FeatureCollection GetGeoCoded(string address)
        {
            var result = GeoDataAccess.GetAddressPoint(address);
            return Helpers.GeoJson.GetFeatureCollection(result);
        }
	}
}