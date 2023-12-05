using Microsoft.EntityFrameworkCore;
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
    public class CourseEnrollmentRepository : RepositoryBase<CourseEnrollment>, ICourseEnrollmentRepository
    {
        public CourseEnrollmentRepository(RepositoryContext context) : base(context)
        {
        }


        public async Task<IEnumerable<CourseEnrollment>> GetCourseEnrollmentsByCourseIdAsync(int courseId, bool trackChanges) =>
            await FindByCondition(x => x.CourseId.Equals(courseId), trackChanges).ToListAsync();


        public async Task<IEnumerable<CourseEnrollment>> GetCourseEnrollmentsByUserIdAsync(int userId, bool trackChanges) =>
            await FindByCondition(x => x.Id.Equals(userId), trackChanges).ToListAsync();

        public async Task<CourseEnrollment> GetCourseEnrollmentByCourseEnrollmentIdAsync(int courseEnrollmentId, bool trackChanges) =>
            await FindByCondition(x => x.CourseEnrollmentId.Equals(courseEnrollmentId), trackChanges)
                .SingleOrDefaultAsync();



        public void CreateCourseEnrollment(CourseEnrollment courseEnrollment) => Create(courseEnrollment);

        public void DeleteCourseEnrollment(CourseEnrollment courseEnrollment) => Delete(courseEnrollment);

        public void UpdateCourseEnrollment(CourseEnrollment courseEnrollment) => Update(courseEnrollment);


    }
}
