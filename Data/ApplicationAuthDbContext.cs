using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bimbrownik_API.Data
{
    public class ApplicationAuthDbContext : IdentityDbContext
    {
        public ApplicationAuthDbContext(DbContextOptions<ApplicationAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var userRoleId = "61999953-7b32-40ee-a4d1-0d3950381e70";
            var adminRoleId = "ebda820d-b993-40e3-b9cd-982db300eb48";

            var roles = new List<IdentityRole>
            {

                new IdentityRole
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                },
                  new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                }

            };

            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
