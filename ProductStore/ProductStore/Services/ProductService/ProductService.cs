using NUglify.Html;
using ProductStore.Entities;
using ProductStore.Services.Dtos.ProductDtos;
using ProductStore.Services.Dtos.ReadProductDtos;
using Volo.Abp.Domain.Repositories;

namespace ProductStore.Services.ProductService
{
    public class ProductService : ProductStoreAppService, IProductService
    {
        private readonly IRepository<Product, int> _productRepo;

        public ProductService(IRepository<Product, int> productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<List<ReadProductDto>> GetAllAsync()
        {
            var products = await _productRepo.GetListAsync();

            return ObjectMapper.Map<List<Product>, List<ReadProductDto>>(products);
        }

        public async Task<ReadProductDto> GetById(int id)
        {
            var product = await _productRepo.GetAsync(id);

            return ObjectMapper.Map<Product, ReadProductDto>(product);
        }

        public async Task<ReadProductDto> CreateAsync(CreateProductDto productDto)
        {
            var insertedProduct = await _productRepo.InsertAsync(ObjectMapper.Map<CreateProductDto, Product>(productDto));

            return ObjectMapper.Map<Product, ReadProductDto>(insertedProduct);
        }

        public async Task<ReadProductDto> UpdateAsync(UpdateProductDto productDto)
        {
            var productDb = await _productRepo.GetAsync(productDto.Id);

            ObjectMapper.Map<UpdateProductDto, Product>(productDto, productDb);

            var updatedProduct = await _productRepo.UpdateAsync(productDb);

            return ObjectMapper.Map<Product, ReadProductDto>(updatedProduct);
        }

        //public async Task DeleteAsync(int id)
        //{
        //    await _productRepo.DeleteAsync(id);
        //}



    }
}
