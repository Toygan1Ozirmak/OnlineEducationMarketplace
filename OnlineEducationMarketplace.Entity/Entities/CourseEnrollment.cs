﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Entities
{
    public class CourseEnrollment
    {

        public int CourseEnrollmentId { get; set; }
        
        public DateTime EnrollmentDate { get; set; }


        //fk
        public int UserId { get; set; }
        public int CourseId { get; set; }

        
    }
}
