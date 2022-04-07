using BusinessLayer.Commands;
using BusinessLayer.ServiceInterfaces;
using Entities.Interfaces;
using Entities.Models;
using MediatR;
using SharedModel.DataTransfers.Responses;
using SharedModel.Request;
using SharedModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Handlers.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDtoResponse>
    {
        private readonly IUserService _userService;
        public CreateUserHandler(IUserService userService) => _userService = userService;

        public async Task<UserDtoResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //try
            //{
            //    var user = new User
            //    {
            //        Username = request.Username,
            //        Password = request.Password,
            //        Created = DateTime.UtcNow,
            //        Updated = DateTime.MinValue,
            //    };

            //    await _context.Users.AddAsync(user);
            //    await _context.SaveChangesAsync();

            //    return new UserDtoResponse(user.Id, user.Username);

            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            return await _userService.CreateUserAsync(request.userDtoRequest);
        }
    }
}
