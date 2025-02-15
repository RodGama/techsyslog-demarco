using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;
using API.TechsysLog.Repositories.Interfaces;
using API.TechsysLog.Services.Interfaces;
using API.TechsysLog.Validations;
using API.TechsysLog.ViewModel;
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.TechsysLog.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IValidator<OrderViewModel> _orderValidation;


        public OrderService(IOrderRepository orderRepository, IValidator<OrderViewModel> orderValidation)
        {
            _orderRepository = orderRepository;
            _orderValidation = orderValidation;
        }
        public void Add(OrderViewModel orderViewModel)
        {
            var address = orderViewModel.Address + " " + orderViewModel.AddressNumber + " " + orderViewModel.Neighborhood + " " + orderViewModel.City + " " + orderViewModel.State;
            var order = new Order(orderViewModel.Description, orderViewModel.OrderNumber, orderViewModel.Price, address, orderViewModel.CEP);

            _orderRepository.Add(order);
        }

        public List<Order> Get(int PageNumber, int pageQuantity)
        {
            return _orderRepository.Get(PageNumber, pageQuantity);
        }

        public async Task<bool> OrderCreationIsValid(OrderViewModel orderViewModel, Result result)
        {
            var resultValidation = await _orderValidation.ValidateAsync(orderViewModel);
            if (!resultValidation.IsValid)
            {
                foreach (var error in resultValidation.Errors)
                {
                    result.Errors.Add(error.ErrorMessage);
                }

                return false;
            }
            return true;
        }

    }
}
