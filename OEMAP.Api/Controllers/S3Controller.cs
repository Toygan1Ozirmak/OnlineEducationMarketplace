    using Amazon.S3;
    using Amazon.S3.Model;
    using DocumentFormat.OpenXml.ExtendedProperties;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using OnlineEducationMarketplace.Services.Contracts;
    using System;
    using System.Threading.Tasks;
    using OnlineEducationMarketplace.Entity.DTOs;
    using OnlineEducationMarketplace.Entity.Entities;

    namespace OEMAP.Api.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class S3Controller : ControllerBase
        {
            private const string S3BucketName = "toygantestbucket";

            private readonly IServiceManager _manager;

            public S3Controller(IServiceManager manager)
            {
                _manager = manager;
            }


        [HttpGet]
        [Route("GetVideo/{courseId:int}")]
        public async Task<IActionResult> GetVideoAsync([FromRoute(Name = "courseId")] int courseId)
        {
            try
            {
                var course = await _manager.CourseService.GetCourseByCourseIdAsync(courseId, false);

                if (course != null && course.VideoURL != null)
                {
                    return Ok(new { videoUrl = course.VideoURL });
                }
                else
                {
                    return NotFound("Course not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetImage/{courseId:int}")]
        public async Task<IActionResult> GetImageAsync([FromRoute(Name = "courseId")] int courseId)
        {
            try
            {
                var course = await _manager.CourseService.GetCourseByCourseIdAsync(courseId, false);

                if (course != null && course.ImageURL != null)
                {
                    return Ok(new { imageUrl = course.ImageURL });
                }
                else
                {
                    return NotFound("Course or Image not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
