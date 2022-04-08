using MediatR;
using SharedModel.DataTransfers;
using SharedModel.DataTransfers.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Commands.Users
{
    public record CreateUserCommand(UserDtoRequest userDtoRequest) : IRequest<UserDtoResponse>;
}
