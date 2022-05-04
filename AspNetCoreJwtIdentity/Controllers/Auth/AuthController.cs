using AspNetCoreJwtIdentity.Constants;
using AspNetCoreJwtIdentity.Controllers.Auth.Contract.Request;
using AspNetCoreJwtIdentity.Controllers.Auth.Contract.Response;
using AspNetCoreJwtIdentity.Extensions;
using Entities.Interfaces;
using Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SharedModel.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspNetCoreJwtIdentity.Controllers.Auth
{
    //https://aspdotnet.tistory.com/2799 - refresh token :: todo
    //https://curity.io/resources/learn/jwt-best-practices/
    public class AuthController : ApiControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IIdentityContext _context;

        public AuthController(IIdentityContext identityContext, IConfiguration configuration, IMediator mediator, ILogger<AuthController> logger) : base(mediator, logger)
        {
            _configuration = configuration;
            _context = identityContext;
        }

        [HttpPost("Signin")]
        [AllowAnonymous]
        [SwaggerResponse(200, HttpStatusCodeDescription.Ok, typeof(SigninUserResponse))]
        public IActionResult Signin([FromBody] SigninUserRequest signinUserRequest)
        {
            try
            {
                var user = AuthenticateUser(signinUserRequest);
                if (user is null)
                {
                    return ApiError.InvalidUsername.Unauthorized(_logger);
                }

                return new SigninUserResponse
                {
                    AccessToken = GenerateJwtToken(user),
                    TokenType = "Bearer",
                }.Ok();
            }
            catch (Exception ex)
            {
                return ex.BadRequest(_logger);
            }
        }

        private User? AuthenticateUser(SigninUserRequest signinUserRequest)
        {
            var user = _context.Users
                .Where(d => d.Username.Equals(signinUserRequest.Username) && d.Password.Equals(signinUserRequest.Password))
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

            //if (user.Role != null)
            //{
            //    claims.Append(new Claim(ClaimTypes.Role, user.Role.Name));
            //}

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
