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

            var orders = GetOrders(0);
            StringBuilder tableHtml = new StringBuilder();
            StringBuilder tableHtml2 = new StringBuilder();
            foreach (var order in orders)
            {
                if(order.DeliveryDate == DateTime.MinValue)
                {
                    tableHtml.Append("<tr><td class=\"text-white\">" + order.OrderNumber + "</td>");
                    tableHtml.Append("<td><div class=\"d-flex align-items-center\"><span class=\"dot dot-xs bg-warning me-2\"></span>In progress</div></td>");
                    tableHtml.Append("<td>" + order.CreationDate.ToShortDateString() + "</td></tr>");
                }
                else
                {
                    tableHtml2.Append("<tr><td class=\"text-white\">" + order.OrderNumber + "</td>");
                    tableHtml2.Append("<td><div class=\"d-flex align-items-center\"><span class=\"dot dot-xs bg-success me-2\"></span>Entregue</div></td>");
                    tableHtml2.Append("<td>" + order.CreationDate.ToShortDateString() + "</td></tr>");
                } 
            }

            OrdersPending.Text = tableHtml.ToString();
            OrdersDelivered.Text = tableHtml2.ToString();
            
        }
        protected IList<Order> GetOrders(int PageNumber)
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

        protected void RegisterOrder(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            NameValueCollection form = Request.Form;

            var jwtToken = ticket.UserData;
            var client = new RestClient("https://localhost:7050/api/v1");

            var request = new RestRequest($"Order/AddOrderToUser?OrderNumber=" + form["ctl00$MainContent$ordernumber"], Method.Put);
            request.AddHeader("Authorization", $"Bearer {jwtToken}");
            RestResponse response = client.Execute(request);
            Response.Redirect("/dashboard");
        }
    }
}