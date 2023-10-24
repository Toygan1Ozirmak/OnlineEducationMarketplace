using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.Exceptions;
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
            //check entity

            var entity = _manager.Review.GetReviewByReviewId(reviewId, trackChanges);
            if (entity != null)
            {
                throw new ReviewNotFoundException(reviewId);
            }
            _manager.Review.DeleteReview(entity);
            _manager.Save();
        }

        public Review GetReviewByReviewId(int reviewId, bool trackChanges)
        {
            var review = _manager.Review.GetReviewByReviewId(reviewId, trackChanges);
            if(review != null)
                throw new ReviewNotFoundException(reviewId);

            return review;
        }


        public IEnumerable<Review> GetReviewsByCourseId(int courseId, bool trackChanges)
        {
            return _manager.Review.GetReviewsByCourseId(courseId, trackChanges);
        }

       
        public void UpdateReview(int reviewId, Review review, bool trackChanges)
        {
            //check entity

            var entity = _manager.Review.GetReviewByReviewId(reviewId, trackChanges);
            if(entity is null)
                throw new ReviewNotFoundException(reviewId);

            entity.Comment = review.Comment;
            entity.Point = review.Point;
            entity.UserId = review.UserId;
            entity.CourseId = review.CourseId;
            entity.Course = review.Course;
            entity.User = review.User;

            _manager.Review.UpdateReview(review);
            _manager.Save();
        }
    }
}
