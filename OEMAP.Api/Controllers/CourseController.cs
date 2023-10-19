using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System.Diagnostics.Eventing.Reader;

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
            try
            {
                var courses = _manager.CourseService.GetAllCourses(false);
                return Ok(courses);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }

        [HttpGet("{courseId:int}")]
        public IActionResult GetCourseByCourseId([FromRoute(Name = "courseId")] int courseId)
        {
            try
            {
                var course = _manager
                .CourseService
                .GetCourseByCourseId(courseId, false);

                if(course is null)
                    return NotFound(); //404

                return Ok(course);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{categoryId:int}")]
        public IActionResult GetCoursesByCategoryId([FromRoute(Name = "categoryId")] int categoryId)
        {
            try
            {
                var courses = _manager
                .CourseService
                .GetCoursesByCategoryId(categoryId, false);

                if (courses is null)
                    return NotFound(); //404

                return Ok(courses);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost()]
        public IActionResult CreateCourse([FromBody] Course course)
        {
            try
            {
                
                if (course is null)
                    return BadRequest(); //400

                _manager.CourseService.CreateCourse(course);

                return StatusCode(201, course);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{courseId:int")]
        public IActionResult UpdateCourse([FromRoute(Name = "courseId")] int courseId,
            [FromBody] Course course) 
        {
            try
            {
                
                if (course is null)
                    return BadRequest(); //400

                //check course

                var entity = _manager
                    .CourseService
                    .GetCourseByCourseId(courseId, true);

                if (entity is null)
                    return NotFound(); //404

                //check id

                if(courseId != course.CourseId)
                    return BadRequest(); //400

                
                _manager.CourseService.UpdateCourse(courseId, course, true);
                return NoContent(); //204
                      
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{courseId:int")]
        public IActionResult DeleteCourse([FromRoute(Name = "courseId")] int courseId)
        {
            try
            {
                var entity = _manager
                    .CourseService
                    .GetCourseByCourseId(courseId, false);
                if (entity is null)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = $"Book with courseId:{courseId} could not found"
                    }); //404

                _manager.CourseService.DeleteCourse(courseId, false);
                return NoContent();

            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("{courseId:int")]
        public IActionResult PartiallyUpdateCourse([FromRoute(Name = "courseId")] int courseId,
            [FromBody] JSonPatchDocument<Course> coursePatch)
        {
            try
            {
                //check entity

                var entity = _manager
                    .CourseService
                    .GetCourseByCourseId(courseId, true);

                if (entity is null)
                    return NotFound(); //404

                coursePatch.ApplyTo(entity);
                _manager.CourseService.UpdateCourse(courseId, entity, true);

                return NoContent(); //204
            }

            catch( Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
