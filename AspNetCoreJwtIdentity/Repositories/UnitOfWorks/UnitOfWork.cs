using Entities;

namespace AspNetCoreJwtIdentity.Repositories.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityContext _context;
        public UnitOfWork(IdentityContext context)
        {
            _context = context;
            //Users = new UserRepository(_context);
        }
        public IUserRepository Users => new UserRepository(_context);

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
