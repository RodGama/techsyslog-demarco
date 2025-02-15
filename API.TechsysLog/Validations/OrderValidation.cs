using API.TechsysLog.DTOs;
using API.TechsysLog.ViewModel;
using FluentValidation;

namespace API.TechsysLog.Validations
{
    public class OrderValidation : AbstractValidator<OrderViewModel>
    {
        public OrderValidation() 
        {
            RuleLevelCascadeMode = CascadeMode.Continue;
            RuleFor(x => x.Description).NotEmpty().WithMessage("Descrição inválida");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Nome com mais de 20 caracteres");
        }
    }
}
