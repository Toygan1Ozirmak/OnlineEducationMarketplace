﻿using OnlineEducationMarketplace.Data.Repositories;
using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Contracts
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        IQueryable<Course> GetAllCourses(bool trackChanges);
        IQueryable<Course> GetCourseByCourseId(int courseId, bool trackChanges);

        IQueryable<Course> GetCourseByUserId(int userId, bool trackChanges);
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
    }
}