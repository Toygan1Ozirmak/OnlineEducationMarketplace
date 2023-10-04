using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Entities
{
    public class Payment
    {
        public Guid TransactionId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Amount { get; set; }
        public bool PaymentStatus { get; set; }

        ICollection<User> Users { get; set; }
        ICollection<Course> Courses { get; set; }

    }
}
