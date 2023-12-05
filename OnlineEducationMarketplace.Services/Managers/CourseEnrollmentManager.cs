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


        public async Task <IEnumerable<CourseEnrollmentDto>> GetCourseEnrollmentsByUserIdAsync(int userId, bool trackChanges)
        {
            var courseEnrollments = await _manager.CourseEnrollment.GetCourseEnrollmentsByUserIdAsync(userId, trackChanges);
            if (courseEnrollments is null)
                throw new CourseEnrollmentByUserIdNotFoundException(userId); //404
            return _mapper.Map<IQueryable<CourseEnrollmentDto>>(courseEnrollments); ;

        }

        public async Task <IEnumerable<CourseEnrollmentDto>> GetCourseEnrollmentsByCourseIdAsync(int courseId, bool trackChanges)
        {
            var courseEnrollments = await _manager.CourseEnrollment.GetCourseEnrollmentsByCourseIdAsync(courseId, trackChanges);
            if (courseEnrollments is null)
                throw new CourseEnrollmentByCourseIdNotFoundException(courseId); //404
            return _mapper.Map<IQueryable<CourseEnrollmentDto>>(courseEnrollments); ;
        }

        public async Task <CourseEnrollmentDto> GetCourseEnrollmentByCourseEnrollmentIdAsync(int courseEnrollmentId, bool trackChanges)
        {
            var courseEnrollment = await _manager.CourseEnrollment.GetCourseEnrollmentByCourseEnrollmentIdAsync(courseEnrollmentId, trackChanges);
            if (courseEnrollment is null)
                throw new CourseEnrollmentByCourseEnrollmentIdNotFoundException(courseEnrollmentId);

            return _mapper.Map<CourseEnrollmentDto>(courseEnrollment);
        }
       

            public async Task <CourseEnrollmentDto> CreateCourseEnrollmentAsync(CourseEnrollmentDtoForInsertion courseEnrollmentDto)
        {
            var entity = _mapper.Map<CourseEnrollment>(courseEnrollmentDto);
            _manager.CourseEnrollment.CreateCourseEnrollment(entity);
            await _manager.SaveAsync();
            return _mapper.Map<CourseEnrollmentDto>(entity);
            
        }

        public async Task DeleteCourseEnrollmentAsync(int courseEnrollmentId, bool trackChanges)
        {
            //check entity
            var entity = await _manager.CourseEnrollment.GetCourseEnrollmentByCourseEnrollmentIdAsync(courseEnrollmentId, trackChanges);
            if (entity != null)
            {
                throw new CourseEnrollmentByCourseEnrollmentIdNotFoundException(courseEnrollmentId);
            }
            _manager.CourseEnrollment.DeleteCourseEnrollment(entity);
            await _manager.SaveAsync();
        }

        public async Task UpdateCourseEnrollmentAsync(int courseEnrollmentId, CourseEnrollmentDtoForUpdate courseEnrollmentDto, bool trackChanges)
        {
            //check entity

            var entity = await _manager.CourseEnrollment.GetCourseEnrollmentByCourseEnrollmentIdAsync(courseEnrollmentId, trackChanges);
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
            await _manager.SaveAsync();
        }

        
    }
}
