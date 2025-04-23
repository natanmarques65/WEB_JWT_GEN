using api_auth.Models;
using api_auth.Environment;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace api_auth.Service
{
    public class AuthService
    {
        private readonly UserService _userService;
        public AuthService(UserService userService)
        {
            _userService = userService;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(JwtSettings.JwtSecret);

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserId.ToString()) };
            claims.AddRange(user.UserRolesList.Select(r => new Claim("roles", r.UserRoleDescription)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(JwtSettings.JwtSecret);

            var userId =  _userService.GetUserByIdentification(user.UserIdentification);

            var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.Sub, user.UserIdentification) };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = JwtSettings.JwtRefreshTokenIssuer,
                Audience = JwtSettings.JwtRefreshTokenAudiance,
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateToken(Token token)
        {
            var handler = new JwtSecurityTokenHandler();
            var result = handler.ValidateToken(token.RefreshToken, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSettings.JwtSecret)),
                ValidIssuer = JwtSettings.JwtRefreshTokenIssuer,
                ValidAudience = JwtSettings.JwtRefreshTokenAudiance
            }, out SecurityToken validatedToken);


            return result.Claims != null;
        }


    }
}
