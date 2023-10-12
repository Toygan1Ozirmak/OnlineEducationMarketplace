using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Repositories.Config
{
    public class MessagesConfig : IEntityTypeConfiguration<Messaging>
    {
        public void Configure(EntityTypeBuilder<Messaging> builder)
        {
            builder.HasKey(c => c.MessagingId);
        }
    }
}
