﻿using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
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
            _manager.Category.GetCategoryByCategoryId(categoryId, trackChanges);
            _manager.Save();
        }

        public Category GetCategoryByCategoryId(int categoryId, bool trackChanges)
        {
            return _manager.Category.GetCategoryByCategoryId(categoryId, trackChanges);
        }

        
        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _manager.Category.GetAllCategories(trackChanges);
        }

        public void UpdateCategory(int categoryId, Category category, bool trackChanges)
        {
            _manager.Category.GetCategoryByCategoryId(categoryId, trackChanges);
            _manager.Category.UpdateCategory(category);
            _manager.Save();
        }
    }
}