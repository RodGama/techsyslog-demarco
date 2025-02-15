using API.TechsysLog.Domain;

namespace API.TechsysLog.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User> Get();
    }
}
