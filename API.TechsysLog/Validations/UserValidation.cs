using API.TechsysLog.DTOs;
using API.TechsysLog.ViewModel;
using FluentValidation;

namespace API.TechsysLog.Validations
{
    public class UserValidation : AbstractValidator<UserViewModel>
    {
        public UserValidation() 
        {
            RuleLevelCascadeMode = CascadeMode.Continue;
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email Inválido");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Nome com mais de 20 caracteres");
            RuleFor(x => x.Password).Equal(x => x.PasswordConfirm).WithMessage("Senhas não coincidem");
        }
    }
}
