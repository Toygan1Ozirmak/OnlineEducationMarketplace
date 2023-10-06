﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Messaging> Messagings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        //dbye yarın karar verelim


    }
}