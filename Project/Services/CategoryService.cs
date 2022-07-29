using AutoMapper;
using Project.Database.Repositories;
using Project.Models;
using Project.Database.Entities;
using Project.Commands;

namespace Project.Services
{
  
        public class CategoriesService : ICategoryService
        {
            private readonly ICategoryRepository categoriesRepository;
            private readonly IMapper _mapper;

            public CategoriesService(ICategoryRepository _categoriesRepository, IMapper mapper)
            {
                _mapper = mapper;
                _categoriesRepository = categoriesRepository;
            }

        public async Task<Models.Category> CreateCategory(CategoryCommand command)
        {
            var entity = _mapper.Map<CategoryEntity>(command);

            var existingProduct = await categoriesRepository.Get(command.Code);
            if (existingProduct != null)
            {
                return null;
            }
            var result = await categoriesRepository.Create(entity);

            return _mapper.Map<Models.Category>(result);
        }

       
        public async Task<bool> DeleteCategory(string code)
        {
            return await categoriesRepository.Delete(code);
        }

        public async Task<Models.Category> Get(string code)
        {
            var categoryEntity = await categoriesRepository.Get(code);

            if (categoryEntity == null)
            {
                return null;
            }

            return _mapper.Map<Models.Category>(categoryEntity);
        }

        Task<Category> ICategoryService.CreateCategory(CategoryCommand categoryCommand)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICategoryService.DeleteCategory(string Code)
        {
            throw new NotImplementedException();
        }

        Task<Category> ICategoryService.Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
