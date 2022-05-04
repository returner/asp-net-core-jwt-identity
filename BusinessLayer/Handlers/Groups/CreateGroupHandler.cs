using BusinessLayer.Commands.Groups;
using Entities.Interfaces;
using Entities.Models;
using MediatR;
using SharedModel.Payloads.Responses;

namespace BusinessLayer.Handlers.Groups
{
    public class CreateGroupHandler : IRequestHandler<CreateGroupCommand, CreateGroupDtoResponse>
    {
        private readonly IIdentityContext _context;
        public CreateGroupHandler(IIdentityContext context) => _context = context;

        public async Task<CreateGroupDtoResponse> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var group = new Group
                {
                    Name = request.createGroupDto.GroupName,
                    Description = request.createGroupDto.Description,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.MinValue,
                };
                await _context.Groups.AddAsync(group, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new CreateGroupDtoResponse(group.Id, group.Name, group.Description, group.Created);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
