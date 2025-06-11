using Bimbrownik_API.data;
using Bimbrownik_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bimbrownik_API.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly ApplicationDbContext _db;
        public FavoriteService(ApplicationDbContext db) => _db = db;

        public async Task<IEnumerable<Post>> GetFavoritesAsync(string userId)
        {
            return await _db.FavoritePosts
                .Where(fp => fp.UserId == userId)
                .Include(fp => fp.Post)
                .Select(fp => fp.Post)
                .ToListAsync();
        }

        public async Task<FavoritePost> AddFavoriteAsync(string userId, Guid postId)
        {
            // walidacja istnienia posta
            var postExists = await _db.Posts.AnyAsync(p => p.Id == postId);
            if (!postExists) throw new KeyNotFoundException("Post nie istnieje.");

            // sprawdź duplikaty
            var exists = await _db.FavoritePosts
                .AnyAsync(fp => fp.UserId == userId && fp.PostId == postId);
            if (exists) throw new InvalidOperationException("Już w ulubionych.");

            var fav = new FavoritePost
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                PostId = postId
            };
            _db.FavoritePosts.Add(fav);
            await _db.SaveChangesAsync();
            return fav;
        }

        public async Task<bool> RemoveFavoriteAsync(string userId, Guid postId)
        {
            var fav = await _db.FavoritePosts
                .FirstOrDefaultAsync(fp => fp.UserId == userId && fp.PostId == postId);
            if (fav == null) return false;

            _db.FavoritePosts.Remove(fav);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}