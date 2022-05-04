using AspNetCoreJwtIdentity.Constants;
using AspNetCoreJwtIdentity.Controllers.Group.Contract.Request;
using AspNetCoreJwtIdentity.Controllers.Group.Contract.Response;
using AspNetCoreJwtIdentity.Extensions;
using AspNetCoreJwtIdentity.Helpers;
using BusinessLayer.Commands.Groups;
using BusinessLayer.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModel.Payloads.Requests;
using SharedModel.Payloads.Requests.Groups;
using Swashbuckle.AspNetCore.Annotations;

namespace AspNetCoreJwtIdentity.Controllers.Group
{
    [Authorize(Policy = AuthorizePolicy.Administrators)]
    public class GroupController : ApiControllerBase
    {
        public GroupController(IMediator mediator, ILogger<GroupController> logger) : base(mediator, logger)
        {
        }

        [HttpPost("CreateGroup")]
        [SwaggerResponse(200, HttpStatusCodeDescription.Ok, typeof(CreateGroupResponse))]
        public async Task<IActionResult> CreateGroupAsync(CreateGroupRequest createGroupRequest)
        {
            try
            {
                var createdGroup = await CommandAsync(new CreateGroupCommand(new CreateGroupDtoRequest(createGroupRequest.GroupName, createGroupRequest.Description)));

                return new CreateGroupResponse(createdGroup.Id, createdGroup.Name, createdGroup.Description, createdGroup.Created).Ok();
            }
            catch (Exception ex)
            {
                return ex.BadRequest(_logger);
            }
        }

        [HttpGet("Groups/{pageIndex:int:min(1)}/{pageSize:int:range(5,20)}")]
        [SwaggerResponse(200, HttpStatusCodeDescription.Ok, typeof(IEnumerable<GetGroupResponse>))]
        public async Task<IActionResult> GetAllGroupsAsync(int pageIndex, int pageSize)
        {
            try
            {
                var groups = await QueryAsync(new GetGroupsQuery(new GetGroupsQueryDtoRequest(pageIndex, pageSize)));

                if (groups is null)
                {
                    return ApiResultHelper.Success(new List<GetGroupResponse>());
                }

                return groups.Select(d => new GetGroupResponse
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    Created = d.Created,
                    Updated = d.Updated,
                }).Ok();
            }
            catch (Exception ex)
            {
                return ex.BadRequest(_logger);
            }
        }
    }
}
