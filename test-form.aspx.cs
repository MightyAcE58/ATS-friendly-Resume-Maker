using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ATS_friendly_Resume_Maker
{
    [Serializable]
    public class FieldData
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }

    public partial class test_form : System.Web.UI.Page
    {
        private List<FieldData> Fields
        {
            get
            {
                if (ViewState["Fields"] == null)
                {
                    ViewState["Fields"] = new List<FieldData>();
                }
                return (List<FieldData>)ViewState["Fields"];
            }
            set
            {
                ViewState["Fields"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SaveFieldValues(); // Save existing inputs before adding
            Fields.Add(new FieldData { Label = $"Field {Fields.Count + 1}", Value = "" });
            BindRepeater();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                SaveFieldValues(); // Save before removing
                int index = Convert.ToInt32(e.CommandArgument);
                if (index >= 0 && index < Fields.Count)
                {
                    Fields.RemoveAt(index);
                    BindRepeater();
                }
            }
        }

        private void BindRepeater()
        {
            Repeater1.DataSource = Fields;
            Repeater1.DataBind();
        }

        private void SaveFieldValues()
        {
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                TextBox txt = (TextBox)Repeater1.Items[i].FindControl("TextBox1");
                if (txt != null)
                {
                    Fields[i].Value = txt.Text; // Save user-entered text
                }
            }
        }
    }
}
