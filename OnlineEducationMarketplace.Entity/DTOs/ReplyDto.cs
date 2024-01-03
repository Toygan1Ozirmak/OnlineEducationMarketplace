﻿using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.DTOs
{
    public record ReplyDto()
    {
        public int ReplyId { get; init; }


        public string Comment { get; init; }


        //fk
        public string Id { get; init; }
        public int ReviewId { get; init; }

        
    }
}