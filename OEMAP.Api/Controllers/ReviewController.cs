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
using System.Drawing;
using static OnlineEducationMarketplace.Entity.Exceptions.BadHttpRequestException;

namespace OEMAP.Api.Controllers
{
    //[Authorize]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ReviewController(IServiceManager manager)
        {
            _manager = manager;
        }


        [HttpGet("GetReviewsByCourseId/{courseId:int}")]
        public async Task <IActionResult> GetReviewsByCourseIdAsync([FromRoute(Name = "courseId")] int courseId)
        {

            var review = await _manager
            .ReviewService
            .GetReviewsByCourseIdAsync(courseId, false);


            return Ok(review);


        }

        [HttpGet("GetReviewByReviewId/{reviewId:int}")]
        public async Task <IActionResult> GetReviewByReviewIdAsync([FromRoute(Name = "reviewId")] int reviewId)
        {

            var review = await _manager
            .ReviewService
            .GetReviewByReviewIdAsync(reviewId, false);



            return Ok(review);


        }

        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("Create")]
        public async Task <IActionResult> CreateReviewAsync([FromBody] ReviewDtoForInsertion reviewDto)
        {


            if (reviewDto is null)
                return BadRequest(); //400


            await _manager.ReviewService.CreateReviewAsync(reviewDto);

            return StatusCode(201, reviewDto);


        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("Update/{reviewId:int}")]
        public async Task <IActionResult> UpdateReviewAsync([FromRoute(Name = "reviewId")] int reviewId,
            [FromBody] ReviewDtoForUpdate reviewDto)
        {


            //if (reviewDto is null)
            //    throw new ReviewBadHttpRequestException(reviewId); //400



            await _manager.ReviewService.UpdateReviewAsync(reviewId, reviewDto, true);
            return NoContent(); //204



        }

        [HttpDelete("Delete/{reviewId:int}")]
        public async Task <IActionResult> DeleteReviewAsync([FromRoute(Name = "reviewId")] int reviewId)
        {



            await _manager.ReviewService.DeleteReviewAsync(reviewId, false);
            return NoContent();


        }

        [HttpPatch("PartiallyUpdate/{reviewId:int}")]
        public async Task <IActionResult> PartiallyUpdateReviewAsync([FromRoute(Name = "reviewId")] int reviewId,
            [FromBody] JsonPatchDocument<ReviewDto> reviewPatch)
        {

            //check entity

            var reviewDto = await _manager
                .ReviewService
                .GetReviewByReviewIdAsync(reviewId, true);


            reviewPatch.ApplyTo(reviewDto);
            await _manager.ReviewService.UpdateReviewAsync(reviewId, 
                new ReviewDtoForUpdate()
                {
                    ReviewId = reviewDto.ReviewId, 
                    Comment = reviewDto.Comment, 
                    Point = reviewDto.Point, 
                    UserId = reviewDto.UserId, 
                    CourseId = reviewDto.CourseId
                }, true);
            return NoContent(); //204


        }

    }
}