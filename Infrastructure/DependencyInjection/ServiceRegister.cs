using Domain.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using ApplicationServicesInterfaces = Application.Interfaces;
using ApplicationServices = Application.Services;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceRegister
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ApplicationServicesInterfaces.IUsersService, ApplicationServices.UsersService>();
        }
    }
}
