using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.DTOs
{
    public record ReviewDtoForUpdate() : ReviewDtoForManipulation
    {
        public int ReviewId { get; init; }




        //public string Comment { get; init; }
        //public int Point { get; init; }

        ////fk
        //public int UserId { get; init; }
        //public int CourseId { get;  init; }
    }
}
