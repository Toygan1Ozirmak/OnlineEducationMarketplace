using OnlineEducationMarketplace.Entity.DTOs;
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
        IEnumerable<Review> GetReviewsByCourseId(int courseId, bool trackChanges);

        Review GetReviewByReviewId(int reviewId, bool trackChanges);

        Review CreateReview(Review review);

        void UpdateReview(int reviewId, ReviewDtoForUpdate reviewDto, bool trackChanges);

        void DeleteReview(int reviewId, bool trackChanges);
    }
}
