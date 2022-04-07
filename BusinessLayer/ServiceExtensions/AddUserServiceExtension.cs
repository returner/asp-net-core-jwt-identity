using BusinessLayer.ServiceInterfaces;
using BusinessLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ServiceExtentions
{
    public static class AddUserServiceExtension
    {
        public static void AddUserService(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
