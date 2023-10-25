using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Exceptions
{
    public abstract class BadHttpRequestException : Exception
    {
        protected BadHttpRequestException(string message) : base(message)
        {

        }


        public sealed class CourseBadHttpRequestException : BadHttpRequestException
        {
            public CourseBadHttpRequestException(int courseId) : base($"The course with id : {courseId} bad request error.")
            {

            }

        }

        public sealed class CreateCourseBadHttpRequestException : BadHttpRequestException
        {
            public CreateCourseBadHttpRequestException(Course course) : base($"Create course bad request error.")
            {
            }

        }

        public sealed class UserBadHttpRequestException : BadHttpRequestException
        {
            public UserBadHttpRequestException(int userId) : base($"The user with id : {userId} bad request error.")
            {
            }
        }

        public sealed class CreateUserBadHttpRequestException : BadHttpRequestException
        {
            public CreateUserBadHttpRequestException(User user) : base($"Create user bad request error.")
            {
            }

        }

        public sealed class ReviewBadHttpRequestException : BadHttpRequestException
        {
            public ReviewBadHttpRequestException(int reviewId) : base($"The review with id : {reviewId} bad request error.")
            {
            }

        }

        public sealed class CreateReviewBadHttpRequestException : BadHttpRequestException
        {
            public CreateReviewBadHttpRequestException(Review review) : base($"Create review bad request error.")
            {
            }

        }

        public sealed class CategoryBadHttpRequestException : BadHttpRequestException
        {
            public CategoryBadHttpRequestException(int categoryId) : base($"The category with id : {categoryId} bad request error.")
            {
            }
        }

        public sealed class CreateCategoryBadHttpRequestException : BadHttpRequestException
        {
            public CreateCategoryBadHttpRequestException(Category category) : base($"Create category bad request error.")
            {
            }

        }



        public sealed class CourseEnrollmentBadHttpRequestException : BadHttpRequestException
        {
            public CourseEnrollmentBadHttpRequestException(int courseEnrollmentId) : base($"The course enrollment with id : {courseEnrollmentId} bad request error.")
            {
            }
        }

        public sealed class CreateCourseEnrollmentBadHttpRequestException : BadHttpRequestException
        {
            public CreateCourseEnrollmentBadHttpRequestException(CourseEnrollment courseEnrollment) : base($"Create courseEnrollment bad request error.")
            {
            }

        }
    }

}

