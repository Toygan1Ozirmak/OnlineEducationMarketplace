using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Entities
{
    public class CourseEnrollment
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public Course CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime EnrollmentDate { get; set; }

        ICollection<User> Users { get; set; }
        ICollection<Course> Courses { get; set; }
        ICollection<Session> Sessions { get; set; }

    }
}
