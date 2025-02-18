using API.TechsysLog.DataContext;
using API.TechsysLog.ViewModel;
using FluentValidation;

namespace API.TechsysLog.Validations
{
    public class UserUpdateValidation : AbstractValidator<UserUpdateViewModel>
    {
        public UserUpdateValidation() 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.OldPassword).NotEmpty().Must(MatchOldPassword).WithMessage("Senha atual inválida");
            RuleFor(x => x.Password).Equal(x => x.PasswordConfirm).WithMessage("Senhas não coincidem");
        }

        private bool MatchOldPassword(UserUpdateViewModel userUpdateViewModel,string oldPassword)
        {
            using ConnectionContext dbConnection = new ConnectionContext();
            var user = dbConnection.Users.Where(x => x.Id == userUpdateViewModel.UserId).FirstOrDefault();
            return BCryptor.InputIsCorrect(oldPassword, user.Password);
        }

    }
}
