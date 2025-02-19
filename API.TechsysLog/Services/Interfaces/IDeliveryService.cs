using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;
using API.TechsysLog.Models;
using API.TechsysLog.ViewModel;

namespace API.TechsysLog.Services.Interfaces
{
    public interface IDeliveryService
    {
        void Notify(int deliveryId);
        Delivery GetById(long orderId);
        void OrderDelivered(long orderId);
        IList<Delivery> GetNotificationsNotReadFromUser(long userId);
        void NotificationsReadByUser(IList<NotificationDTO> notifications);
    }
}
