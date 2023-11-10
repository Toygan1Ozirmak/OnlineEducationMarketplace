using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.DTOs
{
    public record CourseEnrollmentDtoForUpdate() : CourseEnrollmentDtoForManipulation
    {
        [Required]
        public int CourseEnrollmentId { get; init; }

        //public DateTime EnrollmentDate { get; init; }


        ////fk
        //public int UserId { get; init; }
        //public int CourseId { get; init; }
    }
}
