using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.TechsysLog.Models;
using Web.TechsysLog.Results;

namespace Web.TechsysLog
{
    public partial class Dashboard1 : System.Web.UI.Page
    {
        private List<Notification> _notifications;
        private List<Order> _orders;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            if (IsPostBack && !String.IsNullOrEmpty(Request.Form["ctl00$MainContent$ordernumber"].ToString()))
            {
                RegisterOrder(sender, e);
            }

            _orders = GetOrders(0);
            _notifications = GetNotifications();
            StringBuilder tableHtml = new StringBuilder();
            StringBuilder tableHtml2 = new StringBuilder();
            StringBuilder listHtml = new StringBuilder();
            if (_orders != null)
            {
                foreach (var order in _orders)
                {
                    if (order.DeliveryDate == DateTime.MinValue)
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
            }
            if (_notifications != null && _notifications.Count > 0)
            {
                foreach (var notification in _notifications)
                {
                    listHtml.Append("<div class=\"d-flex justify-content-start align-items-start p-3 rounded bg-light mb-3\"><div class=\"ms-4\">");
                    listHtml.Append($"<p class=\"fw-bolder mb-1\">Pedido {notification.OrderNumber} Entregue</p>");
                    listHtml.Append($"<p class=\"text-muted small mb-0\">Seu pedido foi entregue em {notification.NotifiedDate.ToShortDateString()} às {notification.NotifiedDate.ToShortTimeString()}</p></div></div>");
                }

                if (Master != null)
                {
                    Literal litMessage = (Literal)Master.FindControl("NotificationQuantity");
                    if (litMessage != null)
                    {
                        litMessage.Text = _notifications.Count.ToString();
                    }
                }
            }
            OrdersPending.Text = tableHtml.ToString();
            OrdersDelivered.Text = tableHtml2.ToString();
            NotificationsUser.Text = listHtml.ToString();

        }
        protected List<Order> GetOrders(int PageNumber)
        {

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            var loginResult = JsonConvert.DeserializeObject<LoginResult>(ticket.UserData);

            var jwtToken = loginResult.Token;
            var client = new RestClient("https://localhost:7050/api/v1");

            var request = new RestRequest($"/Order/GetAllFromUser?PageNumber={PageNumber}&PageQuantity={10}", Method.Get);
            request.AddHeader("Authorization", $"Bearer {jwtToken}");
            RestResponse response = client.Execute(request);
            var body = response.Content?.ToString();
            if (body == null)
                return null;
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

            var loginResult = JsonConvert.DeserializeObject<LoginResult>(ticket.UserData);

            var jwtToken = loginResult.Token;
            var client = new RestClient("https://localhost:7050/api/v1");

            var request = new RestRequest($"Order/AddOrderToUser?OrderNumber=" + form["ctl00$MainContent$ordernumber"], Method.Put);
            request.AddHeader("Authorization", $"Bearer {jwtToken}");
            RestResponse response = client.Execute(request);
            var body = response.Content?.ToString();
            if (body == null)
                return;
            var result = JsonConvert.DeserializeObject<ResultTemplate>(body);
            if (!result.Success)
            {
                StringBuilder errorHtml = new StringBuilder();
                errorHtml.Append("<div class=\"alert alert-warning d-flex align-items-center\" role=\"alert\"><svg class=\"bi flex-shrink-0 me-2\" width=\"24\" height=\"24\" role=\"img\" aria-label=\"Warning:\"><use xlink:href=\"#exclamation-triangle-fill\"></use></svg><div>");
                foreach (var error in result.Errors)
                {
                    errorHtml.Append(error + "</br>");
                }
                errorHtml.Append("</div></div>");

                ErrorList.Text = errorHtml.ToString();
            }


            Response.Redirect("/dashboard");
        }
        protected List<Notification> GetNotifications()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            var loginResult = JsonConvert.DeserializeObject<LoginResult>(ticket.UserData);

            var jwtToken = loginResult.Token;
            var client = new RestClient("https://localhost:7050/api/v1");

            var request = new RestRequest("Order/GetNotificationsNotReadFromUser", Method.Get);
            request.AddHeader("Authorization", $"Bearer {jwtToken}");
            RestResponse response = client.Execute(request);
            var body = response.Content?.ToString();
            if (body == null)
                return null;
            var result = JsonConvert.DeserializeObject<List<Notification>>(body);
            if (result != null)
            {
                return result;
            }
            else { return null; }
        }

        protected void RegisterViewNotification(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            var loginResult = JsonConvert.DeserializeObject<LoginResult>(ticket.UserData);

            var jwtToken = loginResult.Token;
            var client = new RestClient("https://localhost:7050/api/v1");

            var request = new RestRequest("Order/NotificationsReadByUser", Method.Post);
            request.AddHeader("Authorization", $"Bearer {jwtToken}");
            request.AddParameter("application/json", JsonConvert.SerializeObject(_notifications), ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            Response.Redirect("/dashboard");
        }
    }
}