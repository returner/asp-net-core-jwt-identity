using MediatR;
using SharedModel.DataTransfers.Requests.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Queries
{
    public record GetGroupsQuery(GetGroupsQueryDtoRequest getGroupsQueryDtoRequest) : IRequest<IEnumerable<GetGroupsQueryDtoResponse>?>;
}
