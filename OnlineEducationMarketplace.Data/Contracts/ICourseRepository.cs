using OnlineEducationMarketplace.Data.Repositories;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Contracts
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync(CourseParameters courseParameters, bool trackChanges);

        Task<Course> GetCourseByCourseIdAsync(int courseId, bool trackChanges);

        Task<IEnumerable<Course>> GetCoursesByCategoryIdAsync(int categoryId, bool trackChanges);

        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
    }
}
