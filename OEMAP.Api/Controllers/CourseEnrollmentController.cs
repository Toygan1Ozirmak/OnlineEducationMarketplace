using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System.Diagnostics.Eventing.Reader;
using static OnlineEducationMarketplace.Entity.Exceptions.BadHttpRequestException;
using static OnlineEducationMarketplace.Entity.Exceptions.NotFoundException;

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



        [HttpGet("GetCourseEnrollmentsByCourseId/{courseId:int}")]
        public IActionResult GetCourseEnrollmentsByCourseId([FromRoute(Name = "courseId")] int courseId)
        {

            var courseEnrollments = _manager
            .CourseEnrollmentService
            .GetCourseEnrollmentsByCourseId(courseId, false);


            return Ok(courseEnrollments);


        }

        [HttpGet("GetCourseEnrollmentsByUserId/{userId:int}")]
        public IActionResult GetCourseEnrollmentsByUserId([FromRoute(Name = "userId")] int userId)
        {

            var courseEnrollments = _manager
            .CourseEnrollmentService
            .GetCourseEnrollmentsByUserId(userId, false);


            return Ok(courseEnrollments);


        }

        [HttpGet("GetCourseEnrollmentByCourseEnrollmentId/{courseEnrollmentId:int}")]
        public IActionResult GetCourseEnrollmentByCourseEnrollmentId([FromRoute(Name = "courseEnrollmentId")] int courseEnrollmentId)
        {

            var courseEnrollment = _manager
            .CourseEnrollmentService
            .GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, false);


            return Ok(courseEnrollment);



        }

        [HttpPost("Create")]
        public IActionResult CreateCourseEnrollment([FromBody] CourseEnrollmentDtoForInsertion courseEnrollmentDto)
        {


            if (courseEnrollmentDto is null)
                return BadRequest(); //400

            _manager.CourseEnrollmentService.CreateCourseEnrollment(courseEnrollmentDto);

            return StatusCode(201, courseEnrollmentDto);

        }

        [HttpPut("Update/{courseEnrollmentId:int}")]
        public IActionResult UpdateCourseEnrollment([FromRoute(Name = "courseEnrollmentId")] int courseEnrollmentId,
            [FromBody] CourseEnrollmentDtoForUpdate courseEnrollmentDto)
        {


            if (courseEnrollmentDto is null)
                throw new CourseEnrollmentBadHttpRequestException(courseEnrollmentId); //400


            _manager.CourseEnrollmentService.UpdateCourseEnrollment(courseEnrollmentId, courseEnrollmentDto, true);
            return NoContent(); //204



        }

        [HttpDelete("Delete/{courseEnrollmentId:int}")]
        public IActionResult DeleteCourseEnrollment([FromRoute(Name = "courseEnrollmentId")] int courseEnrollmentId)
        {


            _manager.CourseEnrollmentService.DeleteCourseEnrollment(courseEnrollmentId, false);
            return NoContent();


        }

        [HttpPatch("PartiallyUpdate/{courseEnrollmentId:int}")]
        public IActionResult PartiallyUpdateCourseEnrollment([FromRoute(Name = "courseEnrollmentId")] int courseEnrollmentId,
            [FromBody] JsonPatchDocument<CourseEnrollmentDto> courseEnrollmentPatch)
        {

            //check entity

            var courseEnrollmentDto = _manager
                .CourseEnrollmentService
                .GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, true);


            courseEnrollmentPatch.ApplyTo(courseEnrollmentDto);
            _manager.CourseEnrollmentService.UpdateCourseEnrollment(courseEnrollmentId, 
                new CourseEnrollmentDtoForUpdate()
                {
                    CourseEnrollmentId = courseEnrollmentDto.CourseEnrollmentId, 
                    EnrollmentDate = courseEnrollmentDto.EnrollmentDate, 
                    UserId = courseEnrollmentDto.UserId, 
                    CourseId = courseEnrollmentDto.CourseId
                }, true);
            return NoContent(); //204

        }

    }
}