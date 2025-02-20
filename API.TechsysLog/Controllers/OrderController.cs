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
        private readonly IDeliveryService _deliveryService;
        public OrderController(IOrderService orderService, IDeliveryService deliveryService, ILogger<OrderController> logger, IMapper mapper)
        {
            _orderService = orderService;
            _deliveryService = deliveryService;
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
            {
                return BadRequest(result);
            }
                
        }


        [Authorize]
        [HttpPut("AddOrderToUser")]
        [EndpointName("AddOrderToUser")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public async Task<IActionResult> AddOrderToUser(long OrderNumber)
        {
            _logger.Log(LogLevel.Trace, "Start");
            var result = new Result();
            result.Endpoint = "AddOrderToUser";
            result.Success = false;
            result.Errors = new List<string>();


            var tokenResult = new TokenResult();
            if (Request.Headers.TryGetValue("Authorization", out StringValues authHeader))
            {
                var token = authHeader.ToString().Replace("Bearer ", string.Empty);
                tokenResult = TokenService.DecryptToken(token);
            }

            if (_orderService.GetById(OrderNumber) != null)
            {
                try
                {
                    _orderService.AddToUser(OrderNumber, tokenResult.UserId);
                    result.Success = true;
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
                result.Errors.Add("Não foi possível realizar essa operação");
                return BadRequest(result);
            }
           
        }

        [Authorize]
        [HttpGet("GetOrdersToDeliver")]
        [EndpointName("GetOrdersToDeliver")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public IActionResult GetOrdersToDeliver(int PageNumber, int PageQuantity)
        {
            _logger.Log(LogLevel.Trace, "Start");
            var result = new Result();
            result.Endpoint = "GetOrdersToDeliver";
            result.Success = false;
            result.Errors = new List<string>();

            try
            {
                var orders = _orderService.GetOrdersToDeliver(PageNumber, PageQuantity);

                List<OrderDTO> ordersDTOs = _mapper.Map<List<Order>, List<OrderDTO>>(orders);

                return Ok(ordersDTOs);
            }
            catch
            {
                result.Errors.Add("Não foi possível realizar essa operação");
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
                result.Errors.Add("Não foi possível realizar essa operação");
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
            result.Endpoint = "GetAllFromUser";
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
                result.Errors.Add("Não foi possível realizar essa operação");
                return BadRequest(result);
            }
        }

        [Authorize]
        [HttpGet("DeliverOrder")]
        [EndpointName("DeliverOrder")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public IActionResult DeliverOrder(long OrderId)
        {
            _logger.Log(LogLevel.Trace, "Start");
            var result = new Result();
            result.Endpoint = "DeliverOrder";
            result.Success = false;
            result.Errors = new List<string>();

            try
            {
                _deliveryService.OrderDelivered(OrderId);

                var delivery = _deliveryService.GetById(OrderId);
                var order = _orderService.GetById(OrderId);
                order.Delivery = delivery;
                _orderService.Update(order);
                _deliveryService.Notify(delivery.Id);
                result.Success = true;
                return Ok(result);
            }
            catch
            {
                result.Errors.Add("Não foi possível realizar essa operação");
                return BadRequest(result);
            }
        }

        [Authorize]
        [HttpGet("GetNotificationsNotReadFromUser")]
        [EndpointName("GetNotificationsNotReadFromUser")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public IActionResult GetNotificationsNotReadFromUser()
        {
            _logger.Log(LogLevel.Trace, "Start");
            var result = new Result();
            result.Endpoint = "GetNotificationsNotReadFromUser";
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
                var deliveries = _deliveryService.GetNotificationsNotReadFromUser(tokenResult.UserId);

                IList<NotificationDTO> notificationsDTO = _mapper.Map<IList<Delivery>, IList<NotificationDTO>>(deliveries);

                return Ok(notificationsDTO);
            }
            catch
            {
                result.Errors.Add("Não foi possível realizar essa operação");
                return BadRequest(result);
            }
        }

        [Authorize]
        [HttpPost("NotificationsReadByUser")]
        [EndpointName("NotificationsReadByUser")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public IActionResult NotificationsReadByUser(IList<NotificationDTO> Notifications)
        {
            _logger.Log(LogLevel.Trace, "Start");
            var result = new Result();
            result.Endpoint = "NotificationsReadByUser";
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
                _deliveryService.NotificationsReadByUser(Notifications);

                return Ok(result);
            }
            catch
            {
                result.Errors.Add("Não foi possível realizar essa operação");
                return BadRequest(result);
            }
        }
    }
}
