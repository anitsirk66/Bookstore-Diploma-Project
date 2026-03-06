using BookstoreProjectData.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookstoreWebApp.Seed
{
    public class AdminSeeder
    {
        public static async Task SeedAdmin(
            RoleManager<IdentityRole> roleManager,
                UserManager<User> userManager)
        {
            string email = "kristina@gmail.com";

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                var adminUser = new User
                {
                    UserName = "Admin",
                    Email = email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "AdminPasswd#1");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }

    }
}
