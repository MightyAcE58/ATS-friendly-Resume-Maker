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

        private void LoadEmploymentData(int userId)
        {
            EmploymentEntries.Clear(); // Clear old data

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
                                Company = reader["CompanyName"].ToString(),
                                Title = reader["JobTitle"].ToString(),
                                EmploymentType = reader["EmploymentType"] != DBNull.Value ? reader["EmploymentType"].ToString() : "",
                                StartMonth = reader["StartMonth"] != DBNull.Value ? Convert.ToInt32(reader["StartMonth"]) : 0,
                                StartYear = reader["StartYear"] != DBNull.Value ? Convert.ToInt32(reader["StartYear"]) : 0,
                                EndMonth = reader["EndMonth"] != DBNull.Value ? Convert.ToInt32(reader["EndMonth"]) : 0,
                                EndYear = reader["EndYear"] != DBNull.Value ? Convert.ToInt32(reader["EndYear"]) : 0,
                                Location = reader["Location"] != DBNull.Value ? reader["Location"].ToString() : "",
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : ""
                            });
                        }
                    }
                }
            }

            // Bind data to UI elements like Repeater/GridView if required
        }
        private void LoadEducationData(int userId)
        {
            EducationEntries.Clear();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
            {
                con.Open();
                string query = "SELECT SchoolName, Degree, StartYear, EndYear, City, Description FROM Education WHERE UserID = @UserId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EducationEntries.Add(new EducationData()
                            {
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
                string query = "SELECT Label, Url FROM Links WHERE UserID = @UserId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LinkEntries.Add(new LinkData()
                            {
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
                SaveEmploymentValues();
                int index = Convert.ToInt32(e.CommandArgument);
                if (index >= 0 && index < EmploymentEntries.Count)
                {
                    EmploymentEntries.RemoveAt(index);
                    BindEmploymentRepeater();
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
                SaveEducationValues();
                int index = Convert.ToInt32(e.CommandArgument);
                if (index >= 0 && index < EducationEntries.Count)
                {
                    EducationEntries.RemoveAt(index);
                    BindEducationRepeater();
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
                SaveLinkValues();
                int index = Convert.ToInt32(e.CommandArgument);
                if (index >= 0 && index < LinkEntries.Count)
                {
                    LinkEntries.RemoveAt(index);
                    BindLinksRepeater();
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

                // Insert Employment Data
                foreach (var emp in EmploymentEntries)
                {
                    string query = @"INSERT INTO Experience 
        (UserID, CompanyName, JobTitle, EmploymentType, StartMonth, StartYear, EndMonth, EndYear, Location, Description) 
        VALUES (@UserId, @CompanyName, @JobTitle, @EmploymentType, @StartMonth, @StartYear, @EndMonth, @EndYear, @Location, @Description)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@CompanyName", emp.Company ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@JobTitle", emp.Title ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@EmploymentType", string.IsNullOrEmpty(emp.EmploymentType) ? (object)DBNull.Value : emp.EmploymentType);

                        cmd.Parameters.AddWithValue("@StartMonth", emp.StartMonth > 0 ? (object)emp.StartMonth : DBNull.Value);
                        cmd.Parameters.AddWithValue("@StartYear", emp.StartYear > 0 ? (object)emp.StartYear : DBNull.Value);
                        cmd.Parameters.AddWithValue("@EndMonth", emp.EndMonth > 0 ? (object)emp.EndMonth : DBNull.Value);
                        cmd.Parameters.AddWithValue("@EndYear", emp.EndYear > 0 ? (object)emp.EndYear : DBNull.Value);

                        cmd.Parameters.AddWithValue("@Location", string.IsNullOrEmpty(emp.Location) ? (object)DBNull.Value : emp.Location);
                        cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(emp.Description) ? (object)DBNull.Value : emp.Description);

                        cmd.ExecuteNonQuery();
                    }
                }


                // Insert Education Data
                foreach (var edu in EducationEntries)
                {
                    string query = @"INSERT INTO Education 
(UserId, SchoolName, Degree, StartYear, EndYear, City, Description) 
VALUES (@UserId, @SchoolName, @Degree, @StartYear, @EndYear, @City, @Description)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@SchoolName", edu.School ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Degree", edu.Degree ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@StartYear", edu.StartYear > 0 ? (object)edu.StartYear : DBNull.Value);
                        cmd.Parameters.AddWithValue("@EndYear", edu.EndYear > 0 ? (object)edu.EndYear : DBNull.Value);
                        cmd.Parameters.AddWithValue("@City", string.IsNullOrEmpty(edu.City) ? (object)DBNull.Value : edu.City);
                        cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(edu.Description) ? (object)DBNull.Value : edu.Description);

                        cmd.ExecuteNonQuery();
                    }
                }


                // Insert Links Data
                foreach (var link in LinkEntries)
                {
                    string query = "INSERT INTO Links (UserId, Label, URL) VALUES (@UserId, @Label, @Url)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Label", link.Label);
                        cmd.Parameters.AddWithValue("@URL", link.Url);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // Redirect to resume result page
            Response.Redirect("Default.aspx");
        }
    }
}