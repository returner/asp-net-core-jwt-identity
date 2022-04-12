using MediatR;
using SharedModel.Payloads.Requests.Groups;

namespace BusinessLayer.Queries
{
    public record GetGroupsQuery(GetGroupsQueryDtoRequest getGroupsQueryDtoRequest) : IRequest<IEnumerable<GetGroupsQueryDtoResponse>?>;
}
