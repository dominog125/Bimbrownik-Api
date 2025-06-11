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

        private const string DEFAULT_USER_USERNAME = "user";
        private const string DEFAULT_USER_EMAIL = "user@localhost";
        private const string DEFAULT_USER_PASSWORD = "User@123";

        public static async Task SeedRolesAndUsersAsync(
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
                var adminResult = await userManager.CreateAsync(admin, DEFAULT_ADMIN_PASSWORD);
                if (adminResult.Succeeded)
                    await userManager.AddToRoleAsync(admin, ADMIN_ROLE);
                else
                    throw new Exception($"Seeding admin failed: {string.Join(", ", adminResult.Errors.Select(e => e.Description))}");

                var user = new IdentityUser
                {
                    UserName = DEFAULT_USER_USERNAME,
                    Email = DEFAULT_USER_EMAIL,
                    EmailConfirmed = true
                };
                var userResult = await userManager.CreateAsync(user, DEFAULT_USER_PASSWORD);
                if (userResult.Succeeded)
                    await userManager.AddToRoleAsync(user, USER_ROLE);
                else
                    throw new Exception($"Seeding default user failed: {string.Join(", ", userResult.Errors.Select(e => e.Description))}");
            }
        }
    }
}
