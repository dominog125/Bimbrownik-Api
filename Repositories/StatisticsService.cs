using Bimbrownik_API.data;
using Bimbrownik_API.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bimbrownik_API.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext _appDb;
        private readonly UserManager<IdentityUser> _userManager;

        public StatisticsService(ApplicationDbContext appDb, UserManager<IdentityUser> userManager)
        {
            _appDb = appDb;
            _userManager = userManager;
        }

        public async Task<StatisticsDto> GetStatisticsAsync()
        {
            var totalPosts = await _appDb.Posts.CountAsync();
            var totalComments = await _appDb.Comments.CountAsync();
            var totalCategories = await _appDb.AlcoholCategories.CountAsync();
            var totalUsers = await _userManager.Users.CountAsync();

            return new StatisticsDto
            {
                TotalPosts = totalPosts,
                TotalUsers = totalUsers,
                TotalComments = totalComments,
                TotalCategories = totalCategories
            };
        }
    }
}
