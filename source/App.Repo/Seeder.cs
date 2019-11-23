using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using JsonNet.PrivateSettersContractResolvers;
using App.Data;
using App.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace App.Repo
{
    public class Seeder
    {
        private readonly IServiceProvider _provider;

        public Seeder(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void SeedIt(string jsonData)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };
            List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonData, settings);
            using (var serviceScope = _provider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<UserDbContext>();
                if (!context.Users.Any())
                {
                    context.AddRange(users);
                    context.SaveChanges();
                }
            }
        }
    }
}