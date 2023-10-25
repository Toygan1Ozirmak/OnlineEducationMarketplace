using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.Exceptions;
using OnlineEducationMarketplace.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineEducationMarketplace.Entity.Exceptions.NotFoundException;

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
            if (entity is null)
            {
                throw new ReviewNotFoundByReviewIdException(reviewId);
            }
            _manager.Review.DeleteReview(entity);
            _manager.Save();
        }

        public Review GetReviewByReviewId(int reviewId, bool trackChanges)
        {
            var review = _manager.Review.GetReviewByReviewId(reviewId, trackChanges);
            if(review is null)
                throw new ReviewNotFoundByReviewIdException(reviewId);

            return review;
        }


        public IEnumerable<Review> GetReviewsByCourseId(int courseId, bool trackChanges)
        {
            var reviews = _manager.Review.GetReviewsByCourseId(courseId, trackChanges);
            if(reviews is null)
                throw new ReviewsNotFoundByCourseIdException(courseId);

            return reviews;
        }

       
        public void UpdateReview(int reviewId, Review review, bool trackChanges)
        {
            //check entity

            var entity = _manager.Review.GetReviewByReviewId(reviewId, trackChanges);
            if(entity is null)
                throw new ReviewNotFoundByReviewIdException(reviewId);

            entity.Comment = review.Comment;
            entity.Point = review.Point;
            entity.UserId = review.UserId;
            entity.CourseId = review.CourseId;
            entity.Course = review.Course;
            entity.User = review.User;

            _manager.Review.UpdateReview(entity);
            _manager.Save();
        }
    }
}
