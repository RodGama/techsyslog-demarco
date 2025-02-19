using API.TechsysLog.DataContext;
using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;
using API.TechsysLog.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.TechsysLog.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            _context.SaveChanges();
        }

        public void AddNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }

        public Delivery Get(long OrderId)
        {
            return _context.Deliveries.Where(x => x.OrderNumber == OrderId).FirstOrDefault();
        }


        public IList<Delivery> GetDeliveriesFromUser(long userId)
        {
            var orders = _context.UserOrders.Where(x => x.UserId == userId).Select(order => order.OrderNumber).ToList();

            return _context.Deliveries.Where(item => orders.Contains(item.OrderNumber)).Include(o => o.Notification).ToList();
        }

        public Notification GetNotification(int notificationId)
        {
            return _context.Notifications.Where(x => x.Id == notificationId).FirstOrDefault();
        }

        public void Update(Delivery delivery)
        {
            _context.Deliveries.Update(delivery);
            _context.SaveChanges();
        }

        public void UpdateNotification(Notification notification)
        {
            _context.Notifications.Update(notification);
            _context.SaveChanges();
        }
    }
}
