using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Extensions
{
    public static class DatabaseManager
    {
        public static async void SeedData(this IServiceCollection services, IHost app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                await Infrastructure.Persistence.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
                await Infrastructure.Persistence.Seeds.DefaultSuperAdmin.SeedAsync(userManager, roleManager);
                await Infrastructure.Persistence.Seeds.DefaultUsers.SeedAsync(userManager, roleManager);
                Log.Information("Finished Seeding Default Data");

            }
        }
    }
}
