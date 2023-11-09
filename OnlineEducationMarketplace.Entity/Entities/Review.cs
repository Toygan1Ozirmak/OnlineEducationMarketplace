using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        
        
        public string Comment { get; set; }
        public int Point { get; set; }

        //fk
        public int UserId { get; set; }
        public int CourseId { get; set; }

        //snp
        public Course Course { get; set; }
        public User User { get; set; }

    }
}
