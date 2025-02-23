using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Linq;
using System.Web.UI;

namespace ATS_friendly_Resume_Maker
{
    public partial class template_2 : System.Web.UI.Page
    {
        private string ConnectionString => ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("Login.aspx", true);
                    return;
                }

                if (!IsPostBack)
                {
                    int userId = GetUserIdFromRequest();
                    if (userId > 0)
                    {
                        LoadUserResume(userId);
                    }
                    else
                    {
                        ShowError("Invalid user ID");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("An error occurred while loading the resume.");
                // Log the error here
            }
        }

        private void LoadUserResume(int userId)
        {
            LoadPersonalInfo(userId);
            LoadExperienceData(userId);
            LoadEducationData(userId);
            LoadSkillsData(userId);
        }

        private int GetUserIdFromRequest()
        {
            try
            {
                return Convert.ToInt32(Session["UserId"]);
            }
            catch
            {
                return -1;
            }
        }

        private void LoadPersonalInfo(int userId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    // Load user's full name
                    using (SqlCommand cmd = new SqlCommand("SELECT FullName FROM UserDetail WHERE UserId = @UserId", conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        var name = cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                        litName.Text = name;
                    }

                    // Load contact info and summary
                    using (SqlCommand cmd = new SqlCommand("SELECT Email, Country , PhoneNumber, Summary FROM UserDetail WHERE UserId = @UserId", conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var contactBuilder = new StringBuilder();

                                string email = reader["Email"]?.ToString();
                                string phone = reader["PhoneNumber"]?.ToString();
                                String country = reader["Country"]?.ToString();

                                if (!string.IsNullOrEmpty(email))
                                    contactBuilder.Append(email);

                                if (!string.IsNullOrEmpty(country))
                                {
                                    if (contactBuilder.Length > 0)
                                        contactBuilder.Append(" | ");
                                    contactBuilder.Append(country);
                                }


                                if (!string.IsNullOrEmpty(phone))
                                {
                                    if (contactBuilder.Length > 0)
                                        contactBuilder.Append(" | ");
                                    contactBuilder.Append(phone);
                                }

                                litContactInfo.Text = contactBuilder.ToString();
                                litProfile.Text = reader["Summary"]?.ToString() ?? string.Empty;
                            }
                        }
                    }

                    // Load and append links
                    using (SqlCommand cmd = new SqlCommand("SELECT Label, URL FROM Links WHERE UserId = @UserId", conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            var linkBuilder = new StringBuilder(litContactInfo.Text);
                            while (reader.Read())
                            {
                                if (linkBuilder.Length > 0)
                                    linkBuilder.Append(" | ");

                                linkBuilder.AppendFormat("<a href='{0}' target='_blank'>{1}</a>",
                                    reader["URL"],
                                    reader["Label"]);
                            }
                            litContactInfo.Text = linkBuilder.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Error loading personal information");
                    // Log the error here
                }
            }
        }

        private void LoadExperienceData(int userId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    string query = @"
                        SELECT 
                            ExperienceID,
                            CompanyName,
                            JobTitle,
                            EmploymentType,
                            StartMonth,
                            StartYear,
                            EndMonth,
                            EndYear,
                            Location,
                            Description
                        FROM Experience
                        WHERE UserId = @UserId
                        ORDER BY 
                            CASE WHEN EndYear IS NULL THEN 1 ELSE 0 END DESC,
                            EndYear DESC,
                            EndMonth DESC,
                            StartYear DESC,
                            StartMonth DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            rptExperience.DataSource = dt;
                            rptExperience.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Error loading experience data");
                    // Log the error here
                }
            }
        }

        private void LoadEducationData(int userId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    string query = @"
                        SELECT 
                            SchoolName,
                            Degree,
                            StartYear,
                            EndYear,
                            City,
                            Description
                        FROM Education
                        WHERE UserId = @UserId
                        ORDER BY 
                            CASE WHEN EndYear IS NULL THEN 1 ELSE 0 END DESC,
                            EndYear DESC,
                            StartYear DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            rptEducation.DataSource = dt;
                            rptEducation.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Error loading education data");
                    // Log the error here
                }
            }
        }

        private void LoadSkillsData(int userId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    string query = "SELECT SkillsText FROM Skills WHERE UserId = @UserId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        conn.Open();

                        string skillsText = cmd.ExecuteScalar()?.ToString();

                        if (!string.IsNullOrEmpty(skillsText))
                        {
                            var skills = skillsText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                 .Select(s => new { Skill = s.Trim() })
                                                 .ToList();

                            rptSkills.DataSource = skills;
                            rptSkills.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Error loading skills data");
                    // Log the error here
                }
            }
        }

        protected string GetFormattedDuration(object startMonth, object startYear, object endMonth, object endYear)
        {
            string[] months = {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            };

            var duration = new StringBuilder();

            // Format start date
            if (startMonth != DBNull.Value && startYear != DBNull.Value)
            {
                int sMonth = Convert.ToInt32(startMonth);
                if (sMonth >= 1 && sMonth <= 12)
                {
                    duration.Append(months[sMonth - 1]).Append(" ");
                }
                duration.Append(startYear);
            }

            duration.Append(" - ");

            // Format end date
            if (endMonth != DBNull.Value && endYear != DBNull.Value)
            {
                int eMonth = Convert.ToInt32(endMonth);
                if (eMonth >= 1 && eMonth <= 12)
                {
                    duration.Append(months[eMonth - 1]).Append(" ");
                }
                duration.Append(endYear);
            }
            else
            {
                duration.Append("Present");
            }

            return duration.ToString();
        }

        protected string GetFormattedEducationDuration(object startYear, object endYear)
        {
            var duration = new StringBuilder();

            if (startYear != DBNull.Value)
            {
                duration.Append(startYear);
            }

            duration.Append(" - ");

            if (endYear != DBNull.Value)
            {
                duration.Append(endYear);
            }
            else
            {
                duration.Append("Present");
            }

            return duration.ToString();
        }

        private void ShowError(string message)
        {
            // Implement your error handling here
            // For example, you could show a message on the page
            // or redirect to an error page
            Response.Write($"<script>alert('{message}');</script>");
        }
    }
}