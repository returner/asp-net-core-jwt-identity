using AspNetCoreJwtIdentity.Controllers.Group;
using AspNetCoreJwtIdentity.Controllers.Group.Contract.Request;
using AspNetCoreJwtIdentity.Controllers.Group.Contract.Response;
using AspNetCoreJwtIdentity_Test.Extensions;
using BusinessLayer.Commands.Groups;
using BusinessLayer.Handlers.Groups;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using SharedModel.Payloads.Requests;
using SharedModel.Payloads.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreJwtIdentity_Test.Groups
{
    public class GroupControllerTest
    {
        private readonly Mock<ILogger<GroupController>> _logger = new Mock<ILogger<GroupController>>();

        #region [HttpPost("CreateGroup")]
        [Fact]
        public async Task CreateGroupASync_Handler_Success()
        {
            // arranges
            var database = new SqliteMemoryDatabase();
            var context = database.CreateContext();

            var groupName = Guid.NewGuid().ToString();
            var dtoRequest = new CreateGroupDtoRequest(groupName, null);
            var command = new CreateGroupCommand(dtoRequest);
            var handler = new CreateGroupHandler(context);

            // acts
            var result = await handler.Handle(command, new CancellationToken());

            // asserts
            Assert.NotNull(result);
            Assert.IsType<CreateGroupDtoResponse>(result);
            Assert.Equal(dtoRequest.GroupName, result.Name);
            Assert.Equal(dtoRequest.Description, result.Description);
            Assert.True(result.Created <= DateTime.UtcNow && result.Created > DateTime.MinValue);
        }
        #endregion

        [Fact]
        public async Task CreateGroupAsync_Method_Success()
        {
            // arranges
            var database = new SqliteMemoryDatabase();
            var context = database.CreateContext();
            var mediator = new Mock<IMediator>();

            var groupNameParam = Guid.NewGuid().ToString();
            var descriptionParam = Guid.NewGuid().ToString();

            var request = new CreateGroupRequest(groupNameParam, descriptionParam);
            var dtoRequest = new CreateGroupDtoRequest(request.GroupName, request.Description);
            var command = new CreateGroupCommand(dtoRequest);
            var dtoResponse = new CreateGroupDtoResponse(0, groupNameParam, descriptionParam, DateTime.UtcNow);
            var predictResponse = new CreateGroupResponse(dtoResponse.Id, dtoResponse.Name, dtoResponse.Description, dtoResponse.Created);

            mediator.Setup(d => d.Send(command, new CancellationToken())).ReturnsAsync(dtoResponse);

            // acts
            var sut = new GroupController(mediator.Object, _logger.Object);
            var result = await sut.CreateGroupAsync(request);

            // asserts
            Assert.NotNull(result);
            Assert.True(result.IsSuccess());
            Assert.False(result.IsBadRequest());
            Assert.Equal(200, result.StatusCode());
            Assert.True(result.IsTypeOfValue<CreateGroupResponse>());
            Assert.Equal(result.Value<CreateGroupResponse>(), predictResponse);
        }
    }
}
