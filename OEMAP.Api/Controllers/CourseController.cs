using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OEMAP.Api.ActionFilters;
using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.Exceptions;
using OnlineEducationMarketplace.Entity.RequestFeatures;
using OnlineEducationMarketplace.Services.Contracts;
using System.Diagnostics.Eventing.Reader;
using static OnlineEducationMarketplace.Entity.Exceptions.BadHttpRequestException;

namespace OEMAP.Api.Controllers
{
    //[Authorize]
    //[ServiceFilter(typeof(LogFilterAttribute))]
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CourseController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAllCourses")]
        public async Task <IActionResult> GetAllCoursesAsync([FromQuery]CourseParameters courseParameters)
        {

            var courses = await _manager.CourseService.GetAllCoursesAsync(courseParameters,false);
            return Ok(courses);


        }

        [HttpGet("GetCourseByCourseId/{courseId:int}")]
        public async Task <IActionResult> GetCourseByCourseIdAsync([FromRoute(Name = "courseId")] int courseId)
        {

            var course = await _manager
            .CourseService
            .GetCourseByCourseIdAsync(courseId, false);


            return Ok(course);


        }

        [HttpGet("GetCoursesByCategoryId/category/{categoryId:int}")]
        public async Task <IActionResult> GetCoursesByCategoryIdAsync([FromRoute(Name = "categoryId")] int categoryId)
        {

            var courses = await _manager
            .CourseService
            .GetCoursesByCategoryIdAsync(categoryId, false);


            return Ok(courses);


        }
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("Create")]
        public async Task <IActionResult> CreateCourseAsync([FromBody] CourseDtoForInsertion courseDto)
        {
            if (courseDto is null)
                return BadRequest(); //400

            //if (!ModelState.IsValid)
                //return UnprocessableEntity(ModelState);

            var course =await _manager.CourseService.CreateCourseAsync(courseDto);

            return StatusCode(201, courseDto); //CreatedAtRoute()
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("Update/{courseId:int}")]
        public async Task <IActionResult> UpdateCourseAsync([FromRoute(Name = "courseId")] int courseId,
            [FromBody] CourseDtoForUpdate courseDto)
        {
            //if (courseDto is null)
            //    throw new CourseBadHttpRequestException(courseId); //400

            await _manager.CourseService.UpdateCourseAsync(courseId, courseDto, false);
            return NoContent(); //204


        }

        [HttpDelete("Delete/{courseId:int}")]
        public async Task <IActionResult> DeleteCourseAsync([FromRoute(Name = "courseId")] int courseId)
        {


            await _manager.CourseService.DeleteCourseAsync(courseId, false);
            return NoContent();


        }

        [HttpPatch("PartiallyUpdate/{courseId:int}")]
        public async Task <IActionResult> PartiallyUpdateCourseAsync([FromRoute(Name = "courseId")] int courseId,
            [FromBody] JsonPatchDocument<CourseDto> coursePatch)
        {


            //check entity

            var courseDto = await _manager
                .CourseService
                .GetCourseByCourseIdAsync(courseId, true);

            coursePatch.ApplyTo(courseDto);
            await _manager.CourseService.UpdateCourseAsync(courseId,
                new CourseDtoForUpdate()
                {
                    CourseId = courseDto.CourseId, 
                    Title = courseDto.Title, 
                    Description = courseDto.Description, 
                    CourseLength = courseDto.CourseLength, 
                    Image = courseDto.Image, 
                    CourseStatus = courseDto.CourseStatus, 
                    CategoryId = courseDto.CategoryId
                }, true);

            return NoContent(); //204


        }

    }
}