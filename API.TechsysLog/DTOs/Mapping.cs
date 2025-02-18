using API.TechsysLog.Domain;
using AutoMapper;

namespace API.TechsysLog.DTOs
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<User, UserDTO>();
            CreateMap<Order, OrderDTO>().ForMember(dest => dest.DeliveryDate, m => m.MapFrom(orig => orig.Delivery.DeliveryDate));

        }
    }
}
