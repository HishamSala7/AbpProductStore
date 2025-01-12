namespace ProductStore.Services.Dtos.OrderDetailsDtos
{
    public class CreateOrderDetailsDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

}
