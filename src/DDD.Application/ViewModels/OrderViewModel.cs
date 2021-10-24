using System;
using System.Collections.Generic;

namespace DDD.Application.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CustomerId { get; set; }
    }
}
