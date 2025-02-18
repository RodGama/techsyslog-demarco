using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.TechsysLog.Models;
using Web.TechsysLog.Results;

namespace Web.TechsysLog
{
    public partial class DashboardAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            if (IsPostBack)
            {
                NameValueCollection form = Request.Form;
                if (form.AllKeys.Any(x=>x.StartsWith("SendOrder")))
                    DeliverOrder(sender, e);
            }
            var ordersPending = OrdersToDeliver();
            StringBuilder tableHtml = new StringBuilder();

            foreach (var order in ordersPending)
            {
                tableHtml.Append("<tr><td class=\"text-white\">" + order.OrderNumber + "</td>");
                tableHtml.Append("<td><div class=\"d-flex align-items-center\"><span class=\"dot dot-xs bg-warning me-2\"></span>In progress</div></td>");
                tableHtml.Append("<td>" + order.CreationDate.ToShortDateString() + "</td>");
                tableHtml.Append($"<td><button type=\"submit\" ID=\"SendOrder{order.OrderNumber}\" name=\"SendOrder{order.OrderNumber}\" class=\"btn btn-primary d-block w-100 my-4\">Entregue</button>\r\n</td></tr>");

            }

            OrdersPending.Text = tableHtml.ToString();


        }
        protected void RegisterNewUser(object sender, EventArgs e)
        {
            NameValueCollection form = Request.Form;
            var signUpObj = new SignUpModel(form["fname"], form["email"], form["password"], form["passwordc"], 1);

            var client = new RestClient("https://localhost:7050/api/v1/");
            var request = new RestRequest("User/Add", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(signUpObj), ParameterType.RequestBody);
            RestResponse response = client.Execute(request);

            var body = response.Content.ToString();
            var result = JsonConvert.DeserializeObject<ResultTemplate>(body);
            if (result.Success)
                Response.Redirect("/Dashboard");
            else
            {
                Response.Write("<br/>Password: " + result.Errors[0]);
            }
        }

        protected void RegisterOrder(object sender, EventArgs e)
        {
            NameValueCollection form = Request.Form;
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            var jwtToken = ticket.UserData;
            var orderObj = new OrderModel(form["ctl00$MainContent$description"], Int64.Parse(form["ctl00$MainContent$ordernumber"]), float.Parse(form["ctl00$MainContent$price"]), Int32.Parse(form["ctl00$MainContent$cep"].Replace("-","")), Int32.Parse(form["ctl00$MainContent$addressnumber"]), form["ctl00$MainContent$street"], form["ctl00$MainContent$neighborhood"], form["ctl00$MainContent$city"], form["ctl00$MainContent$state"]);

            var client = new RestClient("https://localhost:7050/api/v1/");
            var request = new RestRequest("Order/Add", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {jwtToken}");
            request.AddParameter("application/json", JsonConvert.SerializeObject(orderObj), ParameterType.RequestBody);

            RestResponse response = client.Execute(request);

            var body = response.Content.ToString();
            var result = JsonConvert.DeserializeObject<ResultTemplate>(body);
            if (result.Success)
                Response.Redirect("/Dashboardadmin");
            else
            {
                Response.Write("<br/>Password: " + result.Errors[0]);
            }
        }
        public void DeliverOrder(object sender, EventArgs e)
        {
            NameValueCollection form = Request.Form;
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var orderString = form.AllKeys.Where(x => x.StartsWith("SendOrder"));
            var jwtToken = ticket.UserData;
            var order = Int64.Parse(orderString.First().Replace("SendOrder", ""));


            var client = new RestClient("https://localhost:7050/api/v1");

            var request = new RestRequest($"Order/DeliverOrder?OrderId="+ order, Method.Get);
            request.AddHeader("Authorization", $"Bearer {jwtToken}");
            RestResponse response = client.Execute(request);
            var body = response.Content.ToString();


            //var client = new RestClient("https://localhost:7050/api/v1/");
            //var request = new RestRequest($"Order/DeliverOrder?OrderId="+ order, Method.Get);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Authorization", $"Bearer {jwtToken}");

            //RestResponse response = client.Execute(request);

            //var body = response.Content.ToString();
            var result = JsonConvert.DeserializeObject<ResultTemplate>(body);
            if (result.Success)
                Response.Redirect("/Dashboardadmin");
            else
            {
                Response.Write("<br/>Password: " + result.Errors[0]);
            }
        }

        protected IList<Order> OrdersToDeliver()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            var jwtToken = ticket.UserData;
            var client = new RestClient("https://localhost:7050/api/v1");

            var request = new RestRequest("Order/GetOrdersToDeliver", Method.Get);
            request.AddHeader("Authorization", $"Bearer {jwtToken}");
            RestResponse response = client.Execute(request);
            var body = response.Content.ToString();

            var result = JsonConvert.DeserializeObject<List<Order>>(body);
            if (result != null)
            {
                return result;
            }
            else { return null; }
        }
    }
}