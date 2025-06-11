using Bimbrownik_API.data;
using Bimbrownik_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bimbrownik_API.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Bimbrownik_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;

        public CommentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetComments([FromQuery] Guid? postId)
        {
            IQueryable<Comment> query = dbContext.Comments.AsQueryable();

            if (postId.HasValue)
                query = query.Where(c => c.PostId == postId.Value);

            var comments = await query.ToListAsync();
            return Ok(comments);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetCommentByID(Guid id)
        {
            var comment = dbContext.Comments.Find(id);


            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);

        }

        [HttpPost]
        [Authorize]
        public IActionResult AddComment(AddCommentDto addComment)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var commentEntity = new Comment()
            {
                Name = addComment.Name,

                PostId = addComment.PostId,

                AuthorId = userId,

            };

            dbContext.Comments.Add(commentEntity);

            dbContext.SaveChanges();

            return Ok(commentEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult UpdateComment(Guid id, UpdateCommentDto updateCommentDto)
        {
            var comment = dbContext.Comments.Find(id);

            if (comment == null)
            {

                return NotFound();

            }

            comment.Name = updateCommentDto.Name;




            dbContext.SaveChanges();

            return Ok(comment);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult Delete(Guid id)
        {

            var comment = dbContext.Comments.Find(id);

            if (comment == null)
            {

                return NotFound();

            }

            dbContext.Comments.Remove(comment);

            dbContext.SaveChanges();

            return Ok();

        }

    }
}
