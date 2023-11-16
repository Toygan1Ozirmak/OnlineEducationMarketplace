using DocumentFormat.OpenXml.Vml.Office;
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
        public IActionResult GetReviewsByCourseId([FromRoute(Name = "courseId")] int courseId)
        {

            var review = _manager
            .ReviewService
            .GetReviewsByCourseId(courseId, false);


            return Ok(review);


        }

        [HttpGet("GetReviewByReviewId/{reviewId:int}")]
        public IActionResult GetReviewByReviewId([FromRoute(Name = "reviewId")] int reviewId)
        {

            var review = _manager
            .ReviewService
            .GetReviewByReviewId(reviewId, false);



            return Ok(review);


        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("Create")]
        public IActionResult CreateReview([FromBody] ReviewDtoForInsertion reviewDto)
        {


            //if (reviewDto is null)
            //    return BadRequest(); //400

            _manager.ReviewService.CreateReview(reviewDto);

            return StatusCode(201, reviewDto);


        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("Update/{reviewId:int}")]
        public IActionResult UpdateReview([FromRoute(Name = "reviewId")] int reviewId,
            [FromBody] ReviewDtoForUpdate reviewDto)
        {


            //if (reviewDto is null)
            //    throw new ReviewBadHttpRequestException(reviewId); //400



            _manager.ReviewService.UpdateReview(reviewId, reviewDto, true);
            return NoContent(); //204



        }

        [HttpDelete("Delete/{reviewId:int}")]
        public IActionResult DeleteReview([FromRoute(Name = "reviewId")] int reviewId)
        {



            _manager.ReviewService.DeleteReview(reviewId, false);
            return NoContent();


        }

        [HttpPatch("PartiallyUpdate/{reviewId:int}")]
        public IActionResult PartiallyUpdateReview([FromRoute(Name = "reviewId")] int reviewId,
            [FromBody] JsonPatchDocument<ReviewDto> reviewPatch)
        {

            //check entity

            var reviewDto = _manager
                .ReviewService
                .GetReviewByReviewId(reviewId, true);


            reviewPatch.ApplyTo(reviewDto);
            _manager.ReviewService.UpdateReview(reviewId, 
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