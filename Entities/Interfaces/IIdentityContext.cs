using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.Interfaces
{
    public interface IIdentityContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();

        DbSet<User> Users { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<UserPool> UserPools { get; set; }
        DbSet<JwtTokenConfiguration> JwtTokenConfigurations { get; set; }
    }
}
