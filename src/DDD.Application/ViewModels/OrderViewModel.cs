using System;
using System.Collections.Generic;
using DDD.Domain.Commands.Order;

namespace DDD.Application.ViewModels
{
    public class OrderViewModel
    {
        public List<OrderItemDto> OrderItems { get; set; }
        public Guid CustomerId { get; set; }
    }
}
