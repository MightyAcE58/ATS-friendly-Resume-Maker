using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ATS_friendly_Resume_Maker
{
    public partial class form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialize ViewState collections
                ViewState["EmploymentForms"] = new List<FormData>();
                ViewState["EducationForms"] = new List<FormData>();
                ViewState["WebsiteForms"] = new List<FormData>();
                ViewState["SkillsForms"] = new List<FormData>();

                // Initialize year dropdowns for all entries that might be added
                PopulateYearDropdowns();
            }

            BindAllRepeaters();
        }

        private void PopulateYearDropdowns()
        {
            // This will be called when new items are added to make sure year dropdowns are populated
            int currentYear = DateTime.Now.Year;
            List<int> years = new List<int>();

            // Generate a list of years (e.g., last 50 years to current year)
            for (int i = currentYear - 50; i <= currentYear; i++)
            {
                years.Add(i);
            }

            ViewState["YearsList"] = years;
        }

        private void PopulateYearDropdownInItem(RepeaterItem item, string startYearID, string endYearID)
        {
            if (item == null) return;

            DropDownList ddlStartYear = item.FindControl(startYearID) as DropDownList;
            DropDownList ddlEndYear = item.FindControl(endYearID) as DropDownList;

            if (ddlStartYear != null && ddlEndYear != null)
            {
                List<int> years = ViewState["YearsList"] as List<int>;
                if (years != null)
                {
                    ddlStartYear.Items.Clear();
                    ddlEndYear.Items.Clear();

                    // Add "Present" option to end year dropdown
                    ddlEndYear.Items.Add(new ListItem("Present", "Present"));

                    foreach (int year in years)
                    {
                        ddlStartYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
                        ddlEndYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
                    }
                }
            }
        }

        protected void rptEmployment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PopulateYearDropdownInItem(e.Item, "ddlStartYear", "ddlEndYear");
            }
        }

        protected void rptEducation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PopulateYearDropdownInItem(e.Item, "ddlStartYear", "ddlEndYear");
            }
        }

        private void BindAllRepeaters()
        {
            BindRepeater(rptEmployment, "EmploymentForms");
            BindRepeater(rptEducation, "EducationForms");
            BindRepeater(rptLinks, "WebsiteForms");
            BindRepeater(rptSkills, "SkillsForms");
        }

        private void BindRepeater(Repeater repeater, string viewStateKey)
        {
            repeater.DataSource = ViewState[viewStateKey] as List<FormData> ?? new List<FormData>();
            repeater.DataBind();
        }

        protected void btnAddEmployment_Click(object sender, EventArgs e) => AddItem("EmploymentForms");
        protected void btnAddEducation_Click(object sender, EventArgs e) => AddItem("EducationForms");
        protected void btnAddWebsite_Click(object sender, EventArgs e) => AddItem("WebsiteForms");
        protected void btnAddSkills_Click(object sender, EventArgs e) => AddItem("SkillsForms");

        private void AddItem(string viewStateKey)
        {
            var forms = ViewState[viewStateKey] as List<FormData> ?? new List<FormData>();
            forms.Add(new FormData());
            ViewState[viewStateKey] = forms;
            BindAllRepeaters();
        }

        protected void rptEmployment_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
                RemoveItem("EmploymentForms", Convert.ToInt32(e.CommandArgument));
        }

        protected void rptEducation_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
                RemoveItem("EducationForms", Convert.ToInt32(e.CommandArgument));
        }

        protected void rptLinks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
                RemoveItem("WebsiteForms", Convert.ToInt32(e.CommandArgument));
        }

        protected void rptSkills_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
                RemoveItem("SkillsForms", Convert.ToInt32(e.CommandArgument));
        }



        protected void RemoveItem(string viewStateKey, int index)
        {
            var forms = ViewState[viewStateKey] as List<FormData>;
            if (forms != null && index >= 0 && index < forms.Count)
            {
                forms.RemoveAt(index);
                ViewState[viewStateKey] = forms;
                BindAllRepeaters();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get employment data
            List<EmploymentData> employmentList = new List<EmploymentData>();
            foreach (RepeaterItem item in rptEmployment.Items)
            {
                TextBox txtCompany = item.FindControl("txtCompany") as TextBox;
                TextBox txtTitle = item.FindControl("txtTitle") as TextBox;
                DropDownList ddlEmployment = item.FindControl("ddlEmployment") as DropDownList;
                DropDownList ddlStartMonth = item.FindControl("ddlStartMonth") as DropDownList;
                DropDownList ddlStartYear = item.FindControl("ddlStartYear") as DropDownList;
                DropDownList ddlEndMonth = item.FindControl("ddlEndMonth") as DropDownList;
                DropDownList ddlEndYear = item.FindControl("ddlEndYear") as DropDownList;
                TextBox txtLocation = item.FindControl("txtLocation") as TextBox;
                TextBox txtDescription = item.FindControl("txtDescription") as TextBox;

                if (txtCompany != null && txtTitle != null)
                {
                    employmentList.Add(new EmploymentData
                    {
                        Company = txtCompany.Text,
                        Title = txtTitle.Text,
                        EmploymentType = ddlEmployment?.SelectedValue,
                        StartMonth = ddlStartMonth?.SelectedValue,
                        StartYear = ddlStartYear?.SelectedValue,
                        EndMonth = ddlEndMonth?.SelectedValue,
                        EndYear = ddlEndYear?.SelectedValue,
                        Location = txtLocation?.Text,
                        Description = txtDescription?.Text
                    });
                }
            }

            // Get education data
            List<EducationData> educationList = new List<EducationData>();
            foreach (RepeaterItem item in rptEducation.Items)
            {
                TextBox txtSchool = item.FindControl("txtSchool") as TextBox;
                TextBox txtDegree = item.FindControl("txtDegree") as TextBox;
                DropDownList ddlStartYear = item.FindControl("ddlStartYear") as DropDownList;
                DropDownList ddlEndYear = item.FindControl("ddlEndYear") as DropDownList;
                TextBox txtCity = item.FindControl("txtCity") as TextBox;
                TextBox txtEduDescription = item.FindControl("txtEduDescription") as TextBox;

                if (txtSchool != null && txtDegree != null)
                {
                    educationList.Add(new EducationData
                    {
                        School = txtSchool.Text,
                        Degree = txtDegree.Text,
                        StartYear = ddlStartYear?.SelectedValue,
                        EndYear = ddlEndYear?.SelectedValue,
                        City = txtCity?.Text,
                        Description = txtEduDescription?.Text
                    });
                }
            }

            // Get website/link data
            List<WebsiteData> websiteList = new List<WebsiteData>();
            foreach (RepeaterItem item in rptLinks.Items)
            {
                TextBox txtLabel = item.FindControl("txtLabel") as TextBox;
                TextBox txtUrl = item.FindControl("txtUrl") as TextBox;

                if (txtLabel != null && txtUrl != null)
                {
                    websiteList.Add(new WebsiteData
                    {
                        Label = txtLabel.Text,
                        Url = txtUrl.Text
                    });
                }
            }

            // Get skills data
            List<string> skillsList = new List<string>();
            foreach (RepeaterItem item in rptSkills.Items)
            {
                TextBox txtSkill = item.FindControl("txtSkill") as TextBox;

                if (txtSkill != null && !string.IsNullOrWhiteSpace(txtSkill.Text))
                {
                    skillsList.Add(txtSkill.Text);
                }
            }

            // TODO: Process all collected data to generate resume
            // For now, you could store in Session or redirect to a result page
        }

        // Updated FormData class to match the base structure
        [Serializable]
        public class FormData
        {
            public string Field1 { get; set; }
            public string Field2 { get; set; }
        }

        // New class for employment data
        [Serializable]
        public class EmploymentData
        {
            public string Company { get; set; }
            public string Title { get; set; }
            public string EmploymentType { get; set; }
            public string StartMonth { get; set; }
            public string StartYear { get; set; }
            public string EndMonth { get; set; }
            public string EndYear { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
        }

        // New class for education data
        [Serializable]
        public class EducationData
        {
            public string School { get; set; }
            public string Degree { get; set; }
            public string StartYear { get; set; }
            public string EndYear { get; set; }
            public string City { get; set; }
            public string Description { get; set; }
        }

        // New class for website/link data
        [Serializable]
        public class WebsiteData
        {
            public string Label { get; set; }
            public string Url { get; set; }
        }
    }
}