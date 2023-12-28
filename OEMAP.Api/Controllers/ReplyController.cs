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
    public class ReplyController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ReplyController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetRepliesByReviewId/{reviewId:int}")]
        public async Task<IActionResult> GetRepliesByReviewIdAsync([FromRoute(Name = "reviewId")] int reviewId)
        {
            var reply = await _manager
                .ReplyService
                .GetRepliesByReviewIdAsync(reviewId, false);

            return Ok(reply);
        }

        [HttpGet("GetReplyByReplyId/{replyId:int}")]
        public async Task<IActionResult> GetReplyByReplyIdAsync([FromRoute(Name = "replyId")] int replyId)
        {
            var reply = await _manager
                .ReplyService
                .GetReplyByReplyIdAsync(replyId, false);

            return Ok(reply);
        }

        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateReplyAsync([FromBody] ReplyDtoForInsertion replyDto)
        {
            if (replyDto is null)
                return BadRequest(); //400

            await _manager.ReplyService.CreateReplyAsync(replyDto);

            return StatusCode(201, replyDto);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("Update/{replyId:int}")]
        public async Task<IActionResult> UpdateReplyAsync([FromRoute(Name = "replyId")] int replyId,
            [FromBody] ReplyDtoForUpdate replyDto)
        {
            await _manager.ReplyService.UpdateReplyAsync(replyId, replyDto, true);
            return NoContent(); //204
        }

        [HttpDelete("Delete/{replyId:int}")]
        public async Task<IActionResult> DeleteReplyAsync([FromRoute(Name = "replyId")] int replyId)
        {
            await _manager.ReplyService.DeleteReplyAsync(replyId, false);
            return NoContent();
        }

        [HttpPatch("PartiallyUpdate/{replyId:int}")]
        public async Task<IActionResult> PartiallyUpdateReplyAsync([FromRoute(Name = "replyId")] int replyId,
            [FromBody] JsonPatchDocument<ReplyDto> replyPatch)
        {
            var replyDto = await _manager
                .ReplyService
                .GetReplyByReplyIdAsync(replyId, true);

            replyPatch.ApplyTo(replyDto);
            await _manager.ReplyService.UpdateReplyAsync(replyId,
                new ReplyDtoForUpdate()
                {
                    ReplyId = replyDto.ReplyId,
                    Comment = replyDto.Comment,                    
                    Id = replyDto.Id,
                    ReviewId = replyDto.ReviewId
                }, true);
            return NoContent(); //204
        }
    }
}
