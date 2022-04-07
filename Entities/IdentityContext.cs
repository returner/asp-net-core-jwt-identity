using Entities.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class IdentityContext : DbContext, IIdentityContext
    {
        public IdentityContext()
        {

        }
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        public DbSet<UserPool> UserPools { get; set; } = null!;
        public DbSet<JwtTokenConfiguration> JwtTokenConfigurations { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
