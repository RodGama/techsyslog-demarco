using API.TechsysLog.DataContext;
using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;
using API.TechsysLog.Repositories.Interfaces;
using API.TechsysLog.ViewModel;
using System.Text;

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

        public List<User> Get(int PageNumber, int pageQuantity)
        {
            return [.. _context.Users
                        .Skip(PageNumber * pageQuantity)
                        .Take(pageQuantity)
                        ];
        }

        public User GetById(int userId)
        {
          return _context.Users.Where(x => x.Id == userId).FirstOrDefault();
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _context.Users.Where(x=>x.Email==email).FirstOrDefault();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
