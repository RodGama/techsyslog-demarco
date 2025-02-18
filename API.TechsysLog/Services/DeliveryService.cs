using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;
using API.TechsysLog.Models;
using API.TechsysLog.Repositories.Interfaces;
using API.TechsysLog.Services.Interfaces;
using API.TechsysLog.Validations;
using API.TechsysLog.ViewModel;
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.TechsysLog.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;


        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public void Add(long orderId, DateTime DateDelivery)
        {
            var delivery = new Delivery { OrderNumber = orderId };
            if (DateDelivery == DateTime.MinValue) delivery.DeliveryDate = DateDelivery;
            _deliveryRepository.Add(delivery);
        }
        public Delivery GetById(long orderId)
        {
            return _deliveryRepository.Get(orderId);
        }

        public void Notify(long orderId)
        {
            throw new NotImplementedException();
        }

        public void OrderDelivered(long orderId)
        {
            var delivery = GetById(orderId);
            if (delivery != null)
            {
                delivery.DeliveryDate = DateTime.Now;
                _deliveryRepository.Update(delivery);
            }
            else
                Add(orderId, DateTime.Now);
        }
    }
}
