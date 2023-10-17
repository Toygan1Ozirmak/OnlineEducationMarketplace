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
            _manager.Course.GetCourseByCourseId(courseId, trackChanges);
            _manager.Save();
        }

        public Course GetCourseByCourseId(int courseId, bool trackChanges)
        {
            return _manager.Course.GetCourseByCourseId(courseId, trackChanges);
        }

        public IEnumerable<Course> GetAllCourses(bool trackChanges)
        {
            return _manager.Course.GetAllCourses(trackChanges);
        }

        public void UpdateCourse(int courseId, Course course, bool trackChanges)
        {
            _manager.Course.GetCourseByCourseId(courseId, trackChanges);
            _manager.Course.UpdateCourse(course);
            _manager.Save();
        }
    }
}
