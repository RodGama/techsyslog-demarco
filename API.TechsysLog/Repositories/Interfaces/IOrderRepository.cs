using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;

namespace API.TechsysLog.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order);
        List<Order> GetUserOrders(User user, int PageNumber, int pageQuantity);
        List<Order> Get(int PageNumber, int pageQuantity);

    }
}
