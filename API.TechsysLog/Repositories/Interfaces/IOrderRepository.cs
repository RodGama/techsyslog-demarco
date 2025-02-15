using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;

namespace API.TechsysLog.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order, int UserId);
        List<Order> Get(int PageNumber, int pageQuantity);
        List<Order> GetByUserId(int pageNumber, int pageQuantity, int userId);
    }
}
