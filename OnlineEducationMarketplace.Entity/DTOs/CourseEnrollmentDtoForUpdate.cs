using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.DTOs
{
    public record CourseEnrollmentDtoForUpdate(int CourseEnrollmentId, DateTime EnrollmentDate, int UserId, int CourseId)
    {
        //public int CourseEnrollmentId { get; init; }

        //public DateTime EnrollmentDate { get; init; }


        ////fk
        //public int UserId { get; init; }
        //public int CourseId { get; init; }
    }
}
