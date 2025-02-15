using API.TechsysLog.Domain;
using API.TechsysLog.ViewModel;

namespace API.TechsysLog.Services.Interfaces
{
    public interface IOrderService
    {
        bool OrderCreationIsValid(OrderViewModel orderViewModel, Result result);
        void Add(OrderViewModel orderViewModel);
        List<Order> Get(int PageNumber, int pageQuantity);
    }
}
