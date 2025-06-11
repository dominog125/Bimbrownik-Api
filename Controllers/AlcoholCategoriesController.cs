using Bimbrownik_API.data;
using Bimbrownik_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Bimbrownik_API.Models.Dto;

namespace Bimbrownik_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AlcoholCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public AlcoholCategoriesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAlcoholCategories()
        {
            var allAlcoholCategories = await dbContext.AlcoholCategories.ToListAsync();

            return Ok(allAlcoholCategories);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetAlcoholCategoryByID(Guid id)
        {
            var AlcoholCategory = await dbContext.AlcoholCategories.FindAsync(id);


            if (AlcoholCategory == null)
            {
                return NotFound();
            }

            return Ok(AlcoholCategory);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAlcoholCategory(AddAlcoholCategory addAlcoholCategory)
        {
            var alcoholcategoryEntity = new AlcoholCategory()
            {
                Name = addAlcoholCategory.Name


            };

            await dbContext.AlcoholCategories.AddAsync(alcoholcategoryEntity);

            await dbContext.SaveChangesAsync();

            return Ok(alcoholcategoryEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAlocoholCategory(Guid id, UpdateAlcoholCategoryDto updateAlcoholCategoryDto)
        {
            var alcoholCategory = await dbContext.AlcoholCategories.FindAsync(id);

            if (alcoholCategory == null)
            {

                return NotFound();

            }

            alcoholCategory.Name = updateAlcoholCategoryDto.Name;

           


           await dbContext.SaveChangesAsync();

            return Ok(alcoholCategory);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var alcoholCategory = await dbContext.AlcoholCategories.FindAsync(id);

            if (alcoholCategory == null)
            {

                return NotFound();

            }

            dbContext.AlcoholCategories.Remove(alcoholCategory);

            await dbContext.SaveChangesAsync();

            return Ok();

        }


    }
}
