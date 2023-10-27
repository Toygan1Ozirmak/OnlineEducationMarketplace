using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.DTOs
{
    public record CourseDtoForUpdate(int CourseId, String Title, string Description, TimeSpan CourseLength, string Image, bool CourseStatus, int CategoryId)
    {
        //public int CourseId { get; init; }
        //public string Title { get; init; }
        //public string Description { get; init; }

        //public TimeSpan CourseLength { get; init; }
        //public DateTime CreatedDate { get; init; }
        //public string Image { get; init; }
        //public bool CourseStatus { get; init; }


        ////fk


        //public int CategoryId { get; init; }
    }
}
