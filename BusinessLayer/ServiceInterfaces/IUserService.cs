using Entities.Models;
using SharedModel.DataTransfers;
using SharedModel.DataTransfers.Responses;

namespace BusinessLayer.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers(UserDtoRequest request);
        Task<UserDtoResponse> CreateUserAsync(UserDtoRequest userDtoRequest);
    }
}
