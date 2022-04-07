using BusinessLayer.ServiceInterfaces;
using Entities.Interfaces;
using Entities.Models;
using SharedModel.DataTransfers;
using SharedModel.DataTransfers.Responses;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IIdentityContext _context;
        public UserService(IIdentityContext context) => _context = context;

        public async Task<UserDtoResponse> CreateUserAsync(UserDtoRequest request)
        {
            try
            {
                var user = new User
                {
                    Username = request.Username,
                    Password = request.Password,
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

        public Task<IEnumerable<User>> GetAllUsers(UserDtoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
