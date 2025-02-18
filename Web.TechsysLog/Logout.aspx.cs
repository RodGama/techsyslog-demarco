using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.TechsysLog
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Session.Clear();  // Clears all session data
            Session.Abandon(); // Ends the session

            Response.Redirect("~/Login.aspx");
        }
    }
}