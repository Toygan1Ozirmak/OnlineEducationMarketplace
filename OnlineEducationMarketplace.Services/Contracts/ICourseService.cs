using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public interface ICourseService
    {
        IEnumerable<CourseDto> GetAllCourses(bool trackChanges);

        CourseDto GetCourseByCourseId(int courseId, bool trackChanges);

        IEnumerable<CourseDto> GetCoursesByCategoryId(int categoryId, bool trackChanges);

        CourseDto CreateCourse(CourseDtoForInsertion course);

        void UpdateCourse(int courseId, CourseDtoForUpdate courseDto, bool trackChanges);

        void DeleteCourse(int courseId, bool trackChanges);

    }
}
