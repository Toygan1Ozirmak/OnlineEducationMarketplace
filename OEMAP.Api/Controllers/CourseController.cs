using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.Exceptions;
using OnlineEducationMarketplace.Services.Contracts;
using System.Diagnostics.Eventing.Reader;
using static OnlineEducationMarketplace.Entity.Exceptions.BadHttpRequestException;

namespace OEMAP.Api.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CourseController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllCourses() 
        {
            
                var courses = _manager.CourseService.GetAllCourses(false);
                return Ok(courses);
            

        }

        [HttpGet("{courseId:int}")]
        public IActionResult GetCourseByCourseId([FromRoute(Name = "courseId")] int courseId)
        {
            
                var course = _manager
                .CourseService
                .GetCourseByCourseId(courseId, false);

            
            return Ok(course);
           

        }

        [HttpGet("category/{categoryId:int}")]
        public IActionResult GetCoursesByCategoryId([FromRoute(Name = "categoryId")] int categoryId)
        {
            
                var courses = _manager
                .CourseService
                .GetCoursesByCategoryId(categoryId, false);

                
                return Ok(courses);
            

        }

        [HttpPost()]
        public IActionResult CreateCourse([FromBody] Course course)
        {


            if (course is null)
                throw new CreateCourseBadHttpRequestException(course); //400

                _manager.CourseService.CreateCourse(course);

                return StatusCode(201, course);
            


        }

        [HttpPut("{courseId:int}")]
        public IActionResult UpdateCourse([FromRoute(Name = "courseId")] int courseId,
            [FromBody] CourseDtoForUpdate courseDto) 
        {
            if (courseDto is null)
                throw new CourseBadHttpRequestException(courseId); //400
               


            _manager.CourseService.UpdateCourse(courseId, courseDto, true);
            return NoContent(); //204
                      
            
        }

        [HttpDelete("{courseId:int}")]
        public IActionResult DeleteCourse([FromRoute(Name = "courseId")] int courseId)
        {
            

            _manager.CourseService.DeleteCourse(courseId, false);
            return NoContent();

            
        }

        [HttpPatch("{courseId:int}")]
        public IActionResult PartiallyUpdateCourse([FromRoute(Name = "courseId")] int courseId,
            [FromBody] JsonPatchDocument<Course> coursePatch)
        {
            
            
                //check entity

                var entity = _manager
                    .CourseService
                    .GetCourseByCourseId(courseId, true);

                coursePatch.ApplyTo(entity);
                _manager.CourseService.UpdateCourse(courseId, new CourseDtoForUpdate(entity.CourseId,entity.CategoryId,entity.Description,entity.CourseLength,entity), true);

                return NoContent(); //204
            
            
        }

    }
}
