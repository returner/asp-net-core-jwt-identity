using Entities;
using Entities.Interfaces;
using Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreJwtIdentity.Controllers
{
    //공부할것
    //https://docs.microsoft.com/ko-kr/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    //https://www.c-sharpcorner.com/UploadFile/b1df45/unit-of-work-in-repository-pattern/
    public class UserRepoController : ApiControllerBase
    {
        public UserRepoController(IMediator mediator, ILogger<UserRepoController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            //return await _userRepository.GetAllUsersAsync();
            await Task.CompletedTask;
            return Ok();
        }
    }
}
