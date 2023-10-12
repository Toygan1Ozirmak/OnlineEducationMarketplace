using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Data.NewFolder;
using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category> , ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Category> GetAllCategories(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetCategoryByCategoryName(int CategoryName, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetCoursesByCategoryName(int CategoryName, bool trackChanges)
        {
            throw new NotImplementedException();
        }

    }
}
