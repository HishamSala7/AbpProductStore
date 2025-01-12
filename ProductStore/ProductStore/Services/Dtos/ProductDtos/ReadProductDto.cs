using ProductStore.Services.Dtos.OrderDetailsDtos;

namespace ProductStore.Services.Dtos.ReadProductDtos
{
    public class ReadProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ReadOrderDetailsDto> OrderDetails { get; set; } = new();
    }
}
