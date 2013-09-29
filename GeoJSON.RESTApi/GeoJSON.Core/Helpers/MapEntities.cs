using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.SqlServer.Types;
using System.Data.SqlClient;
using jGIS.GeoJsonApi.Core.DataAccess;
using jGIS.GeoJsonApi.Core.Models;

namespace jGIS.GeoJsonApi.Core.Helpers
{
	public static class MapEntities
	{

		public static Feature GetAddressPoint(string address, double distance)
		{
			//var features = new List<Feature>();

			var parameters = new List<SqlParameter>();
			var url = new SqlParameter("@address", address);
			parameters.Add(url);
			var dataTable = SqlServerDao.ExecuteProcDataTable("GetBingAddressPoint", parameters);
			var row = dataTable.Rows[0];

			var geography = (SqlGeography)row["point"];
			if (distance > 0) geography = geography.STBuffer(distance);
			var geometry = GetGeometry(geography);

			var properties = GetProperties(row);

			var feature = new Feature
			{
				geometry = geometry,
				properties = properties
			};

			return feature;
			//features.Add(feature);


			//var fc = new FeatureCollection()
			//{
			//	features = features.ToArray()
			//};
			//JavaScriptSerializer serializer = new JavaScriptSerializer();
			//string serialize = serializer.Serialize(fc);
			//return serialize;
		}


		public static FeatureCollection GeoRss(string rssUrl)
		{
			var features = new List<Feature>();

			var parameters = new List<SqlParameter>
				{
					new SqlParameter("@url", rssUrl)
				};

			var dataTable = SqlServerDao.ExecuteProcDataTable("GetGeoRSS", parameters);
			foreach (var row in dataTable.AsEnumerable())
			{
				//point description
				var geography = (SqlGeography)row["point"];
				var point = GetGeometry(geography);
				var properties = GetProperties(row);

				var feature = new Feature
				{
					geometry = point,
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
		public static FeatureCollection Geodataset(string tablename)
		{
			var features = new List<Feature>();
			var dataset = GeoDataAccess.GetSpatialData(tablename);
			foreach (var row in dataset.AsEnumerable())
			{
				//point description
				var geography = (SqlGeography)row["Shape"];
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

		public static FeatureCollection GeoRssByBufferedAddress(string rssUrl, string address, double distance, string type)
		{
			var features = new List<Feature>();

			var parameters = new List<SqlParameter>
				{
					new SqlParameter("@rssUrl", rssUrl),
					new SqlParameter("@address", address),
					new SqlParameter("@Distance", distance)
				};

			var dataTable = SqlServerDao.ExecuteProcDataTable("GetRssNearAddress", parameters);
			foreach (var row in dataTable.AsEnumerable())
			{
				//point description
				var geography = (SqlGeography)row["point"];
				var point = GetGeometry(geography);
				var properties = GetProperties(row);
				var feature = new Feature
				{
					geometry = point,
					properties = properties
				};
				features.Add(feature);
			}

			var fc = new FeatureCollection
			{
				features = features.ToArray()
			};

			return fc;
			//JavaScriptSerializer serializer = new JavaScriptSerializer();
			//string serialize = serializer.Serialize(fc);
			//return serialize;
		}

		private static Geometry GetGeometry(SqlGeography sg)
		{
			return SqlGeometry.Decode(sg);
		}
		//private Geometry GetGeometry(string WKT)
		//{
		//    var gstring = new SqlChars(WKT);
		//    var sg = SqlGeography.STGeomFromText(gstring, 4326);
		//    return SQLServerGeometryHelper.Decode(sg);
		//}
		//private string SerializeJson(object obj)
		//{
		//	var jser = new JavaScriptSerializer();
		//	return jser.Serialize(obj);
		//}

	}
}
