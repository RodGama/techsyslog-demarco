using API.TechsysLog.DataContext;
using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;
using API.TechsysLog.Models;
using API.TechsysLog.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.TechsysLog.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Order order, int UserId)
        {
            _context.Orders.Add(order);
            
            _context.SaveChanges();
        }

        public void AddToUser(int userId, long orderNumber)
        {
            _context.UserOrders.Add(new UserOrders { OrderNumber = orderNumber, UserId = userId });
            _context.SaveChanges();
        }

        public List<Order> Get(int PageNumber, int pageQuantity)
        {
            return [.. _context.Orders
                        .Skip(PageNumber * pageQuantity)
                        .Take(pageQuantity)
                        ];
        }

        public Order GetById(long orderId)
        {
            return _context.Orders.Where(x=>x.OrderNumber==orderId).FirstOrDefault();
        }

        public List<Order> GetByUserId(int PageNumber, int pageQuantity, int UserId)
        {
            var ordersList = _context.UserOrders.Where(x => x.UserId == UserId).Select(order => order.OrderNumber).Skip(PageNumber * pageQuantity)
                        .Take(pageQuantity).ToList();
            var orders = _context.Orders.Where(item => ordersList.Contains(item.OrderNumber)).Include(o => o.Delivery).ToList();
            return orders;
        }

        public List<Order> GetOrdersToDeliver(int pageNumber, int pageQuantity)
        {
            var orders = _context.Orders.Where(item => item.Delivery.DeliveryDate == null).ToList();
            return orders;
        }
    }
}
