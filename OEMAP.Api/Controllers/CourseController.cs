﻿using DocumentFormat.OpenXml.Vml.Office;
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
    [Authorize]
    [ServiceFilter(typeof(LogFilterAttribute))]
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
        public IActionResult GetAllCourses([FromQuery]CourseParameters courseParameters)
        {

            var courses = _manager.CourseService.GetAllCourses(courseParameters,false);
            return Ok(courses);


        }

        [HttpGet("GetCourseByCourseId/{courseId:int}")]
        public IActionResult GetCourseByCourseId([FromRoute(Name = "courseId")] int courseId)
        {

            var course = _manager
            .CourseService
            .GetCourseByCourseId(courseId, false);


            return Ok(course);


        }

        [HttpGet("GetCoursesByCategoryId/category/{categoryId:int}")]
        public IActionResult GetCoursesByCategoryId([FromRoute(Name = "categoryId")] int categoryId)
        {

            var courses = _manager
            .CourseService
            .GetCoursesByCategoryId(categoryId, false);


            return Ok(courses);


        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("Create")]
        public IActionResult CreateCourse([FromBody] CourseDtoForInsertion courseDto)
        {
            //if (courseDto is null)
            //    return BadRequest(); //400
            var course =_manager.CourseService.CreateCourse(courseDto);

            return StatusCode(201, courseDto); //CreatedAtRoute()
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("Update/{courseId:int}")]
        public IActionResult UpdateCourse([FromRoute(Name = "courseId")] int courseId,
            [FromBody] CourseDtoForUpdate courseDto)
        {
            //if (courseDto is null)
            //    throw new CourseBadHttpRequestException(courseId); //400

            _manager.CourseService.UpdateCourse(courseId, courseDto, false);
            return NoContent(); //204


        }

        [HttpDelete("Delete/{courseId:int}")]
        public IActionResult DeleteCourse([FromRoute(Name = "courseId")] int courseId)
        {


            _manager.CourseService.DeleteCourse(courseId, false);
            return NoContent();


        }

        [HttpPatch("PartiallyUpdate/{courseId:int}")]
        public IActionResult PartiallyUpdateCourse([FromRoute(Name = "courseId")] int courseId,
            [FromBody] JsonPatchDocument<CourseDto> coursePatch)
        {


            //check entity

            var courseDto = _manager
                .CourseService
                .GetCourseByCourseId(courseId, true);

            coursePatch.ApplyTo(courseDto);
            _manager.CourseService.UpdateCourse(courseId,
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