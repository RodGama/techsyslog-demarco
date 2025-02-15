using API.TechsysLog.Domain;
using API.TechsysLog.DTOs;
using API.TechsysLog.Repositories.Interfaces;
using API.TechsysLog.Services.Interfaces;
using API.TechsysLog.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.TechsysLog.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, ILogger<UserController> logger,IMapper mapper)
        {
            _userService = userService;
            _logger = logger;
            _mapper = mapper;
        }


        [Authorize]
        [HttpPut("Add")]
        [EndpointName("AddUser")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public IActionResult Add(UserViewModel userViewModel)
        {
            _logger.Log(LogLevel.Trace, "Start");

            var result = new Result();
            result.Endpoint = "AdicionarUsuario";
            result.Success = false;
            result.Errors = new List<string>();

            if (_userService.UserCreationIsValid(userViewModel, result))
            {
                try
                {
                    _userService.Add(userViewModel);
                    return Ok(result);
                }
                catch (Exception ex) 
                {
                    throw ex;
                    //return BadRequest("Não foi possível realizar o cadastro");
                }
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Authorize]
        [HttpGet("GetAll")]
        [EndpointName("GetAll")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public IActionResult GetAll(int PageNumber, int PageQuantity)
        {
            _logger.Log(LogLevel.Trace, "Start");

            var result = new Result();
            result.Endpoint = "ListaUsuarios";
            result.Success = false;
            result.Errors = new List<string>();
            try
            {
                var users = _userService.Get(PageNumber, PageQuantity);
                List<UserDTO> usersDTO = _mapper.Map<List<User>, List<UserDTO>>(users);

                return Ok(usersDTO);
            }
            catch(Exception ex) { throw ex; }
        }
    }
}
