using ProductStore.Entities;
using ProductStore.Services.Dtos.OrderDtos;
using ProductStore.Services.Dtos.ProductDtos;
using ProductStore.Services.Dtos.ReadProductDtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace ProductStore.Services.OrderService
{
    public class OrderService : ProductStoreAppService, IOrderService
    {
        private readonly IRepository<Order, int> _OrderRepo;

        public OrderService(IRepository<Order, int> orderRepo)
        {
            _OrderRepo = orderRepo;
        }

        public async Task<List<ReadOrderDto>> GetAllAsync()
        {
            var orders = await _OrderRepo.GetListAsync();

            return ObjectMapper.Map<List<Order>, List<ReadOrderDto>>(orders);
        }

        public async Task<ReadOrderDto> GetById(int id)
        {
            var order = await _OrderRepo.GetAsync(id);

            return ObjectMapper.Map<Order, ReadOrderDto>(order);
        }

        public async Task<ReadOrderDto> CreateAsync(CreateOrderDto orderDto)
        {
            var insertedOrder = await _OrderRepo.InsertAsync(ObjectMapper.Map<CreateOrderDto, Order>(orderDto));

            return ObjectMapper.Map<Order, ReadOrderDto>(insertedOrder);
        }

        public async Task<ReadOrderDto> UpdateAsync(UpdateOrderDto orderDto)
        {
            var orderDb = await _OrderRepo.GetAsync(orderDto.Id);

            ObjectMapper.Map<UpdateOrderDto, Order>(orderDto, orderDb);

            var updatedOrder = await _OrderRepo.UpdateAsync(orderDb);

            return ObjectMapper.Map<Order, ReadOrderDto>(updatedOrder);
        }

        //public async Task DeleteAsync(int id)
        //{
        //    await _orderRepo.DeleteAsync(id);
        //}

    }
}
