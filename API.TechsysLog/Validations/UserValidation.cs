using API.TechsysLog.DataContext;
using API.TechsysLog.DTOs;
using API.TechsysLog.ViewModel;
using FluentValidation;
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace API.TechsysLog.Validations
{
    public class UserValidation : AbstractValidator<UserViewModel>
    {
        public UserValidation() 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email inválido");
            RuleFor(x => x.Email).NotEmpty().Must(NotAlreadyRegistered).WithMessage("Email já cadastrado");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Nome com mais de 20 caracteres");
            RuleFor(x => x.Password).Equal(x => x.PasswordConfirm).WithMessage("Senhas não coincidem");
        }

        private bool NotAlreadyRegistered(string arg)
        {
            using ConnectionContext dbConnection = new ConnectionContext();
            var userExists = dbConnection.Users.Any(x => x.Email == arg);
            
            return !userExists;
        }
    }
}
