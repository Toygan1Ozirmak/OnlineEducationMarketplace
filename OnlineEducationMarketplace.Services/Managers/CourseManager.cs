using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.Exceptions;
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
            //check entity

            var entity = _manager.Course.GetCourseByCourseId(courseId, trackChanges);
            if(entity is null)
            {
                throw new CourseNotFoundException(courseId);
            }
            _manager.Course.DeleteCourse(entity);
            _manager.Save();
        }

        public Course GetCourseByCourseId(int courseId, bool trackChanges)
        {
            var course = _manager.Course.GetCourseByCourseId(courseId, trackChanges);
            if (course is null)
            {
                throw new CourseNotFoundException(courseId);
            }

            return course;
        }

        public IEnumerable<Course> GetCoursesByCategoryId(int courseId, bool trackChanges)
        {
            return _manager.Course.GetCoursesByCategoryId(courseId, trackChanges);
        }

        public IEnumerable<Course> GetAllCourses(bool trackChanges)
        {
            return _manager.Course.GetAllCourses(trackChanges);
        }

        public void UpdateCourse(int courseId, Course course, bool trackChanges)
        {
            //check entity
            var entity = _manager.Course.GetCourseByCourseId(courseId, trackChanges);
            if(entity is null )
            {
                throw new CourseNotFoundException(courseId);
            }
            
            
            entity.Title = course.Title;
            entity.Description = course.Description;
            entity.CourseLength = course.CourseLength;
            entity.CreatedDate = course.CreatedDate;
            entity.Image = course.Image;
            entity.CourseStatus = course.CourseStatus;
            entity.CategoryId = course.CategoryId;
            entity.Category = course.Category;
            entity.Reviews = course.Reviews;
            entity.CourseEnrollments = course.CourseEnrollments;

            _manager.Course.UpdateCourse(entity);
            _manager.Save();
        }
    }
}
