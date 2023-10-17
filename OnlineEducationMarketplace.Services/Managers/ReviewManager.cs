using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
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
            _manager.Review.GetReviewByCourseId(reviewId, trackChanges);
            _manager.Save();
        }

        
        public Review GetReviewByCourseId(int courseId, bool trackChanges)
        {
            return _manager.Review.GetReviewByCourseId(courseId, trackChanges);
        }

        public IEnumerable<Review> GetAllReviews(bool trackChanges)
        {
            return _manager.Review.GetAllReviews(trackChanges);
        }

        public void UpdateReview(int reviewId, Review review, bool trackChanges)
        {
            _manager.Review.GetReviewByCourseId(reviewId, trackChanges);
            _manager.Review.UpdateReview(review);
            _manager.Save();
        }
    }
}
