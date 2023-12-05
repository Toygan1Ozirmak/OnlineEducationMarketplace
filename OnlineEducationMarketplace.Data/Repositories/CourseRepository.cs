using Microsoft.EntityFrameworkCore;
using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Data.NewFolder;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Repositories
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(RepositoryContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Course>> GetAllCoursesAsync(CourseParameters courseParameters, bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(x => x.CourseId).ToListAsync();

        public async Task<Course> GetCourseByCourseIdAsync(int courseId, bool trackChanges) =>
            await FindByCondition(x => x.CourseId.Equals(courseId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Course>> GetCoursesByCategoryIdAsync(int categoryId, bool trackChanges) =>
            await FindByCondition(x => x.CategoryId.Equals(categoryId), trackChanges)
                .ToListAsync();




        public void CreateCourse(Course course) => Create(course);

        public void UpdateCourse(Course course) => Update(course);

        public void DeleteCourse(Course course) => Delete(course);

        
    }
}
