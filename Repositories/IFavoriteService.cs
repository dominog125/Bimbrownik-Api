using Bimbrownik_API.Models.Entities;


namespace Bimbrownik_API.Services
{
    public interface IFavoriteService
    {
        Task<IEnumerable<Post>> GetFavoritesAsync(string userId);
        Task<FavoritePost> AddFavoriteAsync(string userId, Guid postId);
        Task<bool> RemoveFavoriteAsync(string userId, Guid postId);
    }
}
