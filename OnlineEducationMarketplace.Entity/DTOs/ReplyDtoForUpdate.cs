using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.DTOs
{
    public record ReplyDtoForUpdate : ReplyDtoForManipulation
    {
        public int ReplyId { get; init; }
    }
}
