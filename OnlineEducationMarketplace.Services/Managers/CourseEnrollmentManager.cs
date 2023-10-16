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
            return CourseEnrollment;
        }

        public void DeleteCourseEnrollment(int CourseEnrollmentId, bool trackChanges)
        {
            _manager.CourseEnrollment.DeleteCourseEnrollment(CourseEnrollmentId, trackChanges);
            _manager.Save();
        }

        public CourseEnrollment GetCourseEnrollmentByUserId(int userId)
        {
            return _manager.CourseEnrollment.GetCourseEnrollmentByUserId(userId, trackChanges);
        }

        public Review GetCourseEnrollmentByCourseId(int courseId)
        {
            return _manager.CourseEnrollment.GetCourseEnrollmentByCourseId(courseId, trackChanges);
        }

        public IEnumerable<CourseEnrollment> GetCourseEnrollments(bool trackChanges)
        {
            return _manager.CourseEnrollment.GetCourseEnrollments(trackChanges);
        }

        public void UpdateCourseEnrollment(int CourseEnrollmentId, CourseEnrollment courseEnrollment)
        {
            _manager.CourseEnrollment.Update(CourseEnrollmentId, courseEnrollment);
            _manager.Save();
        }
    }
}
