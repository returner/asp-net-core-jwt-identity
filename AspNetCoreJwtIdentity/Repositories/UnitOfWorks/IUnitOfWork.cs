namespace AspNetCoreJwtIdentity.Repositories.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
    }

}
