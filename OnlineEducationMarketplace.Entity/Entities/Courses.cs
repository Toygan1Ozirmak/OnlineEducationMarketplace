using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Entities
{
    public class Courses
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public DateTime Time { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }


        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }
    }
}
