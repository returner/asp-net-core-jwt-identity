using BusinessLayer.Queries;
using Entities.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedModel.Payloads.Requests.Groups;

namespace BusinessLayer.Handlers.Groups
{
    public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, IEnumerable<GetGroupsQueryDtoResponse>?>
    {
        private readonly IIdentityContext _context;
        public GetGroupsQueryHandler(IIdentityContext context) => _context = context;

        public async Task<IEnumerable<GetGroupsQueryDtoResponse>?> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var groups = await _context.Groups
                    .OrderByDescending(d => d.Id)
                    .Skip((request.getGroupsQueryDtoRequest.pageIndex - 1) * request.getGroupsQueryDtoRequest.pageSize)
                    .Take(request.getGroupsQueryDtoRequest.pageSize)
                    .AsNoTracking()
                    .ToArrayAsync();

                if (groups.Any())
                {
                    var result = groups.Select(g => new GetGroupsQueryDtoResponse
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Description = g.Description,
                        Created = g.Created,
                        Updated = g.Updated,
                    });

                    return result;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
