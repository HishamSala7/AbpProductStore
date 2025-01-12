using AutoMapper.Internal.Mappers;
using ProductStore.Entities;
using ProductStore.Services.Dtos.OrderDtos;
using Volo.Abp.Application.Services;

namespace ProductStore.Services.OrderService
{
    public interface IOrderService : IApplicationService
    {
        Task<List<ReadOrderDto>> GetAllAsync();
        Task<ReadOrderDto> GetById(int id);
        Task<ReadOrderDto> CreateAsync(CreateOrderDto orderDto);
        Task<ReadOrderDto> UpdateAsync(UpdateOrderDto orderDto);
    }
}
