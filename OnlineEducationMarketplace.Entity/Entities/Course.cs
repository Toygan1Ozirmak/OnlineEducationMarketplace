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
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public TimeSpan CourseLength { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool CourseStatus { get; set; }

        public string VideoURL { get; set; }

        public string ImageURL { get; set; }


        //fk


        public int CategoryId { get; set; }

        //snp
        public Category Category { get; set; }

        //cnp
        public ICollection<Review> Reviews { get; set; }
        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }


    }
}