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
            if (!IsPostBack)
            {
                loginLink.Attributes["href"] = "Login.aspx";

                if (Session["UserFirstName"] != null && Session["UserLastName"] != null)
                {
                    lblWelcome.Text = "Welcome, " + Session["UserFirstName"].ToString() + " " + Session["UserLastName"].ToString();
                    loginItem.Visible = false;  // Hide login if user is logged in
                    userDropdown.Visible = true; // Show the welcome dropdown
                }
                else
                {
                    lblWelcome.Text = "";
                    loginItem.Visible = true;
                    userDropdown.Visible = false; // Hide the welcome dropdown
                }
            }
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon(); // Destroy session
            Response.Redirect("Default.aspx");
        }
    }
}