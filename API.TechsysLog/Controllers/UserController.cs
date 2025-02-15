﻿using API.TechsysLog.Repositories.Interfaces;
using API.TechsysLog.Services.Interfaces;
using API.TechsysLog.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.TechsysLog.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }


        [Authorize]
        [HttpPut(Name = "AdicionarUsuario")]
        [EndpointName("AdicionarUsuario")]
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
    }
}
