using Microsoft.EntityFrameworkCore;
using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.NewFolder
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options):
            base(options)
        { 
        }
        public DbSet<Courses> Courses { get; set; }// course olarak değişmesi lazım entitiy
        public DbSet<Users> Users { get; set; }
        public DbSet<Messaging> Messagings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        //dbyle farklı entitiyler onların düzeltilmesi laızm
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new Courses);
        //}



    }
}
