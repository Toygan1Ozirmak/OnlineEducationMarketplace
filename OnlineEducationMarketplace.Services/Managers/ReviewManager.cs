using AutoMapper;
using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.DTOs;
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
        private readonly IMapper _mapper;

        public ReviewManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public ReviewDto CreateReview(ReviewDtoForInsertion reviewDto)
        {
            var entity = _mapper.Map<Review>(reviewDto);
            _manager.Review.CreateReview(entity);
            _manager.Save();
            return _mapper.Map<ReviewDto>(entity);
            
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

        public ReviewDto GetReviewByReviewId(int reviewId, bool trackChanges)
        {
            var review = _manager.Review.GetReviewByReviewId(reviewId, trackChanges);
            if(review is null)
                throw new ReviewNotFoundByReviewIdException(reviewId);

            return _mapper.Map<ReviewDto>(review);
        }


        public IEnumerable<ReviewDto> GetReviewsByCourseId(int courseId, bool trackChanges)
        {
            var reviews = _manager.Review.GetReviewsByCourseId(courseId, trackChanges);
            if(reviews is null)
                throw new ReviewsNotFoundByCourseIdException(courseId);

            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

       
        public void UpdateReview(int reviewId, ReviewDtoForUpdate reviewDto, bool trackChanges)
        {
            //check entity

            var entity = _manager.Review.GetReviewByReviewId(reviewId, trackChanges);
            if(entity is null)
                throw new ReviewNotFoundByReviewIdException(reviewId);

            //entity.Comment = review.Comment;
            //entity.Point = review.Point;
            //entity.UserId = review.UserId;
            //entity.CourseId = review.CourseId;
            //entity.Course = review.Course;
            //entity.User = review.User;
            entity = _mapper.Map<Review>(reviewDto);

            _manager.Review.UpdateReview(entity);
            _manager.Save();
        }
    }
}
