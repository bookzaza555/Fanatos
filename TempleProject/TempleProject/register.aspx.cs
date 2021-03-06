﻿using MySql.Data.MySqlClient;
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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text != "")
            {
                string pattern = null;
                pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

                if (Regex.IsMatch(tbEmail.Text, pattern))
                {
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('email ไม่ถูกต้อง')", true);
                    return;
                }
            }

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
                using (MySqlCommand com = new MySqlCommand("INSERT INTO PROFILE (name,lastname,birthdate,email,username,password,address,phone) VALUES (@name,@lastname,@birthdate,@email,@username,@password,@address,@phone)", con))
                {
                    com.Parameters.Add(new MySqlParameter("name", tbName.Text));
                    com.Parameters.Add(new MySqlParameter("lastname", tbLastname.Text));
                    DateTime date = DateTime.ParseExact(tbBirthdate.Text, "dd/MM/yyyy", null);
                    com.Parameters.Add(new MySqlParameter("birthdate", date));
                    com.Parameters.Add(new MySqlParameter("email", tbEmail.Text));
                    com.Parameters.Add(new MySqlParameter("username", tbUsername.Text));
                    com.Parameters.Add(new MySqlParameter("password", tbPassword.Text));
                    com.Parameters.Add(new MySqlParameter("address", tbAddress.Text));
                    com.Parameters.Add(new MySqlParameter("phone", tbPhone.Text));
                    id = com.ExecuteNonQuery();
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('สมัครสำเร็จ')", true);
                tbUsername.Text = "";
                tbPassword.Text = "";
                tbPassword2.Text = "";
                tbName.Text = "";
                tbLastname.Text = "";
                tbEmail.Text = "";
                tbBirthdate.Text = "";
                tbAddress.Text = "";
                tbPhone.Text = "";
            }

        }
    }
}