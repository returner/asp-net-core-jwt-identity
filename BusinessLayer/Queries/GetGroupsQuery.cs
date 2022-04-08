using MediatR;
using SharedModel.DataTransfers.Requests.Groups;

namespace BusinessLayer.Queries
{
    public record GetGroupsQuery(GetGroupsQueryDtoRequest getGroupsQueryDtoRequest) : IRequest<IEnumerable<GetGroupsQueryDtoResponse>?>;
}
