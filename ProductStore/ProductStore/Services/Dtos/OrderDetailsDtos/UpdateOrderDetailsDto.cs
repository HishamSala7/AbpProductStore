namespace ProductStore.Services.Dtos.OrderDetailsDtos
{
    public class UpdateOrderDetailsDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

}
