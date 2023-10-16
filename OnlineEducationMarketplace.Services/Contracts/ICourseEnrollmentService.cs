using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public interface ICourseEnrollmentService
    {
        IEnumerable<CourseEnrollment> GetAllCourseEnrollments(bool trackChanges);

        CourseEnrollment GetCourseEnrollmentsByCourseId(int courseId, bool trackChanges);

        CourseEnrollment GetCourseEnrollmentsByUserId(int userId, bool trackChanges);

        CourseEnrollment CreateCourseEnrollment(CourseEnrollment courseEnrollment);

        void UpdateCourseEnrollment(int courseEnrollmentId, CourseEnrollment courseEnrollment);

        void DeleteCourseEnrollment(int courseEnrollmentId, bool trackChanges);
    }
}
