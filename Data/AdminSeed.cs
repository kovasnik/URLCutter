using Microsoft.AspNetCore.Identity;
using URLCutter.Models;

namespace URLCutter.Data
{
    public class AdminSeed
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            // Create roles
            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Create admin user
            var adminEmail = "admin@example.com";
            var adminPassword = "Admin123!";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new User { UserName = adminEmail, Email = adminEmail };
                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
