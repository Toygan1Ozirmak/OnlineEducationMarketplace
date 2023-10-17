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
        CourseEnrollment GetCourseEnrollmentByUserId(int userId, bool trackChanges);

        //bir kursa katılanların görüntülenmesi için
        CourseEnrollment GetCourseEnrollmentByCourseId(int courseId, bool trackChanges);

        
        void CreateCourseEnrollment(CourseEnrollment courseEnrollment);
        void UpdateCourseEnrollment(CourseEnrollment courseEnrollment);
        void DeleteCourseEnrollment(CourseEnrollment courseEnrollment);
        
    }
}
