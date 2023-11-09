using OnlineEducationMarketplace.Entity.DTOs;
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
        
        IQueryable<CourseEnrollmentDto> GetCourseEnrollmentsByCourseId(int courseId, bool trackChanges);

        IQueryable<CourseEnrollmentDto> GetCourseEnrollmentsByUserId(int userId, bool trackChanges);

        CourseEnrollmentDto GetCourseEnrollmentByCourseEnrollmentId(int courseEnrollmentId, bool trackChanges);

        CourseEnrollmentDto CreateCourseEnrollment(CourseEnrollmentDtoForInsertion courseEnrollment);

        void UpdateCourseEnrollment(int courseEnrollmentId, CourseEnrollmentDtoForUpdate courseEnrollmentDto, bool trackChanges);

        void DeleteCourseEnrollment(int courseEnrollmentId, bool trackChanges);
    }
}
