using Microsoft.EntityFrameworkCore;
using Project.Database.Entities;
using Project.Models;

namespace Project.Database.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProjectDbContext _dbContext;

        public CategoryRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoryEntity> Create(CategoryEntity category)
        {
            _dbContext.Categories.Add(category);

            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<bool> Delete(string code)
        {
            var category = await Get(code);

            if (category == null)
            {
                return false;
            }

            _dbContext.Remove(category);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CategoryEntity> Get(string code)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(p => p.Code == code);
        }

       
     
    }
}
