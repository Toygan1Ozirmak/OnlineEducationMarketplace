﻿using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Contracts
{
    public interface IReviewRepository : IRepositoryBase<Review>
    {


        Task<IEnumerable<Review>> GetReviewsByCourseIdAsync(int courseId, bool trackChanges);

        Task<Review> GetReviewByReviewIdAsync(int reviewId, bool trackChanges);



        void CreateReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(Review review);

    }
}
