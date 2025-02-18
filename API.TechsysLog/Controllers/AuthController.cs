using API.TechsysLog.Models;
using API.TechsysLog.Repositories.Interfaces;
using API.TechsysLog.Services;
using API.TechsysLog.Services.Interfaces;
using API.TechsysLog.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API.TechsysLog.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Auth")]
        [EndpointName("Auth")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AuthResult))]
        public IActionResult Auth([FromBody] AuthViewModel authViewModel)
        {
            var authResult = new AuthResult();
            try
            {
                authResult = _userService.AuthUser(authViewModel);

                if (authResult.IsValid)
                {
                    var token = TokenService.GenerateToken(authResult.User);
                    authResult.User = null;
                    authResult.Token = token;
                    return Ok(authResult);
                }
                else
                {
                    return BadRequest(authResult);
                }

            }
            catch
            {
                return BadRequest(authResult);
            }

        }
    }
}
