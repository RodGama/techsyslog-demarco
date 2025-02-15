using API.TechsysLog.Repositories.Interfaces;
using API.TechsysLog.Services;
using API.TechsysLog.Services.Interfaces;
using API.TechsysLog.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API.TechsysLog.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost(Name = "Auth")]
        [EndpointName("Auth")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public IActionResult Auth([FromBody] AuthViewModel authViewModel)
        {
            var result = new Result();
            result.Endpoint = "Auth";
            result.Success = false;
            result.Errors = new List<string>();
            var token = TokenService.GenerateToken(new Domain.User());
            return Ok(token);

            return BadRequest(result);
        }
    }
}
