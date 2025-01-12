using Volo.Abp.Domain.Entities.Auditing;

namespace ProductStore.Entities
{
    public class Category : FullAuditedEntity<int>
    {
        public string Name { get; set; }   

        public ICollection<Product> Products { get; set; } 
    }
}
