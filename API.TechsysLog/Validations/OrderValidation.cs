using API.TechsysLog.DataContext;
using API.TechsysLog.DTOs;
using API.TechsysLog.ViewModel;
using FluentValidation;
using System.Data;
using System.Text.RegularExpressions;

namespace API.TechsysLog.Validations
{
    public class OrderValidation : AbstractValidator<OrderViewModel>
    {
        public OrderValidation()
        {
            RuleLevelCascadeMode = CascadeMode.Continue;
            RuleFor(x => x.Description).NotEmpty().WithMessage("Descrição inválida");
            RuleFor(x => x.CEP).NotEmpty().MustAsync(CEPIsValid).WithMessage("CEP inválido");
            RuleFor(x => x.OrderNumber).NotEmpty().Must(OrderNotExists).WithMessage("Pedido já cadastrado");
        }

        private bool OrderNotExists(long arg)
        {
            using ConnectionContext dbConnection = new ConnectionContext();
            var orderExists = dbConnection.Orders.Any(x => x.OrderNumber == arg);

            return !orderExists;
        }

        private async Task<bool> CEPIsValid(int arg, CancellationToken token)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://brasilapi.com.br/api/cep/v2/{arg}"),
            };

            using (var response = await client.SendAsync(request))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
