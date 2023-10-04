using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Entities
{
    public class Review
    {
        public Guid ReviewId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int Userİd { get; set; }
        public User User { get; set; }
        public string Comment { get; set; }
        public int Point { get; set; }
    }
}
