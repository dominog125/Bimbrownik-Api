// ApplicationAuthDbContext.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bimbrownik_API.Data
{
    public class ApplicationAuthDbContext
        : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationAuthDbContext(DbContextOptions<ApplicationAuthDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "c1a1f400-1d2b-4f5a-8b66-aaaaaaaaaaaa";
            var userRoleId = "d2b2f511-2e3c-5g6b-9c77-bbbbbbbbbbbb";
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = userRoleId, Name = "User", NormalizedName = "USER" }
            );

            var adminUserId = "e3c3f622-3f4d-7h8c-0d88-cccccccccccc";
            var normalUserId = "f4d4g733-4h5e-9i0d-1e99-dddddddddddd";
            var hasher = new PasswordHasher<IdentityUser>();
            var admin = new IdentityUser
            {
                Id = adminUserId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@localhost",
                NormalizedEmail = "ADMIN@LOCALHOST",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null!, "Admin@123")
            };
            var user = new IdentityUser
            {
                Id = normalUserId,
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@localhost",
                NormalizedEmail = "USER@LOCALHOST",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null!, "User@123")
            };
            builder.Entity<IdentityUser>().HasData(admin, user);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = adminRoleId, UserId = adminUserId },
                new IdentityUserRole<string> { RoleId = userRoleId, UserId = normalUserId }
            );
        }
    }
}
