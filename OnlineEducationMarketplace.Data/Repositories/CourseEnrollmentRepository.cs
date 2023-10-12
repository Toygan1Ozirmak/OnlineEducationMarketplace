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

        public IQueryable<CourseEnrollment> GetCourseEnrollmentByCourseId(int courseId, bool trackChanges) =>
            FindByCondition(x => x.CourseId.Equals(courseId), trackChanges);

        public IQueryable<CourseEnrollment> GetCourseEnrollmentByUserId(int userId, bool trackChanges) =>
            FindByCondition(x => x.UserId.Equals(userId), trackChanges);

        public IQueryable<CourseEnrollment> GetCourseEnrollmentByUserIdAndCourseId(int userId, int courseId, bool trackChanges) =>
            FindByCondition(x => x.UserId.Equals(userId) && x.CourseId.Equals(courseId), trackChanges);

        public void CreateCourseEnrollment(CourseEnrollment courseEnrollment) => Create(courseEnrollment);

        public void DeleteCourseEnrollment(CourseEnrollment courseEnrollment) => Delete(courseEnrollment);

        public void UpdateCourseEnrollment(CourseEnrollment courseEnrollment) => Update(courseEnrollment);

        public IQueryable<CourseEnrollment> GetAllCourseEnrollmentByUserId(int userId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CourseEnrollment> GetAllCourseEnrollmentByCourseId(int courseId, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
