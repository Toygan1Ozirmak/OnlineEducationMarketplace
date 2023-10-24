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
    public class CourseEnrollmentManager : ICourseEnrollmentService
    {
        private readonly IRepositoryManager _manager;

        public CourseEnrollmentManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        
        public IQueryable<CourseEnrollment> GetCourseEnrollmentsByUserId(int userId, bool trackChanges)
        {
            return _manager.CourseEnrollment.GetCourseEnrollmentsByUserId(userId, trackChanges);
        }

        public IQueryable<CourseEnrollment> GetCourseEnrollmentsByCourseId(int courseId, bool trackChanges)
        {
            return _manager.CourseEnrollment.GetCourseEnrollmentsByCourseId(courseId, trackChanges);
        }

        public CourseEnrollment GetCourseEnrollmentByCourseEnrollmentId(int courseEnrollmentId, bool trackChanges)
        {
            var courseEnrollment = _manager.CourseEnrollment.GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, trackChanges);
            if (courseEnrollment == null)
            {
                throw new CourseEnrollmentNotFoundException(courseEnrollmentId);
            }

            return courseEnrollment;
        }

        public CourseEnrollment CreateCourseEnrollment(CourseEnrollment courseEnrollment)
        {
            _manager.CourseEnrollment.CreateCourseEnrollment(courseEnrollment);
            _manager.Save();
            return courseEnrollment;
        }

        public void DeleteCourseEnrollment(int courseEnrollmentId, bool trackChanges)
        {
            //check entity
            var entity = _manager.CourseEnrollment.GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, trackChanges);
            if (entity != null)
            {
                throw new CourseEnrollmentNotFoundException(courseEnrollmentId);
            }
            _manager.CourseEnrollment.DeleteCourseEnrollment(entity);
            _manager.Save();
        }

        public void UpdateCourseEnrollment(int courseEnrollmentId, CourseEnrollment courseEnrollment, bool trackChanges)
        {
            //check entity

            var entity = _manager.CourseEnrollment.GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, trackChanges);
            if(entity != null)
            {
                throw new CourseEnrollmentNotFoundException(courseEnrollmentId);
            }

            entity.EnrollmentDate = courseEnrollment.EnrollmentDate;
            entity.UserId = courseEnrollment.UserId;
            entity.CourseId = courseEnrollment.CourseId;
            entity.Course = courseEnrollment.Course;
            entity.User = courseEnrollment.User;

            _manager.CourseEnrollment.UpdateCourseEnrollment(courseEnrollment);
            _manager.Save();
        }

        
    }
}
