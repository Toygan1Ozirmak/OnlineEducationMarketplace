using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public interface ICourseService
    {
        Task <IEnumerable<CourseDto>> GetAllCoursesAsync(CourseParameters courseParameters, bool trackChanges);

        Task <CourseDto> GetCourseByCourseIdAsync(int courseId, bool trackChanges);

        Task <IEnumerable<CourseDto>> GetCoursesByCategoryIdAsync(int categoryId, bool trackChanges);

        Task <CourseDto> CreateCourseAsync(CourseDtoForInsertion course);

        Task UpdateCourseAsync(int courseId, CourseDtoForUpdate courseDto, bool trackChanges);

        Task DeleteCourseAsync(int courseId, bool trackChanges);

    }
}
