using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoJSON.RESTApi.Models
{
	public class FilckrRepository : IGeoJSONRepository
	{
		IEnumerable<GeoJSON> IGeoJSONRepository.GetAll()
		{
			throw new NotImplementedException();
		}

		GeoJSON IGeoJSONRepository.Get(int id)
		{
			throw new NotImplementedException();
		}

		GeoJSON IGeoJSONRepository.Add(GeoJSON item)
		{
			throw new NotImplementedException();
		}

		void IGeoJSONRepository.Remove(int id)
		{
			throw new NotImplementedException();
		}

		bool IGeoJSONRepository.Update(GeoJSON item)
		{
			throw new NotImplementedException();
		}


		GeoJSON IGeoJSONRepository.GetIntersecting(GeoJSON.Geometry geometry)
		{
			throw new NotImplementedException();
		}

		GeoJSON IGeoJSONRepository.Query(string id)
		{
			throw new NotImplementedException();
		}
	}
}