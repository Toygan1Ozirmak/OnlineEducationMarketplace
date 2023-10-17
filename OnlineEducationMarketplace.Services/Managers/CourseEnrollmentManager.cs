using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services
{
    public class CourseEnrollmentManager : ICourseEnrollmentService
    {
        private readonly IRepositoryManager _manager;

        public CourseEnrollmentManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<CourseEnrollment> GetAllCourseEnrollments(bool trackChanges)
        {
            return _manager.CourseEnrollment.GetAllCourseEnrollments(trackChanges);
        }

        
        public IQueryable<CourseEnrollment> GetCourseEnrollmentsByUserId(int userId, bool trackChanges)
        {
            return _manager.CourseEnrollment.GetCourseEnrollmentsByUserId(userId, trackChanges);
        }

        public IQueryable<CourseEnrollment> GetCourseEnrollmentsByCourseId(int courseId, bool trackChanges)
        {
            return _manager.CourseEnrollment.GetCourseEnrollmentsByCourseId(courseId, trackChanges);
        }

        public CourseEnrollment GetCourseEnrollmentsByCourseEnrollmentId(int courseEnrollmentId, bool trackChanges)
        {
            return _manager.CourseEnrollment.GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, trackChanges);
        }

        public CourseEnrollment CreateCourseEnrollment(CourseEnrollment courseEnrollment)
        {
            _manager.CourseEnrollment.CreateCourseEnrollment(courseEnrollment);
            _manager.Save();
            return courseEnrollment;
        }

        public void DeleteCourseEnrollment(int courseEnrollmentId, bool trackChanges)
        {
            _manager.CourseEnrollment.GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, trackChanges);
            _manager.Save();
        }

        public void UpdateCourseEnrollment(int courseEnrollmentId, CourseEnrollment courseEnrollment, bool trackChanges)
        {
            _manager.CourseEnrollment.GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, trackChanges);
            _manager.CourseEnrollment.UpdateCourseEnrollment(courseEnrollment);
            _manager.Save();
        }
    }
}
