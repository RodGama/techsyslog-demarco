using API.TechsysLog.DataContext;
using API.TechsysLog.Domain;
using API.TechsysLog.Repositories.Interfaces;

namespace API.TechsysLog.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

        }

        public List<Order> Get(int PageNumber, int pageQuantity)
        {
            return [.. _context.Orders.Skip(PageNumber * pageQuantity).Take(pageQuantity)];
        }

        public List<Order> Get()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetUserOrders(User user, int PageNumber, int pageQuantity)
        {
            //!AINDA NÃO BUSQUEI PELO USUARIO
            return [.. _context.Orders.Skip(PageNumber * pageQuantity).Take(pageQuantity)];
        }
    }
}
