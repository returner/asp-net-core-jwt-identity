using AspNetCoreJwtIdentity.Controllers;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreJwtIdentity_Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var database = new SqliteMemoryDatabase();
            var context = database.CreateContext();
            var userRepository = new Mock<IUserRepository>();

            var _sut = new UserController(userRepository.Object);

            var result = await _sut.GetAllUsers();
            var user2 = result.FirstOrDefault(d => d.Username.Equals("user2"));

            Assert.IsType<User[]>(result);
            Assert.NotNull(user2);
            Assert.Equal(user2.Password, "2222");
        }

        [Fact]
        public async Task Ef6_Test()
        {
            //https://docs.microsoft.com/ko-kr/ef/ef6/fundamentals/testing/mocking?redirectedfrom=MSDN
            // arranges
            var mockSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<IdentityContext>();
            mockContext.Setup(d => d.Users).Returns(mockSet.Object);
            
            // acts
            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
            mockContext.Verify(d => d.SaveChanges(), Times.Once());
            // asserts

        }
    }
}