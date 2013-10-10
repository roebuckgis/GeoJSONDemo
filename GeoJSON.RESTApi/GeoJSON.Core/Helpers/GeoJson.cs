using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jGIS.GeoJsonApi.Core.Models;
using Microsoft.SqlServer.Types;

namespace jGIS.GeoJsonApi.Core.Helpers
{
    public static class GeoJson
    {
        public static FeatureCollection GetFeatureCollection(DataTable sqlresult)
        {
            var features = new List<Feature>();
            var dataset = sqlresult;
            foreach (var row in sqlresult.AsEnumerable())
            {
                var geography = row["Shape"];
                var geo = GetGeometry(geography);
                var properties = GetProperties(row);
                var feature = new Feature
                {
                    geometry = geo,
                    properties = properties
                };
                features.Add(feature);


            }
            var fc = new FeatureCollection
            {
                features = features.ToArray()
            };

            return fc;
        }

        //get any properties and set popup content
        private static object GetProperties(DataRow row)
        {
            var pc = "No description provided";
            if (row.Table.Columns.Contains("description"))
            {
                pc = row["description"].ToString();
            }
            var itemprops = new List<Property>
				{
					new Property(){key="properties", value = "test"}
				};

            dynamic props = new { popupContent = pc, itemprops };
            return props;

        }

        private static Geometry GetGeometry(object geometry)
        {
            return SqlGeometry.Decode((SqlGeography)geometry);
        }
		
    }
}
