using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Entities
{
    public class ProgressTracking
    {
        public int ProgressTrackingId { get; set; }
        
        public int VideoId { get; set; }
        public bool IsTicked { get; set; }
    }
}
