using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jGIS.GeoJsonApi.Core.Helpers;

namespace jGIS.GeoJsonApi.Core.Models
{
	public class GeoDatasetRepository : IGeoJsonRepository
	{
		public FeatureCollection GetAll()
		{
			throw new NotImplementedException();
		}
		public FeatureCollection GetAll(string identifier)
		{
			return MapEntities.Geodataset(identifier);
		}
		public FeatureCollection GetIntersecting(Geometry geometry)
		{
			throw new NotImplementedException();
		}

		public Feature Get(int id)
		{
			throw new NotImplementedException();
		}

		public FeatureCollection Query(string id)
		{
			throw new NotImplementedException();
		}

		public Feature Add(FeatureCollection item)
		{
			throw new NotImplementedException();
		}

		public void Remove(int id)
		{
			throw new NotImplementedException();
		}

		public bool Update(FeatureCollection item)
		{
			throw new NotImplementedException();
		}
	}
}
