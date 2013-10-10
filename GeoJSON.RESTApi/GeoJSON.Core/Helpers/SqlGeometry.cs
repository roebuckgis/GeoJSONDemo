using System.Collections;
using System.Linq;
using Microsoft.SqlServer.Types;
using jGIS.GeoJsonApi.Core.Models;

namespace jGIS.GeoJsonApi.Core.Helpers
{
	//originated from http://www.codeproject.com/Articles/29153/SQL-Geometry-Viewer with modifications to populate an object capable of being serialized into geojson
	//geojson standard can be found at http://www.geojson.org/geojson-spec.html
	public static class SqlGeometry
	{
		public static Geometry Decode(SqlGeography g)
		{

			var result = new Geometry();
			var coordinates = new ArrayList();
			var xy = new double[2];
			switch (g.STGeometryType().Value.ToLower())
			{
				case "point":

					xy[0] = double.Parse(g.Long.ToString());
					xy[1] = double.Parse(g.Lat.ToString());

					result.type = "Point";
					result.coordinates = xy;

					return result;
				case "polygon":
					result.type = "Polygon";
					var cmd = new string(g.STAsText().Value).Trim().Substring(8);
					var polyArray = (cmd.Substring(1, cmd.Length - 2) +
																", ").Split('(');
					var polys = from s in polyArray
											where s.Length > 0
											select s.Trim().Substring(0, s.Length - 3);
					var polyArrayList = new ArrayList();
					foreach (var item in polys)
					{
						coordinates = new ArrayList();
						var coordPairs = from cp in item.Split(',') select cp.Trim().Replace(" ", ",");
						foreach (var pair in coordPairs)
						{
							xy = pair.Split(',').Select(d => double.Parse(d)).ToArray();
							coordinates.Add(xy);
						}
						polyArrayList.Add(coordinates.ToArray());
					}
					result.coordinates = polyArrayList.ToArray();
					return result;
				case "linestring":
					result.type = "LineString";
					for (var i = 1; i <= g.STNumPoints(); i++)
					{
						xy = new double[2];
						xy[0] = double.Parse(g.STPointN(i).Long.ToString());
						xy[1] = double.Parse(g.STPointN(i).Lat.ToString());
						coordinates.Add(xy);
					}
					result.coordinates = coordinates.ToArray();

					return result;
				case "multipoint":
				case "multilinestring":
				case "multipolygon":
				case "geometrycollection":
				//	GeometryGroup mpG = new GeometryGroup();
				//	for (int i = 1; i <= g.STNumGeometries().Value; i++)
				//		mpG.Children.Add(Decode(g.STGeometryN(i)));

				//	return mpG;
				default:
					return result;
			}
		}
	}
}