namespace AspNetCoreJwtIdentity.Models
{
    public class MockContext
    {
        public IList<User> Users { get; set; }
        public MockContext()
        {
            Users = new List<User>
            {
                new User
                {
                    Username = "admin",
                    Password = "0000",
                    UserRole = "admin",
                },
                new User
                {
                    Username = "Kim",
                    Password = "1111",
                    UserRole = "user"
                },
                new User
                {
                    Username = "Park",
                    Password = "2222",
                    UserRole = "user"
                }
            };
        }
    }
}
