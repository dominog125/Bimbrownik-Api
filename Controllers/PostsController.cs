﻿using Bimbrownik_API.data;
using Bimbrownik_API.Models;
using Bimbrownik_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllPosts()
        {
            var allPosts = dbContext.Post.ToList();

            return Ok(allPosts);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetPostByID(Guid id)
        {
            var post = dbContext.Post.Find(id);
            

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);

        }

        [HttpPost]
        public IActionResult AddPost(AddPostDto addPostDto) 
        {
            var postEntity = new Post()
            {
                Name = addPostDto.Name,

                Description = addPostDto?.Description,

                Author = addPostDto.Author,

                Title = addPostDto.Title
            };

            dbContext.Post.Add(postEntity);

            dbContext.SaveChanges();
            
            return Ok(postEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdatePost(Guid id,UpdatePostDto updatePostDto) 
        {
            var post = dbContext.Post.Find(id);

            if(post == null) 
            {

                return NotFound();

            }

            post.Name = updatePostDto.Name;
            
            post.Description = updatePostDto.Description;
          
            post.Author = updatePostDto.Author;
          
            post.Title = updatePostDto.Title;
          

            dbContext.SaveChanges();

            return Ok(post);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id) 
        {

            var post = dbContext.Post.Find(id);

            if (post == null)
            {

                return NotFound();

            }

            dbContext.Post.Remove(post);

            dbContext.SaveChanges();

            return Ok();

        }
    
    }
}
