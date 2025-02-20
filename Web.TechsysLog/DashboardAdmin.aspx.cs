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
        private List<Order> _ordersPending;
        private int _pageNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            var loginResult = JsonConvert.DeserializeObject<LoginResult>(ticket.UserData);
            if (loginResult.Role != Role.Employee)
            {
                Response.Redirect("Dashboard.aspx");
            }
            if (IsPostBack)
            {
                NameValueCollection form = Request.Form;
                if (form.AllKeys.Any(x => x.StartsWith("SendOrder")))
                    DeliverOrder(sender, e);
            }
            OrdersToDeliver(sender, e);
            


        }
        protected void RegisterNewUser(object sender, EventArgs e)
        {
            NameValueCollection form = Request.Form;
            var signUpObj = new SignUpModel(form["ctl00$MainContent$fname"], form["ctl00$MainContent$email"], form["ctl00$MainContent$password"], form["ctl00$MainContent$passwordc"], 0);

            var client = new RestClient("https://localhost:7050/api/v1/");
            var request = new RestRequest("User/Add", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(signUpObj), ParameterType.RequestBody);
            RestResponse response = client.Execute(request);

            var body = response.Content?.ToString();
            if (body != null)
            {
                var result = JsonConvert.DeserializeObject<ResultTemplate>(body);
                if (result.Success)
                    Response.Redirect("/Dashboardadmin");
                else
                {
                    StringBuilder errorHtml = new StringBuilder();
                    errorHtml.Append("<div class=\"alert alert-warning d-flex align-items-center\" role=\"alert\"><svg class=\"bi flex-shrink-0 me-2\" width=\"24\" height=\"24\" role=\"img\" aria-label=\"Warning:\"><use xlink:href=\"#exclamation-triangle-fill\"></use></svg><div>");
                    foreach (var error in result.Errors)
                    {
                        errorHtml.Append(error + "</br>");
                    }
                    errorHtml.Append("</div></div>");

                    ErrorListUser.Text = errorHtml.ToString();
                }
            }
        }

        protected void RegisterOrder(object sender, EventArgs e)
        {
            NameValueCollection form = Request.Form;
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var loginResult = JsonConvert.DeserializeObject<LoginResult>(ticket.UserData);

            var jwtToken = loginResult.Token;
            var orderObj = new OrderModel(form["ctl00$MainContent$description"], Int64.Parse(form["ctl00$MainContent$ordernumber"]), float.Parse(form["ctl00$MainContent$price"]), Int32.Parse(form["ctl00$MainContent$cep"].Replace("-", "")), Int32.Parse(form["ctl00$MainContent$addressnumber"]), form["ctl00$MainContent$street"], form["ctl00$MainContent$neighborhood"], form["ctl00$MainContent$city"], form["ctl00$MainContent$state"]);

            var client = new RestClient("https://localhost:7050/api/v1/");
            var request = new RestRequest("Order/Add", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {jwtToken}");
            request.AddParameter("application/json", JsonConvert.SerializeObject(orderObj), ParameterType.RequestBody);

            RestResponse response = client.Execute(request);

            var body = response.Content?.ToString();
            if (body != null)
            {

                var result = JsonConvert.DeserializeObject<ResultTemplate>(body);
                if (result.Success)
                    Response.Redirect("/Dashboardadmin");
                else
                {
                    StringBuilder errorHtml = new StringBuilder();
                    errorHtml.Append("<div class=\"alert alert-warning d-flex align-items-center\" role=\"alert\"><svg class=\"bi flex-shrink-0 me-2\" width=\"24\" height=\"24\" role=\"img\" aria-label=\"Warning:\"><use xlink:href=\"#exclamation-triangle-fill\"></use></svg><div>");
                    foreach (var error in result.Errors)
                    {
                        errorHtml.Append(error + "</br>");
                    }
                    errorHtml.Append("</div></div>");

                    ErrorListOrder.Text = errorHtml.ToString();
                }
            }
        }
        public void DeliverOrder(object sender, EventArgs e)
        {
            NameValueCollection form = Request.Form;
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var orderString = form.AllKeys.Where(x => x.StartsWith("SendOrder"));
            var loginResult = JsonConvert.DeserializeObject<LoginResult>(ticket.UserData);

            var jwtToken = loginResult.Token;
            var order = Int64.Parse(orderString.First().Replace("SendOrder", ""));


            var client = new RestClient("https://localhost:7050/api/v1");

            var request = new RestRequest($"Order/DeliverOrder?OrderId=" + order, Method.Get);
            request.AddHeader("Authorization", $"Bearer {jwtToken}");
            RestResponse response = client.Execute(request);
        }

        protected void OrdersToDeliver(object sender, EventArgs e)
        {
            string parameter = pageNumber.Value;

            if (!string.IsNullOrEmpty(parameter))
            {
                _pageNumber = Int32.Parse(parameter);
                _pageNumber--;
            }

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var loginResult = JsonConvert.DeserializeObject<LoginResult>(ticket.UserData);

            var jwtToken = loginResult.Token;
            var client = new RestClient("https://localhost:7050/api/v1");

            var request = new RestRequest($"Order/GetOrdersToDeliver?PageNumber={_pageNumber}&PageQuantity={10}", Method.Get);
            request.AddHeader("Authorization", $"Bearer {jwtToken}");
            RestResponse response = client.Execute(request);
            var body = response.Content?.ToString();
            if (body != null)
            {
                var result = JsonConvert.DeserializeObject<List<Order>>(body);
                if (result != null)
                {
                    _ordersPending=result;
                    StringBuilder tableHtml = new StringBuilder();

                    foreach (var order in _ordersPending)
                    {
                        tableHtml.Append("<tr><td class=\"text-white\">" + order.OrderNumber + "</td>");
                        tableHtml.Append("<td><div class=\"d-flex align-items-center\"><span class=\"dot dot-xs bg-warning me-2\"></span>In progress</div></td>");
                        tableHtml.Append("<td>" + order.CreationDate.ToShortDateString() + "</td>");
                        tableHtml.Append($"<td><button type=\"submit\" ID=\"SendOrder{order.OrderNumber}\" name=\"SendOrder{order.OrderNumber}\" class=\"btn btn-primary d-block w-100 my-4\">Entregue</button>\r\n</td></tr>");

                    }

                    OrdersPending.Text = tableHtml.ToString();
                }
            }
        }
    }
}