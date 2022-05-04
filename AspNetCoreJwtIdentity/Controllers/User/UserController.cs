using AspNetCoreJwtIdentity.Constants;
using AspNetCoreJwtIdentity.Helpers;
using BusinessLayer.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModel.Contract.Request;
using SharedModel.Contract.Response;
using SharedModel.Payloads;
using Swashbuckle.AspNetCore.Annotations;

namespace AspNetCoreJwtIdentity.Controllers
{
    /// <summary>
    /// CRUD individual user
    /// </summary>
    //[Authorize(Policy = AuthorizePolicy.Administrators, Roles = AuthorizeRole.Users)]
    [Authorize]
    public class UserController : ApiControllerBase
    {
        public UserController(IMediator mediator, ILogger<UserController> logger) : base(mediator, logger)
        {
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(200, HttpStatusCodeDescription.Ok, typeof(UserResponse))]
        public async Task<IActionResult> CreateUserAsync(UserRequest request)
        {
            try
            {
                var result = await CommandAsync(new CreateUserCommand(new UserDtoRequest(request.Username, request.Password)));
                return ApiResultHelper.Success(result);
            }
            catch (Exception ex)
            {
                return ApiResultHelper.Exception(_logger, ex);
            }

        }
    }
}
