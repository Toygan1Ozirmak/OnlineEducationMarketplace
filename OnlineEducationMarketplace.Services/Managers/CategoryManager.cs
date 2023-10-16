using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Category CreateCategory(Category category)
        {
            _manager.Category.CreateCategory(category);
            _manager.Save();
            return category;
        }

        public void DeleteCategory(int categoryId, bool trackChanges)
        {
            _manager.Category.DeleteCategory(categoryId, trackChanges);
            _manager.Save();
        }

        public Review GetCategoryByCategoryId(int categoryId)
        {
            return _manager.Category.GetCategoryByCategoryId(categoryId, trackChanges);
        }

        
        public IEnumerable<Category> GetCategories(bool trackChanges)
        {
            return _manager.Category.GetCategories(trackChanges);
        }

        public void UpdateCategory(int categoryId, Category category)
        {
            _manager.Category.Update(categoryId, category);
            _manager.Save();
        }
    }
}
