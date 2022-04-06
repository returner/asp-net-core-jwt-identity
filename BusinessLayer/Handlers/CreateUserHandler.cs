using BusinessLayer.Commands;
using Entities.Interfaces;
using Entities.Models;
using MediatR;
using SharedModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserRequest>, IDisposable
    {
        private readonly IIdentityContext _context;
        public CreateUserHandler(IIdentityContext context) => _context = context;

        public void Dispose() => _context.Dispose();

        public async Task<UserRequest> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Users.AddAsync(new User
                {
                    Username = request.userRequest.Username,
                    Password = request.userRequest.Password,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.MinValue,
                });

                return request.userRequest;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
