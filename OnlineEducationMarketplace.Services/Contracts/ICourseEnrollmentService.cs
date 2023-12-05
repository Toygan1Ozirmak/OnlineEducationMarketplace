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
        
        Task <IEnumerable<CourseEnrollmentDto>> GetCourseEnrollmentsByCourseIdAsync(int courseId, bool trackChanges);

        Task <IEnumerable<CourseEnrollmentDto>> GetCourseEnrollmentsByUserIdAsync(int userId, bool trackChanges);

        Task <CourseEnrollmentDto> GetCourseEnrollmentByCourseEnrollmentIdAsync(int courseEnrollmentId, bool trackChanges);

        Task <CourseEnrollmentDto> CreateCourseEnrollmentAsync(CourseEnrollmentDtoForInsertion courseEnrollment);

        Task UpdateCourseEnrollmentAsync(int courseEnrollmentId, CourseEnrollmentDtoForUpdate courseEnrollmentDto, bool trackChanges);

        Task DeleteCourseEnrollmentAsync(int courseEnrollmentId, bool trackChanges);
    }
}
