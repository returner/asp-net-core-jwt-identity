using Entities;
using Entities.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreJwtIdentity.Controllers
{
    //공부할것
    //https://docs.microsoft.com/ko-kr/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    //https://www.c-sharpcorner.com/UploadFile/b1df45/unit-of-work-in-repository-pattern/
    public class UserRepoController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserRepoController(IUserRepository userRespository)
        {
            _userRepository = userRespository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsersAsync();
        }
    }

    public interface IUserRepository
    { 
        Task<IEnumerable<User>> GetAllUsersAsync();
    }

    public class UserRepository : IUserRepository
    {
        private IIdentityContext _context;
        public UserRepository(IIdentityContext context) => _context = context;

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }
    }

}
