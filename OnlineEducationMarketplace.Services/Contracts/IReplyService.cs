using OnlineEducationMarketplace.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public interface IReplyService
    {
        Task<IEnumerable<ReplyDto>> GetRepliesByReviewIdAsync(int reviewId, bool trackChanges);

        Task<ReplyDto> GetReplyByReplyIdAsync(int replyId, bool trackChanges);

        Task<ReplyDto> CreateReplyAsync(ReplyDtoForInsertion reply);

        Task UpdateReplyAsync(int replyId, ReplyDtoForUpdate replyDto, bool trackChanges);

        Task DeleteReplyAsync(int replyId, bool trackChanges);
    }
}
