using AutoMapper;
using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.Exceptions;
using OnlineEducationMarketplace.Entity.RequestFeatures;
using OnlineEducationMarketplace.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineEducationMarketplace.Entity.Exceptions.NotFoundException;

namespace OnlineEducationMarketplace.Services
{
    public class CourseManager : ICourseService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CourseManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<CourseDto> CreateCourseAsync(CourseDtoForInsertion courseDto)
        {
            var entity = _mapper.Map<Course>(courseDto);
            _manager.Course.CreateCourse(entity);
            await _manager.SaveAsync();
            return _mapper.Map<CourseDto>(entity);
        }

        public async Task DeleteCourseAsync(int courseId, bool trackChanges)
        {
            //check entity

            var entity = await _manager.Course.GetCourseByCourseIdAsync(courseId, trackChanges);
            if (entity is null)
            {
                throw new CourseNotFoundByCourseIdException(courseId);
            }
            _manager.Course.DeleteCourse(entity);
            await _manager.SaveAsync();
        }

        public async Task<CourseDto> GetCourseByCourseIdAsync(int courseId, bool trackChanges)
        {
            var course = await _manager.Course.GetCourseByCourseIdAsync(courseId, trackChanges);
            if (course is null)
            {
                throw new CourseNotFoundByCourseIdException(courseId);
            }

            return _mapper.Map<CourseDto>(course);
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesByCategoryIdAsync(int categoryId, bool trackChanges)
        {
            var courses = await _manager.Course.GetCoursesByCategoryIdAsync(categoryId, trackChanges);
            if (courses is null)
            {
                throw new CourseNotFoundByCategoryIdException(categoryId);
            }
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync(CourseParameters courseParameters, bool trackChanges)
        {
            var courses = await _manager.Course.GetAllCoursesAsync(courseParameters, trackChanges);
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task UpdateCourseAsync(int courseId, CourseDtoForUpdate courseDto, bool trackChanges)
        {
            //check entity
            var entity = await _manager.Course.GetCourseByCourseIdAsync(courseId, trackChanges);
            if (entity is null)
            {
                throw new CourseNotFoundByCourseIdException(courseId);
            }


            //entity.Title = course.Title;
            //entity.Description = course.Description;
            //entity.CourseLength = course.CourseLength;
            //entity.CreatedDate = course.CreatedDate;
            //entity.Image = course.Image;
            //entity.CourseStatus = course.CourseStatus;
            //entity.CategoryId = course.CategoryId;
            //entity.Category = course.Category;
            //entity.Reviews = course.Reviews;
            //entity.CourseEnrollments = course.CourseEnrollments;

            entity = _mapper.Map<Course>(courseDto);

            _manager.Course.Update(entity);//updatecourse- update
            await _manager.SaveAsync();
        }


    }
}