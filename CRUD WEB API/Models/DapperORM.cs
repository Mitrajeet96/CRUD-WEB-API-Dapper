using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_WEB_API.Models
{
    public class DapperORM
    {
      
            public static string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=DapperCrud;Integrated Security=True";

            public static void ExecuteWithoutReturn(string SPName, DynamicParameters parameters = null)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    con.Execute(SPName, parameters, commandType: CommandType.StoredProcedure);
                }
            }

            public static T ExecuteScalar<T>(string SPName, DynamicParameters parameters = null)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    return (T)Convert.ChangeType(con.ExecuteScalar(SPName, parameters, commandType: CommandType.StoredProcedure), typeof(T));
                }
            }

        internal static dynamic ReturnList<T>()
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<T> ReturnList<T>(string SPName, DynamicParameters parameters = null)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    return con.Query<T>(SPName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
    }

    
}
