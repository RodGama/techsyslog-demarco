using API.TechsysLog.Domain;
using API.TechsysLog.Models;
using API.TechsysLog.ViewModel;

namespace API.TechsysLog.Services.Interfaces
{
    public interface IUserService
    {
        bool UserCreationIsValid(UserViewModel userViewModel, Result result);
        void Add(UserViewModel userViewModel);
        List<User> Get(int PageNumber, int PageQuantity);
        AuthResult AuthUser(AuthViewModel authViewModel);
    }
}
