using System;
using System.Collections.Generic;
using DDD.Domain.Core.Models;

namespace DDD.Domain.Models
{
    public class Order : EntityAudit
    {
        public Order(decimal totalPrice)
        {
            TotalPrice = totalPrice;
        }

        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
