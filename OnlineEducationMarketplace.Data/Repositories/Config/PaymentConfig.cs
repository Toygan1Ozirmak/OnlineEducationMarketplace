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
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(c => c.PaymentId);
            builder.Property(c => c.Amount).IsRequired();
            builder.Property(c => c.CardDate).IsRequired();
            builder.Property(c => c.CardNumber).IsRequired();
            builder.Property(c => c.CVC).IsRequired();
            builder.Property(c => c.PaymentDate)
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
