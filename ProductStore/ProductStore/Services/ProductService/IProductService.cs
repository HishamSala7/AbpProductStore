using AutoMapper.Internal.Mappers;
using ProductStore.Entities;
using ProductStore.Services.Dtos.ProductDtos;
using ProductStore.Services.Dtos.ReadProductDtos;
using Volo.Abp.Application.Services;

namespace ProductStore.Services.ProductService
{
    public interface IProductService : IApplicationService
    {
        Task<List<ReadProductDto>> GetAllAsync();
        Task<ReadProductDto> GetById(int id);
        Task<ReadProductDto> CreateAsync(CreateProductDto productDto);
        Task<ReadProductDto> UpdateAsync(UpdateProductDto productDto);
    }
}
