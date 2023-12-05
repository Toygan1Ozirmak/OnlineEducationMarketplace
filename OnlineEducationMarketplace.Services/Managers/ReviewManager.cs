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

        public async Task <ReviewDto> CreateReviewAsync(ReviewDtoForInsertion reviewDto)
        {
            var entity = _mapper.Map<Review>(reviewDto);
            _manager.Review.CreateReview(entity);
            await _manager.SaveAsync();
            return _mapper.Map<ReviewDto>(entity);
            
        }

        public async Task DeleteReviewAsync(int reviewId, bool trackChanges)
        {
            //check entity

            var entity = await _manager.Review.GetReviewByReviewIdAsync(reviewId, trackChanges);
            if (entity is null)
            {
                throw new ReviewNotFoundByReviewIdException(reviewId);
            }
            _manager.Review.DeleteReview(entity);
            await _manager.SaveAsync();
        }

        public async Task <ReviewDto> GetReviewByReviewIdAsync(int reviewId, bool trackChanges)
        {
            var review = await _manager.Review.GetReviewByReviewIdAsync(reviewId, trackChanges);
            if(review is null)
                throw new ReviewNotFoundByReviewIdException(reviewId);

            return _mapper.Map<ReviewDto>(review);
        }


        public async Task <IEnumerable<ReviewDto>> GetReviewsByCourseIdAsync(int courseId, bool trackChanges)
        {
            var reviews = await _manager.Review.GetReviewsByCourseIdAsync(courseId, trackChanges);
            if(reviews is null)
                throw new ReviewsNotFoundByCourseIdException(courseId);

            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

       
        public async Task UpdateReviewAsync(int reviewId, ReviewDtoForUpdate reviewDto, bool trackChanges)
        {
            //check entity

            var entity = await _manager.Review.GetReviewByReviewIdAsync(reviewId, trackChanges);
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
            await _manager.SaveAsync();
        }
    }
}
