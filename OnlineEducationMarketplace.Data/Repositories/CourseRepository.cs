using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Data.NewFolder;
using OnlineEducationMarketplace.Entity.Entities;
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

        
        public IQueryable<Course> GetAllCourses(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(x => x.CourseId);

        public Course GetCourseByCourseId(int courseId, bool trackChanges) =>
            FindByCondition(x => x.CourseId.Equals(courseId), trackChanges)
                .SingleOrDefault();

        public IQueryable<Course> GetCoursesByCategoryId(int categoryId, bool trackChanges) =>
            FindByCondition(x => x.CategoryId.Equals(categoryId), trackChanges);
                



        public void CreateCourse(Course course) => Create(course);

        public void UpdateCourse(Course course) => Update(course);

        public void DeleteCourse(Course course) => Delete(course);


    }
}
