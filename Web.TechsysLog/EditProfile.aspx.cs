using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.TechsysLog.Models;
using Web.TechsysLog.Results;

namespace Web.TechsysLog
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("/login.aspx");
            }

            if (IsPostBack)
            {
                NameValueCollection form = Request.Form;
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                var loginResult = JsonConvert.DeserializeObject<LoginResult>(ticket.UserData);

                var jwtToken = loginResult.Token;
                var updateObj = new UpdateUserModel(0,form["ctl00$MainContent$oldpassword"], form["ctl00$MainContent$password"], form["ctl00$MainContent$passwordc"]);

                var client = new RestClient("https://localhost:7050/api/v1/");
                var request = new RestRequest("User/UpdateUser",Method.Put);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", $"Bearer {jwtToken}");

                request.AddParameter("application/json",JsonConvert.SerializeObject(updateObj), ParameterType.RequestBody);
                RestResponse response = client.Execute(request);

            }
        }
    }
}