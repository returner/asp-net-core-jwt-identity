using BusinessLayer.Commands.Users;
using Entities.Interfaces;
using Entities.Models;
using MediatR;
using SharedModel.DataTransfers.Responses;

namespace BusinessLayer.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDtoResponse>
    {
        private readonly IIdentityContext _context;
        public CreateUserHandler(IIdentityContext context) => _context = context;

        public async Task<UserDtoResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User
                {
                    Username = request.userDtoRequest.Username,
                    Password = request.userDtoRequest.Password,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.MinValue,
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return new UserDtoResponse(user.Id, user.Username);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
