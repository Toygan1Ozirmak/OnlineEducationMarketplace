using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        IQueryable<Category> GetAllCategories(bool trackChanges);
        IQueryable<Category> GetCoursesByCategoryName(int CategoryName, bool trackChanges);

        

    }
}
