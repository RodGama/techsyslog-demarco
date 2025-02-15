using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;
using API.TechsysLog.Models;
using API.TechsysLog.Repositories.Interfaces;
using API.TechsysLog.Services;
using API.TechsysLog.Services.Interfaces;
using API.TechsysLog.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace API.TechsysLog.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;
        
        public OrderController(IOrderService orderService, ILogger<OrderController> logger, IMapper mapper)
        {
            _orderService = orderService;
            _logger = logger;
            _mapper = mapper;
        }


        [Authorize]
        [HttpPut("Add")]
        [EndpointName("AddOrder")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public async Task<IActionResult> Add(OrderViewModel orderViewModel)
        {
            _logger.Log(LogLevel.Trace,"Start");
            var result = new Result();
            result.Endpoint = "AdicionarPedido";
            result.Success = false;
            result.Errors = new List<string>();


            var tokenResult = new TokenResult();
            if (Request.Headers.TryGetValue("Authorization", out StringValues authHeader))
            {
                var token = authHeader.ToString().Replace("Bearer ", string.Empty);
                tokenResult= TokenService.DecryptToken(token);
            }
            
            if (await _orderService.OrderCreationIsValid(orderViewModel, result))
            {
                try
                {
                    _orderService.Add(orderViewModel,tokenResult.UserId);
                    result.Success = true;
                    return Ok(result);
                }
                catch (Exception ex) 
                {
                     return BadRequest("Não foi possível realizar o cadastro");
                }
            }
            else
                return BadRequest(result);
        }

        [Authorize]
        [HttpGet("GetAll")]
        [EndpointName("GetAllOrders")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public IActionResult GetAll(int PageNumber, int PageQuantity)
        {
            _logger.Log(LogLevel.Trace, "Start");
            var result = new Result();
            result.Endpoint = "ListarPedidos";
            result.Success = false;
            result.Errors = new List<string>();

            try
            {
                var orders = _orderService.Get(PageNumber, PageQuantity);

                List<OrderDTO> ordersDTOs = _mapper.Map<List<Order>, List<OrderDTO>>(orders);

                return Ok(ordersDTOs);
            }
            catch
            {
                return BadRequest(result);
            }
           
        }

        [Authorize]
        [HttpGet("GetById/{OrderId}")]
        [EndpointName("GetOrderById")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public IActionResult GetById(long OrderId)
        {
            _logger.Log(LogLevel.Trace, "Start");
            var result = new Result();
            result.Endpoint = "BuscarPorId";
            result.Success = false;
            result.Errors = new List<string>();

            try
            {
                var orders = _orderService.GetById(OrderId);

                var ordersDTOs = _mapper.Map<OrderDTO>(orders);

                return Ok(ordersDTOs);
            }
            catch
            {
                return BadRequest(result);
            }
        }

        [Authorize]
        [HttpGet("GetAllFromUser")]
        [EndpointName("GetAllFromUser")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public IActionResult GetAllFromUser(int PageNumber, int PageQuantity)
        {
            _logger.Log(LogLevel.Trace, "Start");
            var result = new Result();
            result.Endpoint = "BuscarPorId";
            result.Success = false;
            result.Errors = new List<string>();

            var tokenResult = new TokenResult();
            if (Request.Headers.TryGetValue("Authorization", out StringValues authHeader))
            {
                var token = authHeader.ToString().Replace("Bearer ", string.Empty);
                tokenResult = TokenService.DecryptToken(token);
            }

            try
            {
                var orders = _orderService.GetByUserId(PageNumber, PageQuantity, tokenResult.UserId);

                List<OrderDTO> ordersDTOs = _mapper.Map<List<Order>, List<OrderDTO>>(orders);

                return Ok(ordersDTOs);
            }
            catch
            {
                return BadRequest(result);
            }
        }

    }
}
