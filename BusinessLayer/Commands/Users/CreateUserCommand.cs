using MediatR;
using SharedModel.DataTransfers;
using SharedModel.DataTransfers.Responses;

namespace BusinessLayer.Commands.Users
{
    public record CreateUserCommand(UserDtoRequest userDtoRequest) : IRequest<UserDtoResponse>;
}
