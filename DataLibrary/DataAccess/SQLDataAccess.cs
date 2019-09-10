using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLibrary.DataAccess
{
    public static class SQLDataAccess
    {
        public static string GetConnectionString(string connectionName = "ProjectDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static T LoadData<T>(string sql)
        {
            using (IDbConnection con = new SqlConnection("ss"))
            {

            }
        }
    }
}
