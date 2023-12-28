using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Contracts
{
    public interface IReplyRepository : IRepositoryBase<Reply>
    {


        Task<IEnumerable<Reply>> GetRepliesByReviewIdAsync(int reviewId, bool trackChanges);

        Task<Reply> GetReplyByReplyIdAsync(int replyId, bool trackChanges);



        void CreateReply(Reply reply);
        void UpdateReply(Reply reply);
        void DeleteReply(Reply reply);

    }
}
