using Bimbrownik_API.data;
using Bimbrownik_API.Models.Dto;
using Bimbrownik_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bimbrownik_API.Controllers
{

    // localhost/api/posts
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PostsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostResponseDto>>> GetAllPosts(
                [FromQuery] string? authorId,
                [FromQuery] string? categoryName,
                [FromQuery(Name = "title")] string? titleContains
            )
        {

            var query = dbContext.Posts
            .AsNoTracking()
            .Include(p => p.AlcoholCategory)          
            .AsQueryable();

           
            if (!string.IsNullOrWhiteSpace(authorId))
            {
                query = query.Where(p => p.AuthorId == authorId);
            }

            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                query = query.Where(p => p.AlcoholCategory.Name == categoryName);
            }

            
            if (!string.IsNullOrWhiteSpace(titleContains))
            {
                query = query.Where(p => p.Title.Contains(titleContains));
            }

            var posts = await query
                   .Select(p => new PostResponseDto
                   {
                       Id = p.Id,
                       Name = p.Name,
                       Description = p.Description,
                       Author = p.AuthorId,
                       Title = p.Title,
                       AlcoholCategoryId = p.AlcoholCategoryId,
                       AlcoholCategoryName = p.AlcoholCategory.Name
                   })
                   .ToListAsync();

            return Ok(posts);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<PostResponseDto>> GetPostByID(Guid id)
        {
            var post = await dbContext.Posts
                .Include(p => p.AlcoholCategory)
                .Where(p => p.Id == id)
                .Select(p => new PostResponseDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Name = p.Name,
                    Description = p.Description,
                    Author = p.AuthorId,
                    AlcoholCategoryId = p.AlcoholCategoryId,
                    AlcoholCategoryName = p.AlcoholCategory.Name
                })
                .FirstOrDefaultAsync();

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public IActionResult AddPost(AddPostDto addPostDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var postEntity = new Post()
            {
                Name = addPostDto.Name,
                Description = addPostDto.Description,
                Title = addPostDto.Title,
                AlcoholCategoryId = addPostDto.AlcoholCategoryId,
                AuthorId = userId
            };

            dbContext.Posts.Add(postEntity);
            dbContext.SaveChanges();

            return Ok(postEntity);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult UpdatePost(Guid id, UpdatePostDto dto)
        {
            var post = dbContext.Posts.Find(id);
            if (post == null)
                return NotFound();

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!User.IsInRole("Admin") && post.AuthorId != currentUserId)
                return Forbid();

            post.Name = dto.Name;
            post.Description = dto.Description;
            post.Title = dto.Title;
            post.AlcoholCategoryId = dto.AlcoholCategoryId;

            dbContext.SaveChanges();
            return Ok(post);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult Delete(Guid id)
        {
            var post = dbContext.Posts.Find(id);
            if (post == null)
                return NotFound();

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!User.IsInRole("Admin") && post.AuthorId != currentUserId)
                return Forbid();

            dbContext.Posts.Remove(post);
            dbContext.SaveChanges();

            return Ok();
        }

    }
}
