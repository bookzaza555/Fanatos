using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace Rmutto.Connection
{
    public static class ConnectionDB
    {
        private static MySqlConnection conn;
        static ConnectionDB()
        {
            //
            // TODO: Add constructor logic here
            //
            //string connectionString = ConfigurationManager.ConnectionStrings["ORCL_RMUTTO"].ToString();
            string connectionString = ConfigurationManager.ConnectionStrings["ORCL"].ToString();
            conn = new MySqlConnection(connectionString);
        }

        public static MySqlConnection GetOracleConnection()
        {
            return conn;
        }


    }
}