using ProductStore.Services.Dtos.OrderDetailsDtos;

namespace ProductStore.Services.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        public int Id { get; set; } 
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<UpdateOrderDetailsDto> OrderDetails { get; set; } = new();
    }

}
