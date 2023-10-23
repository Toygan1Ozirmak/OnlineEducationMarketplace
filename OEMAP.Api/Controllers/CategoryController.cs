using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System.Diagnostics.Eventing.Reader;

namespace OEMAP.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            
                var categories = _manager.CategoryService.GetAllCategories(false);
                return Ok(categories);
           


        }

        [HttpGet("{categoryId:int}")]
        public IActionResult GetCategoryByCategoryId([FromRoute(Name = "categoryId")] int categoryId)
        {
            
                var category = _manager
                .CategoryService
                .GetCategoryByCategoryId(categoryId, false);

                if (category is null)
                    return NotFound(); //404

                return Ok(category);
            

        }

       

        [HttpPost()]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            

                if (category is null)
                    return BadRequest(); //400

                _manager.CategoryService.CreateCategory(category);

                return StatusCode(201, category);
            
        }

        [HttpPut("{categoryId:int")]
        public IActionResult UpdateCategory([FromRoute(Name = "categoryId")] int categoryId,
            [FromBody] Category category)
        {
            

                if (category is null)
                    return BadRequest(); //400

                //check category

                var entity = _manager
                    .CategoryService
                    .GetCategoryByCategoryId(categoryId, true);

                if (entity is null)
                    return NotFound(); //404

                //check id

                if (categoryId != category.CategoryId)
                    return BadRequest(); //400


                _manager.CategoryService.UpdateCategory(categoryId, category, true);
                return NoContent(); //204

            
        }

        [HttpDelete("{categoryId:int")]
        public IActionResult DeleteCategory([FromRoute(Name = "categoryId")] int categoryId)
        {
            
                var entity = _manager
                    .CategoryService
                    .GetCategoryByCategoryId(categoryId, false);
                if (entity is null)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = $"Category with categoryId:{categoryId} could not found"
                    }); //404

                _manager.CategoryService.DeleteCategory(categoryId, false);
                return NoContent();

            
        }

        [HttpPatch("{categoryId:int")]
        public IActionResult PartiallyUpdateCategory([FromRoute(Name = "categoryId")] int categoryId,
            [FromBody] JsonPatchDocument<Category> categoryPatch)
        {
            
                //check entity

                var entity = _manager
                    .CategoryService
                    .GetCategoryByCategoryId(categoryId, true);

                if (entity is null)
                    return NotFound(); //404

                categoryPatch.ApplyTo(entity);
                _manager.CategoryService.UpdateCategory(categoryId, entity, true);

                return NoContent(); //204
            

        }

    }
}
