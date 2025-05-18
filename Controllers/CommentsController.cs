using Bimbrownik_API.data;
using Bimbrownik_API.Models.Entities;
using Bimbrownik_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllPosts()
        {
            var allAlcoholCategories = dbContext.Comments.ToList();

            return Ok(allAlcoholCategories);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetPostByID(Guid id)
        {
            var post = dbContext.Comments.Find(id);


            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);

        }

        [HttpPost]
        public IActionResult AddAlcoholCategory(AddCommentDto addComment)
        {
            var commentEntity = new Comment()
            {
                Name = addComment.Name


            };

            dbContext.Comments.Add(commentEntity);

            dbContext.SaveChanges();

            return Ok(commentEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateAlocoholCategory(Guid id, UpdateCommentDto updateCommentDto)
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
