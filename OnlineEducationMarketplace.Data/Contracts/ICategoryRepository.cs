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
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);

        Task<Category> GetCategoryByCategoryIdAsync(int categoryId, bool trackChanges);

        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);




    }
}
