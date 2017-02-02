using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TempleProject.Class;
using System.Text.RegularExpressions;

namespace TempleProject
{
    public partial class RegisterMonk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
            }
          
        }

        protected void BindDDL()
        {
            DatabaseManager.BindDropDown(ddlRank_Monk, "SELECT * FROM rank_user where id_rank IN(1,2,3)", "rank_name","id_rank","--กรุณาเลือก--");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

            if (tbUsername.Text != "")
            {
                string User = DatabaseManager.ExecuteString("SELECT USERNAME FROM PROFILE WHERE USERNAME = '" + tbUsername.Text + "'");
                if (User == tbUsername.Text)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('ชื่อนี้ถูกใช้งานแล้ว')", true);
                    return;
                }
            }

            if (tbPassword.Text != tbPassword2.Text)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('รหัสผู้ใช้งานไม่ตรงกัน')", true);
                return;
            }

            int id = 0;

            MySqlConnection.ClearAllPools();
            using (MySqlConnection con = new MySqlConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand("INSERT INTO PROFILE (id_rank,username,password,name,lastname,phone) VALUES (@id_rank,@username,@password,@name,@lastname,@phone)", con))
                {
                    com.Parameters.Add(new MySqlParameter("id_rank", ddlRank_Monk.SelectedValue));
                    com.Parameters.Add(new MySqlParameter("username", tbUsername.Text));
                    com.Parameters.Add(new MySqlParameter("password", tbPassword.Text));
                    com.Parameters.Add(new MySqlParameter("name", tbName.Text));
                    com.Parameters.Add(new MySqlParameter("lastname", tbLastname.Text));        
                    com.Parameters.Add(new MySqlParameter("phone", tbPhone.Text));
                    
                    id = com.ExecuteNonQuery();
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('สมัครสำเร็จ')", true);
                tbUsername.Text = "";
                tbPassword.Text = "";
                tbPassword2.Text = "";
                tbName.Text = "";
                tbLastname.Text = "";
                tbPhone.Text = "";
            }

        }
    }
}