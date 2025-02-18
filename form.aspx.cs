using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

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

        private void BindLinksRepeater()
        {
            rptLinks.DataSource = LinkEntries;
            rptLinks.DataBind();
        }
        #endregion

        #region Skills Methods
        protected void btnAddSkills_Click(object sender, EventArgs e)
        {
            SaveSkillValues();
            SkillEntries.Add(new SkillData());
            BindSkillsRepeater();
        }

        protected void rptSkills_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                SaveSkillValues();
                int index = Convert.ToInt32(e.CommandArgument);
                if (index >= 0 && index < SkillEntries.Count)
                {
                    SkillEntries.RemoveAt(index);
                    BindSkillsRepeater();
                }
            }
        }

        private void SaveSkillValues()
        {
            for (int i = 0; i < rptSkills.Items.Count; i++)
            {
                RepeaterItem item = rptSkills.Items[i];

                TextBox txtSkill = (TextBox)item.FindControl("txtSkill");

                if (i < SkillEntries.Count)
                {
                    SkillEntries[i].Skill = txtSkill.Text;
                }
            }
        }

        private void BindSkillsRepeater()
        {
            rptSkills.DataSource = SkillEntries;
            rptSkills.DataBind();
        }
        #endregion

        private void BindAllRepeaters()
        {
            BindEmploymentRepeater();
            BindEducationRepeater();
            BindLinksRepeater();
            BindSkillsRepeater();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Save all values first
            SaveEmploymentValues();
            SaveEducationValues();
            SaveLinkValues();
            SaveSkillValues();

            // Generate resume and redirect to result page
            Session["EmploymentEntries"] = EmploymentEntries;
            Session["EducationEntries"] = EducationEntries;
            Session["LinkEntries"] = LinkEntries;
            Session["SkillEntries"] = SkillEntries;

            Response.Redirect("ResumeResult.aspx");
        }
    }
}