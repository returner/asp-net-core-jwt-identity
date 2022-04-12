using MediatR;
using SharedModel.Payloads;
using SharedModel.Payloads.Responses;

namespace BusinessLayer.Commands.Users
{
    public record CreateUserCommand(UserDtoRequest userDtoRequest) : IRequest<UserDtoResponse>;
}
