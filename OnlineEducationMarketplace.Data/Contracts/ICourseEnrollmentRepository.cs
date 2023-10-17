using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Contracts
{
    public interface ICourseEnrollmentRepository : IRepositoryBase<CourseEnrollment>
    {
        //bütün kurs katılımlarını görüntüler
        IQueryable<CourseEnrollment> GetAllCourseEnrollments(bool trackChanges);

        //kullanıcının kendi kurs kayıtlarını görüntülemesi için
        IQueryable<CourseEnrollment> GetCourseEnrollmentsByUserId(int userId, bool trackChanges);

        //bir kursa katılanların görüntülenmesi için
        IQueryable<CourseEnrollment> GetCourseEnrollmentsByCourseId(int courseId, bool trackChanges);

        CourseEnrollment GetCourseEnrollmentByCourseEnrollmentId(int courseEnrollmentId, bool trackChanges);

        
        void CreateCourseEnrollment(CourseEnrollment courseEnrollment);
        void UpdateCourseEnrollment(CourseEnrollment courseEnrollment);
        void DeleteCourseEnrollment(CourseEnrollment courseEnrollment);
        
    }
}
