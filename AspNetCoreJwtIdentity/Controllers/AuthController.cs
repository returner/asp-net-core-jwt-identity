using Entities.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspNetCoreJwtIdentity.Controllers
{
    //https://aspdotnet.tistory.com/2799 - refresh token
    //https://curity.io/resources/learn/jwt-best-practices/
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IIdentityContext _context;

        public AuthController(IIdentityContext identityContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = identityContext;
        }

        [HttpPost]
        public IActionResult Signin([FromBody] User loginUser)
        {
            IActionResult response = Unauthorized();

            var user = AuthenticateUser(loginUser);
            if (user != null)
            {
                var tokenString = GenerateJwtToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }

            return response;
        }

        private User? AuthenticateUser(User loginCredentials)
        {
            var user = _context.Users
                .Where(d => d.Username.Equals(loginCredentials.Username) && d.Password.Equals(loginCredentials.Password))
                .SingleOrDefault();

            return user;
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                //new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            if (user.Role != null)
            {
                claims.Append(new Claim(ClaimTypes.Role, user.Role.Name));
            }

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials : credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
               
        }
    }
}
