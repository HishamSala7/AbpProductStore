using ProductStore.Entities;
using ProductStore.Services.Dtos.CategoriesDtos;
using ProductStore.Services.Dtos.ReadProductDtos;
using Serilog;
using Volo.Abp.Domain.Repositories;

namespace ProductStore.Services.CategoryService
{
    public class CategoryService : ProductStoreAppService, ICategoryService
    {
        private readonly IRepository<Category, int> _categoryRepo;

        public CategoryService(IRepository<Category, int> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<List<ReadCategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepo.GetListAsync();

            return ObjectMapper.Map<List<Category>, List<ReadCategoryDto>>(categories);
        }

        public async Task<ReadCategoryDto> GetById(int id)
        {
            var category = await _categoryRepo.GetAsync(id);

            return ObjectMapper.Map<Category, ReadCategoryDto>(category);
        }

        public async Task<ReadCategoryDto> CreateAsync(CreateCategoryDto categoryDto)
        {
            var insertedCategory = await _categoryRepo.InsertAsync(ObjectMapper.Map<CreateCategoryDto, Category>(categoryDto));

            return ObjectMapper.Map<Category, ReadCategoryDto>(insertedCategory);
        }

    }
}
