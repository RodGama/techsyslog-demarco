﻿using API.TechsysLog.Domain;
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
            delivery.DeliveryDate = DateDelivery;
            _deliveryRepository.Add(delivery);
        }
        public Delivery GetById(long orderId)
        {
            return _deliveryRepository.Get(orderId);
        }

        public IList<Delivery> GetNotificationsNotReadFromUser(long userId)
        {
            var deliveries = _deliveryRepository.GetDeliveriesFromUser(userId);
            return deliveries = deliveries.Where(x => x.Notification != null && x.Notification.ReadDate == DateTime.MinValue).ToList();
        }

        public void Notify(int deliveryId)
        {
            var notification = new Notification(deliveryId,DateTime.Now);
            _deliveryRepository.AddNotification(notification);
        }

        public void OrderDelivered(long orderId)
        {
            Add(orderId, DateTime.Now);
        }
    }
}
