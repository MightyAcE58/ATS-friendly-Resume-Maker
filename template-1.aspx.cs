using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.UI;


namespace ATS_friendly_Resume_Maker
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserId"] == null)
            {
                // Redirect to login page if session expires
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                // Get the user ID from query string or session
                int userId = GetUserIdFromRequest();
                if (userId > 0)
                {
                    // Load personal information
                    LoadPersonalInfo(userId);

                    // Load experience data
                    LoadExperienceData(userId);

                    // Load education data
                    LoadEducationData(userId);

                    // Load skills data
                    LoadSkillsData(userId);
                }


            }

        }

        private int GetUserIdFromRequest()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            return userId;

            
        }

        private void LoadPersonalInfo(int userId)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
            {
                // Get user name from Users table
                string nameQuery = "SELECT FullName FROM UserDetail WHERE UserId = @UserId";
                string name = "";

                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            name = $"{reader["FullName"]}";
                        }
                    }
                }

                // Get contact info and summary from UserDetail table
                string contactQuery = "SELECT Email, PhoneNumber, Summary FROM UserDetail WHERE UserId = @UserId";
                string contactInfo = "";
                string summary = "";

                using (SqlCommand cmd = new SqlCommand(contactQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            contactInfo = reader["Email"].ToString();
                            if (!string.IsNullOrEmpty(reader["PhoneNumber"].ToString()))
                            {
                                contactInfo += " | " + reader["PhoneNumber"].ToString();
                            }

                            summary = reader["Summary"].ToString();
                        }
                    }
                }

                // Get links from Links table
                string linksQuery = "SELECT Label, URL FROM Links WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(linksQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contactInfo += " | " + $"<a href='{reader["URL"]}' target='_blank' style='text-decoration: none; color: inherit;'>{reader["Label"]}</a>";
                        }
                    }
                }

                // Set the literal controls
                litName.Text = name;
                litContactInfo.Text = contactInfo;
                litProfile.Text = summary;
            }
        }

        private void LoadExperienceData(int userId)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
            {
                string query = @"SELECT ExperienceID, CompanyName, JobTitle, EmploymentType, 
                              StartMonth, StartYear, EndMonth, EndYear, Location, Description 
                              FROM Experience 
                              WHERE UserId = @UserId 
                              ORDER BY EndYear DESC, EndMonth DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        rptExperience.DataSource = dt;
                        rptExperience.DataBind();
                    }
                }
            }
        }

        private void LoadEducationData(int userId)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
            {
                string query = @"SELECT SchoolName, Degree, StartYear, EndYear, City, Description 
                              FROM Education 
                              WHERE UserId = @UserId 
                              ORDER BY EndYear DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        rptEducation.DataSource = dt;
                        rptEducation.DataBind();
                    }
                }
            }
        }

        private void LoadSkillsData(int userId)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
            {
                string query = "SELECT SkillsText FROM Skills WHERE UserId = @UserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        rptSkills.DataSource = dt;
                        rptSkills.DataBind();
                    }
                }
            }
        }

        // Helper method to format experience duration - using different naming to avoid conflicts
        protected string GetFormattedDuration(object startMonth, object startYear, object endMonth, object endYear)
        {
            string[] months = { "January", "February", "March", "April", "May", "June",
                             "July", "August", "September", "October", "November", "December" };

            StringBuilder sb = new StringBuilder();

            // Start date
            if (startMonth != DBNull.Value && startYear != DBNull.Value)
            {
                int sMonth = Convert.ToInt32(startMonth);
                if (sMonth >= 1 && sMonth <= 12)
                {
                    sb.Append(months[sMonth - 1] + " ");
                }
                sb.Append(startYear.ToString());
            }

            sb.Append(" - ");

            // End date
            if (endMonth != DBNull.Value && endYear != DBNull.Value)
            {
                int eMonth = Convert.ToInt32(endMonth);
                if (eMonth >= 1 && eMonth <= 12)
                {
                    sb.Append(months[eMonth - 1] + " ");
                }
                sb.Append(endYear.ToString());
            }
            else
            {
                sb.Append("Present");
            }

            return sb.ToString();
        }

        // Helper method to format education duration - using different naming to avoid conflicts
        protected string GetFormattedEducationDuration(object startYear, object endYear)
        {
            StringBuilder sb = new StringBuilder();

            if (startYear != DBNull.Value)
            {
                sb.Append(startYear.ToString());
            }

            sb.Append(" - ");

            if (endYear != DBNull.Value)
            {
                sb.Append(endYear.ToString());
            }
            else
            {
                sb.Append("Present");
            }

            return sb.ToString();
        }
    }
}