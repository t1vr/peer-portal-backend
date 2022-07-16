using Domain.Entities;
using Domain.IRepositories;
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
                var permissionRepository = serviceProvider.GetRequiredService<IPermissionRepository>();
                await Infrastructure.Persistence.Seeds.DefaultPermissions.SeedAsync(permissionRepository);

                await Infrastructure.Persistence.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
                await Infrastructure.Persistence.Seeds.DefaultSuperAdmin.SeedAsync(userManager, roleManager);
                await Infrastructure.Persistence.Seeds.DefaultUsers.SeedAsync(userManager, roleManager);

                Log.Information("Finished Seeding Default Data");

            }
        }
    }
}
