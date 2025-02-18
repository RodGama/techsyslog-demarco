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
    public partial class Dashboard1 : System.Web.UI.Page
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
                var loginObj = new LoginModel(form["email"], form["password"]);
            }
            var ordersPending = GetOrdersPending(0);
            StringBuilder tableHtml = new StringBuilder();

            foreach (var order in ordersPending)
            {
                tableHtml.Append("<tr><td class=\"text-white\">" + order.OrderNumber + "</td>");
                tableHtml.Append("<td><div class=\"d-flex align-items-center\"><span class=\"dot dot-xs bg-warning me-2\"></span>In progress</div></td>");
                tableHtml.Append("<td>" + order.CreationDate.ToShortDateString() + "</td></tr>");
            }

            OrdersPending.Text = tableHtml.ToString();

            var ordersDelivered = GetOrdersPending(0);
            StringBuilder tableHtml2 = new StringBuilder();

            foreach (var order in ordersPending)
            {
                tableHtml2.Append("<tr><td class=\"text-white\">" + order.OrderNumber + "</td>");
                tableHtml2.Append("<td><div class=\"d-flex align-items-center\"><span class=\"dot dot-xs bg-success me-2\"></span>Entregue</div></td>");
                tableHtml2.Append("<td>" + order.CreationDate.ToShortDateString() + "</td></tr>");
            }

            OrdersDelivered.Text = tableHtml2.ToString();
        }
        protected IList<Order> GetOrdersPending(int PageNumber)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            var jwtToken = ticket.UserData;
            var client = new RestClient("https://localhost:7050/api/v1");

            var request = new RestRequest($"/Order/GetAllFromUser?PageNumber={PageNumber}&PageQuantity={5}", Method.Get);
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

        protected void RegisterOrder(int orderNumber)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            var jwtToken = ticket.UserData;
            var client = new RestClient("https://localhost:7050/api/v1");

            var request = new RestRequest($"/Order/GetAllFromUser?", Method.Get);
            request.AddHeader("Authorization", $"Bearer {jwtToken}");
            RestResponse response = client.Execute(request);

        }
    }
}