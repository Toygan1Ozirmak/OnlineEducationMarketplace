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

        public async Task <Category> CreateCategoryAsync(Category category)
        {
            _manager.Category.CreateCategory(category);
            await _manager.SaveAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(int categoryId, bool trackChanges)
        {
            //check entity

            var entity = await _manager.Category.GetCategoryByCategoryIdAsync(categoryId, trackChanges);
            if (entity != null)
            {
                throw new CategoryNotFoundException(categoryId);
            }
            _manager.Category.DeleteCategory(entity);
            await _manager.SaveAsync();
        }

        public async Task <Category> GetCategoryByCategoryIdAsync(int categoryId, bool trackChanges)
        {
            var category = await _manager.Category.GetCategoryByCategoryIdAsync(categoryId, trackChanges);
            if(category is null)
                throw new CategoryNotFoundException(categoryId);

            return category;
        }

        
        public async Task <IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await _manager.Category.GetAllCategoriesAsync(trackChanges);
        }

        public async Task UpdateCategoryAsync(int categoryId, Category category, bool trackChanges)
        {
            //check entity

            var entity = await _manager.Category.GetCategoryByCategoryIdAsync(categoryId, trackChanges);
            if(entity is null)
                throw new CategoryNotFoundException(categoryId);

            entity.CategoryName = category.CategoryName;
            entity.CategoryDescription = category.CategoryDescription;
            entity.Courses = category.Courses;


            _manager.Category.UpdateCategory(entity);
            await _manager.SaveAsync();
        }
    }
}
