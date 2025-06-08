using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bimbrownik_API.Data
{
    public static class IdentityDataInitializer
    {
        private const string ADMIN_ROLE = "Admin";
        private const string USER_ROLE = "User";

        private const string DEFAULT_ADMIN_USERNAME = "admin";
        private const string DEFAULT_ADMIN_EMAIL = "admin@localhost";
        private const string DEFAULT_ADMIN_PASSWORD = "Admin@123";

        public static async Task SeedRolesAndAdminAsync(
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            if (!await roleManager.RoleExistsAsync(ADMIN_ROLE))
                await roleManager.CreateAsync(new IdentityRole(ADMIN_ROLE));

            if (!await roleManager.RoleExistsAsync(USER_ROLE))
                await roleManager.CreateAsync(new IdentityRole(USER_ROLE));

            if (!await userManager.Users.AnyAsync())
            {
                var admin = new IdentityUser
                {
                    UserName = DEFAULT_ADMIN_USERNAME,
                    Email = DEFAULT_ADMIN_EMAIL,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, DEFAULT_ADMIN_PASSWORD);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, ADMIN_ROLE);
                }
                else
                {
                    throw new Exception($"Seeding admin failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
