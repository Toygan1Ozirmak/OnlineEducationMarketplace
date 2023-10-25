using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System.Diagnostics.Eventing.Reader;
using static OnlineEducationMarketplace.Entity.Exceptions.BadHttpRequestException;

namespace OEMAP.Api.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ReviewController(IServiceManager manager)
        {
            _manager = manager;
        }

        
        [HttpGet("course/{courseId:int}")]
        public IActionResult GetReviewsByCourseId([FromRoute(Name = "courseId")] int courseId)
        {
           
                var review = _manager
                .ReviewService
                .GetReviewsByCourseId(courseId, false);

                
                return Ok(review);
            

        }

        [HttpGet("{reviewId:int}")]
        public IActionResult GetReviewByReviewId([FromRoute(Name = "reviewId")] int reviewId)
        {
            
                var review = _manager
                .ReviewService
                .GetReviewByReviewId(reviewId, false);

                

                return Ok(review);
            

        }

        [HttpPost()]
        public IActionResult CreateReview([FromBody] Review review)
        {
            

                if (review is null)
                    throw new CreateReviewBadHttpRequestException(review);

                _manager.ReviewService.CreateReview(review);

                return StatusCode(201, review);
            

        }

        [HttpPut("{reviewId:int}")]
        public IActionResult UpdateReview([FromRoute(Name = "reviewId")] int reviewId,
            [FromBody] Review review)
        {


            if (review is null)
                throw new ReviewBadHttpRequestException(reviewId); //400

                

                _manager.ReviewService.UpdateReview(reviewId, review, true);
                return NoContent(); //204

            
           
        }

        [HttpDelete("{reviewId:int}")]
        public IActionResult DeleteReview([FromRoute(Name = "reviewId")] int reviewId)
        {
            
               

                _manager.ReviewService.DeleteReview(reviewId, false);
                return NoContent();

            
        }

        [HttpPatch("{reviewId:int}")]
        public IActionResult PartiallyUpdateReview([FromRoute(Name = "reviewId")] int reviewId,
            [FromBody] JsonPatchDocument<Review> reviewPatch)
        {
            
                //check entity

                var entity = _manager
                    .ReviewService
                    .GetReviewByReviewId(reviewId, true);


                reviewPatch.ApplyTo(entity);
                _manager.ReviewService.UpdateReview(reviewId, entity, true);

                return NoContent(); //204
            

        }

    }
}
