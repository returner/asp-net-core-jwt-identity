using Entities;
using Entities.Interfaces;
using Entities.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreJwtIdentity_Test
{
    public sealed class SqliteMemoryDatabase : IDisposable
    {
        private readonly DbConnection _connection;
        private readonly DbContextOptions<IdentityContext> _contextOptions;

        public SqliteMemoryDatabase(bool isRunInitializeData = true)
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _contextOptions = new DbContextOptionsBuilder<IdentityContext>()
                .UseSqlite(_connection)
                .Options;

            if (isRunInitializeData)
            {
                using var context = new IdentityContext(_contextOptions);
                context.Database.EnsureCreated();

                InitDatabase(context);
            }
        }

        private static void InitDatabase(IIdentityContext context)
        {
            context.JwtTokenConfigurations.Add(new JwtTokenConfiguration { ExpireIntervalMinutes = 10 });

            context.Users.Add(new User { Username = "user1", Password = "1111", Created = DateTime.UtcNow });
            context.Users.Add(new User { Username = "user2", Password = "2222", Created = DateTime.UtcNow });

            context.SaveChanges();
        }

        public IIdentityContext CreateContext() => new IdentityContext(_contextOptions);

        public void Dispose() => _connection.Dispose();
    }
}
