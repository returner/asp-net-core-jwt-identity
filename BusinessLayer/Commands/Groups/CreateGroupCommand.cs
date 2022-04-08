using MediatR;
using SharedModel.DataTransfers.Requests;
using SharedModel.DataTransfers.Responses;

namespace BusinessLayer.Commands.Groups
{
    public record CreateGroupCommand(CreateGroupDtoRequest createGroupDto) : IRequest<CreateGroupDtoResponse>;
}
