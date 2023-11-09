using AutoMapper;
using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.Exceptions;
using OnlineEducationMarketplace.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineEducationMarketplace.Entity.Exceptions.NotFoundException;

namespace OnlineEducationMarketplace.Services
{
    public class CourseEnrollmentManager : ICourseEnrollmentService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CourseEnrollmentManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }


        public IQueryable<CourseEnrollmentDto> GetCourseEnrollmentsByUserId(int userId, bool trackChanges)
        {
            var courseEnrollments = _manager.CourseEnrollment.GetCourseEnrollmentsByUserId(userId, trackChanges);
            if (courseEnrollments is null)
                throw new CourseEnrollmentByUserIdNotFoundException(userId); //404
            return _mapper.Map<IQueryable<CourseEnrollmentDto>>(courseEnrollments); ;

        }

        public IQueryable<CourseEnrollmentDto> GetCourseEnrollmentsByCourseId(int courseId, bool trackChanges)
        {
            var courseEnrollments = _manager.CourseEnrollment.GetCourseEnrollmentsByCourseId(courseId, trackChanges);
            if (courseEnrollments is null)
                throw new CourseEnrollmentByCourseIdNotFoundException(courseId); //404
            return _mapper.Map<IQueryable<CourseEnrollmentDto>>(courseEnrollments); ;
        }

        public CourseEnrollmentDto GetCourseEnrollmentByCourseEnrollmentId(int courseEnrollmentId, bool trackChanges)
        {
            var courseEnrollment = _manager.CourseEnrollment.GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, trackChanges);
            if (courseEnrollment is null)
                throw new CourseEnrollmentByCourseEnrollmentIdNotFoundException(courseEnrollmentId);

            return _mapper.Map<CourseEnrollmentDto>(courseEnrollment);
        }
       

            public CourseEnrollmentDto CreateCourseEnrollment(CourseEnrollmentDtoForInsertion courseEnrollmentDto)
        {
            var entity = _mapper.Map<CourseEnrollment>(courseEnrollmentDto);
            _manager.CourseEnrollment.CreateCourseEnrollment(entity);
            _manager.Save();
            return _mapper.Map<CourseEnrollmentDto>(entity);
            
        }

        public void DeleteCourseEnrollment(int courseEnrollmentId, bool trackChanges)
        {
            //check entity
            var entity = _manager.CourseEnrollment.GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, trackChanges);
            if (entity != null)
            {
                throw new CourseEnrollmentByCourseEnrollmentIdNotFoundException(courseEnrollmentId);
            }
            _manager.CourseEnrollment.DeleteCourseEnrollment(entity);
            _manager.Save();
        }

        public void UpdateCourseEnrollment(int courseEnrollmentId, CourseEnrollmentDtoForUpdate courseEnrollmentDto, bool trackChanges)
        {
            //check entity

            var entity = _manager.CourseEnrollment.GetCourseEnrollmentByCourseEnrollmentId(courseEnrollmentId, trackChanges);
            if(entity != null)
            {
                throw new CourseEnrollmentByCourseEnrollmentIdNotFoundException(courseEnrollmentId);
            }

            //entity.EnrollmentDate = courseEnrollment.EnrollmentDate;
            //entity.UserId = courseEnrollment.UserId;
            //entity.CourseId = courseEnrollment.CourseId;
            //entity.Course = courseEnrollment.Course;
            //entity.User = courseEnrollment.User;
            entity = _mapper.Map<CourseEnrollment>(courseEnrollmentDto);

            _manager.CourseEnrollment.UpdateCourseEnrollment(entity);
            _manager.Save();
        }

        
    }
}
