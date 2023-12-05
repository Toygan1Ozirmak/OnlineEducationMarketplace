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
        public async Task <IActionResult> GetAllCategoriesAsync()
        {

            var categories = await _manager.CategoryService.GetAllCategoriesAsync(false);
            return Ok(categories);



        }

        [HttpGet("GetCategoryByCategoryId/{categoryId:int}")]
        public async Task <IActionResult> GetCategoryByCategoryIdAsync([FromRoute(Name = "categoryId")] int categoryId)
        {

            var category = await _manager
            .CategoryService
            .GetCategoryByCategoryIdAsync(categoryId, false);



            return Ok(category);


        }


        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("Create")]
        public async Task <IActionResult> CreateCategoryAsync([FromBody] Category category)
        {


            //if (category is null)
            //    throw new CreateCategoryBadHttpRequestException(category); //400

            await _manager.CategoryService.CreateCategoryAsync(category);

            return StatusCode(201, category);

        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("Update/{categoryId:int}")]
        public async Task <IActionResult> UpdateCategoryAsync([FromRoute(Name = "categoryId")] int categoryId,
            [FromBody] Category category)
        {


            //if (category is null)
            //    throw new CategoryBadHttpRequestException(categoryId); //400



            await _manager.CategoryService.UpdateCategoryAsync(categoryId, category, true);
            return NoContent(); //204


        }

        [HttpDelete("Delete/{categoryId:int}")]
        public async Task <IActionResult> DeleteCategoryAsync([FromRoute(Name = "categoryId")] int categoryId)
        {


            await _manager.CategoryService.DeleteCategoryAsync(categoryId, false);
            return NoContent();


        }

        [HttpPatch("PartiallyUpdate/{categoryId:int}")]
        public async Task <IActionResult> PartiallyUpdateCategoryAsync([FromRoute(Name = "categoryId")] int categoryId,
            [FromBody] JsonPatchDocument<Category> categoryPatch)
        {

            //check entity

            var entity = await _manager
                .CategoryService
                .GetCategoryByCategoryIdAsync(categoryId, true);


            categoryPatch.ApplyTo(entity);
            await _manager.CategoryService.UpdateCategoryAsync(categoryId, entity, true);

            return NoContent(); //204


        }

    }
}