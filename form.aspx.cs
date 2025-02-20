using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;

namespace ATS_friendly_Resume_Maker
{
    [Serializable]
    public class EmploymentData
    {
        public int ExperienceID { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string EmploymentType { get; set; }
        public int StartMonth { get; set; }
        public int StartYear { get; set; }
        public int EndMonth { get; set; }
        public int EndYear { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }

    [Serializable]
    public class EducationData
    {
        public int EducationID { get; set; }
        public string School { get; set; }
        public string Degree { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
    }

    [Serializable]
    public class LinkData
    {
        public int LinkID { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }

    }

    [Serializable]
    public class SkillData
    {
        public string Skill { get; set; }
    }

    public partial class Resume_Maker : System.Web.UI.Page
    {
        private List<EmploymentData> EmploymentEntries
        {
            get
            {
                if (ViewState["EmploymentEntries"] == null)
                {
                    ViewState["EmploymentEntries"] = new List<EmploymentData>();
                }
                return (List<EmploymentData>)ViewState["EmploymentEntries"];
            }
            set
            {
                ViewState["EmploymentEntries"] = value;
            }
        }

        private List<EducationData> EducationEntries
        {
            get
            {
                if (ViewState["EducationEntries"] == null)
                {
                    ViewState["EducationEntries"] = new List<EducationData>();
                }
                return (List<EducationData>)ViewState["EducationEntries"];
            }
            set
            {
                ViewState["EducationEntries"] = value;
            }
        }

        private List<LinkData> LinkEntries
        {
            get
            {
                if (ViewState["LinkEntries"] == null)
                {
                    ViewState["LinkEntries"] = new List<LinkData>();
                }
                return (List<LinkData>)ViewState["LinkEntries"];
            }
            set
            {
                ViewState["LinkEntries"] = value;
            }
        }

        private List<SkillData> SkillEntries
        {
            get
            {
                if (ViewState["SkillEntries"] == null)
                {
                    ViewState["SkillEntries"] = new List<SkillData>();
                }
                return (List<SkillData>)ViewState["SkillEntries"];
            }
            set
            {
                ViewState["SkillEntries"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeYearDropdowns();
                BindAllRepeaters();
                LoadUserData();

                int userId = GetUserId(); // Fetch the UserId from Session

                if (userId > 0)
                {
                    LoadEmploymentData(userId);
                    LoadEducationData(userId);
                    LoadLinkData(userId);
                }
            }

            if (Session["UserId"] == null)
            {
                // Redirect to login page if session expires
                Response.Redirect("Login.aspx");
                return;
            }
        }

        private void LoadUserData()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
            {
                conn.Open();

                // Retrieve User Details
                string getUserQuery = "SELECT FullName, Email, PhoneNumber, Summary, Country FROM UserDetail WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(getUserQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // If data exists
                    {
                        txtFullName.Text = reader["FullName"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtPhone.Text = reader["PhoneNumber"].ToString();
                        txtSummary.Text = reader["Summary"].ToString();
                        txtCountry.Text = reader["Country"].ToString();
                    }
                    reader.Close();
                }

                // Retrieve Skills
                string getSkillsQuery = "SELECT SkillsText FROM Skills WHERE UserID = @UserId";
                using (SqlCommand cmd = new SqlCommand(getSkillsQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // If data exists
                    {
                        txtskill.Text = reader["SkillsText"].ToString();
                    }
                }
            }
        }

        private void LoadEmploymentData(int userId)
        {
            EmploymentEntries.Clear();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
            {
                con.Open();
                string query = "SELECT ExperienceID, CompanyName, JobTitle, EmploymentType, StartMonth, StartYear, EndMonth, EndYear, Location, Description FROM Experience WHERE UserID = @UserId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmploymentEntries.Add(new EmploymentData()
                            {
                                ExperienceID = Convert.ToInt32(reader["ExperienceID"]), // Assign ExperienceID
                                Company = reader["CompanyName"]?.ToString(),
                                Title = reader["JobTitle"]?.ToString(),
                                EmploymentType = reader["EmploymentType"]?.ToString(),
                                StartMonth = reader["StartMonth"] != DBNull.Value ? Convert.ToInt32(reader["StartMonth"]) : 0,
                                StartYear = reader["StartYear"] != DBNull.Value ? Convert.ToInt32(reader["StartYear"]) : 0,
                                EndMonth = reader["EndMonth"] != DBNull.Value ? Convert.ToInt32(reader["EndMonth"]) : 0,
                                EndYear = reader["EndYear"] != DBNull.Value ? Convert.ToInt32(reader["EndYear"]) : 0,
                                Location = reader["Location"]?.ToString(),
                                Description = reader["Description"]?.ToString()
                            });
                        }
                    }
                }
            }
        }


        private void LoadEducationData(int userId)
        {
            EducationEntries.Clear();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
            {
                con.Open();
                string query = "SELECT EducationID, SchoolName, Degree, StartYear, EndYear, City, Description FROM Education WHERE UserID = @UserId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EducationEntries.Add(new EducationData()
                            {
                                EducationID = Convert.ToInt32(reader["EducationID"]),
                                School = reader["SchoolName"].ToString(),
                                Degree = reader["Degree"].ToString(),
                                StartYear = Convert.ToInt32(reader["StartYear"]),
                                EndYear = Convert.ToInt32(reader["EndYear"]),
                                City = reader["City"].ToString(),
                                Description = reader["Description"].ToString()
                            });
                        }
                    }
                }
            }
        }

        private void LoadLinkData(int userId)
        {
            LinkEntries.Clear();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
            {
                con.Open();
                string query = "SELECT LinkID, Label, Url FROM Links WHERE UserID = @UserId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LinkEntries.Add(new LinkData()
                            {
                                LinkID = Convert.ToInt32(reader["LinkID"]),
                                Label = reader["Label"].ToString(),
                                Url = reader["Url"].ToString()
                            });
                        }
                    }
                }
            }
        }

        private void InitializeYearDropdowns()
        {
            // Populate year dropdown lists for the first time
            int currentYear = DateTime.Now.Year;
            List<int> years = Enumerable.Range(currentYear - 50, 51).Reverse().ToList();

            // No need to populate here as it will be done in ItemDataBound events
        }

        #region Employment Methods
        protected void btnAddEmployment_Click(object sender, EventArgs e)
        {
            SaveEmploymentValues();
            EmploymentEntries.Add(new EmploymentData());
            BindEmploymentRepeater();
        }

        protected void rptEmployment_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Remove")
            {
                SaveEmploymentValues(); // Ensure values are saved before deletion

                int index = Convert.ToInt32(e.CommandArgument);
                if (index >= 0 && index < EmploymentEntries.Count)
                {
                    int experienceId = EmploymentEntries[index].ExperienceID; // Get the ExperienceID

                    if (experienceId > 0) // Only delete if it exists in the database
                    {
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
                        {
                            con.Open();
                            string deleteQuery = "DELETE FROM Experience WHERE ExperienceID = @ExperienceID";

                            using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                            {
                                cmd.Parameters.AddWithValue("@ExperienceID", experienceId);
                                cmd.ExecuteNonQuery(); // Delete from database
                            }
                        }
                    }

                    EmploymentEntries.RemoveAt(index); // Remove from the list
                    BindEmploymentRepeater(); // Refresh UI
                }
            }
        }

        protected void rptEmployment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlStartYear = (DropDownList)e.Item.FindControl("ddlStartYear");
                DropDownList ddlEndYear = (DropDownList)e.Item.FindControl("ddlEndYear");

                // Fill years
                int currentYear = DateTime.Now.Year;
                for (int year = currentYear; year >= currentYear - 50; year--)
                {
                    ddlStartYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
                    ddlEndYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
                }

                // Add "Present" option to end year
                ddlEndYear.Items.Add(new ListItem("Present", "0"));

                // Set selected values if data exists
                EmploymentData entry = (EmploymentData)e.Item.DataItem;
                if (entry != null)
                {
                    TextBox txtCompany = (TextBox)e.Item.FindControl("txtCompany");
                    TextBox txtTitle = (TextBox)e.Item.FindControl("txtTitle");
                    DropDownList ddlEmployment = (DropDownList)e.Item.FindControl("ddlEmployment");
                    DropDownList ddlStartMonth = (DropDownList)e.Item.FindControl("ddlStartMonth");
                    DropDownList ddlEndMonth = (DropDownList)e.Item.FindControl("ddlEndMonth");
                    TextBox txtLocation = (TextBox)e.Item.FindControl("txtLocation");
                    TextBox txtDescription = (TextBox)e.Item.FindControl("txtDescription");

                    txtCompany.Text = entry.Company;
                    txtTitle.Text = entry.Title;
                    if (!string.IsNullOrEmpty(entry.EmploymentType))
                    {
                        ddlEmployment.SelectedValue = entry.EmploymentType;
                    }
                    if (entry.StartMonth > 0)
                    {
                        ddlStartMonth.SelectedValue = entry.StartMonth.ToString();
                    }
                    if (entry.StartYear > 0)
                    {
                        ddlStartYear.SelectedValue = entry.StartYear.ToString();
                    }
                    if (entry.EndYear > 0)
                    {
                        ddlEndYear.SelectedValue = entry.EndYear.ToString();
                    }
                    else if (entry.EndYear == 0) // "Present"
                    {
                        ddlEndYear.SelectedValue = "0";
                    }
                    if (entry.EndMonth > 0)
                    {
                        ddlEndMonth.SelectedValue = entry.EndMonth.ToString();
                    }
                    txtLocation.Text = entry.Location;
                    txtDescription.Text = entry.Description;
                }
            }
        }

        private void SaveEmploymentValues()
        {
            for (int i = 0; i < rptEmployment.Items.Count; i++)
            {
                RepeaterItem item = rptEmployment.Items[i];

                TextBox txtCompany = (TextBox)item.FindControl("txtCompany");
                TextBox txtTitle = (TextBox)item.FindControl("txtTitle");
                DropDownList ddlEmployment = (DropDownList)item.FindControl("ddlEmployment");
                DropDownList ddlStartMonth = (DropDownList)item.FindControl("ddlStartMonth");
                DropDownList ddlStartYear = (DropDownList)item.FindControl("ddlStartYear");
                DropDownList ddlEndMonth = (DropDownList)item.FindControl("ddlEndMonth");
                DropDownList ddlEndYear = (DropDownList)item.FindControl("ddlEndYear");
                TextBox txtLocation = (TextBox)item.FindControl("txtLocation");
                TextBox txtDescription = (TextBox)item.FindControl("txtDescription");

                if (i < EmploymentEntries.Count)
                {
                    EmploymentEntries[i].Company = txtCompany.Text;
                    EmploymentEntries[i].Title = txtTitle.Text;
                    EmploymentEntries[i].EmploymentType = ddlEmployment.SelectedValue;
                    EmploymentEntries[i].StartMonth = Convert.ToInt32(ddlStartMonth.SelectedValue);
                    EmploymentEntries[i].StartYear = Convert.ToInt32(ddlStartYear.SelectedValue);
                    EmploymentEntries[i].EndMonth = Convert.ToInt32(ddlEndMonth.SelectedValue);
                    EmploymentEntries[i].EndYear = Convert.ToInt32(ddlEndYear.SelectedValue);
                    EmploymentEntries[i].Location = txtLocation.Text;
                    EmploymentEntries[i].Description = txtDescription.Text;
                }
            }
        }

        private void BindEmploymentRepeater()
        {
            rptEmployment.DataSource = EmploymentEntries;
            rptEmployment.DataBind();
        }
        #endregion

        #region Education Methods
        protected void btnAddEducation_Click(object sender, EventArgs e)
        {
            SaveEducationValues();
            EducationEntries.Add(new EducationData());
            BindEducationRepeater();
        }

        protected void rptEducation_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                SaveEducationValues(); // Save current education values before removing

                int index = Convert.ToInt32(e.CommandArgument);
                if (index >= 0 && index < EducationEntries.Count)
                {
                    int educationId = EducationEntries[index].EducationID; // Get EducationID

                    if (educationId > 0) // Delete only if it exists in the database
                    {
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
                        {
                            con.Open();
                            string deleteQuery = "DELETE FROM Education WHERE EducationID = @EducationID";

                            using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                            {
                                cmd.Parameters.AddWithValue("@EducationID", educationId);
                                cmd.ExecuteNonQuery(); // Delete from database
                            }
                        }
                    }

                    EducationEntries.RemoveAt(index); // Remove from the list
                    BindEducationRepeater(); // Refresh UI
                }
            }

        }

        protected void rptEducation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlStartYear = (DropDownList)e.Item.FindControl("ddlStartYear");
                DropDownList ddlEndYear = (DropDownList)e.Item.FindControl("ddlEndYear");

                // Fill years
                int currentYear = DateTime.Now.Year;
                for (int year = currentYear; year >= currentYear - 50; year--)
                {
                    ddlStartYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
                    ddlEndYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
                }

                // Add "Present" option to end year
                ddlEndYear.Items.Add(new ListItem("Present", "0"));

                // Set selected values if data exists
                EducationData entry = (EducationData)e.Item.DataItem;
                if (entry != null)
                {
                    TextBox txtSchool = (TextBox)e.Item.FindControl("txtSchool");
                    TextBox txtDegree = (TextBox)e.Item.FindControl("txtDegree");
                    TextBox txtCity = (TextBox)e.Item.FindControl("txtCity");
                    TextBox txtEduDescription = (TextBox)e.Item.FindControl("txtEduDescription");

                    txtSchool.Text = entry.School;
                    txtDegree.Text = entry.Degree;
                    if (entry.StartYear > 0)
                    {
                        ddlStartYear.SelectedValue = entry.StartYear.ToString();
                    }
                    if (entry.EndYear > 0)
                    {
                        ddlEndYear.SelectedValue = entry.EndYear.ToString();
                    }
                    else if (entry.EndYear == 0) // "Present"
                    {
                        ddlEndYear.SelectedValue = "0";
                    }
                    txtCity.Text = entry.City;
                    txtEduDescription.Text = entry.Description;
                }
            }
        }

        private void SaveEducationValues()
        {
            for (int i = 0; i < rptEducation.Items.Count; i++)
            {
                RepeaterItem item = rptEducation.Items[i];

                TextBox txtSchool = (TextBox)item.FindControl("txtSchool");
                TextBox txtDegree = (TextBox)item.FindControl("txtDegree");
                DropDownList ddlStartYear = (DropDownList)item.FindControl("ddlStartYear");
                DropDownList ddlEndYear = (DropDownList)item.FindControl("ddlEndYear");
                TextBox txtCity = (TextBox)item.FindControl("txtCity");
                TextBox txtEduDescription = (TextBox)item.FindControl("txtEduDescription");

                if (i < EducationEntries.Count)
                {
                    EducationEntries[i].School = txtSchool.Text;
                    EducationEntries[i].Degree = txtDegree.Text;
                    EducationEntries[i].StartYear = Convert.ToInt32(ddlStartYear.SelectedValue);
                    EducationEntries[i].EndYear = Convert.ToInt32(ddlEndYear.SelectedValue);
                    EducationEntries[i].City = txtCity.Text;
                    EducationEntries[i].Description = txtEduDescription.Text;
                }
            }
        }

        private void BindEducationRepeater()
        {
            rptEducation.DataSource = EducationEntries;
            rptEducation.DataBind();
        }
        #endregion

        #region Links Methods
        protected void btnAddWebsite_Click(object sender, EventArgs e)
        {
            SaveLinkValues();
            LinkEntries.Add(new LinkData());
            BindLinksRepeater();
        }

        protected void rptLinks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                SaveLinkValues(); // Ensure current values are saved

                int index = Convert.ToInt32(e.CommandArgument);
                if (index >= 0 && index < LinkEntries.Count)
                {
                    int linkId = LinkEntries[index].LinkID; // Get LinkID

                    if (linkId > 0) // Delete only if it exists in the database
                    {
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
                        {
                            con.Open();
                            string deleteQuery = "DELETE FROM Links WHERE LinkID = @LinkID";

                            using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                            {
                                cmd.Parameters.AddWithValue("@LinkID", linkId);
                                cmd.ExecuteNonQuery(); // Delete from database
                            }
                        }
                    }

                    LinkEntries.RemoveAt(index); // Remove from the list
                    BindLinksRepeater(); // Refresh UI
                }
            }

        }

        private void SaveLinkValues()
        {
            for (int i = 0; i < rptLinks.Items.Count; i++)
            {
                RepeaterItem item = rptLinks.Items[i];

                TextBox txtLabel = (TextBox)item.FindControl("txtLabel");
                TextBox txtUrl = (TextBox)item.FindControl("txtUrl");

                if (i < LinkEntries.Count)
                {
                    LinkEntries[i].Label = txtLabel.Text;
                    LinkEntries[i].Url = txtUrl.Text;
                }
            }
        }


        private void BindLinksRepeater()
        {
            rptLinks.DataSource = LinkEntries;
            rptLinks.DataBind();
        }
        #endregion

        protected void rptLinks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var linkData = (LinkData)e.Item.DataItem;
                var txtLabel = (TextBox)e.Item.FindControl("txtLabel");
                var txtUrl = (TextBox)e.Item.FindControl("txtUrl");

                txtLabel.Text = linkData.Label;
                txtUrl.Text = linkData.Url;
            }
        }

        private void BindAllRepeaters()
        {
            BindEmploymentRepeater();
            BindEducationRepeater();
            BindLinksRepeater();

        }

        private int GetUserId()
        {
            if (Session["UserId"] != null)
            {
                return Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                Response.Redirect("Login.aspx"); // Redirect if session expires
                return -1;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveEmploymentValues();  // Save UI values first
            SaveEducationValues();
            SaveLinkValues();

            int userId = GetUserId(); // Get UserId from Session

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
            {
                con.Open();



                foreach (var entry in EmploymentEntries.Where(entry => entry.ExperienceID == 0)) // Use 'entry' instead of 'e'
                {

                    if (string.IsNullOrEmpty(entry.Company) || string.IsNullOrEmpty(entry.Title))
                    {
                        string script = "alert('Company Name and Job Title are required fields.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidationAlert", script, true);
                        return; // Stop execution to prevent inserting invalid data
                    }

                    string insertQuery = @"INSERT INTO Experience 
                (UserID, CompanyName, JobTitle, EmploymentType, StartMonth, StartYear, EndMonth, EndYear, Location, Description) 
                OUTPUT INSERTED.ExperienceID VALUES (@UserId, @CompanyName, @JobTitle, @EmploymentType, @StartMonth, @StartYear, @EndMonth, @EndYear, @Location, @Description)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@CompanyName", entry.Company ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@JobTitle", entry.Title ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@EmploymentType", string.IsNullOrEmpty(entry.EmploymentType) ? (object)DBNull.Value : entry.EmploymentType);
                        cmd.Parameters.AddWithValue("@StartMonth", entry.StartMonth > 0 ? (object)entry.StartMonth : DBNull.Value);
                        cmd.Parameters.AddWithValue("@StartYear", entry.StartYear > 0 ? (object)entry.StartYear : DBNull.Value);
                        cmd.Parameters.AddWithValue("@EndMonth", entry.EndMonth > 0 ? (object)entry.EndMonth : DBNull.Value);
                        cmd.Parameters.AddWithValue("@EndYear", entry.EndYear > 0 ? (object)entry.EndYear : DBNull.Value);
                        cmd.Parameters.AddWithValue("@Location", string.IsNullOrEmpty(entry.Location) ? (object)DBNull.Value : entry.Location);
                        cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(entry.Description) ? (object)DBNull.Value : entry.Description);

                        entry.ExperienceID = (int)cmd.ExecuteScalar(); // Get the new ExperienceID
                    }
                }

                //Insert Education Data
                foreach (var edu in EducationEntries.Where(edu => edu.EducationID == 0)) // Insert only new entries
                {
                    // Validate required fields
                    if (string.IsNullOrEmpty(edu.School) || string.IsNullOrEmpty(edu.Degree))
                    {
                        string script = "alert('School Name and Degree are required fields.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidationAlert", script, true);
                        return; // Stop execution to prevent inserting invalid data
                    }

                    // SQL query to insert new record and return the generated EducationID
                    string insertQuery = @"
        INSERT INTO Education 
        (UserId, SchoolName, Degree, StartYear, EndYear, City, Description) 
        OUTPUT INSERTED.EducationID 
        VALUES (@UserId, @SchoolName, @Degree, @StartYear, @EndYear, @City, @Description)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@SchoolName", edu.School ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Degree", edu.Degree ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@StartYear", edu.StartYear > 0 ? (object)edu.StartYear : DBNull.Value);
                        cmd.Parameters.AddWithValue("@EndYear", edu.EndYear > 0 ? (object)edu.EndYear : DBNull.Value);
                        cmd.Parameters.AddWithValue("@City", string.IsNullOrEmpty(edu.City) ? (object)DBNull.Value : edu.City);
                        cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(edu.Description) ? (object)DBNull.Value : edu.Description);

                        // Retrieve the newly inserted EducationID and assign it to the object
                        edu.EducationID = (int)cmd.ExecuteScalar();
                    }
                }


                foreach (var link in LinkEntries.Where(l => l.LinkID == 0)) // Only insert new records
                {

                    if (string.IsNullOrWhiteSpace(link.Label) || string.IsNullOrWhiteSpace(link.Url))
                    {
                        // Skip or handle invalid entries
                        continue;
                    }

                    string query = "INSERT INTO Links (UserID, Label, Url) OUTPUT INSERTED.LinkID VALUES (@UserId, @Label, @Url)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Label", link.Label);
                        cmd.Parameters.AddWithValue("@Url", link.Url);

                        // Retrieve the newly inserted LinkID and update the object
                        link.LinkID = (int)cmd.ExecuteScalar();
                    }
                }

            }

            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string summary = txtSummary.Text.Trim();
            string country = txtCountry.Text.Trim(); // Get country from textbox
            string skills = txtskill.Text.Trim(); // Take skills as a single string

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
            {
                conn.Open();

                // Check if user details exist
                string checkUserQuery = "SELECT COUNT(*) FROM UserDetail WHERE UserId = @UserId";
                SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, conn);
                checkUserCmd.Parameters.AddWithValue("@UserId", userId);
                int userCount = (int)checkUserCmd.ExecuteScalar();

                if (userCount > 0)
                {
                    // Update User Details
                    string updateUserQuery = @"UPDATE UserDetail 
                                           SET FullName = @FullName, Email = @Email, PhoneNumber = @PhoneNumber, Summary = @Summary, Country = @Country 
                                           WHERE UserId = @UserId";
                    SqlCommand updateUserCmd = new SqlCommand(updateUserQuery, conn);
                    updateUserCmd.Parameters.AddWithValue("@Fullname", fullName);
                    updateUserCmd.Parameters.AddWithValue("@UserId", userId);
                    updateUserCmd.Parameters.AddWithValue("@Email", email);
                    updateUserCmd.Parameters.AddWithValue("@PhoneNumber", phone);
                    updateUserCmd.Parameters.AddWithValue("@Summary", summary);
                    updateUserCmd.Parameters.AddWithValue("@Country", country);
                    updateUserCmd.ExecuteNonQuery();
                }
                else
                {
                    // Insert new user details
                    string insertUserQuery = @"INSERT INTO UserDetail (UserId, FullName, Email, PhoneNumber, Summary, Country) 
                                           VALUES (@UserId, @FullName, @Email, @PhoneNumber, @Summary, @Country)";
                    SqlCommand insertUserCmd = new SqlCommand(insertUserQuery, conn);
                    insertUserCmd.Parameters.AddWithValue("@Fullname", fullName);
                    insertUserCmd.Parameters.AddWithValue("@UserId", userId);
                    insertUserCmd.Parameters.AddWithValue("@Email", email);
                    insertUserCmd.Parameters.AddWithValue("@PhoneNumber", phone);
                    insertUserCmd.Parameters.AddWithValue("@Summary", summary);
                    insertUserCmd.Parameters.AddWithValue("@Country", country);
                    insertUserCmd.ExecuteNonQuery();
                }

                // Check if skills already exist for this user
                string checkSkillsQuery = "SELECT COUNT(*) FROM Skills WHERE UserID = @UserId";
                SqlCommand checkCmd = new SqlCommand(checkSkillsQuery, conn);
                checkCmd.Parameters.AddWithValue("@UserId", userId);
                int skillCount = (int)checkCmd.ExecuteScalar();

                if (skillCount > 0)
                {
                    // Update existing skills
                    string updateSkillsQuery = "UPDATE Skills SET SkillsText = @SkillsText WHERE UserID = @UserId";
                    SqlCommand updateSkillsCmd = new SqlCommand(updateSkillsQuery, conn);
                    updateSkillsCmd.Parameters.AddWithValue("@UserId", userId);
                    updateSkillsCmd.Parameters.AddWithValue("@SkillsText", skills); // Ensure no extra quotes or format issues
                    updateSkillsCmd.ExecuteNonQuery();

                }
                else
                {
                    // Insert new skills
                    string insertSkillsQuery = "INSERT INTO Skills (UserID, SkillsText) VALUES (@UserId, @SkillsText)";
                    SqlCommand insertSkillsCmd = new SqlCommand(insertSkillsQuery, conn);
                    insertSkillsCmd.Parameters.AddWithValue("@UserId", userId);
                    insertSkillsCmd.Parameters.AddWithValue("@SkillsText", skills);
                    insertSkillsCmd.ExecuteNonQuery();

                }

            }


            // Redirect to resume result page
            Response.Redirect("Default.aspx");
        }
    }
}