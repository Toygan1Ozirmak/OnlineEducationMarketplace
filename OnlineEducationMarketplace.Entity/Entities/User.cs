using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Entities
{
    public class User : IdentityUser
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserBio { get; set; }

        //cnp
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }



    }
}
