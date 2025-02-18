using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;
using API.TechsysLog.ViewModel;

namespace API.TechsysLog.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User> Get(int PageNumber, int pageQuantity);
        User GetById(int userId);
        User GetUserByEmailAndPassword(string email, string password);
        void Update(User user);
    }
}
