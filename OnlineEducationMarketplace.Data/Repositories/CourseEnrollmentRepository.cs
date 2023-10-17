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

        public IQueryable<CourseEnrollment> GetAllCourseEnrollments(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(x => x.CourseEnrollmentId);

        public IQueryable<CourseEnrollment> GetCourseEnrollmentsByCourseId(int courseId, bool trackChanges) =>
            FindByCondition(x => x.CourseId.Equals(courseId), trackChanges);
                

        public IQueryable<CourseEnrollment> GetCourseEnrollmentsByUserId(int userId, bool trackChanges) =>
            FindByCondition(x => x.UserId.Equals(userId), trackChanges);

        public CourseEnrollment GetCourseEnrollmentByCourseEnrollmentId(int courseEnrollmentId, bool trackChanges) =>
            FindByCondition(x => x.CourseEnrollmentId.Equals(courseEnrollmentId), trackChanges)
                .SingleOrDefault();



        public void CreateCourseEnrollment(CourseEnrollment courseEnrollment) => Create(courseEnrollment);

        public void DeleteCourseEnrollment(CourseEnrollment courseEnrollment) => Delete(courseEnrollment);

        public void UpdateCourseEnrollment(CourseEnrollment courseEnrollment) => Update(courseEnrollment);

        
    }
}
