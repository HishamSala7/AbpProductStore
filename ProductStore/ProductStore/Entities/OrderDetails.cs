﻿using Volo.Abp.Domain.Entities.Auditing;

namespace ProductStore.Entities
{
    public class OrderDetails : FullAuditedEntity<int>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }    
    }
}
