using Entities.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreJwtIdentity.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IIdentityContext _context;
        public UserController(IIdentityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToArray();
        }
    }
}
