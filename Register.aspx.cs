using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace ATS_friendly_Resume_Maker
{
    public partial class Register : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Important
            if (Session["UserFirstName"] != null && Session["UserLastName"] != null)
            {
                Response.Redirect("Default.aspx");
            }


        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check if the email already exists
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE email = @Email";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Email", txtRegEmail.Text);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Email already exists! Please use a different email.');", true);
                        return;
                    }
                }


                string query = "INSERT INTO Users (firstName, lastName, email, password) VALUES (@FirstName, @LastName, @Email, @Password)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtRegEmail.Text);

                    // Hash the password before storing
                    string hashedPassword = HashPassword(txtRegPassword.Text);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Error in Registration!');", true);
                    }
                }
            }

        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Convert byte to hexadecimal
                }
                return builder.ToString();
            }
        }
    }
}

