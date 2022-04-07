using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IIdentityContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();

        DbSet<User> Users { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserPool> UserPools { get; set; }
        DbSet<JwtTokenConfiguration> JwtTokenConfigurations { get; set; }
    }
}
