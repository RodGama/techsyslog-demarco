using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.TechsysLog.Results;

namespace Web.TechsysLog
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            var loginResult = JsonConvert.DeserializeObject<LoginResult>(ticket.UserData);
            if (loginResult.Role == Role.Employee)
            {
                Response.Redirect("Dashboardadmin.aspx");
            }
            Response.Redirect("Dashboard.aspx");
        }
    }
}