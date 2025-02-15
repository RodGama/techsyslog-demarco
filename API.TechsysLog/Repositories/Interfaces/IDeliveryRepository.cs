using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;

namespace API.TechsysLog.Repositories.Interfaces
{
    public interface IDeliveryRepository
    {
        void Add(Delivery delivery);
        Delivery Get(int id);
    }
}
