using API.TechsysLog.Repositories.Interfaces;
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

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [Authorize]
        [HttpPut(Name = "AdicionarUsuario")]
        [EndpointName("AdicionarUsuario")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public IActionResult Add(UserViewModel userViewModel)
        {
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
