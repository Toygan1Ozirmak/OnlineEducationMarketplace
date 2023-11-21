using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OEMAP.Api.ActionFilters;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System.Diagnostics.Eventing.Reader;
using static OnlineEducationMarketplace.Entity.Exceptions.BadHttpRequestException;

namespace OEMAP.Api.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {

            var categories = _manager.CategoryService.GetAllCategories(false);
            return Ok(categories);



        }

        [HttpGet("GetCategoryByCategoryId/{categoryId:int}")]
        public IActionResult GetCategoryByCategoryId([FromRoute(Name = "categoryId")] int categoryId)
        {

            var category = _manager
            .CategoryService
            .GetCategoryByCategoryId(categoryId, false);



            return Ok(category);


        }


        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("Create")]
        public IActionResult CreateCategory([FromBody] Category category)
        {


            //if (category is null)
            //    throw new CreateCategoryBadHttpRequestException(category); //400

            _manager.CategoryService.CreateCategory(category);

            return StatusCode(201, category);

        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("Update/{categoryId:int}")]
        public IActionResult UpdateCategory([FromRoute(Name = "categoryId")] int categoryId,
            [FromBody] Category category)
        {


            //if (category is null)
            //    throw new CategoryBadHttpRequestException(categoryId); //400



            _manager.CategoryService.UpdateCategory(categoryId, category, true);
            return NoContent(); //204


        }

        [HttpDelete("Delete/{categoryId:int}")]
        public IActionResult DeleteCategory([FromRoute(Name = "categoryId")] int categoryId)
        {


            _manager.CategoryService.DeleteCategory(categoryId, false);
            return NoContent();


        }

        [HttpPatch("PartiallyUpdate/{categoryId:int}")]
        public IActionResult PartiallyUpdateCategory([FromRoute(Name = "categoryId")] int categoryId,
            [FromBody] JsonPatchDocument<Category> categoryPatch)
        {

            //check entity

            var entity = _manager
                .CategoryService
                .GetCategoryByCategoryId(categoryId, true);


            categoryPatch.ApplyTo(entity);
            _manager.CategoryService.UpdateCategory(categoryId, entity, true);

            return NoContent(); //204


        }

    }
}