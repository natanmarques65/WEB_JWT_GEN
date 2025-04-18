using api_auth.Models;
using api_auth.Service;
using Microsoft.AspNetCore.Mvc;

namespace api_auth.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AuthService _authService;

        public AuthController(UserService userService, AuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("autenticacao")]
        public async Task<ActionResult<Auth>> Autenticate([FromBody] User user)
        {
            var userUnauthenticated = await _userService.GetUser(user);
            if (userUnauthenticated == null)
            {
                return Unauthorized();
            }

            var token = _authService.GenerateToken(userUnauthenticated);
            var auth = new Auth()
            {
                User = userUnauthenticated,
                Token = token,
                RefreshToken = ""
            };


            return Ok(auth);
        }





    }
}
