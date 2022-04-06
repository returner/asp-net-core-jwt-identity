using AspNetCoreJwtIdentity.Controllers;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AspNetCoreJwtIdentity_Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var database = new SqliteMemoryDatabase();
            var context = database.CreateContext();

            var _sut = new UserController(context);

            var result = _sut.GetAllUsers();
            var user2 = result.FirstOrDefault(d => d.Username.Equals("user2"));

            Assert.IsType<User[]>(result);
            Assert.NotNull(user2);
            Assert.Equal(user2.Password, "2222");
        }
    }
}