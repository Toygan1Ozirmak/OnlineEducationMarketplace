using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Repositories.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.HasData(
                new Category { CategoryName = "Psikolji", CategoryId = 1, CategoryDescription ="mühendislik alanı" },
                new Category { CategoryName = "Mühendislik", CategoryId = 2, CategoryDescription ="mühendislik alanı" },
                new Category { CategoryName = "Dil", CategoryId = 3, CategoryDescription ="mühendislik alanı" },
                new Category { CategoryName = "Güzel Sanatlar", CategoryId = 4, CategoryDescription ="mühendislik alanı" },
                new Category { CategoryName = "Finans", CategoryId = 5, CategoryDescription ="mühendislik alanı" },
                new Category { CategoryName = "Bilim", CategoryId = 6, CategoryDescription ="mühendislik alanı" }
                
                );
        }
    }
}
