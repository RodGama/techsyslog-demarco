using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;
using API.TechsysLog.Models;
using API.TechsysLog.ViewModel;

namespace API.TechsysLog.Services.Interfaces
{
    public interface IOrderService
    {
        Task<bool> OrderCreationIsValid(OrderViewModel orderViewModel, Result result);
        void Add(OrderViewModel orderViewModel, int UserId);
        List<Order> Get(int PageNumber, int pageQuantity);
        List<Order> GetByUserId(int PageNumber, int pageQuantity, int UserId);

    }
}
