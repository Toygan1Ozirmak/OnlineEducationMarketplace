using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public class ReviewManager : IReviewService
    {
        private readonly IRepositoryManager _manager;

        public ReviewManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Review CreateReview(Review review)
        {
            _manager.Review.CreateReview(review);
            _manager.Save();
            return review;
        }

        public void DeleteReview(int reviewId, bool trackChanges)
        {
            _manager.Review.DeleteReview(reviewId, trackChanges);
            _manager.Save();
        }

        public Review GetReviewByUserId(int userId)
        {
            return _manager.Review.GetReviewByUserId(userId, trackChanges);
        }

        public Review GetReviewByCourseId(int courseId)
        {
            return _manager.Review.GetReviewByCourseId(courseId, trackChanges);
        }

        public IEnumerable<Review> GetReviews(bool trackChanges)
        {
            return _manager.Review.GetReviews(trackChanges);
        }

        public void UpdateReview(int reviewId, Review review)
        {
            _manager.Review.Update(reviewId, review);
            _manager.Save();
        }
    }
}
