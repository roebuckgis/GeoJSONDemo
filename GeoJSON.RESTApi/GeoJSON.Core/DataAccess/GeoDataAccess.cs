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
	}
}
