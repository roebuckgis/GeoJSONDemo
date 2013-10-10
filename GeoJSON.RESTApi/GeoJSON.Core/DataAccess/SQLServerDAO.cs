using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace jGIS.GeoJsonApi.Core.DataAccess
{

	public class SqlServerDao
	{
		private static readonly string DbConn = ConfigurationManager.AppSettings["jGISdb"];


		public static DataTable ExecuteSqlDataTable(string sql)
		{
			return ExecuteSqlDataTable(sql, null);
		}

		public static DataTable ExecuteSqlDataTable(string sql, List<SqlParameter> parameters)
		{
			using (var connection = new SqlConnection(DbConn))
			{
				using (var command = new SqlCommand(sql, connection))
				{
					if (parameters != null) command.Parameters.AddRange(parameters.ToArray());


					using (var dataAdapter = new SqlDataAdapter(command))
					{
						var dataTable = new DataTable();
						dataAdapter.Fill(dataTable);
						return dataTable;
					}
				}
			}
		}

		public static DataTable ExecuteProcDataTable(string proc, List<SqlParameter> parameters)
		{
			using (var connection = new SqlConnection(DbConn))
			{
				using (var command = new SqlCommand(proc, connection))
				{
					if (parameters != null) command.Parameters.AddRange(parameters.ToArray());

					command.CommandType = CommandType.StoredProcedure;
					command.CommandText = proc;
					using (var dataAdapter = new SqlDataAdapter(command))
					{
						var dataTable = new DataTable();
						dataAdapter.Fill(dataTable);
						return dataTable;
					}
				}
			}
		}
	}

}
