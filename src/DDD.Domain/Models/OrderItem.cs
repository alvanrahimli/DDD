using System;
using DDD.Domain.Core.Models;

namespace DDD.Domain.Models
{
    public class OrderItem : EntityAudit
    {
        public OrderItem(Guid productId, int count)
        {
            ProductId = productId;
            Count = count;
        }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public int Count { get; set; }
    }
}
