using Entities.Interfaces;
using Entities.Models;

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
            context.Database.EnsureCreated();
            await CreateDefaultGroupAsync(context);
            await CreateAdministratorUsers(context);
            await context.SaveChangesAsync();
        }

        private static async Task CreateDefaultGroupAsync(IIdentityContext context)
        {
            var defaultAdminGroup = new Group
            {
                Name = "Administrators",
                Description = "administrators",
                Created = DateTime.UtcNow,
                Updated = DateTime.MinValue,
            };
            await context.Groups.AddAsync(defaultAdminGroup);
        }

        private static async Task CreateAdministratorUsers(IIdentityContext context)
        {
            await context.Users.AddAsync(new User
            {
                Id = 1,
                Username = "admin",
                Password = "1111",
                Created = DateTime.UtcNow,
                Updated = DateTime.MinValue
            });
        }
    }
}
