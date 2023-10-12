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
    public class CourseManager : ICourseService
    {
        private readonly IRepositoryManager _manager;

        public CourseManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Course CreateCourse(Course course)
        {
            _manager.Course.CreateCourse(course);
            _manager.Save();
            return course;
        }

        public void DeleteCourse(int courseId, bool trackChanges)
        {
            _manager.Course.DeleteCourse(courseId, trackChanges);
            _manager.Save();
        }

        public Course GetCourseByCourseId(int courseId)
        {
            return _manager.Course.GetCourseByCourseId(courseId, trackChanges);
        }

        public IEnumerable<Course> GetCourses(bool trackChanges)
        {
            return _manager.Course.GetCourses(trackChanges);
        }

        public void UpdateCourse(int courseId, Course course)
        {
            _manager.Course.Update(courseId, course);
            _manager.Save();
        }
    }
}
