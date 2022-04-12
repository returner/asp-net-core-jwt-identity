using MediatR;
using SharedModel.Payloads.Requests;
using SharedModel.Payloads.Responses;

namespace BusinessLayer.Commands.Groups
{
    public record CreateGroupCommand(CreateGroupDtoRequest createGroupDto) : IRequest<CreateGroupDtoResponse>;
}
