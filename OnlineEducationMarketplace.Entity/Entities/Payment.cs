using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int Amount { get; set; }
        public int CardNumber { get; set; }
        public int CVC { get; set; }
        public DateTime CardDate { get; set; }
        public DateTime PaymentDate { get; set; }

        //fk
        public String Id { get; set; }
        //snp
        public User User { get; set; }

        

    }
}
