using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public interface ICourseEnrollmentService
    {
        
        IQueryable<CourseEnrollment> GetCourseEnrollmentsByCourseId(int courseId, bool trackChanges);

        IQueryable<CourseEnrollment> GetCourseEnrollmentsByUserId(int userId, bool trackChanges);

        CourseEnrollment GetCourseEnrollmentByCourseEnrollmentId(int courseEnrollmentId, bool trackChanges);

        CourseEnrollment CreateCourseEnrollment(CourseEnrollment courseEnrollment);

        void UpdateCourseEnrollment(int courseEnrollmentId, CourseEnrollment courseEnrollment, bool trackChanges);

        void DeleteCourseEnrollment(int courseEnrollmentId, bool trackChanges);
    }
}
