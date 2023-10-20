using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System.Diagnostics.Eventing.Reader;

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

        
        [HttpGet("{reviewId:int}")]
        public IActionResult GetReviewsByCourseId([FromRoute(Name = "courseId")] int courseId)
        {
            try
            {
                var review = _manager
                .ReviewService
                .GetReviewsByCourseId(courseId, false);

                if (review is null)
                    return NotFound(); //404

                return Ok(review);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{reviewId:int}")]
        public IActionResult GetReviewByReviewId([FromRoute(Name = "reviewId")] int reviewId)
        {
            try
            {
                var review = _manager
                .ReviewService
                .GetReviewByReviewId(reviewId, false);

                if (review is null)
                    return NotFound(); //404

                return Ok(review);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost()]
        public IActionResult CreateReview([FromBody] Review review)
        {
            try
            {

                if (review is null)
                    return BadRequest(); //400

                _manager.ReviewService.CreateReview(review);

                return StatusCode(201, review);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{reviewId:int")]
        public IActionResult UpdateReview([FromRoute(Name = "reviewId")] int reviewId,
            [FromBody] Review review)
        {
            try
            {

                if (review is null)
                    return BadRequest(); //400

                //check review

                var entity = _manager
                    .ReviewService
                    .GetReviewByReviewId(reviewId, true);

                if (entity is null)
                    return NotFound(); //404

                //check id

                if (reviewId != review.CourseId)
                    return BadRequest(); //400


                _manager.ReviewService.UpdateReview(reviewId, review, true);
                return NoContent(); //204

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{reviewId:int")]
        public IActionResult DeleteReview([FromRoute(Name = "reviewId")] int reviewId)
        {
            try
            {
                var entity = _manager
                    .ReviewService
                    .GetReviewByReviewId(reviewId, false);
                if (entity is null)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = $"Review with reviewId:{reviewId} could not found"
                    }); //404

                _manager.ReviewService.DeleteReview(reviewId, false);
                return NoContent();

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("{reviewId:int")]
        public IActionResult PartiallyUpdateReview([FromRoute(Name = "reviewId")] int reviewId,
            [FromBody] JsonPatchDocument<Review> reviewPatch)
        {
            try
            {
                //check entity

                var entity = _manager
                    .ReviewService
                    .GetReviewByReviewId(reviewId, true);

                if (entity is null)
                    return NotFound(); //404

                reviewPatch.ApplyTo(entity);
                _manager.ReviewService.UpdateReview(reviewId, entity, true);

                return NoContent(); //204
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
