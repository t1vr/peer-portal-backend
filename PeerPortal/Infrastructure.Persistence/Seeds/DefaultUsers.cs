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
            var defaultUser1 = new ApplicationUser
            {
                UserName = "basicuser",
                Email = "basicuser@gmail.com",
                FirstName = "John",
                LastName = "Doe",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var defaultUser2 = new ApplicationUser
            {
                UserName = "tanvir",
                Email = "tanvir@gmail.com",
                FirstName = "Tanvir",
                LastName = "Ahmed",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var defaultUser3 = new ApplicationUser
            {
                UserName = "taher",
                Email = "taher@gmail.com",
                FirstName = "Taher",
                LastName = "Irfan",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser1.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser1.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser1, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser1, Roles.Admin.ToString());
                }
            }
            if (userManager.Users.All(u => u.Id != defaultUser2.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser2.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser2, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser2, Roles.Admin.ToString());
                }
            }
            if (userManager.Users.All(u => u.Id != defaultUser3.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser3.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser3, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser3, Roles.Admin.ToString());
                }
            }
        }
    }
}
