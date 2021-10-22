using System;
using DDD.Domain.Core.Models;

namespace DDD.Domain.Models
{
    public class Order : EntityAudit
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
