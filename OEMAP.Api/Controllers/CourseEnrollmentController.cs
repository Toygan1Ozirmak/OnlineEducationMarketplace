using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OEMAP.Api.ActionFilters;
using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System.Diagnostics.Eventing.Reader;
using static OnlineEducationMarketplace.Entity.Exceptions.BadHttpRequestException;
using static OnlineEducationMarketplace.Entity.Exceptions.NotFoundException;

namespace OEMAP.Api.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(LogFilterAttribute))]
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
        public async Task <IActionResult> GetCourseEnrollmentsByCourseIdAsync([FromRoute(Name = "courseId")] int courseId)
        {

            var courseEnrollments = await _manager
            .CourseEnrollmentService
            .GetCourseEnrollmentsByCourseIdAsync(courseId, false);


            return Ok(courseEnrollments);


        }

        [HttpGet("GetCourseEnrollmentsByUserId/{userId:int}")]
        public async Task <IActionResult> GetCourseEnrollmentsByUserIdAsync([FromRoute(Name = "userId")] int userId)
        {

            var courseEnrollments = await _manager
            .CourseEnrollmentService
            .GetCourseEnrollmentsByUserIdAsync(userId, false);


            return Ok(courseEnrollments);


        }

        [HttpGet("GetCourseEnrollmentByCourseEnrollmentId/{courseEnrollmentId:int}")]
        public async Task <IActionResult> GetCourseEnrollmentByCourseEnrollmentIdAsync([FromRoute(Name = "courseEnrollmentId")] int courseEnrollmentId)
        {

            var courseEnrollment = await _manager
            .CourseEnrollmentService
            .GetCourseEnrollmentByCourseEnrollmentIdAsync(courseEnrollmentId, false);


            return Ok(courseEnrollment);



        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("Create")]
        public async Task <IActionResult> CreateCourseEnrollmentAsync([FromBody] CourseEnrollmentDtoForInsertion courseEnrollmentDto)
        {


            if (courseEnrollmentDto is null)
                return BadRequest(); //400

            await _manager.CourseEnrollmentService.CreateCourseEnrollmentAsync(courseEnrollmentDto);

            return StatusCode(201, courseEnrollmentDto);

        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("Update/{courseEnrollmentId:int}")]
        public async Task <IActionResult> UpdateCourseEnrollmentAsync([FromRoute(Name = "courseEnrollmentId")] int courseEnrollmentId,
            [FromBody] CourseEnrollmentDtoForUpdate courseEnrollmentDto)
        {


            //if (courseEnrollmentDto is null)
            //    throw new CourseEnrollmentBadHttpRequestException(courseEnrollmentId); //400


            await _manager.CourseEnrollmentService.UpdateCourseEnrollmentAsync(courseEnrollmentId, courseEnrollmentDto, true);
            return NoContent(); //204



        }

        [HttpDelete("Delete/{courseEnrollmentId:int}")]
        public async Task <IActionResult> DeleteCourseEnrollmentAsync([FromRoute(Name = "courseEnrollmentId")] int courseEnrollmentId)
        {


            await _manager.CourseEnrollmentService.DeleteCourseEnrollmentAsync(courseEnrollmentId, false);
            return NoContent();


        }

        [HttpPatch("PartiallyUpdate/{courseEnrollmentId:int}")]
        public async Task <IActionResult> PartiallyUpdateCourseEnrollmentAsync([FromRoute(Name = "courseEnrollmentId")] int courseEnrollmentId,
            [FromBody] JsonPatchDocument<CourseEnrollmentDto> courseEnrollmentPatch)
        {

            //check entity

            var courseEnrollmentDto = await _manager
                .CourseEnrollmentService
                .GetCourseEnrollmentByCourseEnrollmentIdAsync(courseEnrollmentId, true);


            courseEnrollmentPatch.ApplyTo(courseEnrollmentDto);
            await _manager.CourseEnrollmentService.UpdateCourseEnrollmentAsync(courseEnrollmentId, 
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