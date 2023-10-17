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

        public CourseEnrollment CreateCourseEnrollment(CourseEnrollment courseEnrollment)
        {
            _manager.CourseEnrollment.CreateCourseEnrollment(courseEnrollment);
            _manager.Save();
            return courseEnrollment;
        }

        public void DeleteCourseEnrollment(int courseEnrollmentId, bool trackChanges)
        {
            _manager.CourseEnrollment.DeleteCourseEnrollment(courseEnrollmentId, trackChanges);
            _manager.Save();
        }

        public CourseEnrollment GetCourseEnrollmentByUserId(int userId, bool trackChanges)
        {
            return _manager.CourseEnrollment.GetCourseEnrollmentByUserId(userId, trackChanges);
        }

        public CourseEnrollment GetCourseEnrollmentByCourseId(int courseId, bool trackChanges)
        {
            return _manager.CourseEnrollment.GetCourseEnrollmentByCourseId(courseId, trackChanges);
        }

        public IEnumerable<CourseEnrollment> GetAllCourseEnrollments(bool trackChanges)
        {
            return _manager.CourseEnrollment.GetAllCourseEnrollments(trackChanges);
        }

        public void UpdateCourseEnrollment(int courseEnrollmentId, CourseEnrollment courseEnrollment)
        {
            _manager.CourseEnrollment.UpdateCourseEnrollment(courseEnrollmentId, courseEnrollment);
            _manager.Save();
        }
    }
}
