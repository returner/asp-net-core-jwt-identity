using AspNetCoreJwtIdentity.Constants;
using AspNetCoreJwtIdentity.Helpers;
using AspNetCoreJwtIdentity.Middlewares;
using BusinessLayer.Commands.Groups;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModel.Contracts.Request;
using SharedModel.Contracts.Response;
using SharedModel.DataTransfers.Requests;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Net.Mime;

namespace AspNetCoreJwtIdentity.Controllers
{
    [ApiController]
    [Route("controller")]
    [WebApiResultNonNull]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize(Policy = AuthorizePolicy.Administrators)]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, HttpStatusCodeDescription.BadRequest, typeof(ApiErrorResponse))]
    [SwaggerResponse((int)HttpStatusCode.Unauthorized, HttpStatusCodeDescription.Unauthorized)]
    [SwaggerResponse((int)HttpStatusCode.Forbidden, HttpStatusCodeDescription.Forbidden)]
    public class GroupController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<GroupController> _logger;
        public GroupController(ILogger<GroupController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("CreateGroup")]
        [SwaggerResponse(200, HttpStatusCodeDescription.Ok, typeof(CreateGroupResponse))]
        public async Task<IActionResult> CreateGroupAsync(CreateGroupRequest createGroupRequest)
        {
            try
            {
                var createdGroup = await _mediator.Send(new CreateGroupCommand(new CreateGroupDtoRequest(createGroupRequest.GroupName, createGroupRequest.Description)));

                return ApiResultHelper.Success(new CreateGroupResponse(createdGroup.Id, createdGroup.Name, createdGroup.Description, createdGroup.Created));
            }
            catch (Exception ex)
            {
                //return ApiErrorResponse(ApiError.Exception, ex.Message);
                return ApiResultHelper.Exception(_logger, ex);
            }
        }
    }
}
