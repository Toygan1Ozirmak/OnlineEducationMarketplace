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
        IEnumerable<ReviewDto> GetReviewsByCourseId(int courseId, bool trackChanges);

        ReviewDto GetReviewByReviewId(int reviewId, bool trackChanges);

        ReviewDto CreateReview(ReviewDtoForInsertion review);

        void UpdateReview(int reviewId, ReviewDtoForUpdate reviewDto, bool trackChanges);

        void DeleteReview(int reviewId, bool trackChanges);
    }
}
