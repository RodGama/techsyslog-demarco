using API.TechsysLog.Domain;
using API.TechsysLog.Repositories.Interfaces;
using API.TechsysLog.Services.Interfaces;
using API.TechsysLog.Validations;
using API.TechsysLog.ViewModel;
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.TechsysLog.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserViewModel> _userValidation;


        public UserService(IUserRepository userRepository, IValidator<UserViewModel> userValidation)
        {
            _userRepository = userRepository;
            _userValidation = userValidation;
        }
        public void Add(UserViewModel userViewModel)
        {
            var user = new User(userViewModel.Name,userViewModel.Email,userViewModel.Password,userViewModel.Role); 

            _userRepository.Add(user);
        }

        public List<User> Get()
        {
            throw new NotImplementedException();
        }

        public bool UserCreationIsValid(UserViewModel userViewModel, Result result)
        {

            var resultValidation = _userValidation.Validate(userViewModel);
            if (!resultValidation.IsValid)
            {
                foreach (var error in resultValidation.Errors)
                {
                    result.Errors.Add(error.ErrorMessage);
                }

                return false;
            }
            return true;
        }
    }
}
