using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;

namespace API.TechsysLog.Repositories.Interfaces
{
    public interface IDeliveryRepository
    {
        void Add(Delivery Delivery);
        Delivery Get(long OrderId);
        void Update(Delivery delivery);
    }
}
