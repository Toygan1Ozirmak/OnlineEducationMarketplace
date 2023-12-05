using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public interface ICategoryService
    {
        Task <IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);

        Task <Category> GetCategoryByCategoryIdAsync(int categoryId, bool trackChanges);

        Task <Category> CreateCategoryAsync(Category category);

        Task UpdateCategoryAsync(int categoryId, Category category, bool trackChanges);

        Task DeleteCategoryAsync(int categoryId, bool trackChanges);
    }
}
