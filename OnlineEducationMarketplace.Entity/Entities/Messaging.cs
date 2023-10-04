using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.Entities
{
    public class Messaging
    {
        public Guid MessagingId { get; set; }
        public Guid ReceiverId { get; set; }

        public string Sender { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageDate { get; set; }
        
        ICollection<User> Users { get; set; }
    }
}
