using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.Exceptions;
using OnlineEducationMarketplace.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineEducationMarketplace.Entity.Exceptions.NotFoundException;

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
            //check entity

            var entity = _manager.Category.GetCategoryByCategoryId(categoryId, trackChanges);
            if (entity != null)
            {
                throw new CategoryNotFoundException(categoryId);
            }
            _manager.Category.DeleteCategory(entity);
            _manager.Save();
        }

        public Category GetCategoryByCategoryId(int categoryId, bool trackChanges)
        {
            var category = _manager.Category.GetCategoryByCategoryId(categoryId, trackChanges);
            if(category is null)
                throw new CategoryNotFoundException(categoryId);

            return category;
        }

        
        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _manager.Category.GetAllCategories(trackChanges);
        }

        public void UpdateCategory(int categoryId, Category category, bool trackChanges)
        {
            //check entity

            var entity = _manager.Category.GetCategoryByCategoryId(categoryId, trackChanges);
            if(entity is null)
                throw new CategoryNotFoundException(categoryId);

            entity.CategoryName = category.CategoryName;
            entity.CategoryDescription = category.CategoryDescription;
           

            _manager.Category.UpdateCategory(entity);
            _manager.Save();
        }
    }
}
