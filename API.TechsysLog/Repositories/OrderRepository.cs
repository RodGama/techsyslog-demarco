using API.TechsysLog.DataContext;
using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;
using API.TechsysLog.Models;
using API.TechsysLog.Repositories.Interfaces;
using System.Linq;

namespace API.TechsysLog.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Order order, int UserId)
        {
            _context.Orders.Add(order);
            _context.UserOrders.Add(new UserOrders { OrderNumber = order.OrderNumber, UserId= UserId });
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
            //!AINDA NÃO BUSQUEI PELO USUARIO
            var ordersList = _context.UserOrders.Where(x => x.UserId == UserId).Select(order => order.OrderNumber).Skip(PageNumber * pageQuantity)
                        .Take(pageQuantity).ToList();
            var orders = _context.Orders.Where(item => ordersList.Contains(item.OrderNumber)).ToList();
            return orders;


        }

    }
}
