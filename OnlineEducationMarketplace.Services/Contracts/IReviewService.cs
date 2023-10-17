using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public interface IReviewService
    {
        IEnumerable<Review> GetAllReviews(bool trackChanges);

        
        Review GetReviewByCourseId(int courseId, bool trackChanges);

        Review CreateReview(Review review);

        void UpdateReview(int reviewId, Review review, bool trackChanges);

        void DeleteReview(int reviewId, bool trackChanges);
    }
}
