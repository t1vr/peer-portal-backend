using Application.Shared.Enum;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence.Seeds
{
    /// <summary>
    /// Seed class for seeding users
    /// </summary>
    public static class DefaultUsers
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "basicuser",
                Email = "basicuser@gmail.com",
                FirstName = "John",
                LastName = "Doe",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                }

            }
        }
    }
}
