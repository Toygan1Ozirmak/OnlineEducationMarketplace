using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(bool trackChanges);

        Category GetCategoryByCategoryId(int categoryId, bool trackChanges);

        Category CreateCategory(Category category);

        void UpdateCategory(int categoryId, Category category);

        void DeleteCategory(int categoryId, bool trackChanges);
    }
}
