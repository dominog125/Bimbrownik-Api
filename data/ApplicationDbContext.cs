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
        public DbSet<FavoritePost> FavoritePosts { get; set; }

      
       



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminUserId = "e3c3f622-3f4d-7h8c-0d88-cccccccccccc";
            var normalUserId = "f4d4g733-4h5e-9i0d-1e99-dddddddddddd";
         
            var beerId = Guid.Parse("a1111111-1111-1111-1111-111111111111");
            var wineId = Guid.Parse("b2222222-2222-2222-2222-222222222222");
            var whiskyId = Guid.Parse("c3333333-3333-3333-3333-333333333333");
            var vodkaId = Guid.Parse("d4444444-4444-4444-4444-444444444444");

            builder.Entity<FavoritePost>()
          .HasOne(fp => fp.Post)
          .WithMany() 
          .HasForeignKey(fp => fp.PostId)
          .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AlcoholCategory>().HasData(
                new AlcoholCategory { Id = beerId, Name = "Beer" },
                new AlcoholCategory { Id = wineId, Name = "Wine" },
                new AlcoholCategory { Id = whiskyId, Name = "Whisky" },
                new AlcoholCategory { Id = vodkaId, Name = "Vodka" }
            );

            
            var post1Id = Guid.Parse("e5555555-5555-5555-5555-555555555555");
            var post2Id = Guid.Parse("f6666666-6666-6666-6666-666666666666");
            builder.Entity<Post>().HasData(
                new Post
                {
                    Id = post1Id,
                    Name = "Top 5 Craft Beers",
                    Title = "Moje ulubione piwa rzemieślnicze",
                    Description = "Krótki przegląd piw z lokalnych browarów.",
                    AuthorId = normalUserId,              
                    AlcoholCategoryId = beerId
                },
                new Post
                {
                    Id = post2Id,
                    Name = "Wina na specjalne okazje",
                    Title = "Polecane wina",
                    Description = "Kilka propozycji win na urodziny i rocznice.",
                    AuthorId = adminUserId,             
                    AlcoholCategoryId = wineId
                }
            );

            // Seed komentarzy
            builder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = Guid.Parse("07777777-7777-7777-7777-777777777777"),
                    Name = "Świetny wpis, dzięki!",
                    PostId = post1Id,
                    AuthorId = normalUserId
                },
                new Comment
                {
                    Id = Guid.Parse("08888888-8888-8888-8888-888888888888"),
                    Name = "Ciekawy temat, chętnie spróbuję.",
                    PostId = post1Id,
                    AuthorId = normalUserId
                },
                new Comment
                {
                    Id = Guid.Parse("09999999-9999-9999-9999-999999999999"),
                    Name = "Super rekomendacje.",
                    PostId = post2Id,
                    AuthorId = normalUserId
                }
            );
        }
    }
}
