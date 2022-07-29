using.Project.Commands;
using Project.Models;

namespace Project.Services
{
    public interface ICategoryService
    {        
        Task<Category> Get(string id);
        Task<Category> CreateCategory(CategoryCommand command);
        Task<bool> DeleteCategory(string Code);

    }
}
