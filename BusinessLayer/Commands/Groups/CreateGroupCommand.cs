using MediatR;
using SharedModel.DataTransfers.Requests;
using SharedModel.DataTransfers.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Commands.Groups
{
    public record CreateGroupCommand(CreateGroupDtoRequest createGroupDto) : IRequest<CreateGroupDtoResponse>;
}
