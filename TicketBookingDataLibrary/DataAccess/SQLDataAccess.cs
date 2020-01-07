using Dapper;
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

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection con = new SqlConnection(GetConnectionString()))
            {
                return con.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection con = new SqlConnection(GetConnectionString()))
            {
                return con.Execute(sql, data);
            }

        }

        public static int UpdateNoOfTickets(string sql)
        {
            using (IDbConnection con = new SqlConnection(GetConnectionString()))
            {
                return con.Execute(sql);
            }

        }

        public static int GetMovieID<T>(string sql)
        {
            using (IDbConnection con = new SqlConnection(GetConnectionString())) 
            {
                return con.Query(sql).FirstOrDefault().MovieID;
            }
        }

        public static int GetTotalTickets(string sql)
        {
            using (IDbConnection con = new SqlConnection(GetConnectionString()))
            {
                return con.Query(sql).FirstOrDefault().TotalTickets;
            }
        }
    }
}
