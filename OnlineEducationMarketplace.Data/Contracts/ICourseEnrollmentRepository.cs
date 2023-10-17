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

        //bir kullanıcının tüm katılımlarını görüntüler
        IQueryable<CourseEnrollment> GetAllCourseEnrollmentByUserId(int userId, bool trackChanges);

        //bir kursun bütün katılımlarını görüntüler
        IQueryable<CourseEnrollment> GetAllCourseEnrollmentByCourseId(int courseId, bool trackChanges);

        //kurs ve idye göre belirli bir kursu veya belirli bir katılımcıyı görüntüler
        IQueryable<CourseEnrollment> GetCourseEnrollmentByUserIdAndCourseId(int userId, int courseId, bool trackChanges);

        
        void CreateCourseEnrollment(CourseEnrollment courseEnrollment);
        void UpdateCourseEnrollment(CourseEnrollment courseEnrollment);
        void DeleteCourseEnrollment(CourseEnrollment courseEnrollment);
        CourseEnrollment GetCourseEnrollmentByUserId(int userId, object trackChanges);
    }
}
