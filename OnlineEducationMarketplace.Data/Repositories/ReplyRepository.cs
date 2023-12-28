﻿using Microsoft.EntityFrameworkCore;
using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Data.NewFolder;
using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Repositories
{
    public class ReplyRepository : RepositoryBase<Reply>, IReplyRepository
    {
        public ReplyRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateReview(Reply reply) => Create(reply);

        public void DeleteReview(Reply reply) => Delete(reply);

        public async Task<IEnumerable<Reply>> GetRepliesByReviewIdAsync(int reviewId, bool trackChanges) =>
            await FindByCondition(x => x.ReviewId.Equals(reviewId), trackChanges).ToListAsync();

        public async Task<Reply> GetReplyByReplyIdAsync(int replyId, bool trackChanges) =>
             await FindByCondition(x => x.ReviewId.Equals(replyId), trackChanges)
                .SingleOrDefaultAsync();


        public async void UpdateReview(Reply reply) => Update(reply);
    }
}
