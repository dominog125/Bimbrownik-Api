using System;
using System.Linq;
using System.Threading.Tasks;
using Bimbrownik_API.data;
using Bimbrownik_API.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bimbrownik_API.Data
{
    public static class DbDataSeeder
    {
     
        public static async Task SeedCategoriesPostsCommentsAsync(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            await ctx.Database.MigrateAsync();

            var adminUser = await userManager.FindByNameAsync("admin")
                             ?? throw new InvalidOperationException("Brak użytkownika 'admin'");
            var normalUser = await userManager.FindByNameAsync("user")
                             ?? throw new InvalidOperationException("Brak użytkownika 'user'");

            if (!ctx.AlcoholCategories.Any())
            {
                var categories = new[]
                {
                    new AlcoholCategory { Id = Guid.NewGuid(), Name = "Beer"   },
                    new AlcoholCategory { Id = Guid.NewGuid(), Name = "Wine"   },
                    new AlcoholCategory { Id = Guid.NewGuid(), Name = "Whisky" },
                    new AlcoholCategory { Id = Guid.NewGuid(), Name = "Vodka"  }
                };
                ctx.AlcoholCategories.AddRange(categories);
                await ctx.SaveChangesAsync();
            }

            if (!ctx.Posts.Any())
            {
                var beer = await ctx.AlcoholCategories.SingleAsync(c => c.Name == "Beer");
                var wine = await ctx.AlcoholCategories.SingleAsync(c => c.Name == "Wine");

                var posts = new[]
                {
                    new Post
                    {
                        Id                = Guid.NewGuid(),
                        Name              = "Top 5 Craft Beers",
                        Title             = "Moje ulubione piwa rzemieślnicze",
                        Description       = "Krótki przegląd piw z lokalnych browarów.",
                        AuthorId          = normalUser.Id,
                        AlcoholCategoryId = beer.Id
                    },
                    new Post
                    {
                        Id                = Guid.NewGuid(),
                        Name              = "Wina na specjalne okazje",
                        Title             = "Polecane wina",
                        Description       = "Kilka propozycji win na urodziny i rocznice.",
                        AuthorId          = adminUser.Id,
                        AlcoholCategoryId = wine.Id
                    }
                };
                ctx.Posts.AddRange(posts);
                await ctx.SaveChangesAsync();
            }

            if (!ctx.Comments.Any())
            {
                var firstPost = await ctx.Posts.FirstAsync();
                var secondPost = await ctx.Posts.Skip(1).FirstAsync();

                var comments = new[]
                {
                    new Comment
                    {
                        Id       = Guid.NewGuid(),
                        Name     = "Świetny wpis, dzięki!",
                        PostId   = firstPost.Id,
                        AuthorId = normalUser.Id
                    },
                    new Comment
                    {
                        Id       = Guid.NewGuid(),
                        Name     = "Ciekawy temat, chętnie spróbuję.",
                        PostId   = firstPost.Id,
                        AuthorId = adminUser.Id
                    },
                    new Comment
                    {
                        Id       = Guid.NewGuid(),
                        Name     = "Super rekomendacje.",
                        PostId   = secondPost.Id,
                        AuthorId = normalUser.Id
                    }
                };
                ctx.Comments.AddRange(comments);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
