using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Business.Abstract
{
    public interface ICourseService
    {
        //burayı kararlaştırmamız gerek
        Course GetbyId (int id);

        List<Course> GetAllByCategoryId(int id);
        

        void Add(Course course);
    }
}
