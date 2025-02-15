using API.TechsysLog.DataContext;
using API.TechsysLog.Domain;
using API.TechsysLog.Repositories.Interfaces;

namespace API.TechsysLog.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

        }

        public List<User> Get()
        {
            return [.. _context.Users];
        }
    }
}
