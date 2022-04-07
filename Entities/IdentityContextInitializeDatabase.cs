using Entities.Interfaces;
using Entities.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class IdentityContextInitializeDatabase
    {
        public static async Task InitDatabaseAsync(IdentityContext context)
        {
            await ExecuteDatabaseAsync(context);
        }

        private static async Task ExecuteDatabaseAsync(IdentityContext context)
        {
            //using var context = scopedServiceProvider.GetRequiredService<IdentityContext>();
            context.Database.EnsureCreated();
            await BuildInitDataAsync(context);
            await context.SaveChangesAsync();
        }

        private static async Task BuildInitDataAsync(IIdentityContext context)
        {
            await context.Users.AddAsync(new User
            {
                Id = 1,
                Username = "user1",
                Password = "1111",
                Created = DateTime.UtcNow,
                Updated = DateTime.MinValue
            });
        }
    }
}
