using System;
using System.Collections.Generic;

namespace DDD.Domain.Commands.Order
{
    public class OrderDto
    {
        public Guid CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
