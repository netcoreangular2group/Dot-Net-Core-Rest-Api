using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Simpl.DI;
using Simpl.Core.Models;
using Microsoft.EntityFrameworkCore;
using Simpl.Core.Databases;

namespace Simpl
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public static IConfigurationRoot Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add entity framework using the config connection string
            services.
                AddEntityFrameworkSqlServer().
                AddDbContext<SimplDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SimplCommerce.WebHost")));

            // add identity
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<SimplDbContext, long>()
                .AddDefaultTokenProviders();

            // add OpenIddict
            services.AddOpenIddict<User, Role, SimplDbContext, long>()
                .DisableHttpsRequirement()
                .EnableTokenEndpoint("/api/token")
                .AllowPasswordFlow()
                .AllowRefreshTokenFlow()
                .UseJsonWebTokens()
                .AddEphemeralSigningKey();

            // Add framework services.
            services.AddMvc();
            services.AddDatabase();
            services.AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseOpenIddict();

            // use jwt bearer authentication
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                RequireHttpsMetadata = false,
                Audience = "http://localhost:59657/",
                Authority = "http://localhost:59657/"
            });

            app.UseMvc();
        }
    }
}
