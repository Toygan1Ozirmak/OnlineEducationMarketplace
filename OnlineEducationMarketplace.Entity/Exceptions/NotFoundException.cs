using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message) : base(message) 
        {
        
        }

        
        public sealed class CourseNotFoundByCourseIdException : NotFoundException
        {
            public CourseNotFoundByCourseIdException(int courseId) : base($"The course with id : {courseId} could not found.")
            {

            }

        }

        public sealed class CourseNotFoundByCategoryIdException : NotFoundException
        {
            public CourseNotFoundByCategoryIdException(int categoryId) : base($"The course with id : {categoryId} could not found.")
            {

            }

        }

        public sealed class UserNotFoundException : NotFoundException
        {
            public UserNotFoundException(int userId) : base($"The user with id : {userId} could not found.")
            {
            }
        }

        public sealed class ReviewNotFoundByReviewIdException : NotFoundException
        {
            public ReviewNotFoundByReviewIdException(int reviewId) : base($"The review with review id : {reviewId} could not found.")
            {
            }
        }

        public sealed class ReviewsNotFoundByCourseIdException : NotFoundException
        {
            public ReviewsNotFoundByCourseIdException(int courseId) : base($"The review with course id : {courseId} could not found.")
            {
            }
        }

        public sealed class CategoryNotFoundException : NotFoundException
        {
            public CategoryNotFoundException(int categoryId) : base($"The category with id : {categoryId} could not found.")
            {
            }
        }

        public sealed class CourseEnrollmentByCourseEnrollmentIdNotFoundException : NotFoundException
        {
            public CourseEnrollmentByCourseEnrollmentIdNotFoundException(int courseEnrollmentId) : base($"The course enrollment with course enrollment id : {courseEnrollmentId} could not found.")
            {
            }
        }

        public sealed class CourseEnrollmentByCourseIdNotFoundException : NotFoundException
        {
            public CourseEnrollmentByCourseIdNotFoundException(int courseId) : base($"The course enrollment with course id : {courseId} could not found.")
            {
            }
        }

        public sealed class CourseEnrollmentByUserIdNotFoundException : NotFoundException
        {
            public CourseEnrollmentByUserIdNotFoundException(int userId) : base($"The course enrollment with id : {userId} could not found.")
            {
            }
        }
    }

}

