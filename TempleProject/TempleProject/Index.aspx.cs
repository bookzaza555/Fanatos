using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TempleProject.Class;

namespace TempleProject
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            MySqlConnection.ClearAllPools();
            using (MySqlConnection con = new MySqlConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand("SELECT username,password FROM PROFILE", con))
                {
                    using (MySqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString("username") == tbUsername.Text && reader.GetString("password") == tbPassword.Text)
                            {
                                Label1.Text = "พบผู้ใช้งาน";
                                Label1.Visible = true;
                            }
                            else
                            {
                                Label1.Text = "ไม่พบผู้ใช้งานหรือรหัสผ่านไม่ถูกต้อง";
                                Label1.Visible = true;
                                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('ไม่พบผู้ใช้งานหรือรหัสผ่านไม่ถูกต้อง')", true);
                            }

                        }
                    }
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}