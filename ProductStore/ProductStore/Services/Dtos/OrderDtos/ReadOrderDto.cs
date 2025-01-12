using ProductStore.Services.Dtos.OrderDetailsDtos;

namespace ProductStore.Services.Dtos.OrderDtos
{
    public class ReadOrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<ReadOrderDetailsDto> OrderDetails { get; set; } = new();
    }
}
