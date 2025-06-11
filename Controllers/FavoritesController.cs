// Controllers/FavoritesController.cs
using System.Security.Claims;
using Bimbrownik_API.Models.Dto;
using Bimbrownik_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bimbrownik_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User,Admin")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        // GET: api/Favorites
        [HttpGet]
        public async Task<IActionResult> GetMyFavorites()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var list = await _favoriteService.GetFavoritesAsync(userId!);
            return Ok(list);
        }

        // POST: api/Favorites
        [HttpPost]
        public async Task<IActionResult> AddFavorite([FromBody] AddFavoritePostDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
                var fav = await _favoriteService.AddFavoriteAsync(userId!, dto.PostId);
                return Ok(fav);
            }
            catch (KeyNotFoundException knf)
            {
                return NotFound(new { knf.Message });
            }
            catch (InvalidOperationException ioe)
            {
                return Conflict(new { ioe.Message });
            }
        }

        // DELETE: api/Favorites/{postId}
        [HttpDelete("{postId:guid}")]
        public async Task<IActionResult> RemoveFavorite(Guid postId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var removed = await _favoriteService.RemoveFavoriteAsync(userId!, postId);
            if (!removed)
                return NotFound(new { Message = "Nie znaleziono ulubionego postu." });
            return NoContent();
        }
    }
}
