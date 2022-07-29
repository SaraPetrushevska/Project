using AutoMapper;
using Project.Database.Repositories;
using Project.Models;
using Project.Database.Entities;

namespace Project.Services
{
  
        public class CategoriesService : ICategoryService
        {
            private readonly ICategoryRepository _categoriesRepository;
            private readonly IMapper _mapper;

            public CategoriesService(ICategoryRepository categoriesRepository, IMapper mapper)
            {
                _mapper = mapper;
                _categoriesRepository = categoriesRepository;
            }

        public async Task<Models.Category> CreateCategory(CategoryCommand command)
        {
            var entity = _mapper.Map<CategoryEntity>(command);

            var existingProduct = await categoriesRepository.Get(command.ProductCode);
            if (existingProduct != null)
            {
                return null;
            }
            var result = await categoriesRepository.Create(entity);

            return _mapper.Map<Models.Category>(result);
        }

        public async Task<bool> DeleteCategory(string productCode)
        {
            return await categoriesRepository.Delete(productCode);
        }

        public async Task<Models.Category> Get(string productCode)
        {
            var productEntity = await categoriesRepository.Get(productCode);

            if (productEntity == null)
            {
                return null;
            }

            return _mapper.Map<Models.Product>(productEntity);
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
