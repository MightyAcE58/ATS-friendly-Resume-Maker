using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATS_friendly_Resume_Maker
{
    public partial class PickUrTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                // Redirect to login page if session expires
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnTemplate1_Click(object sender, EventArgs e)
        {
            string url = "template-1.aspx";
            string script = $"window.open('{url}', '_blank');";
            ClientScript.RegisterStartupScript(this.GetType(), "newTab", script, true);
        }
        protected void btnTemplate2_Click(object sender, EventArgs e)
        {
            string url = "template-2.aspx";
            string script = $"window.open('{url}', '_blank');";
            ClientScript.RegisterStartupScript(this.GetType(), "newTab", script, true);
        }
    }
}