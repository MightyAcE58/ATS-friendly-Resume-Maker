using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATS_friendly_Resume_Maker
{
    public partial class Header : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserFirstName"] != null && Session["UserLastName"] != null)
            {
                lblWelcome.Text = "Welcome, " + Session["UserFirstName"].ToString() + " " + Session["UserLastName"].ToString();
                loginLink.Visible = false; // Hide login link if the user is logged in
            }
            else
            {
                lblWelcome.Text = "";
                loginLink.Visible = true; // Show login link if the user is not logged in
            }
        }
    }
}