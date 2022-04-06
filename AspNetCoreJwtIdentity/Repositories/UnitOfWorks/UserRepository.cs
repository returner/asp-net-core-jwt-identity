using Entities;
using Entities.Models;

namespace AspNetCoreJwtIdentity.Repositories.UnitOfWorks
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IdentityContext context) : base(context)
        {

        }

        public IdentityContext IdentityContext
        {
            get { return _context as IdentityContext; }
        }

        public IEnumerable<User> GetAllUsers(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUserFromName(string name)
        {
            return IdentityContext.Users.OrderByDescending(c => c.Username).Take(1).ToList();
        }

        public IEnumerable<User> GetUserWithNames(int pageIndex, int pageSize)
        {
            return IdentityContext.Users.Skip((pageIndex -1 ) * pageSize).Take(1).ToList();
        }
    }

}
