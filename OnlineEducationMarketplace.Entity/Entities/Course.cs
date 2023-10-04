using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Entities
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public TimeSpan CourseLength { get; set; }

        public int CategoryId { get; set; }

        public string Image { get; set; }
        public bool CourseStatus { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        ICollection<User> Users { get; set; }
        ICollection<Review> Reviews { get; set; }
        ICollection<CourseEnrollment> CourseEnrollments { get; set; }


    }
}
