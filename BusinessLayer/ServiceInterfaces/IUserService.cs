using Entities.Models;
using SharedModel.DataTransfers;
using SharedModel.DataTransfers.Responses;
using SharedModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers(UserRequest request);
        Task<UserDtoResponse> CreateUserAsync(UserDtoRequest userDtoRequest);
    }
}
