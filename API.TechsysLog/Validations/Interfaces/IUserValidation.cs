using API.TechsysLog.Domain;
using API.TechsysLog.ViewModel;

namespace API.TechsysLog.Validations.Interfaces
{
    public interface IUserValidation
    {
        bool Validate(UserViewModel userViewModel);
    }
}
