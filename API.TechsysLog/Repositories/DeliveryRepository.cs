using API.TechsysLog.DataContext;
using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;
using API.TechsysLog.Repositories.Interfaces;

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

        public Delivery Get(int id)
        {
            return _context.Deliveries.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
