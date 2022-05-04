using AspNetCoreJwtIdentity.Policies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreJwtIdentity.Controllers
{
    /// <summary>
    /// Example webapi
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ApiControllerBase
    {
        public InfoController(IMediator mediator, ILogger<InfoController> logger) : base(mediator, logger)
        {

        }

        /// <summary>
        /// public api example
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("Public")]
        public string GetPublic()
        {
            return "ok public api";
        }

        /// <summary>
        /// Authorize api example
        /// </summary>
        /// <returns></returns>
        [HttpGet("Auth")]
        public string GetAuthorized()
        {
            return "ok auth api";
        }

        /// <summary>
        /// Authorize and policy exmaple
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = IdentityPolicy.User)]
        [HttpGet("Policy")]
        public string GetPolicy()
        {
            return "Ok policy api";
        }

        /// <summary>
        /// anonymous api example
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("Anonymous")]
        public ObjectResult GetAnonymous()
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type.Equals("role")))
            {
                return StatusCode(StatusCodes.Status200OK, currentUser.Claims.FirstOrDefault(c => c.Type.Equals("role"))?.Value);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Invalid User");
            }
        }

        /// <summary>
        /// get claim
        /// </summary>
        /// <returns></returns>
        [HttpGet("Claim")]
        public ObjectResult GetClaim()
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type.Equals("role")))
            {
                return StatusCode(StatusCodes.Status200OK, currentUser.Claims.FirstOrDefault(c => c.Type.Equals("role"))?.Value);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Invalid User");
            }
        }
    }
}
