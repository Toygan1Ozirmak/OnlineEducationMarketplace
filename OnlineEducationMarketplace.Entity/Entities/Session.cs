﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Entities
{
    public class Session
    {
        public Guid SessionId { get; set; }

        ICollection<User> Users { get; set; }
        ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
}
