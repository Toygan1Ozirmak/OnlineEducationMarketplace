﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Repositories.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId); // User tablosunun anahtarını tanımla
            builder.Property(u => u.UserName).IsRequired(); // Kullanıcı adı alanını zorunlu yap
            builder.Property(u => u.Email).IsRequired();
            builder.HasMany(u => u.Course).WithOne(c => c.User); // User tablosu ile Courses tablosu arasında bir ilişki tanımla
        }
    }
}