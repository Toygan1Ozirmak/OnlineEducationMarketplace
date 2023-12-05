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
        Task <IEnumerable<ReviewDto>> GetReviewsByCourseIdAsync(int courseId, bool trackChanges);

        Task <ReviewDto> GetReviewByReviewIdAsync(int reviewId, bool trackChanges);

        Task <ReviewDto> CreateReviewAsync(ReviewDtoForInsertion review);

        Task UpdateReviewAsync(int reviewId, ReviewDtoForUpdate reviewDto, bool trackChanges);

        Task DeleteReviewAsync(int reviewId, bool trackChanges);
    }
}
