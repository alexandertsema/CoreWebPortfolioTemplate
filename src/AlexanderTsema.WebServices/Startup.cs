#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexanderTsema.Mapper.Mapper;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AlexanderTsema.WebServices
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

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //services.AddMvc();
            services.AddMvc().AddJsonOptions(options => { // fix loop references for EF
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddAutoMapper(typeof(MappingProfile));

            // Add DI
            services.AddScoped(typeof(AlexanderTsema.Storage.Abstractions.Core.IStorage),
                typeof(AlexanderTsema.Storage.Concretes.Core.Storage));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            #if DEBUG

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            #endif

            loggerFactory.AddFile(Configuration.GetSection("Logging"));

            app.UseMvc();
        }
    }
}
