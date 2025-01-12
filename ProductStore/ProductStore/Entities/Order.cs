using Volo.Abp.Domain.Entities.Auditing;

namespace ProductStore.Entities
{
    public class Order : FullAuditedEntity<int>
    {
        public DateTime OrderDate { get; set; } 
        public decimal TotalAmount { get; set; } 
        public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
