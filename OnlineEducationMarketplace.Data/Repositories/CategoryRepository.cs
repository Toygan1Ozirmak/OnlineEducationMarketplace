using Microsoft.EntityFrameworkCore;
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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(x => x.CategoryId).ToListAsync();

        public async Task<Category> GetCategoryByCategoryIdAsync(int categoryId, bool trackChanges) =>
            await FindByCondition(x => x.CategoryId.Equals(categoryId), trackChanges)
                .SingleOrDefaultAsync();

        public void CreateCategory(Category category) => Create(category);

        public void UpdateCategory(Category category) => Update(category);

        public void DeleteCategory(Category category) => Delete(category);
    }
}
