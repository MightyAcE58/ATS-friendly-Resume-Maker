using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            get => (List<EmploymentData>)ViewState["EmploymentEntries"] ?? new List<EmploymentData>();
            set => ViewState["EmploymentEntries"] = value;
        }

        private List<EducationData> EducationEntries
        {
            get => (List<EducationData>)ViewState["EducationEntries"] ?? new List<EducationData>();
            set => ViewState["EducationEntries"] = value;
        }

        private List<LinkData> LinkEntries
        {
            get => (List<LinkData>)ViewState["LinkEntries"] ?? new List<LinkData>();
            set => ViewState["LinkEntries"] = value;
        }

        private List<SkillData> SkillEntries
        {
            get => (List<SkillData>)ViewState["SkillEntries"] ?? new List<SkillData>();
            set => ViewState["SkillEntries"] = value;
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
        }


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
                var entry = (EmploymentData)e.Item.DataItem;
                InitializeEmploymentItem(e, entry);
            }
        }

        private void InitializeEmploymentItem(RepeaterItemEventArgs e, EmploymentData entry)
        {
            var ddlStartYear = (DropDownList)e.Item.FindControl("ddlStartYear");
            var ddlEndYear = (DropDownList)e.Item.FindControl("ddlEndYear");

            PopulateYearDropdowns(ddlStartYear, ddlEndYear);

            var txtCompany = (TextBox)e.Item.FindControl("txtCompany");
            var txtTitle = (TextBox)e.Item.FindControl("txtTitle");
            var ddlEmployment = (DropDownList)e.Item.FindControl("ddlEmployment");
            var ddlStartMonth = (DropDownList)e.Item.FindControl("ddlStartMonth");
            var ddlEndMonth = (DropDownList)e.Item.FindControl("ddlEndMonth");
            var txtLocation = (TextBox)e.Item.FindControl("txtLocation");
            var txtDescription = (TextBox)e.Item.FindControl("txtDescription");

            txtCompany.Text = entry.Company;
            txtTitle.Text = entry.Title;
            ddlEmployment.SelectedValue = entry.EmploymentType;
            ddlStartMonth.SelectedValue = entry.StartMonth.ToString();
            ddlStartYear.SelectedValue = entry.StartYear.ToString();
            ddlEndYear.SelectedValue = entry.EndYear.ToString() == "0" ? "0" : entry.EndYear.ToString();
            ddlEndMonth.SelectedValue = entry.EndMonth.ToString();
            txtLocation.Text = entry.Location;
            txtDescription.Text = entry.Description;
        }

        private void PopulateYearDropdowns(DropDownList ddlStartYear, DropDownList ddlEndYear)
        {
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear; year >= currentYear - 50; year--)
            {
                ddlStartYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
                ddlEndYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
            }
            ddlEndYear.Items.Add(new ListItem("Present", "0"));
        }

        private void SaveEmploymentValues()
        {
            for (int i = 0; i < rptEmployment.Items.Count; i++)
            {
                var item = rptEmployment.Items[i];
                var txtCompany = (TextBox)item.FindControl("txtCompany");
                var txtTitle = (TextBox)item.FindControl("txtTitle");
                var ddlEmployment = (DropDownList)item.FindControl("ddlEmployment");
                var ddlStartMonth = (DropDownList)item.FindControl("ddlStartMonth");
                var ddlStartYear = (DropDownList)item.FindControl("ddlStartYear");
                var ddlEndMonth = (DropDownList)item.FindControl("ddlEndMonth");
                var ddlEndYear = (DropDownList)item.FindControl("ddlEndYear");
                var txtLocation = (TextBox)item.FindControl("txtLocation");
                var txtDescription = (TextBox)item.FindControl("txtDescription");

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
                var entry = (EducationData)e.Item.DataItem;
                InitializeEducationItem(e, entry);
            }
        }

        private void InitializeEducationItem(RepeaterItemEventArgs e, EducationData entry)
        {
            var ddlStartYear = (DropDownList)e.Item.FindControl("ddlStartYear");
            var ddlEndYear = (DropDownList)e.Item.FindControl("ddlEndYear");

            PopulateYearDropdowns(ddlStartYear, ddlEndYear);

            var txtSchool = (TextBox)e.Item.FindControl("txtSchool");
            var txtDegree = (TextBox)e.Item.FindControl("txtDegree");
            var txtCity = (TextBox)e.Item.FindControl("txtCity");
            var txtEduDescription = (TextBox)e.Item.FindControl("txtEduDescription");

            txtSchool.Text = entry.School;
            txtDegree.Text = entry.Degree;
            ddlStartYear.SelectedValue = entry.StartYear.ToString();
            ddlEndYear.SelectedValue = entry.EndYear.ToString() == "0" ? "0" : entry.EndYear.ToString();
            txtCity.Text = entry.City;
            txtEduDescription.Text = entry.Description;
        }

        private void SaveEducationValues()
        {
            for (int i = 0; i < rptEducation.Items.Count; i++)
            {
                var item = rptEducation.Items[i];
                var txtSchool = (TextBox)item.FindControl("txtSchool");
                var txtDegree = (TextBox)item.FindControl("txtDegree");
                var ddlStartYear = (DropDownList)item.FindControl("ddlStartYear");
                var ddlEndYear = (DropDownList)item.FindControl("ddlEndYear");
                var txtCity = (TextBox)item.FindControl("txtCity");
                var txtEduDescription = (TextBox)item.FindControl("txtEduDescription");

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
                int index = Convert.ToInt32(e.CommandArgument);
                LinkEntries.RemoveAt(index);
                BindLinksRepeater();
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

        private void SaveLinkValues()
        {
            List<LinkData> currentLinks = new List<LinkData>();
            foreach (RepeaterItem item in rptLinks.Items)
            {
                var txtLabel = (TextBox)item.FindControl("txtLabel");
                var txtUrl = (TextBox)item.FindControl("txtUrl");

                currentLinks.Add(new LinkData
                {
                    Label = txtLabel.Text,
                    Url = txtUrl.Text
                });
            }
            LinkEntries = currentLinks;
        }

        private void BindLinksRepeater()
        {
            rptLinks.DataSource = LinkEntries;
            rptLinks.DataBind();
        }



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
            List<SkillData> currentSkills = new List<SkillData>();

            for (int i = 0; i < rptSkills.Items.Count; i++)
            {
                var item = rptSkills.Items[i];
                var txtSkill = (TextBox)item.FindControl("txtSkill");

                currentSkills.Add(new SkillData
                {
                    Skill = txtSkill.Text
                });
            }
            SkillEntries = currentSkills;
        }

        private void BindSkillsRepeater()
        {
            rptSkills.DataSource = SkillEntries;
            rptSkills.DataBind();
        }


        private void BindAllRepeaters()
        {
            BindEmploymentRepeater();
            BindEducationRepeater();
            BindLinksRepeater();
            BindSkillsRepeater();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveEmploymentValues();
            SaveEducationValues();
            SaveLinkValues();
            SaveSkillValues();

            Session["EmploymentEntries"] = EmploymentEntries;
            Session["EducationEntries"] = EducationEntries;
            Session["LinkEntries"] = LinkEntries;
            Session["SkillEntries"] = SkillEntries;

            Response.Redirect("ResumeResult.aspx");
        }
    }
}
