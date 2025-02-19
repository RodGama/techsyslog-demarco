using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;

namespace API.TechsysLog.Repositories.Interfaces
{
    public interface IDeliveryRepository
    {
        void Add(Delivery Delivery);
        void AddNotification(Notification notification);
        Delivery Get(long OrderId);
        IList<Delivery> GetDeliveriesFromUser(long userId);
        Notification GetNotification(int notificationId);
        void Update(Delivery delivery);
        void UpdateNotification(Notification notification);
    }
}
