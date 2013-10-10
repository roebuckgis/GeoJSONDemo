using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace jGIS.GeoJsonApi.Core.DataAccess
{
	public static class GeoDataAccess
	{
		public static DataTable GetSpatialData(string tablename)
		{
			var parameters = new List<SqlParameter>
				{
					new SqlParameter("@Dataset", tablename)
				};

			return SqlServerDao.ExecuteProcDataTable("GetGeoDataset", parameters);
		}

        public static DataTable GeoRss(string rssUrl)
        {
			var parameters = new List<SqlParameter>
				{
					new SqlParameter("@url", rssUrl)
				};

			return SqlServerDao.ExecuteProcDataTable("GetGeoRSS", parameters);
        }

        public static DataTable Intersect(string focuslayer, string overlayer)
        {
            var parameters = new List<SqlParameter>
				{
					new SqlParameter("@focuslayer", focuslayer),
                    new SqlParameter("@overlayer", overlayer)
				};

            return SqlServerDao.ExecuteProcDataTable("Intersect", parameters);
        }

        public static DataTable GetAddressPoint(string address)
        {
            var parameters = new List<SqlParameter>();
            var url = new SqlParameter("@address", address);
            parameters.Add(url);
            return SqlServerDao.ExecuteProcDataTable("GetBingAddressPoint", parameters);
        }
        public static DataTable GetRssNearAddress(string rssUrl, string address, double distance, string type)
        {
            var parameters = new List<SqlParameter>
				    {
					    new SqlParameter("@rssUrl", rssUrl),
					    new SqlParameter("@address", address),
					    new SqlParameter("@Distance", distance)
				    };

            return SqlServerDao.ExecuteProcDataTable("GetRssNearAddress", parameters);
        }


	}
}
