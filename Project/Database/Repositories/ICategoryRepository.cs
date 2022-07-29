using Project.Database.Entities;
using Project.Models;

namespace Project.Database.Repositories

{
    public interface ICategoryRepository
    {
        Task<CategoryEntity> Create(CategoryEntity category);

        Task<CategoryEntity> Get(string code);

        Task<bool> Delete(string code);
    }
}
