using AspNetCoreJwtIdentity.Constants;
using AspNetCoreJwtIdentity.Helpers;
using AspNetCoreJwtIdentity.Middlewares;
using BusinessLayer.Commands;
using BusinessLayer.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModel.Contract.Request;
using SharedModel.Contract.Response;
using SharedModel.Contracts.Response;
using SharedModel.DataTransfers;
using SharedModel.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Net.Mime;

namespace AspNetCoreJwtIdentity.Controllers
{
    [ApiController]
    [Route("controller")]
    [WebApiResultNonNullAttribute]
    [Produces(MediaTypeNames.Application.Json)]
    //[Authorize(Policy = AuthorizePolicy.Administrators, Roles = AuthorizeRole.Users)]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, HttpStatusCodeDescription.BadRequest, typeof(ApiErrorResponse))]
    [SwaggerResponse((int)HttpStatusCode.Unauthorized, HttpStatusCodeDescription.Unauthorized)]
    [SwaggerResponse((int)HttpStatusCode.Forbidden, HttpStatusCodeDescription.Forbidden)]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(200, HttpStatusCodeDescription.Ok, typeof(UserResponse))]
        public async Task<IActionResult> CreateUserAsync(UserRequest request)
        {
            try
            {
                var result = await _mediator.Send(new CreateUserCommand(new UserDtoRequest(request.Username, request.Password)));
                return ApiResultHelper.Success(result);
            }
            catch(Exception ex)
            {
                //return ApiErrorResponse(ApiError.Exception, ex.Message);
                return ApiResultHelper.Exception(_logger, ex);
            }

        }
    }
}
