using Application.Shared.Enum;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence.Seeds
{
    /// <summary>
    /// Seed class for Roles
    /// </summary>
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            //Seed Roles
            var a = new ApplicationRole(Roles.SuperAdmin.ToString());
            await roleManager.CreateAsync(new ApplicationRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new ApplicationRole(Roles.Admin.ToString()));
        }
    }
}
