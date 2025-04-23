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

        [HttpPost("auth")]
        public async Task<ActionResult<Auth>> Autenticate([FromBody] User user)
        {
            var userUnauthenticated =  _userService.GetUser(user);
            if (userUnauthenticated == null)
            {
                return Unauthorized();
            }

            var auth = new Auth()
            {
                User = userUnauthenticated,
                Token = new Token()
                {
                    AccessToken = _authService.GenerateToken(userUnauthenticated),
                    RefreshToken = _authService.GenerateRefreshToken(userUnauthenticated)
                }
            };

            return Ok(auth);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<Auth>> RefreshToken([FromBody] Auth auth)
        {
            var authencathedUser = _userService.GetUserByIdentification(auth.User.UserIdentification);
            if(authencathedUser == null)
            {
                return Unauthorized("User not found");
            }

            if (auth.Token.AccessToken == null || auth.Token.RefreshToken == null)
            {
                return BadRequest("Invalid Token");
            }

            var result =  _authService.ValidateToken(auth.Token);
            if (!result)
            {
                return Unauthorized("Token Expired");
            }

            var newAuth = new Auth()
            {
                User = auth.User,
                Token = new Token()
                {
                    AccessToken = _authService.GenerateToken(auth.User),
                    RefreshToken = _authService.GenerateRefreshToken(auth.User)
                }
            };

            return Ok(auth);
        }
    }
}
