using MediatR;
using SharedModel.DataTransfers;
using SharedModel.DataTransfers.Responses;
using SharedModel.Request;
using SharedModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Commands
{
    public record CreateUserCommand(UserDtoRequest userDtoRequest) : IRequest<UserDtoResponse>;
}
