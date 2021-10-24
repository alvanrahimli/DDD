using System;

namespace DDD.Application.ViewModels
{
    public class OrderItemViewModel
    {
        public Guid Id { get; set; }
        public int Count { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
