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

        //kullanıcının kendi kurs kayıtlarını görüntülemesi için
        Task<IEnumerable<CourseEnrollment>> GetCourseEnrollmentsByUserIdAsync(int userId, bool trackChanges);

        //bir kursa katılanların görüntülenmesi için
        Task<IEnumerable<CourseEnrollment>> GetCourseEnrollmentsByCourseIdAsync(int courseId, bool trackChanges);

        Task<CourseEnrollment> GetCourseEnrollmentByCourseEnrollmentIdAsync(int courseEnrollmentId, bool trackChanges);


        void CreateCourseEnrollment(CourseEnrollment courseEnrollment);
        void UpdateCourseEnrollment(CourseEnrollment courseEnrollment);
        void DeleteCourseEnrollment(CourseEnrollment courseEnrollment);

    }
}
