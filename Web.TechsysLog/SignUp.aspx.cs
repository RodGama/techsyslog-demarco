using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.TechsysLog.FormData;
using Newtonsoft.Json;
using Web.TechsysLog.Models;
using RestSharp;
using Web.TechsysLog.Results;
using System.Text;

namespace Web.TechsysLog
{
    public partial class SignUp : System.Web.UI.Page
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
                var signUpObj = new SignUpModel(form["fname"], form["email"], form["password"], form["passwordc"], 1);

                var client = new RestClient("https://localhost:7050/api/v1/");
                var request = new RestRequest("User/Add", Method.Put);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(signUpObj), ParameterType.RequestBody);
                RestResponse response = client.Execute(request);

                var body = response.Content?.ToString();
                if (body == null)
                {
                    var result = JsonConvert.DeserializeObject<ResultTemplate>(body);
                    if (result.Success)
                        Response.Redirect("/Dashboard");
                    else
                    {
                        StringBuilder errorHtml = new StringBuilder();
                        errorHtml.Append("<div class=\"alert alert-warning d-flex align-items-center\" role=\"alert\"><svg class=\"bi flex-shrink-0 me-2\" width=\"24\" height=\"24\" role=\"img\" aria-label=\"Warning:\"><use xlink:href=\"#exclamation-triangle-fill\"></use></svg><div>");
                        foreach (var error in result.Errors)
                        {
                            errorHtml.Append(error + "</div></div>");
                        }

                        ErrorList.Text = errorHtml.ToString();
                    }
                }
            }
        }
    }
}