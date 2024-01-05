using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Entities
{
    public class Reply
    {
        public int ReplyId { get; set; }


        public string ReplyText { get; set; }
        

        //fk
        public string Id { get; set; }
        public int ReviewId { get; set; }

        //snp
        public Review Review { get; set; }
        public User User { get; set; }
    }
}
