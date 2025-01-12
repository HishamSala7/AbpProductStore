using ProductStore.Services.Dtos.OrderDetailsDtos;

namespace ProductStore.Services.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<CreateOrderDetailsDto> OrderDetails { get; set; } = new();
    }


}
