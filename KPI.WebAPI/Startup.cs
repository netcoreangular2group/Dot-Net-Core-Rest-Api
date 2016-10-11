using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using KPI.WebAPI.Extensions;
using Microsoft.Extensions.Configuration;
using KPI.Infrastructure.Data;
using Microsoft.DotNet.Cli.Utils.CommandParsing;

namespace KPI.WebAPI
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private static readonly IList<ModuleInfo> Modules = new List<ModuleInfo>();

        private IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            _hostingEnvironment = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true);
            //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            //if (env.IsDevelopment())
            //{
            //    builder.AddUserSecrets();
            //}

            //builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }



        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            GlobalConfiguration.WebRootPath = _hostingEnvironment.WebRootPath;
            GlobalConfiguration.ContentRootPath = _hostingEnvironment.ContentRootPath;

            //refactor
            services.LoadInstalledModules(Modules, _hostingEnvironment);
            services.AddCustomizedDataStore(Configuration);
            services.AddMvc().AddXmlSerializerFormatters();
            return services.Build(Configuration, _hostingEnvironment);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseMvc();
        }
    }
}
