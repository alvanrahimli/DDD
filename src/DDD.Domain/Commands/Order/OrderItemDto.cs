using System;

namespace DDD.Domain.Commands.Order
{
    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public decimal ProductPrice { get; set; }

        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
