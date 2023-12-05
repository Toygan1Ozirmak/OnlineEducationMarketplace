using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.DTOs
{
    public abstract record CourseDtoForManipulation
    {

        //constrainsler eklenecek
        //ıd yok
        
        public string Title { get; init; }
        
        public string Description { get; init; }

        public TimeSpan CourseLength { get; init; }
        public DateTime CreatedDate { get; init; }
        
        public string Image { get; init; }
        public bool CourseStatus { get; init; }


        //fk


        public int CategoryId { get; init; }
    }
}
