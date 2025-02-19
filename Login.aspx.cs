using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace ATS_friendly_Resume_Maker
{
    public partial class Login : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Important
            if (Session["UserFirstName"] != null && Session["UserLastName"] != null)
            {
                Response.Redirect("Default.aspx");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                try
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        lblStatus.Text = "✅ Database Connected Successfully!";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "❌ Database Connection Failed: " + ex.Message;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UserId, FirstName, LastName FROM Users WHERE Email = @Email AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", HashPassword(txtPassword.Text)); // Ensure password hashing matches

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // ✅ Ensures data is available
                        {
                            Session["UserId"] = reader["UserId"].ToString();
                            Session["UserEmail"] = txtEmail.Text;
                            Session["UserFirstName"] = reader["FirstName"].ToString(); // ✅ Match exact column case
                            Session["UserLastName"] = reader["LastName"].ToString();

                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            lblStatus.Text = "Invalid Email or Password!";
                        }
                    }
                }
            }
        }
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Convert byte to hex string
                }
                return builder.ToString();
            }
        }
    }
}