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
            //necessary package to use in-memory SQL Server database. Version 1.1.1, installed using Visual Studio NuGet
            //install MailKit, JsonNet.PrivateSettersContractResolvers, Newtonsoft.Json, ...

            //Add services (interfaces) and db contexts (in memory, erased when server stops running)
            services.AddDbContext<UserDbContext>(opt => opt.UseInMemoryDatabase("FriendsDB")); //Every UserDbContext declaration refers to
                                                                                               //Db set on the Context (same db, always)
            services.AddTransient<IUser, UserRepo>(); //Adds dependency injection, the controller constructor only needs to say that
                                                      //he recieves a IUser (that is implemented the Repo) and the injector will Contruct
                                                      //the Repo class. With Transient, for every controller, is a different iteration
                                                      //of the UserRepo class!
                                                      //This is necessary to solve and determine the scope of dependencies!

            services.AddDbContext<EventDbContext>(opt => opt.UseInMemoryDatabase("FriendsDB"));
            services.AddTransient<IEvent, EventRepo>();

            services.AddDbContext<LoginDbContext>(opt => opt.UseInMemoryDatabase("FriendsDB"));
            services.AddTransient<ILogin, LoginRepo>();

            // Add framework services.
            services.AddMvc();
            // Reads from the appsettigns json file the necessary data to configurate the email interface
            // Connects the read configurations with the EmailService class 
            services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            // With a Singleton, for every class that requires a IEmailConfiguration, it is the same object!
            services.AddTransient<IEmailService, EmailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            //Temporary variable (closure, Configure Scope) used to get the json information of the db seed
            var dataText = System.IO.File.ReadAllText(@"usersSeed.json");
            //Seed the users db with the original users
            Seeder seeder = new Seeder(app.ApplicationServices);
            seeder.SeedIt(dataText);
        }


    }
}
