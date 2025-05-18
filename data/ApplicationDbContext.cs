using Bimbrownik_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bimbrownik_API.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }


        public DbSet<Post> Posts { get; set; }

        public DbSet<AlcoholCategory> AlcoholCategories{ get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
