using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Repositories.Config
{
    public class ReplyConfig : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder.HasKey(k => k.ReplyId);

            builder.HasOne(c => c.Review)
               .WithMany(c => c.Replies)
               .HasForeignKey(c => c.ReviewId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.User)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.Id)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
