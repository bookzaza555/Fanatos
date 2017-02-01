using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using MySql.Data.MySqlClient;
namespace TempleProject.Class
{
    public class DatabaseManager
    {

        public static readonly string PROVIDER = "MySql.Data.MySqlClient";
        //public static readonly string DATA_SOURCE = "203.158.140.67";
        public static readonly string HOST = "localhost";
        public static readonly string USER = "test";
        public static readonly string PASSWORD = "1234";
        public static readonly string DATABASE = "test";
        public static readonly string CONNECTION_STRING = @"host= " + HOST + ";user=" + USER + ";password=" + PASSWORD + ";database=" + DATABASE + ";";

        public static void ExecuteNonQuery(string sql)
        {
            using (MySqlConnection con = new MySqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    com.ExecuteNonQuery();
                }
            }
        }
        public static int ExecuteInt(string sql)
        {
            MySqlConnection.ClearAllPools();
            int output = -1;
            using (MySqlConnection con = new MySqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            output = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            return output;
        }
        public static string ExecuteString(string sql)
        {
            MySqlConnection.ClearAllPools();
            string output = null;
            using (MySqlConnection con = new MySqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            output = reader.GetValue(0).ToString();
                        }
                    }
                }
            }
            return output;
        }
        public static int ExecuteSequence(string seq_name)
        {
            MySqlConnection.ClearAllPools();
            int seq;
            using (MySqlConnection con = new MySqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand("SELECT " + seq_name + ".NEXTVAL FROM DUAL", con))
                {
                    using (MySqlDataReader reader = com.ExecuteReader())
                    {
                        reader.Read();
                        seq = int.Parse(reader.GetValue(0).ToString());
                    }
                }
            }
            return seq;
        }
        public static void ExeDDL2String(DropDownList ddl ,string sql)
        {
            MySqlConnection.ClearAllPools();
            using (MySqlConnection con = new MySqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ddl.Items.Add(new ListItem(reader.GetString(0) + " | " + reader.GetString(1), reader.GetString(0) + ""));
                        }
                    }
                }
            }
        }
        public static void ExeDDL2Int(DropDownList ddl, string sql)
        {
            MySqlConnection.ClearAllPools();
            using (MySqlConnection con = new MySqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ddl.Items.Add(new ListItem(reader.GetInt32(0) + " | " + reader.GetString(1), reader.GetInt32(0) + ""));
                        }
                    }
                }
            }
        }
        public static void ExeDDLselectNameAndLast(DropDownList ddl, string sql)
        {
            MySqlConnection.ClearAllPools();
            using (MySqlConnection con = new MySqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ddl.Items.Add(new ListItem(reader.GetString(1), reader.GetInt32(0) + ""));
                        }
                    }
                }
            }
        }
        public static void BindDropDownNon(DropDownList ddl, string sql, string text, string value)
        {
            MySqlConnection.ClearAllPools();
            ddl.DataSource = CreateSQLDataSource(sql);
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
        }
        public static void BindDropDown(DropDownList ddl, string sql, string text, string value, string first)
        {
            MySqlConnection.ClearAllPools();
            ddl.DataSource = CreateSQLDataSource(sql);
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(first, ""));
        }
        public static void BindGridView(GridView gv, string sql)
        {
            MySqlConnection.ClearAllPools();
            SqlDataSource sds = CreateSQLDataSource(sql);
            gv.DataSource = sds;
            gv.DataBind();
        }
        public static SqlDataSource CreateSQLDataSource(string sql)
        {
            return new SqlDataSource("MySql.Data.MySqlClient", CONNECTION_STRING, sql);
        }

        public static string GetPersonImageFileName(string citizenID)
        {
            MySqlConnection.ClearAllPools();
            string fileName = "";
            using (MySqlConnection con = new MySqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand("SELECT URL FROM PS_PERSON_IMAGE WHERE CITIZEN_ID = '" + citizenID + "' AND PRESENT = 1", con))
                {
                    using (MySqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fileName = reader.GetValue(0).ToString();
                        }
                    }
                }
            }
            return fileName;
        }
        public static string[] GetPersonImageFileNames(string citizenID)
        {
            MySqlConnection.ClearAllPools();
            List<string> fileNameList = new List<string>();
            using (MySqlConnection con = new MySqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand("SELECT URL FROM PS_PERSON_IMAGE WHERE CITIZEN_ID = '" + citizenID + "'", con))
                {
                    using (MySqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fileNameList.Add(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            return fileNameList.ToArray();
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomFileName()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 24)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static bool StringEqual(string source, string[] target)
        {
            for (int i = 0; i < target.Length; ++i)
            {
                if (source == target[i])
                {
                    return true;
                }
            }
            return false;
        }

    }
}