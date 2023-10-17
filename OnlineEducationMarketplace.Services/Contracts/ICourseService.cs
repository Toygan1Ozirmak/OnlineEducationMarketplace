using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses(bool trackChanges);

        Course GetCourseByCourseId(int courseId, bool trackChanges);

        IEnumerable<Course> GetCoursesByCategoryId(int categoryId, bool trackChanges);

        Course CreateCourse(Course course);

        void UpdateCourse(int courseId, Course course, bool trackChanges);

        void DeleteCourse(int courseId, bool trackChanges);

    }
}
