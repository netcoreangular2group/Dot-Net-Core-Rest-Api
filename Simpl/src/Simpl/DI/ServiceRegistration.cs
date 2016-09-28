using Microsoft.Extensions.DependencyInjection;
using Simpl.Core.Services;

namespace Simpl.DI
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
