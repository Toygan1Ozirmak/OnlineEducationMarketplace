using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System.Diagnostics.Eventing.Reader;

namespace OEMAP.Api.Controllers
{
    [Route("api/courseenrollments")]
    [ApiController]
    public class CourseEnrollmentController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CourseEnrollmentController(IServiceManager manager)
        {
            _manager = manager;
        }

        

        [HttpGet("{courseId:int}")]
        public IActionResult GetCourseEnrollmentsByCourseId([FromRoute(Name = "courseId")] int courseId)
        {
            try
            {
                var courseEnrollments = _manager
                .CourseEnrollmentService
                .GetCourseEnrollmentsByCourseId(courseId, false);

                if (courseEnrollments is null)
                    return NotFound(); //404

                return Ok(courseEnrollments);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{userId:int}")]
        public IActionResult GetCourseEnrollmentsByUserId([FromRoute(Name = "userId")] int userId)
        {
            try
            {
                var courseEnrollments = _manager
                .CourseEnrollmentService
                .GetCourseEnrollmentsByUserId(userId, false);

                if (courseEnrollments is null)
                    return NotFound(); //404

                return Ok(courseEnrollments);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{courseEnrollmentId:int}")]
        public IActionResult GetCourseEnrollmentByCourseEnrollmentId([FromRoute(Name = "courseEnrollmentId")] int courseEnrollmentId)
        {
            try
            {
                var courseEnrollment = _manager
                .CourseEnrollmentService
                .GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, false);

                if (courseEnrollment is null)
                    return NotFound(); //404

                return Ok(courseEnrollment);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost()]
        public IActionResult CreateCourseEnrollment([FromBody] CourseEnrollment courseEnrollment)
        {
            try
            {

                if (courseEnrollment is null)
                    return BadRequest(); //400

                _manager.CourseEnrollmentService.CreateCourseEnrollment(courseEnrollment);

                return StatusCode(201, courseEnrollment);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{courseEnrollmentId:int")]
        public IActionResult UpdateCourseEnrollment([FromRoute(Name = "courseEnrollmentId")] int courseEnrollmentId,
            [FromBody] CourseEnrollment courseEnrollment)
        {
            try
            {

                if (courseEnrollment is null)
                    return BadRequest(); //400

                //check course enrollment

                var entity = _manager
                    .CourseEnrollmentService
                    .GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, true);

                if (entity is null)
                    return NotFound(); //404

                //check id

                if (courseEnrollmentId != courseEnrollment.CourseEnrollmentId)
                    return BadRequest(); //400


                _manager.CourseEnrollmentService.UpdateCourseEnrollment(courseEnrollmentId, courseEnrollment, true);
                return NoContent(); //204

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{courseEnrollmentId:int")]
        public IActionResult DeleteCourseEnrollment([FromRoute(Name = "courseEnrollmentId")] int courseEnrollmentId)
        {
            try
            {
                var entity = _manager
                    .CourseEnrollmentService
                    .GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, false);
                if (entity is null)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = $"Course Enrollment with courseEnrollmentId:{courseEnrollmentId} could not found"
                    }); //404

                _manager.CourseEnrollmentService.DeleteCourseEnrollment(courseEnrollmentId, false);
                return NoContent();

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("{courseEnrollmentId:int")]
        public IActionResult PartiallyUpdateCourseEnrollment([FromRoute(Name = "courseEnrollmentId")] int courseEnrollmentId,
            [FromBody] JsonPatchDocument<CourseEnrollment> courseEnrollmentPatch)
        {
            try
            {
                //check entity

                var entity = _manager
                    .CourseEnrollmentService
                    .GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, true);

                if (entity is null)
                    return NotFound(); //404

                courseEnrollmentPatch.ApplyTo(entity);
                _manager.CourseEnrollmentService.UpdateCourseEnrollment(courseEnrollmentId, entity, true);

                return NoContent(); //204
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
