using Bimbrownik_API.data;
using Bimbrownik_API.Models.Entities;
using Bimbrownik_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Bimbrownik_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class AlcoholCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public AlcoholCategoriesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAllAlcoholCategories()
        {
            var allAlcoholCategories = dbContext.AlcoholCategories.ToList();

            return Ok(allAlcoholCategories);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetAlcoholCategoryByID(Guid id)
        {
            var AlcoholCategory = dbContext.AlcoholCategories.Find(id);


            if (AlcoholCategory == null)
            {
                return NotFound();
            }

            return Ok(AlcoholCategory);

        }

        [HttpPost]
        public IActionResult AddAlcoholCategory(AddAlcoholCategory addAlcoholCategory)
        {
            var alcoholcategoryEntity = new AlcoholCategory()
            {
                Name = addAlcoholCategory.Name


            };

            dbContext.AlcoholCategories.Add(alcoholcategoryEntity);

            dbContext.SaveChanges();

            return Ok(alcoholcategoryEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateAlocoholCategory(Guid id, UpdateAlcoholCategoryDto updateAlcoholCategoryDto)
        {
            var alcoholCategory = dbContext.AlcoholCategories.Find(id);

            if (alcoholCategory == null)
            {

                return NotFound();

            }

            alcoholCategory.Name = updateAlcoholCategoryDto.Name;

           


            dbContext.SaveChanges();

            return Ok(alcoholCategory);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {

            var alcoholCategory = dbContext.AlcoholCategories.Find(id);

            if (alcoholCategory == null)
            {

                return NotFound();

            }

            dbContext.AlcoholCategories.Remove(alcoholCategory);

            dbContext.SaveChanges();

            return Ok();

        }


    }
}
