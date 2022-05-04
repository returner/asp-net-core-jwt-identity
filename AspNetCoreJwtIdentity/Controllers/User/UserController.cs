using AspNetCoreJwtIdentity.Constants;
using AspNetCoreJwtIdentity.Helpers;
using AspNetCoreJwtIdentity.Middlewares;
using BusinessLayer.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModel.Contract.Request;
using SharedModel.Contract.Response;
using SharedModel.Contracts.Response;
using SharedModel.Payloads;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Net.Mime;

namespace AspNetCoreJwtIdentity.Controllers
{
    //[Authorize(Policy = AuthorizePolicy.Administrators, Roles = AuthorizeRole.Users)]
    [Authorize]
    public class UserController : ApiControllerBase
    {
        public UserController(IMediator mediator, ILogger<UserController> logger) : base(mediator, logger)
        {
        }

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
                //return ApiErrorResponse(ApiError.Exception, ex.Message);
                return ApiResultHelper.Exception(_logger, ex);
            }

        }
    }
}
