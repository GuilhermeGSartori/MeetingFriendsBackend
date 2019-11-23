using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using App.Services;
using App.Repo;

namespace MeetingFriendsBackEnd
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //install microsoft.entityframeworkcore.InMemory 1.1
            services.AddDbContext<UserDbContext>(opt => opt.UseInMemoryDatabase("FriendsDB"));
            services.AddTransient<IUser, UserRepo>();

            services.AddDbContext<EventDbContext>(opt => opt.UseInMemoryDatabase("FriendsDB"));
            services.AddTransient<IEvent, EventRepo>();

            services.AddDbContext<LocationDbContext>(opt => opt.UseInMemoryDatabase("FriendsDB"));
            services.AddTransient<ILocation, LocationRepo>();
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            var dataText = System.IO.File.ReadAllText(@"usersSeed.json");
            Seeder seeder = new Seeder(app.ApplicationServices);
            seeder.SeedIt(dataText);
        }


    }
}
