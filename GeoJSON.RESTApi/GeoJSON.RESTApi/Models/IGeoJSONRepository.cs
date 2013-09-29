using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoJSON.RESTApi.Models
{
	interface IGeoJSONRepository
	{
		IEnumerable<GeoJSON> GetAll();
		GeoJSON GetIntersecting(GeoJSON.Geometry geometry);
		GeoJSON Get(int id);
		GeoJSON Query(string id);
		GeoJSON Add(GeoJSON item);
		void Remove(int id);
		bool Update(GeoJSON item);
	}
}
