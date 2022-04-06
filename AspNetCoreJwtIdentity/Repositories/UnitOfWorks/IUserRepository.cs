using Entities.Models;

namespace AspNetCoreJwtIdentity.Repositories.UnitOfWorks
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAllUsers(int id);
        IEnumerable<User> GetUserWithNames(int pageIndex, int pageSize);
    }

}
