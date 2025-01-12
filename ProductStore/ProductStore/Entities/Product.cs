using Volo.Abp.Domain.Entities.Auditing;

namespace ProductStore.Entities
{
    public class Product : FullAuditedEntity<int>
    {
        public string Name { get; set; }    
        public decimal Price { get; set; }  
        public int StockQuantity { get; set; } 
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; } 
    }
}
