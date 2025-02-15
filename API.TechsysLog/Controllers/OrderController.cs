using API.TechsysLog.Repositories.Interfaces;
using API.TechsysLog.Services.Interfaces;
using API.TechsysLog.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.TechsysLog.Controllers
{
    [ApiController]
    [Route("api/v1/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }


        [Authorize]
        [HttpPut(Name = "AdicionarPedido")]
        [EndpointName("AdicionarPedido")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public IActionResult Add(OrderViewModel orderViewModel)
        {
            _logger.Log(LogLevel.Trace,"Start");
            var result = new Result();
            result.Endpoint = "AdicionarPedido";
            result.Success = false;
            result.Errors = new List<string>();

            if (_orderService.OrderCreationIsValid(orderViewModel, result))
            {
                try
                {
                    _orderService.Add(orderViewModel);
                    return Ok(result);
                }
                catch (Exception ex) 
                {
                    return BadRequest("Não foi possível realizar o cadastro");
                }
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
