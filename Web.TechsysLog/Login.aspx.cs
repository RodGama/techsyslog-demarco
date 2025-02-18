using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.TechsysLog.Models;
using Web.TechsysLog.Results;

namespace Web.TechsysLog
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("dashboard.aspx");
            }

            if (IsPostBack)
            {
                NameValueCollection form = Request.Form;
                var loginObj = new LoginModel(form["email"], form["password"]);

                var client = new RestClient("https://localhost:7050/api/v1/");
                var request = new RestRequest("Auth/Auth", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(loginObj), ParameterType.RequestBody);
                RestResponse response = client.Execute(request);

                var body = response.Content.ToString();
                var result = JsonConvert.DeserializeObject<LoginResult>(body);
                if (!string.IsNullOrEmpty(result.Token))
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                           1,               
                           form["email"],        
                           DateTime.Now,    
                           DateTime.Now.AddMinutes(30), 
                           false,
                           JsonConvert.SerializeObject(result),          
                           FormsAuthentication.FormsCookiePath
                     );

                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(cookie);
                    if (result.Role == Role.Employee)
                        Response.Redirect("/Dashboardadmin");
                    Response.Redirect("/Dashboard");

                }

                else
                {
                    Response.Write("<br/>Password: " + result.Errors[0]);
                }


            }
        }
    }
}