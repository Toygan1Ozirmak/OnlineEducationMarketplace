using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.DTOs
{

    public partial record CourseDto()
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public TimeSpan CourseLength { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Image { get; set; }
        public bool CourseStatus { get; set; }


        ////fk


        public int CategoryId { get; init; }
    }
}
