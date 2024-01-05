using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.DTOs
{
    public abstract record ReplyDtoForManipulation
    {

        public string ReplyText { get; init; }


        //fk
        public string Id { get; init; }
        public int ReviewId { get; init; }
    }
}
