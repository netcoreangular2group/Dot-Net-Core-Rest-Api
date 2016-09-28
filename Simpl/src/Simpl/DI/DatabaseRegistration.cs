using Microsoft.Extensions.DependencyInjection;
using Simpl.Core.Databases;

namespace Simpl.DI
{
    public static class DatabaseRegistration
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            var connectionString = Startup.Configuration[$"ConnectionStrings:DefaultConnection"];
            services.AddSingleton<IDatabase, SqlDatabase>(impl => new SqlDatabase(connectionString));
        }
    }
}
