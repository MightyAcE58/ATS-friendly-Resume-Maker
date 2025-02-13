using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATS_friendly_Resume_Maker
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + Session["UserFirstName"].ToString() + " " + Session["UserLastName"].ToString();

            String str = Session["UserFirstName"].ToString() +" "+ Session["UserLastName"].ToString();
            TextBox1.Text = str;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}