using Entities;

namespace AspNetCoreJwtIdentity.Repositories.UnitOfWorks
{
    public class ExampleController
    {
        private void Start()
        {
            using var unitOfWork = new UnitOfWork(new IdentityContext());
            var result = unitOfWork.Users.GetUserWithNames(1, 2);
            unitOfWork.Complete();
        }
    }

}
