using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;

namespace API.TechsysLog.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order, int UserId);
        void AddToUser(int userId, long orderNumber);
        List<Order> Get(int PageNumber, int pageQuantity);
        Order GetById(long orderId);
        List<Order> GetByUserId(int pageNumber, int pageQuantity, int userId);
        List<Order> GetOrdersToDeliver(int pageNumber, int pageQuantity);
    }
}
