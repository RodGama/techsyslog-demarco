using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;

namespace API.TechsysLog.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User> Get(int PageNumber, int pageQuantity);
    }
}
