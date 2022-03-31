using AspNetCoreJwtIdentity.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreJwtIdentity.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("Public")]
        public string GetPublic()
        {
            return "ok public api";
        }

        [HttpGet("Auth")]
        public string GetAuthorized()
        {
            return "ok auth api";
        }

        [Authorize(Policy = Policies.User)]
        [HttpGet("Policy")]
        public string GetPolicy()
        {
            return "Ok policy api";
        }

        [AllowAnonymous]
        [HttpGet("Anonymous")]
        public ObjectResult GetAnonymous()
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type.Equals("role")))
            {
                return StatusCode(StatusCodes.Status200OK, currentUser.Claims.FirstOrDefault(c => c.Type.Equals("role")).Value);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Invalid User");
            }
        }

        [HttpGet("Claim")]
        public ObjectResult GetClaim()
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type.Equals("role")))
            {
                return StatusCode(StatusCodes.Status200OK, currentUser.Claims.FirstOrDefault(c => c.Type.Equals("role")).Value);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Invalid User");
            }
        }
    }
}
